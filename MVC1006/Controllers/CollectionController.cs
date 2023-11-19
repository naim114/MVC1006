using Microsoft.AspNetCore.Mvc;
using MVC1006.Models;

namespace MVC1006.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NumberDictionary()
        {
            IDictionary<int, string> dictNumbers = new Dictionary<int, string>()
            {
                {1, "One" },
                {2, "Two" },
                {3, "Three" }
            };

            ViewBag.DictNumbers = dictNumbers;

            return View();
        }

        public IActionResult CityDictionary() {
            IDictionary<string, string> dictCities = new Dictionary<string, string>()
            {
                {"KUL", "Kuala Lumpur" },
                {"PEN", "Penang" },
                {"JHB", "Johor Bahru" },
                {"KCH", "Kuching" },
            };

            ViewBag.DictCities = dictCities;

            return View();
        }

        public IActionResult CityDictionaryAdd()
        {
            IDictionary<string, string> dictCities = new Dictionary<string, string>()
            {
                {"KUL", "Kuala Lumpur" },
                {"PEN", "Penang" },
                {"JHB", "Johor Bahru" },
                {"KCH", "Kuching" },
            };

            dictCities.Add("LGK", "Langkawi");
            dictCities.Add("KBR", "Kota Bharu");

            ViewBag.DictCities = dictCities;

            return View();
        }

        public IActionResult NumberList()
        {
            IList<int> listNumbers = new List<int>() { 10, 20, 30, 40 };

            ViewBag.ListNumbers = listNumbers;

            return View();
        }

        public IActionResult AddNumbersList()
        {
            IList<int> listNumbers = new List<int>();

            listNumbers.Add(10);
            listNumbers.Add(20);
            listNumbers.Add(30);
            listNumbers.Add(40);
            listNumbers.Add(50);

            ViewBag.ListNumbers = listNumbers;

            return View();
        }

        public IActionResult PetList()
        {
            IList<string> listPets = new List<string>() { "cat", "dog", "rabbit", "hamster"};
            listPets.Add("gecko");
            listPets.Add("turtle");

            ViewBag.ListPets = listPets;

            return View();
        }

        public IActionResult RemoveNumbersList()
        {
            IList<int> listNumbers = new List<int>() { 1, 2, 3, 4, 5, 1, 2};

            listNumbers.Remove(2);

            ViewBag.ListNumbers = listNumbers;

            return View();
        }

        public IActionResult InfoPetList()
        {
            IList<string> listPets = new List<string>() { "cat", "dog", "rabbit", "hamster" };
            int count = listPets.Count;
            bool contains = listPets.Contains("rabbit");
            int indexOf = listPets.IndexOf("rabbit");

            ViewBag.ListPets = listPets;
            ViewBag.Count = count;
            ViewBag.Contains = contains;
            ViewBag.IndexOf = indexOf;

            return View();
        }

        public IActionResult EmployeeList()
        {
            IList<Employee> listEmployee = new List<Employee>()
            {
                new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M", Position = "Lecturer", StartDate = new DateTime(2010, 7, 1), Campus = "MIIT", Salary = 4631},
                new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M", Position = "Executive", StartDate = new DateTime(2010, 4, 15), Campus = "BMI", Salary = 3000},
                new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F", Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15), Campus = "MIIT", Salary = 6000},
                new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F", Position = "Clerk", StartDate = new DateTime(2008, 8, 1), Campus = "BMI", Salary = 2000}
            };

            return View(listEmployee);
        }

        public IActionResult EmployeeListAdd()
        {
            IList<Employee> listEmployee = new List<Employee>()
            {
                new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M", Position = "Lecturer", StartDate = new DateTime(2010, 7, 1), Campus = "MIIT", Salary = 4631},
                new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M", Position = "Executive", StartDate = new DateTime(2010, 4, 15), Campus = "BMI", Salary = 3000},
                new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F", Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15), Campus = "MIIT", Salary = 6000},
                new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F", Position = "Clerk", StartDate = new DateTime(2008, 8, 1), Campus = "BMI", Salary = 2000}
            };

            listEmployee.Add(new Employee { EmpId = 10, Name = "Tun Perak", Gender = "M", Position = "Professor", StartDate = new DateTime(2008, 8, 1), Campus = "MIIT", Salary = 15300 });

            return View(listEmployee);
        }
    }
}
