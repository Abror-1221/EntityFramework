using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_account")]
    public class Accounts
    {
        [Key]
        [ForeignKey("Persons")]
        public string NIK { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual Persons Persons { get; set; }
        public virtual Profilings Profilings { get; set; }
        public virtual ICollection<RoleAccounts> RoleAccounts { get; set; }
    }
}
