using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_university")]
    public class Universities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("University_Id")]
        public virtual ICollection<Educations> Educations { get; set; }
    }
}
