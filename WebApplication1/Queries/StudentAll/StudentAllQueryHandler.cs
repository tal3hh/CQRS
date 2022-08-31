using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Queries.StudentAll
{
    public class StudentAllQueryHandler : IRequestHandler<StudentAllQuery, IEnumerable<StudentAllQueryResult>>
    {
        private readonly StudentContext _context;
        public StudentAllQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentAllQueryResult>> Handle(StudentAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Students.Select(x => new StudentAllQueryResult { Id = x.Id, Name = x.Name, Age = x.Age, Surname = x.Surname }).AsNoTracking().ToListAsync();

            return result;
        }
    }
}
