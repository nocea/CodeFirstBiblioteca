using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace BibliotecaDAL
{
    public class Usuario
    {
        [Column("id_usuario")]
        public long Id { get; set; }
        public int dni_usuario { get; set; }
        public string nombre_usuario { get; set; } = null!;
        public string apellidos_usuario { get; set; } = null!;
        public string tlf_usuario { get; set; } = null!;
        public string clave_usuario { get; set; } = null!;
        public bool estaBloqueado_usuario { get; set; }
        public DateTime fch_fin_bloqueo_usuario { get; set; }
        public DateTime fch_alta_usuario { get; set; }
        public DateTime fch_baja_usuario { get; set; }
    }
}