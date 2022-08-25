using SchoolApi.Domain.Enum;

namespace SchoolApi.Domain.ModelView
{
    public class Response
    {
        public string? Message { get; set; }
        public Status Status { get; set; }
        public string? Url { get; set; }
        public string? Label { get; set; }
    }
}
