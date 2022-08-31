using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CQRS.Queries.StudentById
{
    public class StudentByIdQuery : IRequest<StudentByIdQueryResult>
    {
        public int Id { get; set; }

        public StudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
