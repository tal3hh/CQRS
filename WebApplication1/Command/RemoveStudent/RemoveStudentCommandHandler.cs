using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Data;
using MediatR;

namespace CQRS.Command.RemoveStudent
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _context;
        public RemoveStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.Id);
            _context.Remove(student);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
