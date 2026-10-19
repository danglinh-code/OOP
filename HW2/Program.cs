using System;

namespace HW2
{
    public class Person
    {
        private string name;
        private string address;
        private double salary;

        public Person()
        {
        }

        public Person(string name, string address, double salary)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }

    class Program
    {
        public static Person inputPersonInfo(string name, string address, string sSalary)
        {
            if (string.IsNullOrEmpty(sSalary))
            {
                throw new Exception("You must input Salary.");
            }

            double salary;
            if (!double.TryParse(sSalary, out salary))
            {
                throw new Exception("You must input digit.");
            }

            if (salary <= 0)
            {
                throw new Exception("Salary is greater than zero");
            }

            return new Person(name, address, salary);
        }

        public static void displayPersonInfo(Person person)
        {
            Console.WriteLine("Information of Person you have entered:");
            Console.WriteLine("Name:" + person.Name);
            Console.WriteLine("Address:" + person.Address);
            Console.WriteLine("Salary:" + person.Salary);
        }

        public static Person[] sortBySalary(Person[] person)
        {
            if (person == null || person.Length == 0)
            {
                throw new Exception("Can't Sort Person");
            }

            for (int i = 0; i < person.Length - 1; i++)
            {
                for (int j = 0; j < person.Length - i - 1; j++)
                {
                    if (person[j].Salary > person[j + 1].Salary)
                    {
                        Person temp = person[j];
                        person[j] = person[j + 1];
                        person[j + 1] = temp;
                    }
                }
            }

            return person;
        }

        static void Main(string[] args)
        {
            Person[] persons = new Person[3];

            Console.WriteLine("=====Management Person programer=====");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Input Information of Person");
                Console.Write("Please input name:");
                string name = Console.ReadLine();

                Console.Write("Please input address:");
                string address = Console.ReadLine();

                while (true)
                {
                    Console.Write("Please input salary:");
                    string sSalary = Console.ReadLine();

                    try
                    {
                        persons[i] = inputPersonInfo(name, address, sSalary);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            try
            {
                persons = sortBySalary(persons);

                for (int i = 0; i < 3; i++)
                {
                    displayPersonInfo(persons[i]);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}