using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.QueryStringDotNET;

namespace UnifiedMedicalLanguageSystem
{
    public class UMLS
    {
        internal TicketGrantingTicket TGT { get; set; }
        private RootSource[] _sources = null;

        private UMLS(TicketGrantingTicket tgt, RootSource[] rootSources)
        {
            TGT = tgt;
            _sources = rootSources;
        }

        private UMLS(TicketGrantingTicket tgt)
        {
            TGT = tgt;
        }

        /// <summary>
        /// Factory method for creating an UMLS object to query the UMLS database
        /// </summary>
        /// <param name="apiKey">Your API key. Can be found after logging in using the credentials you set up at https://uts.nlm.nih.gov//uts.html#profile </param>
        /// <param name="rootSources">All the UMLS root sources (RSABs) to use when searching and retrieving information from UMLS</param>
        /// <returns>An awaitable Task which represents </returns>
        public static async Task<UMLS> CreateAsync(string apiKey, params RootSource[] rootSources)
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
            if (rootSources != null && rootSources.Length > 0)
            {
                return new UMLS(tgt, rootSources);
            }
            return new UMLS(tgt);
        }

        public async Task<SingleQueryResponse> SimpleSearch(string term, bool getDeepResults)
        {
            string searchResultRaw;
            var queryString = new QueryString();
            using (var client = new HttpClient())
            {
                var serviceTicket = await TGT.GetServiceTicket();
                queryString.Add("search", term);
                queryString.Add("ticket", serviceTicket.TicketKey);
                if (_sources != null && _sources.Length > 0)
                {
                   queryString.Add("sabs", string.Join(",", _sources.Select(s => s.GetSourceAbbreviation())));
                }
                var response = await client.GetAsync(Constants.SimpleSearchURI + queryString.ToString());
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
                    queryString = new QueryString();
                    using (var client = new HttpClient())
                    {
                        var serviceTicket = await TGT.GetServiceTicket();
                        queryString.Add("ticket", serviceTicket.TicketKey);
                        var response = await client.GetAsync((clrSearchResults[i] as ShallowResultEntry).Uri + queryString.ToString());
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
            var queryString = new QueryString();
            var serviceTicket = await TGT.GetServiceTicket();
            using (var client = new HttpClient())
            {
                queryString.Add("ticket", serviceTicket.TicketKey);
                var link = new Uri(cuiLink + queryString.ToString());
                if (!link.IsWellFormedOriginalString())
                {
                    return null;
                }
                var response = await client.GetAsync(link);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var resultRaw = await response.Content.ReadAsStringAsync();
                return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IQueryResponse>(resultRaw, new SingleQueryResponseConverter(), new ConceptResultConverter()));
            }
        }

        public async Task<IQueryResponse> Concept(Uri cuiLink)
        {
            return await Concept(cuiLink.ToString());
        }

        public async Task<IQueryResponse> Definitions(string definitionsLink)
        {
            var queryString = new QueryString();
            var serviceTicket = await TGT.GetServiceTicket();
            using (var client = new HttpClient())
            {
                queryString.Add("ticket", serviceTicket.TicketKey);
                var response = await client.GetAsync(definitionsLink + queryString.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var resultRaw = await response.Content.ReadAsStringAsync();
                return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IQueryResponse>(resultRaw, new CollectionQueryResponseConverter(), new DefintionResultConverter()));
            }
        }

        public async Task<IQueryResponse> Definitions(Uri definitionsLink)
        {
            return await Definitions(definitionsLink.ToString());
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
