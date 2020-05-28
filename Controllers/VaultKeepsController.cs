using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;

        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }

        [Authorize]
        [HttpPost]
        public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                newVaultKeep.UserId = user.Value;
                if (user == null)
                {
                    throw new Exception("Login!!");
                }
                return Ok(_vks.Create(newVaultKeep));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // [Authorize]
        // [HttpDelete("{id}")]
        // public ActionResult<string> Delete(int id)
        // {
        //     try
        //     {
        //         Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        //         string userId = user.Value;
        //         return Ok(_vks.Delete(id, userId));
        //     }
        //     catch (System.Exception err)
        //     {
        //         return BadRequest(err.Message);
        //     }
        // }
    }
}