using EuroMilhao2.Models;
using EuroMilhao2.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EuroMilhao2.Controllers
{
    public class KeysGeradasController : Controller
    {

        private readonly IKeysGeradasRepository _keysGeradasRepository;
        private readonly ListKeysGeradas _listDeKeysGeradas;

        public KeysGeradasController(IKeysGeradasRepository keysGeradasRepository, ListKeysGeradas listDeKeysGeradas)
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

            int numeChaves2 = 0;

            int.TryParse(numeChaves, out numeChaves2);  // convertwndo para int


            if (numeChaves2 > 0)// se for maior que zero Gerará a quant solicitada
            {
                while (true)
                {
                    for (int i = 0; i < numeChaves2; i++)
                    {
                        KeysGeradas keysGeradas = new KeysGeradas();

                        keysGeradas.ValidaRepeticao(keysGeradas);//função que verifica todos os quisitos necessários

                        _listDeKeysGeradas.SetListKeysSorteadas(keysGeradas); //add na lista
                    }


                    if (_keysGeradasRepository.SalvarChaves())
                    {
                        break;//se true mostra chves geradas

                    }
                    _listDeKeysGeradas.LimparListKeysGeradas();
                }

            }

            else //se não gerará só uma
            {

                keys.ValidaRepeticao(keys);

                _listDeKeysGeradas.SetListKeysSorteadas(keys);

                if (!_keysGeradasRepository.SalvarChaves())
                {
                    TempData["erro"] = "Essa chave ja existe!";

                    _listDeKeysGeradas.LimparListKeysGeradas();

                    return RedirectToAction("Criar");
                }


            }

            //_keysGeradasRepository.SalvarChaves();// após passar por todas verificações e add na lista, salvo na base de dados


            //ViewBag.mensagem = "";

            return RedirectToAction("Index", "ListKeysGeradas"); //retorna para view que mostra os gerados no momento

        }




    }
}
