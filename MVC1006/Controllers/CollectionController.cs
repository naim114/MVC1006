using Microsoft.AspNetCore.Mvc;
using MVC1006.Models;
using System.Linq;

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

            ViewBag.OrderName = listEmployee.OrderBy(x => x.Name);
            ViewBag.OrderStartDate = listEmployee.OrderBy(x => x.StartDate);
            ViewBag.OrderDescSalary = listEmployee.OrderByDescending(x => x.Salary);
            ViewBag.OrderCampusName = listEmployee.OrderBy(x => x.Campus).ThenBy(x => x.Name);

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

        public IActionResult EmployeeListRestriction()
        {
            IList<Employee> listEmployee = new List<Employee>()
            {
                new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M", Position = "Lecturer", StartDate = new DateTime(2010, 7, 1), Campus = "MIIT", Salary = 4631},
                new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M", Position = "Executive", StartDate = new DateTime(2010, 4, 15), Campus = "BMI", Salary = 3000},
                new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M", Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1), Campus = "MFI", Salary = 10000},
                new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M", Position = "Technician", StartDate = new DateTime(2015, 3, 15), Campus = "BMI", Salary = 2050},
                new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M", Position = "Professor", StartDate = new DateTime(2014, 7, 1), Campus = "MIIT", Salary = 16205},
                new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F", Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15), Campus = "MIIT", Salary = 6000},
                new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M", Position = "Manager", StartDate = new DateTime(2012, 10, 1), Campus = "MIIT", Salary = 5300},
                new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F", Position = "Clerk", StartDate = new DateTime(2008, 8, 1), Campus = "BMI", Salary = 2000},
                new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F", Position = "Executive", StartDate = new DateTime(2008, 8, 1), Campus = "MFI", Salary = 3000},
                new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M", Position = "Professor", StartDate = new DateTime(2008, 8, 1), Campus = "MIIT", Salary = 15300}
            };

            ViewBag.Female = listEmployee.Where(x => x.Gender == "F");
            ViewBag.MIIT = listEmployee.Where(x => x.Campus == "MIIT");
            ViewBag.HighSalary = listEmployee.Where(x => x.Salary >= 5000);
            ViewBag.Senior = listEmployee.Where(x => x.StartDate < new DateTime(2011,01,01));
            ViewBag.SeniorMale = listEmployee.Where(x => x.StartDate < new DateTime(2011,01,01) && x.Gender == "M");
            ViewBag.MIITMFI = listEmployee.Where(x => x.Campus == "MIIT" || x.Campus == "MFI").OrderBy(x => x.Campus).ThenBy(x => x.Name);

            return View(listEmployee);
        }

        public IActionResult EmployeeRestAgg()
        {
            IList<Employee> listEmployee = new List<Employee>()
            {
                new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M", Position = "Lecturer", StartDate = new DateTime(2010, 7, 1), Campus = "MIIT", Salary = 4631},
                new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M", Position = "Executive", StartDate = new DateTime(2010, 4, 15), Campus = "BMI", Salary = 3000},
                new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M", Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1), Campus = "MFI", Salary = 10000},
                new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M", Position = "Technician", StartDate = new DateTime(2015, 3, 15), Campus = "BMI", Salary = 2050},
                new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M", Position = "Professor", StartDate = new DateTime(2014, 7, 1), Campus = "MIIT", Salary = 16205},
                new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F", Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15), Campus = "MIIT", Salary = 6000},
                new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M", Position = "Manager", StartDate = new DateTime(2012, 10, 1), Campus = "MIIT", Salary = 5300},
                new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F", Position = "Clerk", StartDate = new DateTime(2008, 8, 1), Campus = "BMI", Salary = 2000},
                new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F", Position = "Executive", StartDate = new DateTime(2008, 8, 1), Campus = "MFI", Salary = 3000},
                new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M", Position = "Professor", StartDate = new DateTime(2008, 8, 1), Campus = "MIIT", Salary = 15300}
            };

            ViewBag.CountAll = listEmployee.Count();
            ViewBag.CountMale = listEmployee.Where(x => x.Gender == "M").Count();
            ViewBag.CountFemale = listEmployee.Where(x => x.Gender == "F").Count();
            ViewBag.AverageSalary = listEmployee.Average(x=>x.Salary);
            ViewBag.AverageSalaryMale = listEmployee.Where(x => x.Gender == "M").Average(x=>x.Salary);
            ViewBag.AverageSalaryFemale = listEmployee.Where(x => x.Gender == "F").Average(x=>x.Salary);

            return View(listEmployee);
        }

        public IActionResult FindElement()
        {
            IList<Employee> listEmployee = new List<Employee>()
            {
                new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M", Position = "Lecturer", StartDate = new DateTime(2010, 7, 1), Campus = "MIIT", Salary = 4631},
                new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M", Position = "Executive", StartDate = new DateTime(2010, 4, 15), Campus = "BMI", Salary = 3000},
                new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M", Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1), Campus = "MFI", Salary = 10000},
                new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M", Position = "Technician", StartDate = new DateTime(2015, 3, 15), Campus = "BMI", Salary = 2050},
                new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M", Position = "Professor", StartDate = new DateTime(2014, 7, 1), Campus = "MIIT", Salary = 16205},
                new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F", Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15), Campus = "MIIT", Salary = 6000},
                new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M", Position = "Manager", StartDate = new DateTime(2012, 10, 1), Campus = "MIIT", Salary = 5300},
                new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F", Position = "Clerk", StartDate = new DateTime(2008, 8, 1), Campus = "BMI", Salary = 2000},
                new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F", Position = "Executive", StartDate = new DateTime(2008, 8, 1), Campus = "MFI", Salary = 3000},
                new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M", Position = "Professor", StartDate = new DateTime(2008, 8, 1), Campus = "MIIT", Salary = 15300}
            };

            var result = listEmployee.First(x => x.EmpId == 5);

            return View(result);
        }

        public IActionResult SelectSubSet()
        {
            IList<Employee> listEmployee = new List<Employee>()
            {
                new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M", Position = "Lecturer", StartDate = new DateTime(2010, 7, 1), Campus = "MIIT", Salary = 4631},
                new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M", Position = "Executive", StartDate = new DateTime(2010, 4, 15), Campus = "BMI", Salary = 3000},
                new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M", Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1), Campus = "MFI", Salary = 10000},
                new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M", Position = "Technician", StartDate = new DateTime(2015, 3, 15), Campus = "BMI", Salary = 2050},
                new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M", Position = "Professor", StartDate = new DateTime(2014, 7, 1), Campus = "MIIT", Salary = 16205},
                new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F", Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15), Campus = "MIIT", Salary = 6000},
                new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M", Position = "Manager", StartDate = new DateTime(2012, 10, 1), Campus = "MIIT", Salary = 5300},
                new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F", Position = "Clerk", StartDate = new DateTime(2008, 8, 1), Campus = "BMI", Salary = 2000},
                new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F", Position = "Executive", StartDate = new DateTime(2008, 8, 1), Campus = "MFI", Salary = 3000},
                new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M", Position = "Professor", StartDate = new DateTime(2008, 8, 1), Campus = "MIIT", Salary = 15300}
            };

            var result = listEmployee.Select(x => new Employee() {EmpId=x.EmpId, Name = x.Name, Position = x.Position });

            return View(result);
        }

        public IActionResult SelectNetSalary()
        {
            IList<Employee> listEmployee = new List<Employee>()
            {
                new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M", Position = "Lecturer", StartDate = new DateTime(2010, 7, 1), Campus = "MIIT", Salary = 4631},
                new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M", Position = "Executive", StartDate = new DateTime(2010, 4, 15), Campus = "BMI", Salary = 3000},
                new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M", Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1), Campus = "MFI", Salary = 10000},
                new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M", Position = "Technician", StartDate = new DateTime(2015, 3, 15), Campus = "BMI", Salary = 2050},
                new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M", Position = "Professor", StartDate = new DateTime(2014, 7, 1), Campus = "MIIT", Salary = 16205},
                new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F", Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15), Campus = "MIIT", Salary = 6000},
                new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M", Position = "Manager", StartDate = new DateTime(2012, 10, 1), Campus = "MIIT", Salary = 5300},
                new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F", Position = "Clerk", StartDate = new DateTime(2008, 8, 1), Campus = "BMI", Salary = 2000},
                new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F", Position = "Executive", StartDate = new DateTime(2008, 8, 1), Campus = "MFI", Salary = 3000},
                new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M", Position = "Professor", StartDate = new DateTime(2008, 8, 1), Campus = "MIIT", Salary = 15300}
            };

            var result1 = listEmployee.Select(x => new Employee() { EmpId = x.EmpId, Name = x.Name, Position = x.Position, Salary = x.Salary, Deduction = x.Salary * 0.09, NetSalary = x.Salary - (x.Salary * 0.09) });
            var result2 = listEmployee.Select(x => new Employee() { EmpId = x.EmpId, Name = x.Name, Position = x.Position, Salary = x.Salary, Deduction = x.Salary * 0.09, NetSalary = x.Salary - (x.Salary * 0.09) }).Where(x => x.Deduction >= 1000).OrderBy(x => x.Name);

            return View(result2);
        }
    }
}
