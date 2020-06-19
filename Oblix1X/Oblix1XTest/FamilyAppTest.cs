using NUnit.Framework;
using Oblix1X;

namespace Oblix1XTest
{
    class FamilyAppTest
    {

        [Test]

        public void TestChildren()
        {
            var marius = new Person { Id = 5, FirstName = "Marius Borg Høiby", BirthYear = 1997 };
            var metteMarit = new Person { Id = 4, FirstName = "Mette Marit", BirthYear = 1973 };
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
          
            sverreMagnus.Mother = metteMarit;
            marius.Mother = metteMarit;


            var app = new FamilyApp(metteMarit, marius, sverreMagnus);
            var actualResponse = app.HelpCommand("vis 4");
            var expectedResponse = "Mette Marit  (Id=4) Født: 1973\n"
                                   + "  Barn:\n"
                                   + "    Marius Borg Høiby (Id=5) Født: 1997\n"
                                   + "    Sverre Magnus (Id=1) Født: 2005\n";
                                   

            Assert.AreEqual(expectedResponse, actualResponse);
        }



        [Test]
        public void TestNoChilde()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var app = new FamilyApp(sverreMagnus);
            var actualResponse = app.HelpCommand("vis 1");
            var expectedResponse = "Sverre Magnus  (Id=1) Født: 2005\n";

            Assert.AreEqual(expectedResponse, actualResponse);

        }



    }
}
