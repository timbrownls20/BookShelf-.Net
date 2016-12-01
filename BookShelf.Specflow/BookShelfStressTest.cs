using NUnit.Framework;
using System;

namespace BookShelf.Specflow
{
    [TestFixture]
    public class BookShelfStressTets
    {
        private const int MAXTEST = 50;

        [Test]
        public void BookSearchStressTest()
        {
            var feature = new BookShelfFeature();

            feature.FeatureSetup();
            feature.TestInitialize();

            for (int i = 0; i < MAXTEST; i++)
            {
                Console.WriteLine("----- Attempt {0} -----", i);
                feature.FindingAParticularBook();
                feature.ScenarioCleanup();
            }

            
        }
    }
}
