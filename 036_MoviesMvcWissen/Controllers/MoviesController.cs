﻿using _036_MoviesMvcWissen.Contexts;
using _036_MoviesMvcWissen.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Controllers
{
    public class MoviesController : Controller
    {
        MoviesContext db = new MoviesContext();


        // GET: Movies
        public ViewResult Index()
        {
            var model = db.Movies.ToList();
            if (model == null)
                model = new List<Movie>();
            return View(model);
        }
        //[AcceptVerbs("GET")]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //[AcceptVerbs("POST")]
        [HttpPost] // AcceptVerbs de kullanabilirdik
        public RedirectToRouteResult Add(string Name, string ProductionYear, string BoxOfficeReturn)
        {
            var entity = new Movie()
            {
                Name = Name,
                ProductionYear = ProductionYear,
                BoxOfficeReturn = Convert.ToDouble(BoxOfficeReturn.Replace(",","."), CultureInfo.InvariantCulture)
            };
            db.Movies.Add(entity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}