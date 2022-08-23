namespace SchoolApi.Application.DTOs.Student
{
    public class StudentUpdate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddilName { get; set; }
        public DateTime Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
