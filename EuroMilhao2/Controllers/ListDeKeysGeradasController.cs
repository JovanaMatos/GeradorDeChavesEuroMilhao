using EuroMilhao2.Context;
using EuroMilhao2.Models;
using EuroMilhao2.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EuroMilhao2.Controllers
{
    public class ListDeKeysGeradasController : Controller
    {

        private readonly ListDeKeysGeradas _listKeysGeradas;


        private readonly IKeysGeradasRepository _keysGeradasRepository;



        public ListDeKeysGeradasController(ListDeKeysGeradas listKeysGeradas, IKeysGeradasRepository keysGeradasRepository)
        {

            _listKeysGeradas = listKeysGeradas;
            _keysGeradasRepository = keysGeradasRepository;
        }

        public IActionResult Index()
        {

            var result = View(_listKeysGeradas.GetListDeKeysGeradas()); //mostra na view chaves geradas no momento


            _listKeysGeradas.LimparListDeKeysGeradas();// limpa após mostrar

            return result;
        }






    }
}
