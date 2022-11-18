namespace TALLER_17_11.DTOs
{
    using System;

    public class ConductorDTO
    {
        public int ID { get; set; }
        public string IDENTIFICACION { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public DateTime? FECHANACIMIENTO { get; set; }
        public bool? ESTADO { get; set; }
    }
}
