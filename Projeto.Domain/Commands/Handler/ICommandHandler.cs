using Projeto.Domain.Commands.Input;
using Projeto.Domain.Commands.Result;

namespace Projeto.Domain.Commands.Handler
{
	public interface ICommandHandler<T> where T : ICommand
	{
		ICommandResult Handle(T command);
	}
}