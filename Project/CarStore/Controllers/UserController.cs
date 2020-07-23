using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.API.Extensions;
using CarStore.API.Helpers;
using CarStore.API.Resource;
using CarStore.Domain.Models;
using CarStore.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CarStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                Name = user.Name,
                Token = tokenString
            });
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult>Register([FromBody]SaveUserResource model)
        {
            // map model to entity
            var user = _mapper.Map<SaveUserResource, User>(model);

            // create user
            var result = await _userService.Register(user, model.Password);
             
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(result.User);

            return Ok(userResource);
        }

        [HttpGet]
        [Route("/api/Users")]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();

            var resource = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

            return resource;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Negative parameter exception");
            }

            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Add Header
            var eTag = HashFactory.GetHash(user.LastModified.ToString());
            HttpContext.Response.Headers.Add(EtagHeader, eTag);

            var resource = _mapper.Map<User, UserResource>(user);

            return Ok(resource);
        }


        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var user = _mapper.Map<SaveUserResource, User>(resource);

            var result = await _userService.SaveAsync(user);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(result.User);

            return Ok(userResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            // ETag is required
            if (!HttpContext.Request.Headers.ContainsKey(MatchHeader))
            {
                return new StatusCodeResult(412);
            }
            var ETag = HttpContext.Request.Headers[MatchHeader];

            var user = _mapper.Map<SaveUserResource, User>(resource);

            var result = await _userService.UpdateAsync(id, user, ETag);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(result.User);

            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(result.User);

            return Ok(userResource);

        }
    }
}