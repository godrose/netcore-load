﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Api.Mappers;
using Samples.Specifications.Server.Api.Models;
using Samples.Specifications.Server.Domain.Services.Storage;

namespace Samples.Specifications.Server.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserMapper _userMapper;

        public UserController(
            IUserRepository userRepository,
            UserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {

            var users = await _userRepository.GetAll();
            return users.Select(_userMapper.MapToUserDto);
        }
    }
}