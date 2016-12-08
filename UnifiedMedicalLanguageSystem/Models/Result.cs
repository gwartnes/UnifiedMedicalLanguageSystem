using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace UnifiedMedicalLanguageSystem
{
    public class SearchResult : IResult
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ClassType ClassType { get; set; }
        public IResultEntry[] Results { get; set; }
    }

    public class ConceptResult : IResult
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ClassType ClassType { get; set; }
        public string UI { get; set; }
        public bool Suppressible { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime MajorRevisionDate { get; set; }
        public char Status { get; set; }
        public ICollection<SemanticType> SemanticTypes { get; set; }
        public int AtomCount { get; set; }
        public int AttributeCount { get; set; }
        public int CVMembercount { get; set; }
        public Uri Atoms { get; set; }
        public Uri Definitions { get; set; }
        public Uri Relations { get; set; }
        public Uri DefaultPreferredAtom { get; set; }
        public int RelationCount { get; set; }
        public string Name { get; set; }
    }

    public class DefinitionResult : IResult
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ClassType ClassType { get; set; }
        public bool SourceOriginated { get; set; }
        public string RootSource { get; set; }
        public string Value { get; set; }
    }
}