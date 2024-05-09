using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancellApp.Models
{
    public class ComitionModel
    {
        public int IdLiquidacionPrepago { get; set; }
        public decimal ValorComision { get; set; }
        public string Vigente { get; set; }
        public decimal ValorComisionRestante { get; set; }
        public string IdPos { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
    }
}
