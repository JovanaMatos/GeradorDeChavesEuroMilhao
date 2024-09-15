using EuroMilhao2.Context;
using EuroMilhao2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EuroMilhao2.Controllers
{
    public class ListDeKeysGeradasController : Controller
    {

        private readonly ListDeKeysGeradas _listKeysGeradas;

        public ListDeKeysGeradasController(ListDeKeysGeradas listKeysGeradas)
        {

            _listKeysGeradas = listKeysGeradas;
        }

        public IActionResult Index()
        {

            var result = View(_listKeysGeradas.GetListDeKeysGeradas()); //mostra na view chaves geradas no momento


            _listKeysGeradas.LimparListDeKeysGeradas();// limpa após mostrar

            return result;
        }



    }
}
