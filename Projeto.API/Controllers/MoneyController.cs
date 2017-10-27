using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Managers;
using Projeto.Infra.Transactions;
using System.Threading.Tasks;

namespace Projeto.API.Controllers
{
	public class MoneyController : BaseController
    {
		public MoneyController(IUow uow) : base(uow) { }


		[HttpGet]
		[Route("v1/Money/Distance:{Distance}")]
		public async Task<IActionResult> Get(double Distance) => await Response(MoneyManager.GetValue(Distance));
	}
}