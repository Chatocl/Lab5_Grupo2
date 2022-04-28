using Lab5_Grupo2.Models;
using Lab5_Grupo2.Models.Datos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Lab5_Grupo2.Controllers
{
    public class VehiculosController : Controller
    {
        private IHostingEnvironment Environment;
        public VehiculosController(IHostingEnvironment _environment)
        {
            Environment = _environment;

        }
        // GET: VehiculosController1
        public ActionResult Index()
        {
            return View(Singleton.Instance.ArbolVehiculos.GetList());
        }

        // GET: VehiculosController1/Details/5
        public ActionResult Details(int id)
        {
            var viewVehiculo = Singleton.Instance.ArbolVehiculos.GetList().FirstOrDefault(a => a.Placa == id);
            return View(viewVehiculo);
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
            var viewVehiculo = Singleton.Instance.ArbolVehiculos.GetList().FirstOrDefault(a => a.Placa == id);
            return View(viewVehiculo);
        }

        // POST: VehiculosController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var viewVehiculo = Singleton.Instance.ArbolVehiculos.GetList().FirstOrDefault(a => a.Placa == id);
                Singleton.Instance.ArbolVehiculos.Edit(viewVehiculo).Latitud = Convert.ToInt32(collection["latitud"]);
                Singleton.Instance.ArbolVehiculos.Edit(viewVehiculo).Longitud = Convert.ToInt32(collection["longitud"]);
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
            var viewVehiculo = Singleton.Instance.ArbolVehiculos.GetList().FirstOrDefault(a => a.Placa == id);
            return View(viewVehiculo);
        }

        // POST: VehiculosController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var viewVehiculo = Singleton.Instance.ArbolVehiculos.GetList().FirstOrDefault(a => a.Placa == id);
                Singleton.Instance.ArbolVehiculos.Remove(viewVehiculo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Busqueda(int Busqueda)
        {
            try
            {
                if (Busqueda > 0)
                {
                    Vehiculos viewVehiculo = Singleton.Instance.ArbolVehiculos.GetList().FirstOrDefault(a => a.Placa == Busqueda);
                    if (viewVehiculo == null)
                    {
                        TempData["Bus"] = "No se encontro el vehiculo";

                    }
                    return View(viewVehiculo);
                }
                return View();
            }
            catch
            {
                TempData["Bus"] = "No se encontro el vehiculo";
                return View();
            }
        }
 
        public ActionResult CargarArchivo(IFormFile File)
        {

            string Color = "", Propietario = "";
            int Placa = 0, Latitud = 0, Longitud = 0;
            try
            {

                if (File != null)
                {
                    string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string FileName = Path.GetFileName(File.FileName);
                    string FilePath = Path.Combine(path, FileName);
                    using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                    {
                        File.CopyTo(stream);
                    }
                    using (TextFieldParser csvFile = new TextFieldParser(FilePath))
                    {

                        csvFile.CommentTokens = new string[] { "#" };
                        csvFile.SetDelimiters(new string[] { "," });
                        csvFile.HasFieldsEnclosedInQuotes = true;

                        csvFile.ReadLine();

                        while (!csvFile.EndOfData)
                        {
                            string[] fields = csvFile.ReadFields();
                            Placa = Convert.ToInt32(fields[0]);
                            Color = Convert.ToString(fields[1]);
                            Propietario = Convert.ToString(fields[2]);
                            Latitud = Convert.ToInt32(fields[3]);
                            Longitud = Convert.ToInt32(fields[4]);
                            Vehiculos nuevoVehiculo = new Vehiculos
                            {
                                Placa = Placa,
                                Color = Color,
                                Propietario = Propietario,
                                Latitud = Latitud,
                                Longitud = Longitud

                            };
                            Singleton.Instance.ArbolVehiculos.add(nuevoVehiculo);
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewData["Message"] = "Algo sucedio mal";
                return RedirectToAction(nameof(Index));

            }
        }
    }
}