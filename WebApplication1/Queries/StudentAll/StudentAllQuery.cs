using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CQRS.Queries.StudentAll
{
    public class StudentAllQuery : IRequest<IEnumerable<StudentAllQueryResult>>
    {
    }
}
