using FluentValidator;
using Projeto.Domain.Commands.Input;
using Projeto.Domain.Commands.Result;
using Projeto.Domain.Repositories;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Commands.Handler
{
	public class UpdateUserCommandHandler : Notifiable, ICommandHandler<UpdateUserCommand>
	{
		private readonly IUserRepository _userRepository;

		public UpdateUserCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

		public ICommandResult Handle(UpdateUserCommand command)
		{
			ICommandResult result = null;

			if (command != null)
			{
				User user = _userRepository.Get(command.UserId);

				if (user != null)
				{
					user.UpdateDistance(command.Distance);
					_userRepository.UpdateDistance(user);

					result = new GenericCommandResult(user.Id, user.Odometer.ToString());
				}

				else
					AddNotification("User Id", "User id not found");
			}

			else
				AddNotification("Command", "Invalid command");

			return result;
		}
	}
}