using FluentValidator;
using Projeto.Domain.Commands.Input;
using Projeto.Domain.Repositories;
using Projeto.Domain.Commands.Result;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Commands.Handler
{
	public class UpdateUsageCommandHandler : Notifiable, ICommandHandler<UpdateUsageCommand>
	{
		private readonly IUsageRepository _usageRepository;

		public UpdateUsageCommandHandler(IUsageRepository usageRepository) => _usageRepository = usageRepository;

		public ICommandResult Handle(UpdateUsageCommand command)
		{
			ICommandResult result = null;

			if (command != null)
			{
				Usage usage = _usageRepository.Get(command.UsageId);

				if (usage != null)
				{
					if (usage.Active)
					{
						if (command.Distance > 0)
							usage.AddDistance(command.Distance);

						else
							AddNotification("Distance", "Value needs to be greater than 0");

						if (!command.Active)
							usage.End();

						if (IsValid())
						{
							_usageRepository.Update(usage);

							result = new GenericCommandResult(usage.Id, usage.Distance.ToString());
						}
					}

					else
						AddNotification("Usage", "Usage is not Active");
				}

				else
					AddNotification("Usage Id", "Usage id not found");
			}

			else
				AddNotification("Command", "Invalid command");

			return result;
		}
	}
}