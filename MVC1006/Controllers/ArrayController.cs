using Microsoft.AspNetCore.Mvc;
using MVC1006.AssignedValues;

namespace MVC1006.Controllers
{
    public class ArrayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IntegerArray() {
            int[] numbers = { 6, 3, 1, 2, 5, 4 };
            ViewBag.Numbers = numbers;
            return View();
        }

        public IActionResult StringArray() {
            string[] pets = { "cat", "dog", "rabbit", "hamster", "turtle" };
            ViewBag.Pets = pets;
            return View();
        }

        public IActionResult PosLajuRatesArray()
        {
            PosLaju p = new PosLaju();
            ViewBag.WeightCategories = p.weightCategories;
            ViewBag.Zones = p.zones;
            ViewBag.Rates = p.rates;

            return View();
        }

        public IActionResult MultiplicationArray()
        {
            int[,] multiplications = new int[13, 13];
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    multiplications[i, j] = i * j;
                }
            }

            ViewBag.Multiplications = multiplications;

            return View();
        }

        public IActionResult Jagged1DimensionalArray()
        {
            SoftwareHouse s = new SoftwareHouse();

            ViewBag.Employees = s.employees;
            ViewBag.Skills = s.skills;

            return View();

        }

        public IActionResult Jagged2DimensionalArray()
        {
            CourseGrade c = new CourseGrade();

            ViewBag.Students = c.students;
            ViewBag.Courses = c.courses;

            return View();

        }
    }
}
