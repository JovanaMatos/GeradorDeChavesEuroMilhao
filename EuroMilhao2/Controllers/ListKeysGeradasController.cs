using EuroMilhao2.Context;
using EuroMilhao2.Models;
using EuroMilhao2.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EuroMilhao2.Controllers
{
    public class ListKeysGeradasController : Controller
    {

        private readonly ListKeysGeradas _listKeysGeradas;


        private readonly IKeysGeradasRepository _keysGeradasRepository;



        public ListKeysGeradasController(ListKeysGeradas listKeysGeradas, IKeysGeradasRepository keysGeradasRepository)
        {

            _listKeysGeradas = listKeysGeradas;
            _keysGeradasRepository = keysGeradasRepository;
        }

        public IActionResult Index()
        {

            var result = View(_listKeysGeradas.GetListKeysGeradas()); //mostra na view chaves geradas no momento


            _listKeysGeradas.LimparListKeysGeradas();// limpa após mostrar

            return result;
        }






    }
}
