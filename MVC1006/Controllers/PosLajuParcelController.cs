using Microsoft.AspNetCore.Mvc;
using MVC1006.Models;

namespace MVC1006.Controllers
{
    public class PosLajuParcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ParcelDelivery()
        {
            PosLajuParcel p = new PosLajuParcel();

            p.IndexWeight = p.IndexZone = -1;

            return View(p);
        }

        [HttpPost]
        public IActionResult ParcelDelivery(PosLajuParcel p)
        {
            return (ModelState.IsValid) ? View("ParcelDeliveryInvoice", p) : View(p);
        }
    }
}
