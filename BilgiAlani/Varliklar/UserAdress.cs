using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BilgiAlani.Varliklar
{
    [Table("UserAdresses")]
    public class UserAdress
    {
        [Key]
        public string WindowsKimligi { get; set; }
       
        public string Adress { get; set; }
    }
}
