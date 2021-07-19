using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using buggerLogger.Models;
using buggerLogger.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace buggerLogger.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfileController : ControllerBase
  {
    private readonly ProfileService _service;
    private readonly BugService _bserv;
    public ProfileController(ProfileService service, BugService bserv)
    {
      _service = service;
      _bserv = bserv;
      
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile profile = _service.GetProfileById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/bug")]
    public ActionResult<IEnumerable<Bug>> GetBugByProfileId(string id)
    {
      try
      {
        return Ok(_bserv.GetBugByProfileId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    } 

//     [HttpGet("{id}/keeps")]
//     public ActionResult<IEnumerable<VaultKeepViewModel>> GetKeepByProfileId(string id)
//     {
//       try
//       {
//         return Ok(_kserv.GetByProfileId(id));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e.Message);
//       }
//     }

//   }
}
}
