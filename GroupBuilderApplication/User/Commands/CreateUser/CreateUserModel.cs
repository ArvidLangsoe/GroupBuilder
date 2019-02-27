using System.ComponentModel.DataAnnotations;

namespace GroupBuilderApplication.Commands.CreateUser
{
    public class CreateUserModel
    {
        //Maybe change this to more general information so that each group can have different values.
        public string StudentId { get; set; }

        [Required]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}