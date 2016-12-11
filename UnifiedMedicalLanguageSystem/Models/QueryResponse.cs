using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedMedicalLanguageSystem
{
    public class SingleQueryResponse : IQueryResponse
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public IResult Result { get; set; }
    }

    public class CollectionQueryResponse : IQueryResponse
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public ICollection<IResult> Result { get; set; }
    }

    public static class QueryExtensions
    {
        public static IEnumerable<ResultEntry> GetShallowSearchResults(this SingleQueryResponse queryResponse)
        {
            if (queryResponse == null)
            {
                return null;
            }
            if (!(queryResponse.Result is SearchResult) || queryResponse.Result.ClassType != ClassType.SearchResults)
            {
                throw new InvalidCastException("The query response provided did not have search results.");
            }
            var searchResults = (queryResponse.Result as SearchResult).Results;
            if (searchResults == null || searchResults.Count() == 0)
            {
                return null;
            }
            if (!(searchResults.First() is ResultEntry))
            {
                throw new InvalidCastException("The search result entries were not shallow results.");
            }
            return searchResults.Select(r => r as ResultEntry);
        }

        public static Task<IEnumerable<ResultEntry>> GetShallowSearchResults(this Task<SingleQueryResponse> queryResponseTask)
        {
            return queryResponseTask.ContinueWith(c => c.Result.GetShallowSearchResults());
        }

        public static Task<List<ResultEntry>> ToListAsync(this Task<IEnumerable<ResultEntry>> queryResponseTaskEnumerable)
        {
            return queryResponseTaskEnumerable?.ContinueWith(a => a.Result?.ToList());
        }

        public static IEnumerable<T> GetShallowSearchResults<T>(this SingleQueryResponse queryResponse, Func<ResultEntry, T> selector)
        {       
            return queryResponse.GetShallowSearchResults()?.Select(s => selector(s as ResultEntry));
        }

        public static Task<IEnumerable<T>> GetShallowSearchResults<T>(this Task<SingleQueryResponse> queryResponseTask, Func<ResultEntry, T> selector)
        {
            return queryResponseTask.ContinueWith(c => c.Result.GetShallowSearchResults(selector));
        }

        public static Task<List<T>> ToListAsync<T>(this Task<IEnumerable<T>> queryResponseTaskSelected)
        {
            return queryResponseTaskSelected?.ContinueWith(a => a.Result?.ToList());
        }
    }
}
