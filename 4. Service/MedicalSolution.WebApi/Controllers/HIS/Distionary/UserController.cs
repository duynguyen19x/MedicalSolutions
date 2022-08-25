using MedicalSolutions.Business.Facade.HIS;
using MedicalSolutions.Business.Facade.HIS.Dictionary;
using MedicalSolutions.Business.Facade.HIS.Systems;
using MedicalSolutions.BusinessModels.Common;
using MedicalSolutions.BusinessModels.HIS.Dictionary;
using MedicalSolutions.BusinessModels.HIS.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalSolutions.WebApi.Controllers.HIS.Dictionary
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

        // HttpPost api/<UserController>/5
        [HttpPost("GetById")]
        public async Task<ResultDto<UserDto>> GetByUser(UserDto user)
        {
            return await _userFacade.GetByUser(user);
        }

        // POST api/<UserController>
        [HttpPost("Inserṭ")]
        [Authorize]
        public async Task<ResultDto<UserDto>> Inserṭ([FromBody] UserDto value)
        {
            return await _userFacade.Inserṭ(value);
        }

        [Authorize]
        [HttpGet("XXX̣")]
        public object XXX̣()
        {
            return new { A = "A", B = "B" };
        }

        // PUT api/<UserController>/5
        [HttpPut("Update")]
        public async Task<ResultDto<UserDto>> Update([FromBody] UserDto value)
        {
            return await _userFacade.Update(value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("Delete")]
        public async Task<ResultDto<bool>> Delete(Guid id)
        {
            return await _userFacade.Delete(id);
        }
    }
}
