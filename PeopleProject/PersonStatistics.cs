namespace PeopleProject;

public class PersonStatistics
{
    private List<Person> _people;

    public List<Person> People
    {
        get => _people;
        set
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            _people = value;
        }
    }

    public PersonStatistics(List<Person> people)
    {
        if (people == null) throw new ArgumentNullException(nameof(people));
        _people = people;
    }

    public double GetAverageAge()
    {
        if (People.Count == 0) throw new InvalidOperationException("Üres a lista!");

        double sum = 0;
        foreach (Person person in People)
        {
            sum += person.Age;
        }

        return sum / People.Count;
    }

    public int GetNumberOfStudents()
    {
        return People.Count(person => person.IsStudent);
    }

    public Person GetPersonWithHighestScore()
    {
        if (People.Count == 0) throw new InvalidOperationException("Üres a lista!");

        Person? highestScorer = People.MaxBy(person => person.Score);
        if (highestScorer == null) throw new InvalidOperationException();
        return highestScorer;
    }

    public double GetAverageScoreOfStudents()
    {
        if (People.Count == 0) throw new InvalidOperationException("Üres a lista!");
        if (GetNumberOfStudents() == 0) throw new InvalidOperationException("Nincs tanuló a listában!");

        double sum = 0;
        foreach (Person person in People)
        {
            if (!person.IsStudent) continue;
            sum += person.Score;
        }
        return sum / GetNumberOfStudents();
    }

    public Person GetOldestStudent()
    {
        if (People.Count == 0) throw new InvalidOperationException("Üres a lista!");

        Person? oldest = People.FindAll(person => person.IsStudent).MaxBy(student => student.Age);
        if (oldest == null) throw new InvalidOperationException();
        return oldest;
    }

    public bool IsAnyoneFailing()
    {
        bool failing = false;
        foreach (Person person in People)
        {
            if (person.Score >= 40) continue;
            failing = true;
            break;
        }
        return failing;
    }
}
