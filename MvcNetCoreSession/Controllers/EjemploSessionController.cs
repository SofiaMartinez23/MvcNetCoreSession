using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcNetCoreSession.Extensions;
using MvcNetCoreSession.Helpers;
using MvcNetCoreSession.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcNetCoreSession.Controllers
{


    public class EjemploSessionController : Controller
    {
        HelperSessionContextAccesor helper;

        public EjemploSessionController(HelperSessionContextAccesor helper)
        {
            this.helper = helper;
        }

        public IActionResult Index()
        {
            List<Mascota> mascotas = this.helper.GetMascotasSession();
            return View(mascotas);
        }

        public IActionResult SessionSimple(string accion)
        {
            if (accion != null) 
            {
                if (accion.ToLower() == "almacenar")
                {
                    HttpContext.Session.SetString("nombre", "Programeitor");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                    ViewData["MENSAJE"] = "Datos almacenados de Session";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    ViewData["USUARIO"] = HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] = HttpContext.Session.GetString("hora");

                }
                }
            
            return View();
        }

        public IActionResult SessionMascota(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                   Mascota mascota = new Mascota();
                    mascota.Nombre = "Flounder";
                    mascota.Raza = "Pez";
                    mascota.Edad = 5;

                    byte[] data = HelperBinarySession.ObjectToByte(mascota);
                    HttpContext.Session.Set("MASCOTA", data);
                    ViewData["MENSAJE"] = "Mascota almacenada en Session";

                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("MASCOTA");
                    Mascota mascota = (Mascota) HelperBinarySession.ByteToObject(data);
                    ViewData["MASCOTA"] = mascota;
                }
            }

            return View();
        }

        public IActionResult SessionCollection(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota>()
                    {
                        new Mascota{Nombre= "Nala", Raza= "Leona", Edad= 10},
                        new Mascota{Nombre= "Olaf", Raza= "Nieve", Edad= 14},
                        new Mascota{Nombre= "Rafiki", Raza= "Mono", Edad= 20},
                        new Mascota{Nombre= "Sebastian", Raza= "Cangrejo", Edad= 12}
                    };
                    byte[] data = HelperBinarySession.ObjectToByte(mascotas);
                    HttpContext.Session.Set("MASCOTA", data);
                    ViewData["MASCOTA"] = "Coleccion almacenada en Session";
                    return View();

                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("MASCOTA");
                    List<Mascota> mascotas =  (List<Mascota>) HelperBinarySession.ByteToObject(data);
                    return View(mascotas);

                }
            }
            return View();
        }

        public IActionResult SessionMascotaJson(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascotas = new Mascota
                    {
                        Nombre = "Simba", Raza = "Leon", Edad = 9
                    };
                    string jsonMascota = HelperJsonSession.SerializeObject<Mascota>(mascotas);
                    HttpContext.Session.SetString("MASCOTA", jsonMascota);
                    ViewData["MENSAJE"] = "Mascota JSON almacenada";

                }
                else if (accion.ToLower() == "mostrar")
                {
                    string json = HttpContext.Session.GetString("MASCOTA");
                    Mascota mascota = HelperJsonSession.DeserializableObject<Mascota>(json);    
                    ViewData["MASCOTA"] = mascota;

                }
            }
            return View();
        }

        public IActionResult SessionMascotaObject(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota
                    {
                        Nombre = "Olaf", Raza = "Muñeco", Edad = 19
                    };
                    HttpContext.Session.SetObject<Mascota>("MASCOTAOBJECT", mascota);
                    ViewData["MENSAJE"] = "Mascota como Object almacenada";

                }
                else if (accion.ToLower() == "mostrar")
                {
                    Mascota mascota = HttpContext.Session.GetObject<Mascota>("MASCOTAOBJECT");
                    ViewData["MASCOTA"] = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionMascotaCollection(string accion)
        {
            if (accion != null) 
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota>
                    {
                        new Mascota {Nombre = "Patricio", Raza = "Estrella de mar", Edad = 19 },
                        new Mascota {Nombre = "Apu", Raza = "Monito", Edad = 10 },
                        new Mascota {Nombre = "Donald", Raza = "Pato", Edad = 50 },
                        new Mascota {Nombre = "Pluto", Raza = "Perro", Edad = 60 },
                    };
                    HttpContext.Session.SetObject<Mascota>("MASCOTAS", mascotas);
                    ViewData["MENSAJE"] = "Coleccion Mascotas almacenada";
                    return View();

                }
                else if (accion.ToLower() == "mostrar")
                {
                    List<Mascota> mascotas = HttpContext.Session.GetObject<List<Mascota>>("MASCOTAS");
                    return View(mascotas);

                }
            }
            return View();

        }
    }
}
