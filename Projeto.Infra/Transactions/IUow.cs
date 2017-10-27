namespace Projeto.Infra.Transactions
{
	public interface IUow
	{
		void Commit();
		void RollBack();
	}
}