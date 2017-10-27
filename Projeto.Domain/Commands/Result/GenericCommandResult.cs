using System;

namespace Projeto.Domain.Commands.Result
{
	public class GenericCommandResult : ICommandResult
	{
		public GenericCommandResult() { }

		public GenericCommandResult(Guid id, string name)
		{
			Id = id;
			Name = name;
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}