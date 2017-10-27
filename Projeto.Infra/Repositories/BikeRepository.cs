using Projeto.Domain.Repositories;
using System;
using System.Linq;
using Projeto.Domain.Entities;
using Projeto.Infra.Context;

namespace Projeto.Infra.Repositories
{
	public class BikeRepository : IBikeRepository
	{
		private readonly ProjetoContext _context;

		public BikeRepository(ProjetoContext context) => _context = context;

		public bool Add(Bike bike)
		{
			if (bike.IsValid())
				_context.Bikes.Add(bike);

			return bike.IsValid();
		}

		public Bike Get(Guid id) => _context.Bikes.FirstOrDefault(x => x.Id == id);
	}
}