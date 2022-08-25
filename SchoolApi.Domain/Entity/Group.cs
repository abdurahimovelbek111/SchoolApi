namespace SchoolApi.Domain.Entity
{
    public class Group:BaseEntity
    {        
        /// <summary>
        /// Guruh nomi
        /// </summary>
        public string GroupName { get; set; }
        public Group()
        {
            Students = new HashSet<Student>();            
        }
       public ICollection<Student> Students { get; set; }         
       public ICollection<GroupTeacher> GroupTeachers { get; set; }

      
    }
}
