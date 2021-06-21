using CohesionIB.ApiEngineer.CodeChallenge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionIB.ApiEngineer.CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationCodeController : ControllerBase
    {
        private static bool _acceptedTerms = false;
        private IInvitationCodeService _invitationCodeService;

        public InvitationCodeController(IInvitationCodeService invitationCodeService)
        {
            _invitationCodeService = invitationCodeService;
        }

        [HttpGet]
        [Route("acceptTerms")]
        public IActionResult AcceptTerms()
        {
            _acceptedTerms = true;
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!_acceptedTerms)
                return Unauthorized();

            _acceptedTerms = false;

            if (!_invitationCodeService.HasCode)
                return NoContent();

            return Ok(new { _invitationCodeService.Code });
        }

        /// <summary>
        /// Use an invitation code to assign a device id to a user
        /// </summary>
        /// <param name="code">A invitation code that was returned</param>
        /// <param name="deviceId">The device id to associate with the user.</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(int code, long deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
