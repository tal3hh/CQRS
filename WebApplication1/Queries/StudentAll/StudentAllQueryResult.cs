﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Queries.StudentAll
{
    public class StudentAllQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Surname { get; set; }
    }
}
