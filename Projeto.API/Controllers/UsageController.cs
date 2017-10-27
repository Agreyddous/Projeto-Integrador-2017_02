using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Commands.Handler;
using Projeto.Domain.Commands.Input;
using Projeto.Domain.Repositories;
using Projeto.Infra.Transactions;
using System;
using System.Threading.Tasks;

namespace Projeto.API.Controllers
{
	public class UsageController : BaseController
    {
		private readonly RegisterUsageCommandHandler _registerHandler;
		private readonly UpdateUsageCommandHandler _updateHandler;

		private readonly IUsageRepository _usageRepository;

		public UsageController(IUow uow, RegisterUsageCommandHandler registerHandler, UpdateUsageCommandHandler updateHandler, IUsageRepository usageRepository) : base(uow)
		{
			_registerHandler = registerHandler;
			_updateHandler = updateHandler;
			_usageRepository = usageRepository;
		}

		[HttpGet]
		[Route("v1/Usage/{Id}")]
		public async Task<IActionResult> Get(Guid Id) => await Response(_usageRepository.Get(Id));

		[HttpGet]
		[Route("v1/Usage/GetByUser:{Id}")]
		public async Task<IActionResult> GetByUser(Guid Id) => await Response(_usageRepository.GetByUser(Id));

		[HttpGet]
		[Route("v1/Usage/GetByBike:{Id}")]
		public async Task<IActionResult> GetByBike(Guid Id) => await Response(_usageRepository.GetByBike(Id));

		[HttpPost]
		[Route("v1/Usage/Add")]
		public async Task<IActionResult> Add([FromBody]RegisterUsageCommand command) => await Response(_registerHandler.Handle(command), _registerHandler.Notifications);

		[HttpPut]
		[Route("v1/Usage/Update")]
		public async Task<IActionResult> Update([FromBody]UpdateUsageCommand command) => await Response(_updateHandler.Handle(command), _updateHandler.Notifications);
	}
}