using Projeto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Domain.Entities;
using Projeto.Infra.Context;
using System.Data.Entity;

namespace Projeto.Infra.Repositories
{
	public class UsageRepository : IUsageRepository
	{
		private readonly ProjetoContext _context;

		public UsageRepository(ProjetoContext context) => _context = context;

		public bool Add(Usage usage)
		{
			if (usage.IsValid())
				_context.Usages.Add(usage);

			return usage.IsValid();
		}

		public Usage Get(Guid usageId) => _context.Usages.FirstOrDefault(x => x.Id == usageId);
		public List<Usage> GetByBike(Guid bikeId) => _context.Usages.Where(x => x.Bike.Id == bikeId).ToList();
		public List<Usage> GetByUser(Guid userId) => _context.Usages.Where(x => x.User.Id == userId).ToList();
		public bool Update(Usage usage)
		{
			if (usage.IsValid())
				_context.Entry(usage).State = EntityState.Modified;

			return usage.IsValid();
		}
	}
}