using EuroMilhao2.Models;

namespace EuroMilhao2.Repository.Interfaces
{
    public interface IKeysGeradasRepository
    {
        public List<Estatistica> NumerosMaisGerados();
        public List<Estatistica> NumerosMenosGerados();

        public  bool SalvarChaves();
     
       Task<List<KeysGeradas>> MostrarTodasChaves();
    }
}
