using FluentValidator;
using Projeto.Domain.Commands.Input;
using Projeto.Domain.Commands.Result;
using Projeto.Domain.Repositories;
using Projeto.Domain.ValueObjects;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Commands.Handler
{
	public class RegisterUserCommandHandler : Notifiable, ICommandHandler<RegisterUserCommand>
	{
		private readonly IUserRepository _userRepository;

		public RegisterUserCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

		public ICommandResult Handle(RegisterUserCommand command)
		{
			ICommandResult result = null;

			if (command != null)
			{
				Name name = new Name(command.FirstName, command.LastName);
				User user = new User(name, command.ProfilePic);

				AddNotifications(user.Notifications);

				if (IsValid())
				{
					_userRepository.Add(user);

					result = new GenericCommandResult(user.Id, user.Name.ToString());
				}

				else
					AddNotification("User", "User is not valid");
			}

			else
				AddNotification("Command", "Invalid command");

			return result;
		}
	}
}