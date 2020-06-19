using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oblix1X
{
    public class FamilyApp
    {
        public List<Person> _people;

        public string WelcomeMessage { get; set; }
        public string CommandPrompt { get; set; }


        public FamilyApp(params Person[] people) =>
            (_people, WelcomeMessage) = (new List<Person>(people), @"Skriv Hjelp for kommandoer");

        public string HelpCommand(string command)
        {
            if (HelpText(command, out var HelpCommand)) return HelpCommand;
            if ( command == "Tree" || command == "tree")
            {
                return _people.Aggregate((string)null, (current, person) => current + person.GetDescription());
            }
            foreach (var person in _people)
            {
                var id = person.Id;
                if (command != $"vis {person.Id}" || person.Id != id) continue;
                var children = FindChildren(person);
                var description = (string)person.GetDescription();
                description = AddChildesToDescription(children, description);
                return description;

            }
            return "Noe feilet , Prøv igjen";
        }

        private static string AddChildesToDescription(List<Person> children, string description)
        {
            if (children.Count <= 0) return description;
            description += "  Barn:\n";
            foreach (var child in children)
            {
                description += "    " + child.FirstName + " (Id=" + child.Id + ")" + " Født: " + child.BirthYear + "\n";
            }

            return description;
        }

        private List<Person> FindChildren(Person person)
        {
            var children = new List<Person>();
            foreach (var possibleChild in _people)
            {
                if (possibleChild.Father == person || possibleChild.Mother == person)
                    children.Add(possibleChild);
            }

            return children;
        }

        private static bool HelpText(string command, out string HelpCommand)
        {
            if (command == "hjelp" || command == "Hjelp")
            {
                {
                    HelpCommand = "kommondo :\n" +
                                    "   tree : viser etter tree mellom alle famile medlemer, DødsÅr Id Navn og etter navn og når de er føtt og hvem far og mor de har, skulle de ha noen " +
                                    "\n" +
                                    "    vis id : Viser en bestemt person med mor, far og barn , og id for dem \n";
                    return true;
                }
            }

            HelpCommand = null;
            return false;
        }
    }
}

