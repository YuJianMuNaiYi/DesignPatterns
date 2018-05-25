namespace FactoryMethod.Sources.Exercise
{
    public interface IFruit
    {
    }

    public class Apple : IFruit
    {
    }

    public class Orange : IFruit
    {
    }

    public interface IVehicle
    {
    }

    public class Bicycle : IVehicle
    {
    }

    public class Train : IVehicle
    {
    }

    public class Car : IVehicle
    {
    }

    public interface IEntry
    {
    }

    public class EntryWithName : IEntry
    {
        public EntryWithName(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }

    public class EntryWithNameAndTitle : EntryWithName
    {
        private const int DefaultAge = 24;
        private const string DefaultTitle = "UnKnown";

        public EntryWithNameAndTitle(string name, int age, string title) : base(name)
        {
            Age = age;
            Title = title;
        }

        public EntryWithNameAndTitle(string name) : this(name, DefaultAge, DefaultTitle)
        {
        }

        public EntryWithNameAndTitle(string name, int age) : this(name, age, DefaultTitle)
        {
        }

        public int Age { get; private set; }
        public string Title { get; private set; }
    }
}