using MedicalSolutions.Business.Facade.HIS;
using MedicalSolutions.Business.Facade.HIS.Dictionary;
using MedicalSolutions.Business.Facade.HIS.Systems;
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
        private readonly static TokenFacade _tokenFacade;
        private AppSetting _appSetting;

        public UserController(IOptionsMonitor<AppSetting> optionsMonitor)
        {
            if (_appSetting == null)
                _appSetting = optionsMonitor.CurrentValue;
        }

        static UserController()
        {
            _userFacade = new UserFacade();
            _tokenFacade = new TokenFacade();
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
                var token = GenarateToken(user);

                return token;
            }

            return null;
        }

        [HttpPost("RefreshToken")]
        public async Task<ResultDto<TokenDto>> RefreshToken(TokenDto token)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);
            var tokenValidationParameters = new TokenValidationParameters()
            {
                // Tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,

                // Ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                // Set thời gian
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false // không kiểm tra hết hạn
            };

            try
            {
                // Check valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(token.AcceptToken, tokenValidationParameters, out var validatedToken);

                // Kiểm tra thuật toán
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);

                    if (!result)
                    {
                        return new ResultDto<TokenDto>()
                        {
                            Message = "Invalid token",
                            Status = null,
                        };
                    }
                }

                // Check acceptToken đã hoạt động chưa
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(f => f.Type == JwtRegisteredClaimNames.Exp).Value);
                var expireDate = ConvertToDate(utcExpireDate);
                if (expireDate >= DateTime.UtcNow)
                {
                    return new ResultDto<TokenDto>()
                    {
                        Message = "Access token has not yet expired"
                    };
                }

                // Kiểm tra refreshToken có trong database ko?
                var storedToken = await _tokenFacade.Get(token.RefreshToken); // RefreshToken = RefreshToken trong database
                if (storedToken == null)
                {
                    return new ResultDto<TokenDto>()
                    {
                        Message = "Refresh token does not exist"
                    };
                }

                // Kiểm tra refreshToken đã sử dụng hoặc thu hồi chưa
                if (storedToken.IsUsed)
                {
                    return new ResultDto<TokenDto>()
                    {
                        Message = "Refresh token has been used"
                    };
                }
                if (storedToken.IsRevoked)
                {
                    return new ResultDto<TokenDto>()
                    {
                        Message = "Refresh token has been revoked"
                    };
                }

                // Kiểm tra Id có trong RefreshToken 
                var jti = tokenInVerification.Claims.FirstOrDefault(f => f.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.Jti != jti)
                {
                    return new ResultDto<TokenDto>()
                    {
                        Message = "Token doesn't match"
                    };
                }

                // Update token
                storedToken.IsRevoked = true;
                storedToken.IsUsed = true;
                await _tokenFacade.Update(storedToken);

                // Tạo token mới
                var userById = ((await _userFacade.GetById(storedToken.UserId)).Result) as UserDto;
                var tokenResult = GenarateToken(userById);

                return new ResultDto<TokenDto>()
                {
                    Status = 1,
                    Result = tokenResult
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<TokenDto>()
                {
                    Message = ex.Message,
                    Status = null,
                };
            }
        }

        private DateTime ConvertToDate(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }

        private TokenDto GenarateToken(UserDto user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Code", user.UserName),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    // Role
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var acceptToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenarateRefreshToken();

            // Lưu token
            var tokenDto = new TokenDto()
            {
                Id = Guid.NewGuid(),
                Jti = token.Id,
                UserId = user.Id.GetValueOrDefault(),
                AcceptToken = acceptToken,
                RefreshToken = refreshToken,
                IsUsed = false,
                IsRevoked = false,
                IssueAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddSeconds(20),
            };

            var isInsertToken = _tokenFacade.Insert(tokenDto);

            return new TokenDto()
            {
                AcceptToken = acceptToken,
                RefreshToken = refreshToken,
            };
        }

        private string GenarateRefreshToken()
        {
            var key = Guid.NewGuid().ToString().Replace("-", String.Empty);
            var keyToBytes = Encoding.UTF8.GetBytes(key);

            return Convert.ToBase64String(keyToBytes);
        }
    }
}
