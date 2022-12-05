namespace Newsletter.BackendApi.Dtos
{
    public class RegisterDto
    {
        public string NameLastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password{ get; set; }
    }
}
