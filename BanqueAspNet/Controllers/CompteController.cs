
using BanqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanqueWeb.Controllers
{
    public class CompteController : Controller
    {
        public IActionResult Index(string message, int? search)
        {
            ViewData["Title"] = "Salut";
            ViewBag.message = message;
            Compte compte = (search != null) ? Compte.GetCompteById((int)search) : null;
            return View(compte);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SubmitCreate(Compte compte)
        {
            string messageError;
            
            if(compte.Client.Save())
            {
                if (compte.Save())
                {
                    return RedirectToAction("Index", new { message = $"le compte a été crée avec le numéro {compte.Id}" });
                }
                else
                {
                    messageError = "Erreur création compte";
                }
            }
            else
            {
                messageError = "Erreur création client";
            }
            ViewBag.messageError = messageError;
            return View("Create", compte);
        }

        public IActionResult Detail(int id)
        {
            Compte compte = Compte.GetCompteById(id);
            if(compte != null)
            {
                compte.Operations = Operation.GetOperationsByCompteId(id);
            }
            return View(compte);
        }

        public IActionResult ActionOperation(int id, string type)
        {
            ViewBag.Id = id;
            ViewBag.Type = type;
            return View();
        }

        public IActionResult SubmitOperation(int id, string type, decimal montant)
        {
            Compte compte = Compte.GetCompteById(id);
            if(compte != null)
            {
                if(type == "depot")
                {
                    Operation o = new Operation(montant);
                    compte.Depot(o);
                }
                else if(type =="retrait")
                {
                    Operation o = new Operation(montant * -1);
                    compte.Retrait(o);
                }
            }
            return RedirectToAction("Detail", new { Id = id });
        }
    }
}
