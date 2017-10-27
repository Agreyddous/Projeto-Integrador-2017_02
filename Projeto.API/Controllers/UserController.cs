using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Commands.Handler;
using Projeto.Domain.Commands.Input;
using Projeto.Domain.Repositories;
using Projeto.Infra.Transactions;
using System;
using System.Threading.Tasks;

namespace Projeto.API.Controllers
{
	public class UserController : BaseController
    {
		private readonly RegisterUserCommandHandler _registerHandler;
		private readonly UpdateUserCommandHandler _updateHandler;

		private readonly IUserRepository _userRepository;

		public UserController(IUow uow, RegisterUserCommandHandler registerHandler, UpdateUserCommandHandler updateHandler, IUserRepository userRepository) : base(uow)
		{
			_registerHandler = registerHandler;
			_updateHandler = updateHandler;
			_userRepository = userRepository;
		}

		[HttpGet]
		[Route("v1/User/{Id}")]
		public async Task<IActionResult> Get(Guid Id) => await Response(_userRepository.Get(Id));

		[HttpPost]
		[Route("v1/User/Add")]
		public async Task<IActionResult> Add([FromBody]RegisterUserCommand command) => await Response(_registerHandler.Handle(command), _registerHandler.Notifications);

		[HttpPut]
		[Route("v1/User/Update")]
		public async Task<IActionResult> Update([FromBody]UpdateUserCommand command) => await Response(_updateHandler.Handle(command), _updateHandler.Notifications);
	}
}