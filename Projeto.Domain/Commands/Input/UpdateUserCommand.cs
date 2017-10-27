using System;

namespace Projeto.Domain.Commands.Input
{
	public class UpdateUserCommand : ICommand
	{
		public Guid UserId { get; set; }
		public double Distance { get; set; }
	}
}