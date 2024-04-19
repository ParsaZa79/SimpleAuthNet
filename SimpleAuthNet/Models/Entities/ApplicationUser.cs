using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SimpleAuthNet.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public DateTime BirthDate { get; set; }
}