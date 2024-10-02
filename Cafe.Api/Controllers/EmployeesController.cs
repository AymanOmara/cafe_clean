using Cafe.Api.Utils;
using Cafe.Application.Services.Employees.Commands.CreateEmployee;
using Cafe.Application.Services.Employees.Commands.DeleteEmployee;
using Cafe.Application.Services.Employees.Commands.UpdateEmployee;
using Cafe.Application.Services.Employees.Employees.Query;
using Cafe.Domain.Features.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _meadiator;

        public EmployeesController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }
        [HttpGet("Employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _meadiator.Send( new EmployeesQuery());
            return result.ToResult();
        }
        [HttpPost("add-employee")]
        public async Task<IActionResult> CreateEmployee([FromBody]CreateEmployeeCommand command)
        {
            var result = await _meadiator.Send(command);
            return result.ToResult();
        }
        [HttpDelete("delete-employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id) {
            var result = await _meadiator.Send(new DeleteEmployeeCommand(id));
            return result.ToResult();
        }
        [HttpPut("update-employee")]
        public async Task<IActionResult> UpdateEmployee([FromBody]EmployeeEntity employee)
        {
            var result = await _meadiator.Send(new UpdateEmployeeCommand(employee));
            return result.ToResult();
        }
    }
}