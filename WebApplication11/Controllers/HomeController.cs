using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WebApplication11.Models;
using WebApplication11.Models.Dane;

namespace WebApplication11.Controllers
{


    [EnableCors(origins: "http://localhost:44436/", headers: "*", methods: "*")]
    public class HomeController : Controller


    {

        public RezerwacjaContext _context;
      

        public HomeController()
        {
           
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public JsonResult Wypozy([FromBody] MyModel model)
        {
            //TODO: zapis danych do bazy danych
            ViewBag.liczba = model.imie;
            return Json(model);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public string Wypozycz([FromBody] Rezerwacja_ rezer)
        {

            using (RezerwacjaContext rezerwacjaContext = new RezerwacjaContext())
            {
                _context = rezerwacjaContext;

                bool zm = false;

              
               
                    foreach (var r in _context.Rezerwacja)
                    {
                        if (rezer.NazwaNart == r.NazwaNart)
                        {
                        zm = true;
                        
                            _context.Rezerwacja.Remove(r);
                            var nartWypozyczone = new Wypozyczone() { NazwaNart = rezer.NazwaNart, OSOBA = rezer.OSOBA };
                            _context.Wypozyczone.Add( nartWypozyczone);
                            break;
                            

                        }
                    }
                    _context.SaveChanges();
                if(zm)
                    return "WYPORZYCZONE DLA CIEBIE PRZYJACIELU :)";
                
                else
                {
                    return "BRAK NART :(";
                }

            }
        }

     

        [System.Web.Http.HttpGet]
        public JsonResult Index()
        {
            using (RezerwacjaContext rezerwacjaContext = new RezerwacjaContext())
            {
                _context = rezerwacjaContext;
                return Json(_context.Rezerwacja.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public string Zwolnij([FromBody] Zwolnij_ zwolnij)
        {
            using (RezerwacjaContext rezerwacjaContext = new RezerwacjaContext())
            {
                _context = rezerwacjaContext;


                bool zm = false;

                foreach (var r in _context.Wypozyczone)
                {
                    if (zwolnij.NazwaNart== r.NazwaNart)
                    {
                        zm = true;
                        break;
                    }
                }
                if (zm)
                {
                    foreach (var r in _context.Wypozyczone)
                    {
                        if (zwolnij.NazwaNart == r.NazwaNart)
                        {
                            _context.Wypozyczone.Remove(r);
                            var nartWypozyczone = new Rezerwacja { NazwaNart = r.NazwaNart, OSOBA = r.OSOBA };
                            _context.Rezerwacja.Add(nartWypozyczone);
                            break;


                        }
                    }
                    _context.SaveChanges();

                    return "Usunięto narty";
                }
                else
                {
                    return "Nie usunięto";
                }

               
            }
        }

    

        [System.Web.Http.HttpGet]
        public JsonResult Serwis_baza()
        {
            using (RezerwacjaContext rezerwacjaContext = new RezerwacjaContext())
            {

                _context = rezerwacjaContext;

                return Json(_context.Wypozyczone.ToList(), JsonRequestBehavior.AllowGet);
            }
        }






    }

}