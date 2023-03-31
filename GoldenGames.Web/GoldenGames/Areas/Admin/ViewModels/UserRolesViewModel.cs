using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GoldenGames.Areas.Admin.ViewModels
{
    public class UserRolesViewModel
    {
        [Key]
        public string? User { get; set; } = string.Empty;
        public string? UserRole { get; set; } = string.Empty;

    }
}
