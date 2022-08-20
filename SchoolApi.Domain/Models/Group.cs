using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Models
{
    public class Group:BaseEntity
    {        
        public string GroupName { get; set; }
        public Group()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
