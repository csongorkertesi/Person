namespace PeopleProject;

public class Person
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public bool IsStudent { get; private set; }
    public int Score { get; private set; }

    public Person(int id, string name, int age, bool isStudent, int score)
    {
        Id = id;
        Name = name;
        Age = age;
        IsStudent = isStudent;
        Score = score;
    }
}