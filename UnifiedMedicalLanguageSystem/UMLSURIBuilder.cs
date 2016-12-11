using System.Linq;

namespace UnifiedMedicalLanguageSystem
{
    public static class UMLSURIBuilder
    {
        private const string _BASE = "https://uts-ws.nlm.nih.gov/rest";
        private const string _SEARCH = _BASE + "/search/current";
        private const string _CUI = _BASE + "/content/current/CUI/";
        private const string _ATOMS = "/atoms";
        private const string _PREFERRED_ATOM = _ATOMS + "/preferred";
        private const string _DEFINITIONS = "/definitions";
        private const string _RELATIONS = "/relations";
        private const string _TICKET_QUERY_STRING = "?ticket=";
        private const string _SEARCH_QUERY_STRING = "&string=";
        private const string _SABS_QUERY_STRING = "&sabs=";
        private const string _PAGE_NUMBER_QUERY_STRING = "&pageNumber=";
        private const string _PAGE_SIZE_QUERY_STRING = "&pageSize=";
        private const string _SEARCH_TYPE_QUERY_STRING = "&searchType=";

        //TODO: Add format checking on each input string to make sure it adheres to a format

        public static string SearchURI(string serviceTicket, string searchTerm, SearchOptions options = null)
        {
            return _SEARCH + _TICKET_QUERY_STRING + serviceTicket + _SEARCH_QUERY_STRING + searchTerm + ExtendedSearchQueryString(options);
        }

        public static string ConceptUIURI(string conceptUI, string serviceTicket)
        {
            return _CUI + conceptUI + _TICKET_QUERY_STRING + serviceTicket;
        }

        public static string AtomsURI(string conceptUI, string serviceTicket)
        {
            return _CUI + conceptUI + _ATOMS + _TICKET_QUERY_STRING + serviceTicket;
        }

        public static string PreferredAtomURI(string conceptUI, string serviceTicket)
        {
            return _CUI + conceptUI + _PREFERRED_ATOM + _TICKET_QUERY_STRING + serviceTicket;
        }

        public static string DefintionsURI(string conceptUI, string serviceTicket)
        {
            return _CUI + conceptUI + _DEFINITIONS + _TICKET_QUERY_STRING + serviceTicket;
        }

        public static string RelationsURI(string conceptUI, string serviceTicket)
        {
            return _CUI + conceptUI + _RELATIONS + _TICKET_QUERY_STRING + serviceTicket;
        }

        private static string ExtendedSearchQueryString(SearchOptions options)
        {
            var extendedQueryString = string.Empty;
            if (options != null)
            {
                if (options.PageNumber.HasValue)
                {
                    extendedQueryString += _PAGE_NUMBER_QUERY_STRING + options.PageNumber;
                }
                if (options.PageSize.HasValue)
                {
                    extendedQueryString += _PAGE_SIZE_QUERY_STRING + options.PageSize;
                }
                if (options.SearchType.HasValue)
                {
                    extendedQueryString += _SEARCH_TYPE_QUERY_STRING + options.SearchType;
                }
                if (options.Sabs != null && options.Sabs.Length > 0)
                {
                    extendedQueryString += _SABS_QUERY_STRING + string.Join(",", options.Sabs.Select(s => s.GetSourceAbbreviation()));
                }
            }
            return extendedQueryString;
        }
    }

}
