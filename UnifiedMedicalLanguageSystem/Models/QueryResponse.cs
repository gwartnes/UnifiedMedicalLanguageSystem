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
        public static IEnumerable<ShallowResultEntry> GetShallowSearchResults(this SingleQueryResponse queryResponse)
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
            if (!(searchResults.First() is ShallowResultEntry))
            {
                throw new InvalidCastException("The search result entries were not shallow results.");
            }
            return searchResults.Select(r => r as ShallowResultEntry);
        }

        public static Task<IEnumerable<ShallowResultEntry>> GetShallowSearchResults(this Task<SingleQueryResponse> queryResponseTask)
        {
            return queryResponseTask.ContinueWith(c => c.Result.GetShallowSearchResults());
        }

        public static Task<List<ShallowResultEntry>> ToListAsync(this Task<IEnumerable<ShallowResultEntry>> queryResponseTaskEnumerable)
        {
            return queryResponseTaskEnumerable.ContinueWith(a => a.Result.ToList());
        }

        public static IEnumerable<T> GetShallowSearchResults<T>(this SingleQueryResponse queryResponse, Func<ShallowResultEntry, T> selector)
        {       
            return queryResponse.GetShallowSearchResults().Select(s => selector(s as ShallowResultEntry));
        }

        public static Task<IEnumerable<T>> GetShallowSearchResults<T>(this Task<SingleQueryResponse> queryResponseTask, Func<ShallowResultEntry, T> selector)
        {
            return queryResponseTask.ContinueWith(c => c.Result.GetShallowSearchResults(selector));
        }

        public static Task<List<T>> ToListAsync<T>(this Task<IEnumerable<T>> queryResponseTaskSelected)
        {
            return queryResponseTaskSelected.ContinueWith(a => a.Result.ToList());
        }

        public static IEnumerable<DeepResultEntry> GetDeepSearchResults(this SingleQueryResponse queryResponse)
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
            if (!(searchResults.First() is DeepResultEntry))
            {
                throw new InvalidCastException("The search result entries were not shallow results.");
            }
            return searchResults.Select(r => r as DeepResultEntry);
        }

        public static IEnumerable<T> GetDeepSearchResults<T>(this SingleQueryResponse queryResponse, Func<DeepResultEntry, T> selector)
        {
            return queryResponse.GetDeepSearchResults().Select(s => selector(s as DeepResultEntry));
        }

        public static Task<IEnumerable<T>> GetDeepSearchResults<T>(this Task<SingleQueryResponse> queryResponseTask, Func<DeepResultEntry, T> selector)
        {
            return queryResponseTask.ContinueWith(c => c.Result.GetDeepSearchResults(selector));
        }

        public static ConceptResult GetConceptResult(this IQueryResponse queryResponse)
        {
            if (!(queryResponse is SingleQueryResponse))
            {
                throw new InvalidCastException("Query Response is in an invalid format for a Concept Result");
            }
            var sqResponse = queryResponse as SingleQueryResponse;
            if (!(sqResponse.Result is ConceptResult))
            {
                throw new InvalidCastException("Query Response's result is in an invalid format for a Concept Result");
            }
            return sqResponse.Result as ConceptResult;
        }

        public static Task<ConceptResult> GetConceptResult(this Task<IQueryResponse> queryResponseTask)
        {
            return queryResponseTask.ContinueWith(c => c.Result.GetConceptResult());
        }
    }
}
