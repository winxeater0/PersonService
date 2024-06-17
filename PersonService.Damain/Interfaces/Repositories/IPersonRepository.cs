using PersonService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
    }
}
