namespace Projeto.Domain.Managers
{
	public static class MoneyManager
	{
		public static double GetValue(double distance) => distance * Runtime.Tax;
	}
}