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
        public async Task CreateUMLS_NotNull(string apiKey)
        {
            var umls = await UMLS.CreateAsync(apiKey);
            Assert.That(umls, Is.Not.Null);
        }

        [TestCase("3c969069-e0fd-46d0-8cef-4c1f59e97dfe")]
        public async Task TicketGrantingTicket_NotNull(string apiKey)
        {
            var umls = await UMLS.CreateAsync(apiKey);
            Assert.That(umls.TGT, Is.Not.Null);
            Assert.That(umls.TGT.TicketKey, Is.Not.Null);
        }

        [TestCase("3c969069-e0fd-46d0-8cef-4c1f59e97dfe")]
        public async Task ServiceTicket_NotNull(string apiKey)
        {
            var umls = await UMLS.CreateAsync(apiKey);
            Assert.That(await umls.TGT.GetServiceTicket(), Is.Not.Null);
            Assert.That((await umls.TGT.GetServiceTicket()).TicketKey, Is.Not.Null);
        }

        [TestCase("3c969069-e0fd-46d0-8cef-4c1f59e97dfe")]
        public async Task ServiceTicket_Valid(string apiKey)
        {
            var umls = await UMLS.CreateAsync(apiKey);
            var serviceTicket = await umls.TGT.GetServiceTicket();
            

            Assert.That(await umls.TGT.GetServiceTicket(), Is.Not.Null);
            Assert.That((await umls.TGT.GetServiceTicket()), Is.Not.Null);
        }
    }
}
