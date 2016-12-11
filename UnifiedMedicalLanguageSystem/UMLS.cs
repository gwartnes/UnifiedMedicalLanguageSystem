using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
        /// <param name="rootSources">All the UMLS root sources (RSABs) to use when searching and retrieving information from UMLS</param>
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

        public async Task<SingleQueryResponse> Search(string term, SearchOptions options = null)
        {
            string searchResultRaw;
            using (var client = new HttpClient())
            {
                var serviceTicket = await TGT.GetServiceTicket();
                var response = await client.GetAsync(UMLSURIBuilder.SearchURI(serviceTicket.TicketKey, term, options));
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                searchResultRaw = await response.Content.ReadAsStringAsync();
            }
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SingleQueryResponse>(searchResultRaw, new SingleQueryResponseConverter(), new SearchResultConverter(), new SearchEntryResultConverter()));
        }

        public async Task<IQueryResponse> Concept(string cui)
        {
            using (var client = new HttpClient())
            {
                var serviceTicket = await TGT.GetServiceTicket();
                var response = await client.GetAsync(UMLSURIBuilder.ConceptUIURI(cui, serviceTicket.TicketKey));
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var resultRaw = await response.Content.ReadAsStringAsync();
                return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IQueryResponse>(resultRaw, new SingleQueryResponseConverter(), new ConceptResultConverter()));
            }
        }

        public async Task<IQueryResponse> Definitions(string cui)
        {
            using (var client = new HttpClient())
            {
                var serviceTicket = await TGT.GetServiceTicket();
                var response = await client.GetAsync(UMLSURIBuilder.DefintionsURI(cui, serviceTicket.TicketKey));
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

    internal class SearchEntryResultConverter : CustomCreationConverter<IResultEntry>
    {
        public override IResultEntry Create(Type objectType)
        {
            return new ResultEntry();
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
