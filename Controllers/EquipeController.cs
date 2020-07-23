using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Projeto_E_PLAYER.Models;


namespace Projeto_E_PLAYER.Controllers
{
    public class EquipeController : Controller
    {
        
        Equipe equipeModel = new Equipe();

        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        public IActionResult Privacy()
        {   
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form, Equipe equipe){
            equipe.IdEquipe = Int32.Parse(form ["IdEquipe"] );

            var file = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                equipe.Imagem   = file.FileName;
            }
            else
            {
                equipe.Imagem   = "padrao.png";
            }
 
        equipe.Nome = form["Nome"];
        equipe.Imagem  = form["Imagem"];

        equipeModel.Create(equipe);

        ViewBag.Equipes = equipeModel.ReadAll();
        return  LocalRedirect("~/equipe");
        }
          
        [Route("[controller]/{id}")]
        public IActionResult Excluir (int id)
        {
          equipeModel.Delete(id);
          return  LocalRedirect("~/equipe");


        }
    }

}
