using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedMedicalLanguageSystem;

namespace UnifiedMedicalLanguageSystem.Portable.Tests
{
    [TestFixture]
    public class AuthenticationTests
    {
        [TestCase("3c969069-e0fd-46d0-8cef-4c1f59e97dfe")]
        public async Task UMLSCreatedWithValidApiKey(string apiKey)
        {
            var umls = await UMLS.CreateAsync(apiKey);
            Assert.NotNull(umls);
        }

        [TestCase("gestational diabetes")]
        public async Task SimpleSearchJsonToObjectResultSuccessful(string searchTerm)
        {
            var umls = await UMLS.CreateAsync("3c969069-e0fd-46d0-8cef-4c1f59e97dfe");
            var result = await umls.SimpleSearch(searchTerm, false);
            Assert.NotNull(result);
        }
    }
}
