using Amoenus.PclTimer;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace UnifiedMedicalLanguageSystem.Models
{
    internal class ServiceTicket
    {
        internal string TicketKey { get; set; }
        internal DateTime DateGenerated { get; set; }

        private string _ticketGrantingTicketKey;
        private string _service;
        private CountDownTimer _timer;

        private ServiceTicket(string service, string serviceTicketKey, DateTime dateGenerated, string ticketGrantingTicketKey)
        {
            _service = service;
            _ticketGrantingTicketKey = ticketGrantingTicketKey;
            TicketKey = serviceTicketKey;
            DateGenerated = dateGenerated;
            _timer = new CountDownTimer(TimeSpan.FromMinutes(5));
            _timer.ReachedZero += _timer_ReachedZero;
            _timer.Start();
        }

        private async void _timer_ReachedZero(object sender, EventArgs e)
        {
            await RefreshServiceTicketKey();
            _timer.Reset();
            _timer.Start();
        }

        internal static async Task<ServiceTicket> CreateAsync(string service, string tgtKey)
        {
            return new ServiceTicket(service, await GetServiceTicketKey(service, tgtKey), DateTime.Now, tgtKey);
        }

        private async Task RefreshServiceTicketKey()
        {
            TicketKey = await GetServiceTicketKey(_service, _ticketGrantingTicketKey);
            DateGenerated = DateTime.Now;
        }

        private static async Task<string> GetServiceTicketKey(string service, string tgtKey)
        {
            using (var client = new HttpClient())
            {
                var uri = $"https://utslogin.nlm.nih.gov/cas/v1/tickets/{tgtKey}";
                var response = await client.PostAsync(uri, new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("service", service)
                }));
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("There was a problem retrieving a service ticket. Check to make sure the ticket granting ticket provided is correct.");
                }
                var stKey = (await response.Content.ReadAsStringAsync()).Trim();
                if (string.IsNullOrWhiteSpace(stKey) || !stKey.StartsWith("ST") || !stKey.EndsWith("cas"))
                {
                    throw new Exception($"The response received was not a valid service ticket. Response content: {stKey}");
                }
                return stKey;
            }
        }

        internal async Task<bool> ValidateAsync(Guid apiKey)
        {
            var client = new HttpClient();
            var uri = new Uri($"https://utslogin.nlm.nih.gov/cas/serviceValidate?ticket={TicketKey}&service={_service}");
            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            var xmlResponse = XDocument.Parse(await response.Content.ReadAsStringAsync());
            Guid apiKeyValidated;
            if (!Guid.TryParse(xmlResponse.Descendants().FirstOrDefault(d => d.Name.LocalName.Equals("user", StringComparison.OrdinalIgnoreCase)).Value, out apiKeyValidated))
            {
                return false;
            }

            return apiKey == apiKeyValidated;
        }
    }
}