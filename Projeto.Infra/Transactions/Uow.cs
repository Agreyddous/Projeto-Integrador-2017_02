using Projeto.Infra.Context;

namespace Projeto.Infra.Transactions
{
	public class Uow : IUow
	{
		private readonly ProjetoContext _context;

		public Uow(ProjetoContext context) => _context = context;

		public void Commit()
		{
			_context.SaveChanges();
		}

		public void RollBack() { }
	}
}