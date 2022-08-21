using MedicalSolutions.Business.Facade.HIS;
using MedicalSolutions.Business.Facade.HIS.Dictionary;
using MedicalSolutions.BusinessModels.Common;
using MedicalSolutions.BusinessModels.HIS.Dictionary;
using MedicalSolutions.BusinessModels.HIS.Systems;
using MedicalSolutions.WebApi.Common;
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
        private AppSetting _appSetting;

        public UserController(IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _appSetting = optionsMonitor.CurrentValue;
        }

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

        // GET api/<UserController>/5
        [HttpGet("GetById")]
        public async Task<ResultDto<UserDto>> GetByUser(UserDto user)
        {
            return await _userFacade.GetByUser(user);
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
        public async Task<ResultDto<bool>> Delete(Guid id)
        {
            return await _userFacade.Delete(id);
        }

        [HttpPost("Login")]
        public async Task<TokenDto> Login(UserDto user)
        {
            if (user == null)
                return null;

            var result = await GetByUser(user);
            if (result != null)
            {
                return new TokenDto()
                {
                    RefreshToken = await GenarateToken(user)
                };
            }
            else
            {
                return null;
            }
        }

        private async Task<string> GenarateToken(UserDto user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Code", user.Code),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),

                    // Role

                    new Claim("TokenId", Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return await Task.FromResult(jwtTokenHandler.WriteToken(token));
        }
    }
}
