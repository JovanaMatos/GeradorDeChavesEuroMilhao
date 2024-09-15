using EuroMilhao2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace EuroMilhao2.Models
{
    [Table("ChavesGeradas2")]
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
        public DateTime DataSorteio { get; set; } = DateTime.Now;

        
    }
}