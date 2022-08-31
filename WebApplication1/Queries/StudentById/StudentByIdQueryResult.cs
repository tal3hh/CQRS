using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Queries.StudentById
{
    public class StudentByIdQueryResult
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Surname { get; set; }
    }
}
