using EuroMilhao2.Repository.Interfaces;

namespace EuroMilhao2.Models
{
    public class Estatistica
    {

        public int NumeroFrequencia { get; set; }
        public int Number { get; set; }
        public string Porcentagem { get; set; }
        public int Total { get; set; }

        public List<Estatistica> NumbMais = new List<Estatistica>();
        public List<Estatistica> NumbMenos = new List<Estatistica>();
       
        public Estatistica(){}

       
        public List<Estatistica> SetNumerosMaisGerados(List<Estatistica> list)
        {
            NumbMais.AddRange(list);


            return NumbMais;


        }
        public List<Estatistica> SetNumerosMenosGerados(List<Estatistica> list)
        {
            NumbMenos.AddRange(list);
            return NumbMenos;


        } 
        public List<Estatistica> GetNumerosMaisGerados()
        {
            
            return NumbMais;


        }
        public List<Estatistica> GetNumerosMenosGerados()
        {
            
            return NumbMenos;


        }


    }
}
