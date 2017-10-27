namespace Projeto.Domain.Commands.Input
{
	public class RegisterBikeCommand : ICommand
	{
		public string Latitude { get; set; }
		public string Longitude { get; set; }
	}
}