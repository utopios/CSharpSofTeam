using CoursAspNet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNet.Controllers
{
    public class PersonController : Controller
    {

        //le service pour récuperer le chemin wwwroot automatiquement
        IWebHostEnvironment _env;

        public PersonController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            //renvoie du html generer par razor
            List<Person> liste = Person.GetPersons();
            //Pour partager les données entre controller et view, on peut utiliser
            //1 -> ViewData
            //ViewData["listePersonnes"] = liste;
            //2 -> ViewBag
            //ViewBag.ListePersonnes = liste;
            //3 -> par Model de vue != Model du MVC

            return View(liste);
        }

        public IActionResult Detail(int id)
        {
            //Logique metier 
            return Ok(new { valId = id });
        }
        public IActionResult Form()
        {
            return View();
            //return View("~/Views/Home/Index.cshtml");
        }

        //public IActionResult SubmitPerson(string firstName, string lastName, IFormFile avatar)
        //{

        //    //Logique metier pour gerer les types files
        //    //Copier l'image et stocker l'url
        //    //Le chemin cible
        //    string salt = Guid.NewGuid().ToString();
        //    string path = Path.Combine(_env.WebRootPath, "images", salt+"-"+avatar.FileName);
        //    //Création d'un flux vers le chemin cible
        //    Stream stream = System.IO.File.Create(path);
        //    avatar.CopyTo(stream);
        //    stream.Close();
        //    //stocker le chemin dans un viewBag, ou dans une base de données
        //    ViewBag.image = "images/" + salt + "-" + avatar.FileName;
        //    Person p = new Person { FirstName = firstName, LastName = lastName };
        //    return View(p);
        //}

        public IActionResult SubmitPerson(string firstName, string lastName, IFormFile[] avatars)
        {

            //Logique metier pour gerer les types files
            //Copier l'image et stocker l'url
            //Le chemin cible
            List<string> chemins = new List<string>();
            foreach(IFormFile avatar in avatars)
            {
                string salt = Guid.NewGuid().ToString();
                string path = Path.Combine(_env.WebRootPath, "images", salt + "-" + avatar.FileName);
                //Création d'un flux vers le chemin cible
                Stream stream = System.IO.File.Create(path);
                avatar.CopyTo(stream);
                stream.Close();
                //stocker le chemin dans un viewBag, ou dans une base de données
                chemins.Add("images/" + salt + "-" + avatar.FileName);
            }
            ViewBag.images = chemins;
            Person p = new Person { FirstName = firstName, LastName = lastName };
            return View(p);
        }
    }
}
