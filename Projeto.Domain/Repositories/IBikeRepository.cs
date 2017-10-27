using Projeto.Domain.Entities;
using System;

namespace Projeto.Domain.Repositories
{
	public interface IBikeRepository
	{
		Bike Get(Guid id);
		bool Add(Bike bike);
	}
}