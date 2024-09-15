using EuroMilhao2.Models;
using EuroMilhao2.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace EuroMilhao2.Controllers
{
    public class KeysGeradasController : Controller
    {

        private readonly IKeysGeradasRepository _keysGeradasRepository;
        private readonly ListDeKeysGeradas _listDeKeysGeradas;

        public KeysGeradasController(IKeysGeradasRepository keysGeradasRepository, ListDeKeysGeradas listDeKeysGeradas)
        {
            _keysGeradasRepository = keysGeradasRepository;
            _listDeKeysGeradas = listDeKeysGeradas;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _keysGeradasRepository.MostrarTodasChaves());// mostra lista da base de dados de chaves
        }



        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar([Bind("KeysId,KeyNumber1,KeyNumber2,KeyNumber3,KeyNumber4,KeyNumber5,KeyStar1,KeyStar2")] KeysGeradas keys)
        {


            string numeChaves = Request.Form["numeChaves"];//pegando pelo requst pois ja havia criado as classes 

            int numeChaves2 = int.Parse(numeChaves);// convertando para int


            if (numeChaves2 > 0)// se for maior que zero Gerará a quant solicitada
            {
                for (int i = 0; i < numeChaves2; i++)
                {
                    KeysGeradas keysGeradas = new KeysGeradas();

                    ValidaRepeticao(keysGeradas);//função que verifica todos os quisitos necessários

                    _listDeKeysGeradas.SetListKeysSorteadas(keysGeradas); //add na lista

                }
            }
            else //se não gerará só uma
            {

                ValidaRepeticao(keys);

                _listDeKeysGeradas.SetListKeysSorteadas(keys);

            }

            _keysGeradasRepository.SalvarChaves();// após passar por todas verificações e add na lista, salvo na base de dados

            return RedirectToAction("Index", "ListDeKeysGeradas"); //retorna para view que mostra os gerados no momento

        }

        public void ValidaRepeticao(KeysGeradas keys)
        {

            var SetNumbers = new HashSet<int>();//criando hashSet apenas para não gerar numeros repetidos
            var SetStars = new HashSet<int>();



            var numbersArray = new int[] { keys.KeyNumber1.GetValueOrDefault(), keys.KeyNumber2.GetValueOrDefault(),//criei um array antes pois o hashset esta gerando 0 para primeira posição por ter nullos
                keys.KeyNumber3.GetValueOrDefault(), keys.KeyNumber4.GetValueOrDefault(), keys.KeyNumber5.GetValueOrDefault() };

            var starsArray = new int[] { keys.KeyStar1.GetValueOrDefault(), keys.KeyStar2.GetValueOrDefault() };


            foreach (var number in numbersArray)// verifica se tem 0 se não add
            {
                if (number != 0)
                {
                    SetNumbers.Add(number);
                }
            }

            foreach (var star in starsArray)
            {
                if (star != 0)
                {
                    SetStars.Add(star);
                }
            }



            while (SetNumbers.Count < 5) // enquanto não criar 5 numeros não saira do loop e não add repetidos
            {

                SetNumbers.Add(KeyRandomNumber());
            }
            while (SetStars.Count < 2)
            {
                SetStars.Add(KeyRandomStar());
            }

            var numbersList = SetNumbers.ToList(); //converte para lista para adicionar nas classes
            var starsList = SetStars.ToList();


            keys.KeyNumber1 = numbersList[0]; // add valores as propiedades
            keys.KeyNumber2 = numbersList[1];
            keys.KeyNumber3 = numbersList[2];
            keys.KeyNumber4 = numbersList[3];
            keys.KeyNumber5 = numbersList[4];

            keys.KeyStar1 = starsList[0];
            keys.KeyStar2 = starsList[1];


            keys.DataSorteio = DateTime.Now;




        }



        public int KeyRandomNumber() // para gerar numero aleatorios de 1-50
        {
            Random random = new Random();
            return random.Next(1, 51);
        }
        public int KeyRandomStar()
        {
            Random random = new Random(); // para gerar numero aleatorios de 1-12
            return random.Next(1, 13);
        }





    }
}
