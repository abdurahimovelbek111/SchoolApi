namespace SchoolApi.Application.DTOs
{
    public class GroupDto 
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<GroupTeacherDto> GrupTeacherDtos { get; set; }
    }
}
