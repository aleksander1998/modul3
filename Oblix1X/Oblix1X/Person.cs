using System;
using System.Collections.Generic;
using System.Text;

namespace Oblix1X
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }

        public object GetDescription()
        {
            string Oput = null;
            Oput = GetDescriptionOfPerson(Oput);
            Oput = DescriptionPersonFather(Oput);
            Oput = DescriptionPersonMother(Oput);

            Oput += "\n";
            return Oput;
        }



        private string DescriptionPersonMother(string Oput)
        {
            if (Mother != null)
            {
                if (Mother.FirstName != null) Oput += " Mor: " + Mother.FirstName;
                if (Mother.Id != 0) Oput += " (Id=" + Mother.Id + ")";
            }

            return Oput;
        }

        private string DescriptionPersonFather(string Oput)
        {
            if (Father != null)
            {
                if (Father.FirstName != null) Oput += " Far: " + Father.FirstName;
                if (Father.Id != 0) Oput += " (Id=" + Father.Id + ")";
            }

            return Oput;
        }

        private string GetDescriptionOfPerson(string Oput)
        {
            if (FirstName != null) Oput += FirstName + " ";
            if (LastName != null) Oput += LastName;
            if (Id != 0) Oput += " (Id=" + Id + ")";
            if (BirthYear != 0) Oput += " Født: " + BirthYear;
            if (DeathYear != 0) Oput += " Død: " + DeathYear;
            return Oput;
        }


    }
}