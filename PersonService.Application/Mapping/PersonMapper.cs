
using PersonService.Application.Dtos;
using PersonService.Application.Interfaces.Mapping;
using PersonService.Domain.Entities;
using System;

namespace imobiSystem.Application.Mapping
{
    public class PersonMapper : IPersonMapper
    {
        public PersonDto ToDto(Person person)
        {
            return new PersonDto
            {
                Id = person.Id,
                Identification = person.Identification,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birth = person.Birth
            };
        }

        public Person ToEntity(PersonDto personDto)
        {
            return new Person
            {
                Id = personDto.Id,
                Identification = personDto.Identification,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Birth = personDto.Birth
            };
        }
    }
}
