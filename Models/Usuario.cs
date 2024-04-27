namespace DancellApp.Models
{
    using SQLite;
    using System.Globalization;

    public class Usuario
    {
        private const string Value = " ";

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
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaGestion { get; set; }
        public string Identificacion { get; set; }
        public int EquipoPort { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", Nombre, Apellido);
            }
        }

        public string NameProfile
        {
            get
            {
                int indName = Nombre.IndexOf(Value);
                Nombre = Nombre.Substring(0, indName);
                var indLastName = Apellido.IndexOf(Value);
                Apellido = Apellido.Substring(0, indLastName);
                return string.Format("{0} {1}", Nombre, Apellido);
            }
        }

        public string Zona
        {
            get
            {
                switch (EquipoPort)
                {
                    case 1:
                        return "Cesar - Poblaciones";
                    case 3:
                        return "Guajira";
                    default: return "Cesar";
                }
            }
        }
    }
}
