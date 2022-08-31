using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Data;
using MediatR;

namespace CQRS.Queries.StudentById
{
    public class StudentByIdQueryHandler : IRequestHandler<StudentByIdQuery, StudentByIdQueryResult>
    {
        private readonly StudentContext _context;

        public StudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }


        public async Task<StudentByIdQueryResult> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Set<Student>().FindAsync(request.Id);

            return new StudentByIdQueryResult()
            {
                Name = student.Name,
                Age = student.Age,
                Surname = student.Surname
            };
        }
    }
}
