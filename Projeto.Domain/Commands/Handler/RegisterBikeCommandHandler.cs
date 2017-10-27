using FluentValidator;
using Projeto.Domain.Commands.Input;
using Projeto.Domain.Commands.Result;
using Projeto.Domain.Repositories;
using Projeto.Domain.ValueObjects;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Commands.Handler
{
	public class RegisterBikeCommandHandler : Notifiable, ICommandHandler<RegisterBikeCommand>
	{
		private readonly IBikeRepository _bikeRepository;

		public RegisterBikeCommandHandler(IBikeRepository bikeRepository) => _bikeRepository = bikeRepository;

		public ICommandResult Handle(RegisterBikeCommand command)
		{
			ICommandResult result = null;

			if (command != null)
			{
				Location location = new Location(command.Latitude, command.Longitude);
				Bike bike = new Bike(location);

				AddNotifications(bike.Notifications);

				if (IsValid())
				{
					_bikeRepository.Add(bike);

					result = new GenericCommandResult(bike.Id, bike.Location.ToString());
				}

				else
					AddNotification("Bike", "Bike is not valid");
			}

			else
				AddNotification("Command", "Command is invalid");

			return result;
		}
	}
}