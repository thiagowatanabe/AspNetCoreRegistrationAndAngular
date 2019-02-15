using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Column(TypeName="nvarchar(50)")]
        public string FullName { get; set; }
    }
}