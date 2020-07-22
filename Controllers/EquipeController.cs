using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_E_PLAYER.Models;

namespace Projeto_E_PLAYER.Controllers
{
    public class EquipeController : Controller
    {
        
        Equipe equipeModel = new Equipe();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {   
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IformCollection form){
        equipe.IdEquipe = Int32.Parse(form ["IdEquipe"] );
        equipe.Nome = form["Nome"];
        equipe.Imagem  = form["Imagem"];

        equipeModel.Create(equipe);

        ViewBag.Equipes = equipeModels.ReadAll();
        return return LocalRedirect("~/equipe");
        }
    }


}
