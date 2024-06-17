using Confluent.Kafka;
using Newtonsoft.Json;
using PersonService.Application.Dtos;
using PersonService.Application.Interfaces;
using PersonService.Application.Interfaces.Mapping;
using PersonService.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Confluent.Kafka.ConfigPropertyNames;

namespace imobiSystem.Application
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonMapper _personMapper;
        private readonly IProducer<Null, string> _producer;

        public PersonManager(IPersonRepository personRepository, IPersonMapper personMapper, IProducer<Null, string> producer)
        {
            _personRepository = personRepository;
            _personMapper = personMapper;
            _producer = producer;
        }

        public async Task<string> RowTheDice(RowTheDiceInput input)
        {

            Random number = new Random();
            var generatedNumber = number.Next(1, 6);

            string output = "O resultado do dado foi "+generatedNumber.ToString();

            if (generatedNumber == input.RowNumber)
                output = output +". Parabéns!!! você acertou!";

            var message = new Message<Null, string>
            {
                Value = output.ToString()
            };

            //cria o tópico no kafka
            await _producer.ProduceAsync("my-topic", message);

            return output;
        }

        public async Task<PersonDto> TestPerson()
        {
            var personDto = new PersonDto { Id = 1, FirstName = "Matheus", LastName = "Aguiar", Identification = "12345678901", Birth = new DateTime() };

            await _producer.ProduceAsync("my-topic", new Message<Null, string>
            {
                Value = JsonConvert.SerializeObject(
                personDto)
            });

            return personDto;
        }
    }
}
