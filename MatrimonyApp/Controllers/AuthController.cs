using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrimonyApp.Data;
using MatrimonyApp.DTOs;
using MatrimonyApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;
        public AuthController(IAuthRepository _authRepository)
        {
            this.authRepository = _authRepository;
        }
        [HttpGet("hi")]
      
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //validate request
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if(await authRepository.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("User already exists");
            }
            var userToCreate = new User { Username = userForRegisterDto.Username};

            var createdUser = await authRepository.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}