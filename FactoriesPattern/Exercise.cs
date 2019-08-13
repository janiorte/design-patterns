using System;

namespace Coding.Exercise
{
    public class PersonFactory
    {
        private int Id { get; set; }

        public Person CreatePerson(string name)
        {
            return new Person
            {
                Id = Id++,
                Name = name
            };
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
