using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SF_Module14
{
    class Program
    {
        static void Main(string[] args)
        {
            // [0.4]
            /*
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            List<string> peopleList = new List<string>();

            foreach (string person in people)
            {
                if (person.ToUpper().StartsWith("А"))
                    peopleList.Add(person);
            }

            peopleList.Sort();

            foreach (string str in peopleList)
                Console.WriteLine(str);
            */

            // [0.8.1 - 0.8.2]
            /*
            var objects = new List<object>()
            {
                1,
                "Сергей ",
                "Андрей ",
                300,
            };

            var names = from p in objects
                        where p is string
                        orderby p
                        select p;

            foreach (var name in names)
                Console.WriteLine(name);
            //
            foreach (var stringObject in objects.Where(o => o is string).OrderBy(o => o))
                Console.WriteLine(stringObject);
            */

            // [14.1.1]
            /*
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));

            var bigCities = russianCities
                .Where(c => c.Name.Length <= 10)
                .OrderBy(c => c.Name.Length);

            foreach (var bigCity in bigCities)
                Console.WriteLine(bigCity.Name + " - " + bigCity.Population);
            */

            // [14.1.2]
            /*
            string[] text = { "Раз два три", "четыре пять шесть", "семь восемь девять" };

            var words = from str in text
                        from word in str.Split(' ')
                        select word;

            foreach (var word in words)
                Console.WriteLine(word);
            */

            // [14.1.5]
            /*
            var companies = new Dictionary<string, string[]>();

            companies.Add("Apple", new[] { "Mobile", "Desktop" });
            companies.Add("Samsung", new[] { "Mobile" });
            companies.Add("IBM", new[] { "Desktop" });

            var mobileCompanies = companies
                .Where(c => c.Value.Contains("Mobile"));

            foreach (var company in mobileCompanies)
                Console.WriteLine(company.Key);
            */

            // [14.1.6]
            /*
            var numsList = new List<int[]>()
            {
                new[] {2, 3, 7, 1},
                new[] {45, 17, 88, 0},
                new[] {23, 32, 44, -6},
            };

            var orderedNums = numsList
                .SelectMany(s => s)
                .OrderBy(s => s);

            foreach (var ord in orderedNums)
                Console.WriteLine(ord);
            */

            // [14.2.1]
            /*
            string[] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };

            var wordsInfo = words.Select(w =>
            new
            {
                Name = w,
                Length = w.Length
            })
                .OrderBy(word => word.Length);


            foreach (var word in wordsInfo)
                Console.WriteLine($"{word.Name} - {word.Length} букв");
            */

            // [14.2.3]
            /*
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var youngStudentApplications = from s in students
                                           where s.Age < 27
                                           let birthYear = DateTime.Now.Year - s.Age
                                           select new Application
                                           {
                                               Name = s.Name,
                                               YearOfBirth = birthYear
                                           };

            foreach (var studApplication in youngStudentApplications)
                Console.WriteLine(studApplication.Name + ", " + studApplication.YearOfBirth);
            */

            // [14.2.4]
            /*
            var students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }}
            };

            var courses = new List<Course>
            {
                new Course {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
                new Course {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };

            var studentsWithCourses = from stud in students 
                                      where stud.Age < 29
                                      where stud.Languages.Contains("английский")
                                      let birthYear = DateTime.Now.Year - stud.Age
                                      from course in courses
                                      where course.Name.Contains("C#")
                                      select new
                                      {
                                          Name = stud.Name,
                                          BirthYear = birthYear,
                                          CourseName = course.Name
                                      };

            foreach (var stud in studentsWithCourses)
                Console.WriteLine($"Студент {stud.Name} ({stud.BirthYear}) добавлен курс {stud.CourseName}");
            */

            // [14.2.5]
            /*
            var contacts = new List<Contact>()
            {
                new Contact() { Name = "Андрей", Phone = 7999945005 },
                new Contact() { Name = "Сергей", Phone = 799990455 },
                new Contact() { Name = "Иван", Phone = 79999675 },
                new Contact() { Name = "Игорь", Phone = 8884994 },
                new Contact() { Name = "Анна", Phone = 665565656 },
                new Contact() { Name = "Василий", Phone = 3434 }
            };

            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar;
                Console.Clear();

                if (!Char.IsDigit(keyChar))
                    Console.WriteLine("Ошибка ввода, введите число");
                else
                {
                    IEnumerable<Contact> page = null;

                    switch (keyChar)
                    {
                        case ('1'):
                            page = contacts.Take(2);
                            break;
                        case ('2'):
                            page = contacts.Skip(2).Take(2);
                            break;
                        case ('3'):
                            page = contacts.Skip(4).Take(2);
                            break;
                    }

                    if (page == null)
                    {
                        Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует");
                        continue;
                    }

                    foreach (var contact in page)
                        Console.WriteLine(contact.Name + " " + contact.Phone);
                }
            }
            */

            // [14.2.10]
            /*
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                var input = Console.ReadKey().KeyChar;

                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                else
                {
                    var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }
            */
        }

        // [14.1.1]
        /*
        public class City
        {
            public string Name { get; set; }
            public long Population { get; set; }

            public City(string name, long population)
            {
                Name = name;
                Population = population;
            }
        }
        */

        // [14.2.3]
        /*
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }

        public class Application
        {
            public string Name { get; set; }
            public int YearOfBirth { get; set; }
        }
        */

        // [14.2.4]
        /*
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }

        public class Course
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
        }
        */

        // [14.2.5]
        /*
        public class Contact
        {
            public string Name { get; set; }
            public long Phone { get; set; }
        }
        */

        // [14.2.10]
        /*
        public class Contact
        {
            public String Name { get; }
            public String LastName { get; }
            public long PhoneNumber { get; }
            public String Email { get; }

            public Contact(string name, string lastName, long phoneNumber, String email)
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }
        }
        */
    }
}
