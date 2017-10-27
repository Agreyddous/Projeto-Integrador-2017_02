namespace Projeto.Domain.Commands.Input
{
	public class RegisterUserCommand : ICommand
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ProfilePic { get; set; }
	}
}