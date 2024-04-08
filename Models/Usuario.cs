﻿namespace DancellApp.Models
{
    using SQLite;
    public class Usuario
    {
        [PrimaryKey]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CodRol { get; set; }
        public bool Activo { get; set; }
        public bool Estado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DesRol { get; set; }
        public string Especialista { get; set; }
        public string Gerencial { get; set; }
        public DateTime FechaGestion { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.Nombre, this.Apellido);
            }
        }
    }
}
