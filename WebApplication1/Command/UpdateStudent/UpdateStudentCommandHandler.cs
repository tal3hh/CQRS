using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Data;
using MediatR;

namespace CQRS.Command.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _context;
        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.Id);
            student.Name = request.Name;
            student.Surname = request.Surname;
            student.Age = request.Age;
            await _context.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
