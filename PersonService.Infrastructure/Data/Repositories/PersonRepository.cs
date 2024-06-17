using Microsoft.EntityFrameworkCore;
using PersonService.Domain.Entities;
using PersonService.Domain.Interfaces.Repositories;
using PersonService.Infrastructure.Data.Repositories;
using PersonService.Infrastrusture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Infrastructure.Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        private readonly SqlContext sqlContext;

        public PersonRepository(SqlContext sqlContext) : base(sqlContext) 
        {
            this.sqlContext = sqlContext;
        }

        //public List<Person> GetCorretoresByIds(List<int> ids)
        //{
        //    var ret = sqlContext.Corretores
        //        .Where(x => ids.Contains(x.Id)).ToList();
        //    return ret;
        //}
    }
}
