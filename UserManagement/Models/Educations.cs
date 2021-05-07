using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_education")]
    public class Educations
    {      
        public int Id { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        
        [ForeignKey("Education_Id")]
        public virtual ICollection<Profilings> Profilings { get; set; }
        public int University_Id { get; set; }
        [JsonIgnore]
        public virtual Universities Universities { get; set; }

    }
}
