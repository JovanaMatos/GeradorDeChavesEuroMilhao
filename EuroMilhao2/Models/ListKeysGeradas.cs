using EuroMilhao2.Context;

namespace EuroMilhao2.Models
{
    public class ListKeysGeradas
    {
        private List<KeysGeradas> ListKeysSorteadas = new List<KeysGeradas>();
          
        public void SetListKeysSorteadas(KeysGeradas keys) //para add na lista
        {
            ListKeysSorteadas.Add(keys);

        }
        public List<KeysGeradas> GetListKeysGeradas() //mostrar lista
        {
            List<KeysGeradas> copiaListKeysSorteadas = new List<KeysGeradas>(ListKeysSorteadas);

            return copiaListKeysSorteadas; // enviando copia para evitar caso de modificação
        }

        public void LimparListKeysGeradas() // para limpar lista depois de ser salvo e mostrar
        {
            ListKeysSorteadas.Clear();

        }

       


    }
}
