namespace TALLER_17_11.DTOs
{
    using System;

    public class SancionesDTO
    {
        public int ID { get; set; }
        public DateTime? FECHA_ACTUAL { get; set; }
        public string SANCION { get; set; }
        public string OBSERVACION { get; set; }
        public Decimal VALOR { get; set; }
    }
}
