﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }

        public Person()
        {
        }
    }
}
