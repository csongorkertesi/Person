using PeopleProject;

namespace TestPeopleProject
{
    public class Tests
    {
        public PersonStatistics PS;
        public List<Person> People;

        [SetUp]
        public void Setup()
        {
            People = new List<Person>()
            {
                new Person(1, "Aladár", 30, true, 100),
                new Person(2, "Benedek", 35, true, 25),
                new Person(3, "Csongor", 53, false, 10),
                new Person(4, "Dénes", 27, true, 10)
            };
            PS = new PersonStatistics(People);
        }

        [Test]
        public void PS_GetAverageAge()
        {
            Assert.That(PS.GetAverageAge(), Is.EqualTo(36.25));
            PS.People = new List<Person> { new Person(5, "Kende", 80, true, 100) };
            Assert.That(PS.GetAverageAge(), Is.EqualTo(80));
        }

        [Test]
        public void PS_GetNumberOfStudents()
        {
            Assert.That(PS.GetNumberOfStudents(), Is.EqualTo(3));
        }

        [Test]
        public void PS_GetPersonWithHighestScore()
        {
            Assert.That(PS.GetPersonWithHighestScore(), Is.EqualTo(People[0]));
        }

        [Test]
        public void PS_GetAverageScoreOfStudents()
        {
            double avg = PS.GetAverageScoreOfStudents();
            Assert.That(avg, Is.EqualTo(45));
        }

        [Test]
        public void PS_GetOldestStudent()
        {
            Assert.That(PS.GetOldestStudent(), Is.EqualTo(People[1]));
        }

        [Test]
        public void PS_IsAnyoneFailing()
        {
            Assert.That(PS.IsAnyoneFailing(), Is.True);
            PS.People = new List<Person> { new Person(1, "Teszt", 30, true, 100) };
            Assert.That(PS.IsAnyoneFailing(), Is.False);
        }
    }
}