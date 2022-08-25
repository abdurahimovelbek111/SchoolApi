using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApi.Domain.Entity
{
    public class Student: BaseEntity
    {
        /// <summary>
        /// Ismi
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Familyasi
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Sharifi
        /// </summary>
        public string MiddilName { get; set; }
        /// <summary>
        /// Tug'ilgan yil.oy.kun
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Pasport seria
        /// </summary>
        public string PassportSeria { get; set; }
        /// <summary>
        /// Passport nomeri
        /// </summary>
        public string PassportNumber { get; set; }
        /// <summary>
        /// Telfon raqami
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Manzili
        /// </summary>
        public string Address { get; set; }        
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }    
    }
}
