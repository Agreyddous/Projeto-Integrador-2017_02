using FluentValidator;
using Projeto.Domain.Commands.Input;
using Projeto.Domain.Commands.Result;
using Projeto.Domain.Repositories;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Commands.Handler
{
	public class RegisterUsageCommandHandler : Notifiable, ICommandHandler<RegisterUsageCommand>
	{
		private readonly IUsageRepository _usageRepository;
		private readonly IUserRepository _userRepository;
		private readonly IBikeRepository _bikeRepository;

		public RegisterUsageCommandHandler(IUsageRepository usageRepository, IUserRepository userRepository, IBikeRepository bikeRepository)
		{
			_usageRepository = usageRepository;
			_userRepository = userRepository;
			_bikeRepository = bikeRepository;
		}

		public ICommandResult Handle(RegisterUsageCommand command)
		{
			ICommandResult result = null;

			if (command != null)
			{
				User user = _userRepository.Get(command.UserId);
				Bike bike = _bikeRepository.Get(command.BikeId);

				if (user == null)
					AddNotification("User Id", "User id not found");

				if (bike == null)
					AddNotification("Bike Id", "Bike id not found");

				if(IsValid())
				{
					Usage usage = new Usage(user, bike);

					AddNotifications(usage.Notifications);

					if (IsValid())
					{
						_usageRepository.Add(usage);

						result = new GenericCommandResult(usage.Id, usage.StartDate.ToString());
					}

					else
						AddNotification("Usage", "Usage is not valid");
				}
			}

			else
				AddNotification("Command", "Invalid command");

			return result;
		}
	}
}