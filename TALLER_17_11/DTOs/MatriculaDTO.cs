namespace TALLER_17_11.DTOs
{
    using System;

    public class MatriculaDTO
    {
        public int ID { get; set; }
        public string NUMERO { get; set; }
        public DateTime? FECHAEXPEDICION { get; set; }
        public DateTime? VALIDAHASTA { get; set; }
        public bool? ESTADO { get; set; }
    }
}
