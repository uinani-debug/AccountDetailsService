using AutoMapper;
using AccountLibrary.API.Models;
using AccountLibrary.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountLibrary.API.Controllers
{
    [ApiController]
  
    public class AccountController : ControllerBase
    {
        private readonly IAccountLibraryRepository _AccountLibraryRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountLibraryRepository AccountLibraryRepository,
            IMapper mapper)
        {
            _AccountLibraryRepository = AccountLibraryRepository ??
                throw new ArgumentNullException(nameof(AccountLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

     

        [Route("api/v1/getAccountDetails")]
        [HttpGet]
        public ActionResult<AccountDetails> GetAccountDetails(string AccountNumber)
        {
            
            var accpuntsFromRepo = _AccountLibraryRepository.GetAccountDetailsByID(AccountNumber);

            if (accpuntsFromRepo == null)
            {
                return NotFound();
            }

            return Ok((_mapper.Map<Entities.Account, AccountDetails>(accpuntsFromRepo)));
        }
    
    }
}