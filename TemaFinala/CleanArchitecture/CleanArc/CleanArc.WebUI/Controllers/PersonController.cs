using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArc.Application.Commands.PersonCommands;
using CleanArc.Application.Queries.ActivityQueries;
using CleanArc.WebUI.Controllers.Base;
using System.Threading.Tasks;

namespace CleanArc.WebUI.Controllers
{
    #region***Cornel***

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAllPersonQueryResponse>> GetAllPersons()
        {
            return Ok(await Mediator.Send(new GetAllPersonQuery() { }));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetPersonByIdQueryResponse>> GetPersonById([FromQuery]GetPersonByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAllPersonByLastNameQueryResponse>> GetAllPersonByLastName([FromQuery] GetAllPersonByLastNameQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AddPersonCommandResponse>> AddPerson([FromBody]AddPersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EditPersonCommandResponse>> EditPerson([FromBody]EditPersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Unit>> DeletePerson([FromBody]DeletePersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }

    #endregion***Cornel***
}
