using System;

namespace Coding.Exercise
{
    public class Person : IPerson
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson : IPerson
    {
        private Person Person { get; set; }

        public ResponsiblePerson(Person person)
        {
            Person = person;
        }

        public int Age { get => Person.Age; set => Person.Age = value; }

        public string Drink()
        {
            if (Age < 18)
                return "too young";
            else
                return Person.Drink();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }

        public string Drive()
        {
            if (Age < 16)
                return "too young";
            else
                return Person.Drive();
        }
    }
}
