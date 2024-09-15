using EuroMilhao2.Context;
using EuroMilhao2.Models;
using EuroMilhao2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;

namespace EuroMilhao2.Repositories
{
    //Para manipular os dados da base de dados
    public class KeysGeradasRepository : IKeysGeradasRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly ListDeKeysGeradas listKeysGeradas;

        public KeysGeradasRepository(AppDbContext appDbContext, ListDeKeysGeradas listKeysGeradas)
        {
            _appDbContext = appDbContext;
            this.listKeysGeradas = listKeysGeradas;
        }

        public async Task<List<KeysGeradas>> MostrarTodasChaves()//função para mostrar todos os gerados
        {
            return await _appDbContext.KeysGeradas.ToListAsync();
        }

        public void SalvarChaves()// para savar chaves
        {
            foreach (var keys in listKeysGeradas.GetListDeKeysGeradas())
            {
                var keyGeradas = new KeysGeradas()
                {
                    KeyNumber1 = Convert.ToInt32(keys.KeyNumber1.Value),
                    KeyNumber2 = Convert.ToInt32(keys.KeyNumber2.Value),
                    KeyNumber3 = Convert.ToInt32(keys.KeyNumber3.Value),
                    KeyNumber4 = Convert.ToInt32(keys.KeyNumber4.Value),
                    KeyNumber5 = Convert.ToInt32(keys.KeyNumber5.Value),
                    KeyStar1 = Convert.ToInt32(keys.KeyStar1.Value),
                    KeyStar2 = Convert.ToInt32(keys.KeyStar2.Value),
                    DataSorteio = keys.DataSorteio


                };

                _appDbContext.KeysGeradas.Add(keyGeradas);

            }

            _appDbContext.SaveChanges();
        }


        
    }
}

           