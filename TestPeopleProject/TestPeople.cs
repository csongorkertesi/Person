using PeopleProject;

namespace TestPeopleProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PS_Letrehoz_NullListaval_AgumentNulltDob()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                PersonStatistics PS = new(null);
            });
        }

        [Test]
        public void PS_Letrehoz()
        {
            List<Person> people = new List<Person>()
            {
                new Person(1, "Albert", 12, true, 10),
                new Person(2, "Balázs", 17, true, 80),
                new Person(3, "Csongor", 50, false, 0),
                new Person(4, "Dénes", 60, false, 100)
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.People, Is.EqualTo(people));
        }

        [Test]
        public void PS_GetAverageAge_UresLista_HibatDob()
        {
            List<Person> people = new();
            PersonStatistics PS = new(people);
            Assert.Throws<InvalidOperationException>(() => {
                PS.GetAverageAge();
            });
        }

        [Test]
        public void PS_GetAverageAge()
        {
            List<Person> people = new List<Person>()
            {
                new Person(1, "Albert", 12, true, 10),
                new Person(2, "Balázs", 17, true, 80),
                new Person(3, "Csongor", 50, false, 0),
                new Person(4, "Dénes", 60, false, 100)
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.GetAverageAge(), Is.EqualTo((12 + 17 + 50 + 60) / 4d));
        }

        [Test]
        public void PS_GetNumberOfStudents_UresLista()
        {
            List<Person> people = new();
            PersonStatistics PS = new(people);
            Assert.That(PS.GetNumberOfStudents(), Is.EqualTo(0));
        }

        [Test]
        public void PS_GetNumberOfStudents_NincsStudent()
        {
            List<Person> people = new()
            {
                new Person(1, "Aladár", 50, false, 100),
                new Person(2, "Béla", 50, false, 99),
                new Person(3, "Cecil", 40, false, 10)
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.GetNumberOfStudents(), Is.EqualTo(0));
        }

        [Test]
        public void PS_GetNumberOfStudents_VegyesLista_2()
        {
            List<Person> people = new()
            {
                new Person(1, "Aladár", 50, false, 100),
                new Person(2, "Béla", 50, false, 99),
                new Person(3, "Cecil", 40, false, 10),
                new Person(4, "Dénes", 10, true, 100), // 1
                new Person(5, "Elemér", 13, true, 70) // 2
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.GetNumberOfStudents(), Is.EqualTo(2));
        }

        [Test]
        public void PS_GetNumberOfStudents_VegyesLista_3()
        {
            List<Person> people = new()
            {
                new Person(1, "Aladár", 50, false, 100),
                new Person(2, "Béla", 50, false, 99),
                new Person(3, "Cecil", 40, false, 10),
                new Person(4, "Dénes", 10, true, 100), // 1
                new Person(5, "Elemér", 13, true, 70), // 2
                new Person(6, "Ferenc", 16, true, 80), // 3
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.GetNumberOfStudents(), Is.EqualTo(3));
        }

        [Test]
        public void PS_GetPersonWithHighestScore_UresLista_HibatDob()
        {
            List<Person> people = new();
            PersonStatistics PS = new(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                PS.GetPersonWithHighestScore();
            });
        }

        [Test]
        public void PS_GetPersonWithHighestScore()
        {
            List<Person> people = new()
            {
                new Person(1, "Aladár", 50, false, 30),
                new Person(2, "Béla", 50, false, 99),
                new Person(3, "Cecil", 40, false, 10),
                new Person(4, "Dénes", 10, true, 100),
                new Person(5, "Elemér", 13, true, 70),
                new Person(6, "Ferenc", 16, true, 80)
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.GetPersonWithHighestScore(), Is.EqualTo(people[3]));
        }

        [Test]
        public void PS_GetPersonWithHighestScore_TobbLegnagyobb()
        {
            List<Person> people = new()
            {
                new Person(1, "Aladár", 50, false, 30),
                new Person(2, "Béla", 50, false, 100),
                new Person(3, "Cecil", 40, false, 10),
                new Person(4, "Dénes", 10, true, 100),
                new Person(5, "Elemér", 13, true, 70),
                new Person(6, "Ferenc", 16, true, 80)
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.GetPersonWithHighestScore(), Is.EqualTo(people[1]));
        }

        [Test]
        public void PS_GetAverageScoreOfStudents_UresLista_HibatDob()
        {
            List<Person> people = new();
            PersonStatistics PS = new(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                PS.GetAverageScoreOfStudents();
            });
        }

        [Test]
        public void PS_GetAverageScoreOfStudents_NincsStudent_HibatDob()
        {
            List<Person> people = new()
            {
                new Person(1, "Aladár", 30, false, 100),
                new Person(2, "Bence", 31, false, 99)
            };
            PersonStatistics PS = new(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                PS.GetAverageScoreOfStudents();
            });
        }

        [Test]
        public void PS_GetAverageScoreOfStudents()
        {
            List<Person> people = new()
            {
                new Person(1, "Aladár", 50, false, 30),
                new Person(2, "Béla", 50, false, 100),
                new Person(3, "Cecil", 40, false, 10),
                new Person(4, "Dénes", 10, true, 100), //
                new Person(5, "Elemér", 13, true, 70), //
                new Person(6, "Ferenc", 16, true, 80) //
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.GetAverageScoreOfStudents(), Is.EqualTo((100 + 70 + 80) / 3d));
        }

        [Test]
        public void PS_GetOldestStudent_UresLista_HibatDob()
        {
            List<Person> people = new();
            PersonStatistics PS = new(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                PS.GetOldestStudent();
            });
        }

        [Test]
        public void PS_GetOldestStudent_NincsStudent_HibatDob()
        {
            List<Person> people = new()
            {
                new Person(1, "Aladár", 20, false, 100),
                new Person(2, "Brutus", 20, false, 90)
            };
            PersonStatistics PS = new(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                PS.GetOldestStudent();
            });
        }

        [Test]
        public void PS_GetOldestStudent()
        {
            List<Person> people = new()
            {
                new Person(1, "Aladár", 50, false, 30),
                new Person(2, "Béla", 50, false, 100),
                new Person(3, "Cecil", 40, false, 10),
                new Person(4, "Dénes", 10, true, 100),
                new Person(5, "Elemér", 13, true, 70),
                new Person(6, "Ferenc", 16, true, 80)
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.GetOldestStudent(), Is.EqualTo(people[5]));
        }

        [Test]
        public void PS_IsAnyoneFailing_Hamis()
        {
            List<Person> people = new()
            {
                new Person(1, "Éppen Hogy", 20, true, 40),
                new Person(2, "Hibátlan", 21, false, 100),
                new Person(3, "Jó", 19, true, 75)
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.IsAnyoneFailing(), Is.False);
        }

        [Test]
        public void PS_IsAnyoneFailing_Igaz()
        {
            List<Person> people = new()
            {
                new Person(1, "Pont Nem", 20, true, 39),
                new Person(2, "Jó", 19, true, 75),
                new Person(3, "Átment", 19, false, 50)
            };
            PersonStatistics PS = new(people);
            Assert.That(PS.IsAnyoneFailing(), Is.True);
        }
    }
}