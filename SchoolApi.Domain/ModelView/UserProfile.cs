namespace SchoolApi.Domain.ModelView
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MainRole { get; set; }
        public List<string> Roles { get; set; }

        public static bool isCreate = true;

        public static UserProfile _user=null;
        public static UserProfile User
        {
            get =>_user ?? new UserProfile()
                {
                    Id=10,
                    Name="Elbek",
                    Surname="Abdurahimov",
                    MainRole="Admin",
                    Roles=new List<string>() { { "Admin" }, { "Manitoring" }, { "User"} }
                };
        }
        private UserProfile()
        { }
        ~UserProfile(){

        }

    }
}
