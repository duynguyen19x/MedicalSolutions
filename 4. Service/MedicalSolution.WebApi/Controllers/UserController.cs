using MedicalSolutions.Business.Facade.HIS;
using MedicalSolutions.BusinessModels.Common;
using MedicalSolutions.BusinessModels.HIS.Dictionary;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalSolutions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly static UserFacade _userFacade;

        static UserController()
        {
            _userFacade = new UserFacade();
        }

        // GET: api/<UserController>
        [HttpGet("GetList")]
        public async Task<ResultDto<List<UserDto>>> GetList()
        {
            return await _userFacade.GetList();
        }

        // GET api/<UserController>/5
        [HttpGet("GetById")]
        public async Task<ResultDto<UserDto>> GetById(Guid id)
        {
            return await _userFacade.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost("Inserṭ")]
        public async Task<ResultDto<UserDto>> Inserṭ([FromBody] UserDto value)
        {
            return await _userFacade.Inserṭ(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("Update")]
        public async Task<ResultDto<UserDto>> Update([FromBody] UserDto value)
        {
            return await _userFacade.Update(value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("Delete")]
        public async Task<ResultDto<Guid>> Delete(Guid id)
        {
            return await _userFacade.Delete(id);
        }
    }
}
