using EuroMilhao2.Models;

namespace EuroMilhao2.Repository.Interfaces
{
    public interface IKeysGeradasRepository
    {
        public List<Estatistica> Estatistica();

        public  bool SalvarChaves();
     
       Task<List<KeysGeradas>> MostrarTodasChaves();
    }
}
