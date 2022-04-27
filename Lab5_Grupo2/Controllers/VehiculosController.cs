using Lab5_Grupo2.Models.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab5_Grupo2.Controllers
{
    public class VehiculosController : Controller
    {
        // GET: VehiculosController1
        public ActionResult Index()
        {
            return View(Singleton.Instance.ArbolVehiculos.GetList());
        }

        // GET: VehiculosController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehiculosController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiculosController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newAuto = new Models.Vehiculos()
                {
                    Placa = Convert.ToInt32(collection["Placa"]),
                    Color = collection["Color"],
                    Propietario = collection["Propietario"],
                    Latitud = Convert.ToInt32(collection["Latitud"]),
                    Longitud = Convert.ToInt32(collection["Longitud"])

                };
                Singleton.Instance.ArbolVehiculos.add(newAuto);   
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculosController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehiculosController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculosController1/Delete/5
        public ActionResult Delete(int id)
        {
           
            return View();
        }

        // POST: VehiculosController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
               // Singleton.Instance.ArbolVehiculos.Remove(a => a.VIzq == id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
