using System.ComponentModel.DataAnnotations;

namespace GroupBuilderApplication.Commands.CreateUser
{
    public class CreateUserModel
    {
        public string StudentId { get; set; }

        [Required]
        public string Email { get; set; }

        public string Name { get; set; }

    }
}