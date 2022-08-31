using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Command.CreateStudent;
using CQRS.Command.RemoveStudent;
using CQRS.Command.UpdateStudent;
using CQRS.Queries;
using CQRS.Queries.StudentAll;
using CQRS.Queries.StudentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            return Ok(await _mediator.Send(new StudentByIdQuery(id)));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            return Ok(await _mediator.Send(new StudentAllQuery()));
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand create)
        {
            await _mediator.Send(create);

            return Created("",create.Name);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand update)
        {
            await _mediator.Send(update);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveStudent(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }
    }
}
