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

    // [HttpGet("{id}")]  // NOTE '{}' signifies a var parameter
    // public ActionResult<Keep> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_service.GetById(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }


    // [HttpPost]
    // [Authorize]
    // // NOTE ANYTIME you need to use Async/Await you will return a Task
    // public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    // {
    //   try
    //   {
    //     // NOTE HttpContext == 'req'
    //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //     newKeep.CreatorId = userInfo.Id;
    //     newKeep.Creator = userInfo;
    //     return Ok(_service.Create(newKeep));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    // [HttpPut("{id}")]
    // [Authorize]
    // public async Task<ActionResult<Keep>> Edit([FromBody] Keep updated, int id)
    // {
    //   try
    //   {
    //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //     updated.CreatorId = userInfo.Id;
    //     updated.Creator = userInfo;
    //     updated.Id = id;
    //     return Ok(_service.Edit(updated));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    // [HttpDelete("{id}")]
    // [Authorize]
    // public async Task<ActionResult<Keep>> Delete(int id)
    // {
    //   try
    //   {
    //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //     return Ok(_service.Delete(id, userInfo.Id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

  }
}