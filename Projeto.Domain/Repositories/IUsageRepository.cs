using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Projeto.Domain.Repositories
{
	public interface IUsageRepository
	{
		Usage Get(Guid usageId);
		List<Usage> GetByUser(Guid userId);
		List<Usage> GetByBike(Guid bikeId);
		bool Add(Usage usage);
		bool Update(Usage usage);
	}
}