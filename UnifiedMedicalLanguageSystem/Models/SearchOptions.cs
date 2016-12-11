using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedMedicalLanguageSystem
{
    public class SearchOptions
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public SearchType? SearchType { get; set; }
        public RootSource[] Sabs { get; set; }

        public SearchOptions(params RootSource[] sources)
        {
            Sabs = sources;
        }
    }
}
