namespace TALLER_17_11.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sanciones
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime? FECHA_ACTUAL { get; set; }
        public string SANCION { get; set; }
        public string OBSERVACION { get; set; }
        public Decimal VALOR { get; set; }
        public string CONDUCTORFK { get; set; }
        [ForeignKey("CONDUCTORFK")]
        public virtual Conductor Conductor { get; set; }
    }
}
