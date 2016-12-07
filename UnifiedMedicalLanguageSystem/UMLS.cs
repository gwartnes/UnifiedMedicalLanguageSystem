using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnifiedMedicalLanguageSystem.Models;
using UnifiedMedicalLanguageSystem.Models.Enums;

namespace UnifiedMedicalLanguageSystem
{
    public class UMLS
    {
        internal TicketGrantingTicket TGT { get; set; }

        private UMLS(TicketGrantingTicket tgt)
        {
            TGT = tgt;
        }

        /// <summary>
        /// Factory method for creating an UMLS object to query the UMLS database
        /// </summary>
        /// <param name="apiKey">Your API key. Can be found after logging in using the credentials you set up at https://uts.nlm.nih.gov//uts.html#profile </param>
        /// <returns>An awaitable Task which represents </returns>
        public static async Task<UMLS> CreateAsync(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException("The value for the apiKey parameter should not be null.");
            }
            Guid apiKeyGuid;
            if (!Guid.TryParse(apiKey, out apiKeyGuid))
            {
                throw new FormatException("The supplied API key is not in a correct format.");
            }
            var tgt = await TicketGrantingTicket.CreateAsync(apiKeyGuid);

            var serviceTicket = await tgt.GetServiceTicket();
            if (!await serviceTicket.ValidateAsync(tgt.ApiKey))
            {
                throw new Exception("Invalid TGT/ST.");
            }
            return new UMLS(tgt);
        }

        public async Task<SingleQueryResponse> SimpleSearch(string term, bool getDeepResults, params RootSource[] sources)
        {
            string searchResultRaw;
            using (var client = new HttpClient())
            {
                var serviceTicket = await TGT.GetServiceTicket();
                var uri = string.Format(Constants.SimpleSearchURI, term, serviceTicket.TicketKey);
                if (sources != null && sources.Length > 0)
                {
                    uri += "&sabs=" + string.Join(",", sources.Select(s => s.GetSourceCode()));
                }
                var response = await client.GetAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                searchResultRaw = await response.Content.ReadAsStringAsync();
            }
            var searchObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SingleQueryResponse>(searchResultRaw, new SingleQueryResponseConverter(), new SearchResultConverter(), new ShallowSearchResultConverter()));
            if (getDeepResults)
            {
                var clrSearchResults = (searchObject.Result as SearchResult).Results;
                for (int i = 0; i < clrSearchResults.Length ; i++)
                {
                    using (var client = new HttpClient())
                    {
                        var serviceTicket = await TGT.GetServiceTicket();
                        var response = await client.GetAsync((clrSearchResults[i] as ShallowResultEntry).Uri + "?ticket=" + serviceTicket.TicketKey);
                        if (!response.IsSuccessStatusCode)
                        {
                            return null;
                        }

                        var jsonConcept = await response.Content.ReadAsStringAsync();
                        var clrConcept = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IQueryResponse>(jsonConcept, new SingleQueryResponseConverter(), new ConceptResultConverter()));
                        clrSearchResults[i] = new DeepResultEntry
                        {
                            UI = clrSearchResults[i].UI,
                            RootSource = clrSearchResults[i].RootSource,
                            Name = clrSearchResults[i].Name,
                            Concept = clrConcept
                        };
                    }
                }
                (searchObject.Result as SearchResult).Results = clrSearchResults;
            }
            
            return searchObject;
        }

        public async Task<IQueryResponse> Concept(string cuiLink)
        {
            var serviceTicket = await TGT.GetServiceTicket();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{cuiLink}?ticket={serviceTicket.TicketKey}");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var resultRaw = await response.Content.ReadAsStringAsync();
                return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IQueryResponse>(resultRaw, new SingleQueryResponseConverter(), new ConceptResultConverter()));
            }
        }

        public async Task<IQueryResponse> Definitions(string definitionsLink)
        {
            var serviceTicket = await TGT.GetServiceTicket();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{definitionsLink}?ticket={serviceTicket.TicketKey}");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var resultRaw = await response.Content.ReadAsStringAsync();
                return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IQueryResponse>(resultRaw, new CollectionQueryResponseConverter(), new DefintionResultConverter()));
            }
        }
    }

    internal class SingleQueryResponseConverter : CustomCreationConverter<IQueryResponse>
    {
        public override IQueryResponse Create(Type objectType)
        {
            return new SingleQueryResponse();
        }
    }

    internal class CollectionQueryResponseConverter : CustomCreationConverter<IQueryResponse>
    {
        public override IQueryResponse Create(Type objectType)
        {
            return new CollectionQueryResponse();
        }
    }

    internal class SearchResultConverter : CustomCreationConverter<IResult>
    {
        public override IResult Create(Type objectType)
        {
            return new SearchResult();
        }
    }

    internal class ShallowSearchResultConverter : CustomCreationConverter<IResultEntry>
    {
        public override IResultEntry Create(Type objectType)
        {
            return new ShallowResultEntry();
        }
    }

    internal class ConceptResultConverter : CustomCreationConverter<IResult>
    {
        public override IResult Create(Type objectType)
        {
            return new ConceptResult();
        }
    }

    internal class DefintionResultConverter : CustomCreationConverter<IResult>
    {
        public override IResult Create(Type objectType)
        {
            return new DefinitionResult();
        }
    }
}
