using System;

namespace Projeto.Domain.Commands.Input
{
	public class RegisterUsageCommand : ICommand
	{
		public Guid UserId { get; set; }
		public Guid BikeId { get; set; }
	}
}