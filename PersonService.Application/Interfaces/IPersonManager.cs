//using PersonService.Application.Dtos;
using PersonService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Application.Interfaces
{
    public interface IPersonManager
    {
        Task<string> RowTheDice(RowTheDiceInput input);
        Task<PersonDto> TestPerson();
    }
}
