using System;

namespace Projeto.Domain.Entities
{
	public class Usage : Entity
	{
		protected Usage() { }

		public Usage(User user, Bike bike)
		{
			User = user;
			Bike = bike;

			StartDate = DateTime.Now;
			EndDate = DateTime.Now;
			Active = true;
		}

		public virtual User User { get; private set; }
		public virtual Bike Bike { get; private set; }
		public DateTime StartDate { get; private set; }
		public DateTime EndDate { get; private set; }
		public double Distance { get; private set; }
		public bool Active { get; private set; }

		public void End()
		{
			Active = false;
			EndDate = DateTime.Now;
		}

		public void AddDistance(double distance) => Distance += distance;
	}
}