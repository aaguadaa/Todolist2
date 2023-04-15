using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public User theUser { get; set; }
        public Role theRole { get; set; }

    }
}
