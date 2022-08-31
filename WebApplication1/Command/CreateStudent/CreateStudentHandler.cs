using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Data;
using MediatR;

namespace CQRS.Command.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _context;

        public CreateStudentHandler(StudentContext context)
        {
            _context = context;
        }



        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            await _context.Students.AddAsync(new Student { Name = request.Name, Age = request.Age, Surname = request.Surname });
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
