using EuroMilhao2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace EuroMilhao2.Models
{
    [Table("Keys")]
    public class KeysGeradas
    {
        [Key]
        public int KeysId { get; set; }

        //[Range(1, 50, ErrorMessage = "O numero deve estar de 01 - 50")]
        public int? KeyNumber1 { get; set; }

        //[Range(1, 50, ErrorMessage = "O numero deve estar de 01  50")]
        public int? KeyNumber2 { get; set; }

        //[Range(1, 50, ErrorMessage = "O numero deve estar de 01 - 50")]
        public int? KeyNumber3 { get; set; }

        //[Range(1, 50, ErrorMessage = "O numero deve estar de 01 - 50")]
        public int? KeyNumber4 { get; set; }

        //[Range(1, 50, ErrorMessage = "O numero deve estar de 01 - 50")]
        public int? KeyNumber5 { get; set; }

        // [Range(1, 12, ErrorMessage = "O numero deve estar de 01 - 12")]
        public int? KeyStar1 { get; set; }

        //[Range(1, 12, ErrorMessage = "O numero deve estar de 01 - 12")]
        public int? KeyStar2 { get; set; }


        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;




        public void ValidaRepeticao(KeysGeradas keys)
        {

            var SetNumbers = new HashSet<int>();//criando hashSet apenas para não gerar numeros repetidos
            var SetStars = new HashSet<int>();



            var numbersArray = new int[] { keys.KeyNumber1.GetValueOrDefault(), keys.KeyNumber2.GetValueOrDefault(),//criei um array antes pois o hashset esta gerando 0 para primeira posição por ter nullos
                keys.KeyNumber3.GetValueOrDefault(), keys.KeyNumber4.GetValueOrDefault(), keys.KeyNumber5.GetValueOrDefault() };

            var starsArray = new int[] { keys.KeyStar1.GetValueOrDefault(), keys.KeyStar2.GetValueOrDefault() };


            foreach (var number in numbersArray)// verifica se tem 0 se não add
            {
                if (number != 0)
                {
                    SetNumbers.Add(number);
                }
            }

            foreach (var star in starsArray)
            {
                if (star != 0)
                {
                    SetStars.Add(star);
                }
            }



            while (SetNumbers.Count < 5) // enquanto não criar 5 numeros não saira do loop e não add repetidos
            {

                SetNumbers.Add(KeyRandomNumber());
            }
            while (SetStars.Count < 2)
            {
                SetStars.Add(KeyRandomStar());
            }

            var numbersList = SetNumbers.ToList(); //converte para lista para adicionar nas classes
            var starsList = SetStars.ToList();

            numbersList.Sort();
            starsList.Sort();

            keys.KeyNumber1 = numbersList[0]; // add valores as propiedades
            keys.KeyNumber2 = numbersList[1];
            keys.KeyNumber3 = numbersList[2];
            keys.KeyNumber4 = numbersList[3];
            keys.KeyNumber5 = numbersList[4];

            keys.KeyStar1 = starsList[0];
            keys.KeyStar2 = starsList[1];


            keys.Date = DateTime.Now;

           

        }



        public int KeyRandomNumber() // para gerar numero aleatorios de 1-50
        {
            Random random = new Random();
            return random.Next(1, 51);
        }
        public int KeyRandomStar()
        {
            Random random = new Random(); // para gerar numero aleatorios de 1-12
            return random.Next(1, 13);
        }






    }
}