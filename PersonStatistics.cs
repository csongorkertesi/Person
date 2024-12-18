namespace PeopleProject;

public class PersonStatistics
{
    public List<Person> People { private get; set; }

    public PersonStatistics(List<Person> people)
    {
        People = people;
    }

    public double GetAverageAge()
    {
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
        Person highestScore = People[0];
        foreach (Person person in People)
        {
            if (person.Score > highestScore.Score)
            {
                highestScore = person;
            }
        }
        return highestScore;
    }

    public double GetAverageScoreOfStudents()
    {
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
        Person oldest = new Person(-1, "", -1, true, 0);
        foreach (Person person in People)
        {
            if (!person.IsStudent) continue;
            if (person.Age > oldest.Age) oldest = person;
        }
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
