using System.ComponentModel.DataAnnotations;

namespace Gym.API.V1.Aggregates.Users.Models
{
    public class UserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Does Not Match Password With ConfirmPassword.Please Try Again.")]
        public string ConfirmPassword { get; set; }
    }
}
