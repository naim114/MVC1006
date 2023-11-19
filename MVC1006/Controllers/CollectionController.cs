using Microsoft.AspNetCore.Mvc;

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
            IDictionary<string, string> dictCities= new Dictionary<string, string>()
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
    }
}
