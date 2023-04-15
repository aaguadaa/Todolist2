using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Status { get; set; }
    }
}
