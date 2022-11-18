namespace TALLER_17_11.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Matricula
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key]
        public string NUMERO { get; set; }
        public DateTime? FECHAEXPEDICION { get; set; }
        public DateTime? VALIDAHASTA { get; set; }
        public bool? ESTADO { get; set; }
       
    }
}
