using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace UnifiedMedicalLanguageSystem.TestClient
{
    class Program
    {
        static Action<string> w = Console.WriteLine;
        static Func<string> r = Console.ReadLine;
        const int exitNumber = 0;
        static int selectedNumber = -1;
        static UMLS umls;

        static void Main(string[] args)
        {
            umls = UMLS.CreateAsync("3c969069-e0fd-46d0-8cef-4c1f59e97dfe", RootSource.CSP).GetAwaiter().GetResult();

            while (selectedNumber != 0)
            {
                MainMenu();
                switch (selectedNumber)
                {
                    case 1:
                        SimpleSearch();
                        break;
                    case 2:
                        Concept();
                        break;
                    case 3:
                        Definitions();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void Definitions()
        {
            w("Enter a definition link: ");
            var definitionLink = r();
            var result = umls.Definitions(definitionLink).GetAwaiter().GetResult() as CollectionQueryResponse;
            w(JsonConvert.SerializeObject(result, Formatting.Indented, new StringEnumConverter()));
        }

        private static void Concept()
        {
            w("Enter a concept link: ");
            var conceptLink = r();
            var result = umls.Concept(conceptLink).GetAwaiter().GetResult() as SingleQueryResponse;
            w(JsonConvert.SerializeObject(result, Formatting.Indented, new StringEnumConverter()));
        }

        private static void SimpleSearch()
        {
            w("Enter a search term: ");
            var term = r();
            var result = umls.SimpleSearch(term, false).GetShallowSearchResults().GetAwaiter().GetResult() as SingleQueryResponse;
            w(JsonConvert.SerializeObject(result, Formatting.Indented, new StringEnumConverter()));
        }

        private static void MainMenu()
        {
            w("Please select an option.");
            w("1) Simple vocabulary search");
            w("2) Retrieve concept");
            w("3) Retrieve definitions");
            w("===========================");
            w("0) Exit");
            if (!int.TryParse(r(), out selectedNumber))
            {
                w("Not a valid selection.");
                MainMenu();
            }
        }
    }
}
