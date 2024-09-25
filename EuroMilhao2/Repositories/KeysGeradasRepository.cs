using EuroMilhao2.Context;
using EuroMilhao2.Models;
using EuroMilhao2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;

namespace EuroMilhao2.Repositories
{
    //Para manipular os dados da base de dados
    public class KeysGeradasRepository : IKeysGeradasRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly ListKeysGeradas _listKeysGeradas;



        public KeysGeradasRepository(AppDbContext appDbContext, ListKeysGeradas listKeysGeradas)
        {
            _appDbContext = appDbContext;
            _listKeysGeradas = listKeysGeradas;


        }

        public async Task<List<KeysGeradas>> MostrarTodasChaves()//função para mostrar todos os gerados
        {
            return await _appDbContext.KeysGeradas.ToListAsync();

        }

        public bool SalvarChaves()// para savar chaves
        {

            foreach (var keys in _listKeysGeradas.GetListKeysGeradas())//verifica se chave existe 
            {

                var verificaSeExisteBd = _appDbContext.KeysGeradas.Any(X => X.KeyNumber1.Equals(keys.KeyNumber1.Value)//verificar se existe chave igual
                                                        && X.KeyNumber2.Equals(keys.KeyNumber2.Value)
                                                        && X.KeyNumber3.Equals(keys.KeyNumber3.Value)
                                                        && X.KeyNumber4.Equals(keys.KeyNumber4.Value)
                                                        && X.KeyNumber5.Equals(keys.KeyNumber5.Value)
                                                        && X.KeyStar1.Equals(keys.KeyStar1.Value)
                                                        && X.KeyStar2.Equals(keys.KeyStar2.Value));
                if (verificaSeExisteBd)
                {
                    return false;
                }
            }



            foreach (var keys in _listKeysGeradas.GetListKeysGeradas())
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
                    Date = Convert.ToDateTime(keys.Date)

                };


                _appDbContext.KeysGeradas.Add(keyGeradas);
            }

            _appDbContext.SaveChanges();

            return true;

        }


        public List<Estatistica> NumerosMaisGerados()
        {

            var bd = _appDbContext.KeysGeradas.ToList(); // passando a bd para uma variavel tipo lista


            var numbers = from key in bd
                          from numb in new[] { key.KeyNumber1, key.KeyNumber2, key.KeyNumber3, key.KeyNumber4, key.KeyNumber5 }
                          select numb; //fazendo um select apenas dos numeros



            var agrupados = from numb in numbers // agrupando numeros iguais e depois contando a quantidade
                            group numb by numb into agrupa
                            select new
                            {
                                numeros = agrupa.Key,
                                quantidade = agrupa.Count()
                            };



            var resultado = from item in agrupados
                            orderby item.quantidade descending //ordenando a quantidade em ordem descrecente para depois pegar os que mais sairam
                            select item;


            var estatisticaNumb = resultado.Take(5); // pegrando apenas os 5 primeiros que mais saiu


            List<Estatistica> listEstatistica = new List<Estatistica>(); // criando uma lista do tipo estatistica

            int totalBd = bd.Count();

            foreach (var item in estatisticaNumb)
            {
                Estatistica estatistica = new Estatistica // criando um obj do tipo estatistica e passando os dados do agrupamento
                {
                    Number = Convert.ToInt32(item.numeros), // convertendo para int 
                    NumeroFrequencia = item.quantidade,
                    Total = totalBd,//quantidade de chaves no total
                    Porcentagem = (((double)item.quantidade / totalBd) * 100).ToString("0.00", CultureInfo.InvariantCulture) //calculando valor de quantos porcento

                };

                listEstatistica.Add(estatistica);

            }



            return listEstatistica;

        }

        public List<Estatistica> NumerosMenosGerados()
        {
            var bd = _appDbContext.KeysGeradas.ToList();
            var listnumbs = bd.SelectMany(x => new[] { x.KeyNumber1, x.KeyNumber2, x.KeyNumber3, x.KeyNumber4, x.KeyNumber5 })
                .GroupBy(numGroup => numGroup).Select(ng => new { valor = ng.Key, quant = ng.Count() }).OrderBy(x => x.quant).Take(5).ToList();

            List<Estatistica> listMenosGerados = new List<Estatistica>();
            int totalBd = bd.Count();

            foreach (var item in listnumbs)
            {
                Estatistica estatistica = new Estatistica // criando um obj do tipo estatistica e passando os dados do agrupamento
                {
                    Number = Convert.ToInt32(item.valor), // convertendo para int 
                    NumeroFrequencia = item.quant,
                    Total = totalBd,//quantidade de chaves no total
                    Porcentagem = (((double)item.quant / totalBd) * 100).ToString("0.00", CultureInfo.InvariantCulture) //calculando valor de quantos porcento

                };

                listMenosGerados.Add(estatistica);

            }


            return listMenosGerados;
        }
}





}

















