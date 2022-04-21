using Lab5_Grupo2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_Grupo2.Controllers
{
    public class VehiculosController : Controller
    {
        // GET: VehiculosController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculosController1/Create
    }
}
