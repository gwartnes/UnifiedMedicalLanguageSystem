using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Amoenus.PclTimer;

namespace UnifiedMedicalLanguageSystem
{
    public class TicketGrantingTicket
    {
        public string TicketKey { get; internal set; }
        internal DateTime DateGenerated { get; set; }
        internal Guid ApiKey { get; set; }

        private CountDownTimer _timer;

        private TicketGrantingTicket(Guid apiKey, string ticketKey, DateTime dateGenerated)
        {
            ApiKey = apiKey;
            TicketKey = ticketKey;
            DateGenerated = dateGenerated;
            _timer = new CountDownTimer(TimeSpan.FromHours(8));
            _timer.ReachedZero += _timer_ReachedZero;
            _timer.Start();
        }

        private async void _timer_ReachedZero(object sender, EventArgs e)
        {
            await RefreshTicketGeneratingTicketKey();
            _timer.Reset();
            _timer.Start();
        }

        private async Task RefreshTicketGeneratingTicketKey()
        {
            TicketKey = await GetTicketGeneratingTicketKey(ApiKey);
            DateGenerated = DateTime.Now;
        }

        private static async Task<string> GetTicketGeneratingTicketKey(Guid apiKey)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri($"https://utslogin.nlm.nih.gov/cas/v1/api-key");
                var response = await client.PostAsync(uri, new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("apikey", apiKey.ToString())
                }));
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("There was a problem retrieving a ticket granting ticket. Check to make sure the api key provided is correct.");
                }
                var htmlDoc = new HtmlDocument();
                htmlDoc.Load(await response.Content.ReadAsStreamAsync());
                var tgtLink = htmlDoc.DocumentNode.Descendants("form").FirstOrDefault()?.Attributes.FirstOrDefault(action => action.Name.Equals("action", StringComparison.OrdinalIgnoreCase)).Value;
                return tgtLink.Substring(tgtLink.IndexOf("TGT-"));
            }
        }

        internal static async Task<TicketGrantingTicket> CreateAsync(Guid apiKey)
        {
            return new TicketGrantingTicket(apiKey, await GetTicketGeneratingTicketKey(apiKey), DateTime.Now);
        }

        public async Task<ServiceTicket> GetServiceTicket(string service = "http://umlsks.nlm.nih.gov")
        {
            return await ServiceTicket.CreateAsync(service, TicketKey);
        }
    }
}
