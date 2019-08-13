namespace Coding.Exercise
{
    public interface IPerson
    {
        int Age { get; set; }

        string Drink();
        string DrinkAndDrive();
        string Drive();
    }
}