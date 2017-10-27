using System;

namespace Projeto.Domain.Commands.Input
{
	public class UpdateUsageCommand : ICommand
	{
		public Guid UsageId { get; set; }
		public double Distance { get; set; }
		public bool Active { get; set; }
	}
}