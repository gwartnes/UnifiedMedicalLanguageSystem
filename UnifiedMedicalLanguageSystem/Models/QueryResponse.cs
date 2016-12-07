using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedMedicalLanguageSystem.Models
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
}
