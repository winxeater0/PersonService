using PersonService.Application.Dtos;
using PersonService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Application.Interfaces.Mapping
{
    public interface IPersonMapper
    {
        Person ToEntity(PersonDto personDto);
        PersonDto ToDto(Person person);
    }
}
