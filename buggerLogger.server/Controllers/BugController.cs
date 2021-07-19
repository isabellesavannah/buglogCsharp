using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using buggerLogger.Models;
using buggerLogger.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace buggerLogger.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BugController : ControllerBase
  {
    private readonly BugService _service;
    public BugController(BugService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Bug>> Get()
    {
        try
        {
            return Ok(_service.GetAll());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpPost]
    public async Task<ActionResult<Bug>> CreateBug([FromBody] Bug newBug)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newBug.CreatorId = userInfo.Id;
        newBug.Creator = userInfo;
        return Ok(_service.CreateBug(newBug));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}