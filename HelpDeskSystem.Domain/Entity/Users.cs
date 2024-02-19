using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskSystem.Domain.Enum;

namespace HelpDeskSystem.Domain.Entity
{
    public class Users
    {
       
         public  Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public Role Role { get; set; }

    }
}
