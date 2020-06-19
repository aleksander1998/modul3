using NUnit.Framework;
using  Oblix1X;

namespace Oblix1XTest
{
  
    public class PersonTest
    {
        public class Tests
        {


            [Test]
            public void TestAllFields()
            {
                var p = new Person
                {
                    Id = 17,
                    FirstName = "Ola",
                    LastName = "Nordmann",
                    BirthYear = 2000,
                    DeathYear = 3000,
                    Father = new Person() { Id = 23, FirstName = "Per" },
                    Mother = new Person() { Id = 29, FirstName = "Lise" },
                };

                var actualDescription = p.GetDescription();
                var expectedDescription = "Ola Nordmann (Id=17) F�dt: 2000 D�d: 3000 Far: Per (Id=23) Mor: Lise (Id=29)\n";

                Assert.AreEqual(expectedDescription, actualDescription);

            }
            [Test]
            public void TestNoFields()
            {
                var p = new Person
                {
                    Id = 1,
                };

                var actualDescription = p.GetDescription();
                var expectedDescription = " (Id=1)\n";

                Assert.AreEqual(expectedDescription, actualDescription);
            }
            [Test] 
            public void TestSomneFields()
            {
                var p = new Person
                {

                    Id = 15,
                    FirstName = "Noepil",
                    LastName = "Poo",
                    Mother = new Person { Id = 23, FirstName = "Sumi" }

                };

                var actualDescription = p.GetDescription();
                var expectedDescription = "Noepil Poo (Id=15) Mor: Sumi (Id=23)\n";

                Assert.AreEqual(expectedDescription, actualDescription);
            }
        }
    }
    }