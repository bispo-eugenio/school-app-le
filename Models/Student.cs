namespace schoolApp.Models;

using Person = schoolApp.Models.@abstract.Person;
using Stats = schoolApp.Types.@Enums.Stats;

internal class Students
{
    private class Student : Person
    {
        private List<double> Grade { get; set; }

        public Student(string firstName, string lastName,
        DateTime birthday, string cpf, Stats stats)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Cpf = cpf;
            Stats = stats;
            Grade = [];
        }

        public Student(string firstName, string lastName,
         DateTime birthday, string cpf, Stats stats, List<double> grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Cpf = cpf;
            Stats = stats;
            Grade = grade;
        }





    }
}
