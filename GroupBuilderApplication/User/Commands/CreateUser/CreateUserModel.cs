using System.ComponentModel.DataAnnotations;

namespace GroupBuilderApplication.Commands.CreateUser
{
    public class CreateUserModel
    {
        [Required]
        public string StudentId { get; set; }

    }
}