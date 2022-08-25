using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApi.Domain.Entity
{
    public class GroupTeacher
    {
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]

        public Group Group { get; set; }

        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        
        public Teacher Teacher { get; set; }
    }
}
