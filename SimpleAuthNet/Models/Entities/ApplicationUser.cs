namespace SimpleAuthNet.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public string CustomTag { get; set; }
}