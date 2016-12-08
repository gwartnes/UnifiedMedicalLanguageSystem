using Newtonsoft.Json;
using System;

namespace UnifiedMedicalLanguageSystem
{
    public class ShallowResultEntry : IResultEntry
    {
        public string UI { get; set; }
        public string RootSource { get; set; }
        public string Name { get; set; }
        public Uri Uri { get; set; }
    }

    public class DeepResultEntry : IResultEntry
    {
        public string UI { get; set; }
        public string RootSource { get; set; }
        public string Name { get; set; }
        [JsonProperty("uri")]
        public IQueryResponse Concept { get; set; }
    }
}