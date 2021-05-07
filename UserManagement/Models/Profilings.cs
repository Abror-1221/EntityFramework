using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_profiling")]
    public class Profilings
    {
        [Key]
        [ForeignKey("Accounts")]
        public string NIK { get; set; }
        public int Education_Id { get; set; }
        [JsonIgnore]
        public virtual Educations Educations { get; set; }
        [JsonIgnore]
        public virtual Accounts Accounts { get; set; }
    }
}
