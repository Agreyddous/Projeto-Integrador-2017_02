using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Commands.Handler;
using Projeto.Domain.Commands.Input;
using Projeto.Domain.Repositories;
using Projeto.Infra.Transactions;
using System;
using System.Threading.Tasks;

namespace Projeto.API.Controllers
{
	public class BikeController : BaseController
    {
		private readonly RegisterBikeCommandHandler _registerHandler;

		private readonly IBikeRepository _bikeRepository;

		public BikeController(IUow uow, RegisterBikeCommandHandler registerHandler, IBikeRepository bikeRepository) : base(uow)
		{
			_registerHandler = registerHandler;
			_bikeRepository = bikeRepository;
		}

		[HttpGet]
		[Route("v1/Bike/{Id}")]
		public async Task<IActionResult> Get(Guid Id) => await Response(_bikeRepository.Get(Id));

		[HttpPost]
		[Route("v1/Bike/Add")]
		public async Task<IActionResult> Add([FromBody]RegisterBikeCommand command) => await Response(_registerHandler.Handle(command), _registerHandler.Notifications);
	}
}