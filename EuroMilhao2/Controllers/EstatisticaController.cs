﻿using EuroMilhao2.Models;
using EuroMilhao2.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EuroMilhao2.Controllers
{
    public class EstatisticaController : Controller
    {

        private readonly IKeysGeradasRepository _keysGeradasRepository;
        

        public EstatisticaController(IKeysGeradasRepository keysGeradasRepository)
        {
            _keysGeradasRepository = keysGeradasRepository;
            
        }




        public IActionResult Index()
        {


            Estatistica estatistica = new Estatistica();
            estatistica.SetNumerosMaisGerados(_keysGeradasRepository.NumerosMaisGerados());   
            estatistica.SetNumerosMenosGerados(_keysGeradasRepository.NumerosMenosGerados());   
            

           
            return View(estatistica);
        }




    }
}
