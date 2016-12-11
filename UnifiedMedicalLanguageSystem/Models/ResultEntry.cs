using System;

namespace UnifiedMedicalLanguageSystem
{
    public class ResultEntry : IResultEntry
    {
        public string UI { get; set; }
        public string RootSource { get; set; }
        public string Name { get; set; }
        public Uri Uri { get; set; }
    }
}