using System;
using System.Collections.Generic;
using System.Linq;
using buggerLogger.Models;
using buggerLogger.Repositories;
using Microsoft.AspNetCore.Http;

namespace buggerLogger.Services
{
  public class BugService
  {
    private readonly BugRepository _repo;

    public BugService(BugRepository repo)
    {
      _repo = repo;
    }

    // ----------------------------------------------------------- NOTE Get all bugs
    internal IEnumerable<Bug> GetAll()
    {
        return _repo.GetAll();
    }

    // ----------------------------------------------------------- NOTE Get bugs by profile id
    internal IEnumerable<Bug> GetBugByProfileId(string id)
    {
      return _repo.GetBugByProfileId(id);
    }

    // ----------------------------------------------------------- NOTE Create bug
    internal Bug CreateBug(Bug newBug)
    {
      return _repo.CreateBug(newBug);
    }
  }
}