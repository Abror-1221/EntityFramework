using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_roleaccount")]
    public class RoleAccounts
    {
        public string AccountsNIK { get; set; }
        [JsonIgnore]
        public virtual Accounts Accounts { get; set; }
        public int RolesId { get; set; }
        [JsonIgnore]
        public virtual Roles Roles { get; set; }
    }
}
