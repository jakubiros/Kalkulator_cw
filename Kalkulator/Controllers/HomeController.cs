using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Jakub";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien dobry" : "Dobry wieczor";

            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname = "Kowalska"},
                new Dane {Name = "Jan", Surname = "Nowak"},
                new Dane {Name = "Janusz", Surname = "Szpilka"}
            };

            return View(osoby);
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie}, masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View();
        }

        public IActionResult Calculator(Calculator kalkulator)
        {

            if (kalkulator.Operator == '+')
            {
                kalkulator.Result = kalkulator.x + kalkulator.y;
            }
            else if (kalkulator.Operator == '-')
            {
                kalkulator.Result = kalkulator.x - kalkulator.y;
            }
            else if (kalkulator.Operator == '*')
            {
                kalkulator.Result = kalkulator.x * kalkulator.y;
            }
            else if (kalkulator.Operator == '/')
            {
                if (kalkulator.y == 0)
                {
                    ViewBag.wynik = "Nie można dzielić przez 0";
                    return View();
                }
                kalkulator.Result = kalkulator.x / kalkulator.y;
            }
            else
            {
                ViewBag.wynik = "Brak znaku lub liczby";
                return View();
            }

            ViewBag.wynik = $"Wynik: {kalkulator.Result}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}