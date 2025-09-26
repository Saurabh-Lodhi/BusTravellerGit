namespace BusTraveller.Web.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}
