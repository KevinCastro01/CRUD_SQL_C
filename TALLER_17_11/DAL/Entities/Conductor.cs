namespace TALLER_17_11.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Conductor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key]
        public string IDENTIFICACION { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public DateTime? FECHANACIMIENTO { get; set; }
        public bool? ESTADO { get; set; }
        public string MATRICULAFK { get; set; }
        [ForeignKey("MATRICULAFK")]
        public virtual Matricula Matriculas { get; set; }
    }
}
