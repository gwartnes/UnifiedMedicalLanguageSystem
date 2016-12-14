using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedMedicalLanguageSystem.Portable.Tests
{
    [TestFixture]
    public class SearchTests
    {
        private UMLS _umls;

        public SearchTests()
        {
            Init().GetAwaiter().GetResult();
        }

        public async Task Init()
        {
            _umls = await UMLS.CreateAsync("3c969069-e0fd-46d0-8cef-4c1f59e97dfe");
        }

        [TestCase("gestational diabetes")]
        public async Task SimpleSearch_NotNull(string searchTerm)
        {
            var umls = await UMLS.CreateAsync("3c969069-e0fd-46d0-8cef-4c1f59e97dfe");
            var result = await umls.Search(searchTerm);
            Assert.That(result, Is.Not.Null);
        }
    }
}
