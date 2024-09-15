using EuroMilhao2.Models;

namespace EuroMilhao2.Repository.Interfaces
{
    public interface IKeysGeradasRepository
    {
        public void SalvarChaves();
     
       Task<List<KeysGeradas>> MostrarTodasChaves();
    }
}
