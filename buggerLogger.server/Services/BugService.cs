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

    internal IEnumerable<Bug> GetAll()
    {
        return _repo.GetAll();
    }

    // internal Keep GetById(int id)
    // {
    //   var data = _repo.GetById(id);
    //   if (data == null)
    //   {
    //     throw new Exception("Invalid Id");
    //   }
    //   return data;
    // }

    // internal Keep Create(Keep newKeep)
    // {
    //   return _repo.Create(newKeep);
    // }

    // internal Keep Edit(Keep updated)
    // {
    //   var original = GetById(updated.Id);
    //   if (original.CreatorId != updated.CreatorId)
    //   {
    //     throw new Exception("Invalid Edit Permissions");
    //   }
    //   updated.Description = updated.Description != null ? updated.Description : original.Description;
    //   updated.Name = updated.Name != null ? updated.Name : original.Name;
    //   return _repo.Edit(updated);
    // }

    // internal IEnumerable<Keep> GetByProfileId(string id)
    // {
    //   IEnumerable<Keep> keeps = _repo.GetKeepByProfileId(id);
    //   return _repo.GetKeepByProfileId(id);
    // }

    // internal IEnumerable<Keep> GetByAccountId(string id)
    // {
    //   return _repo.GetKeepByProfileId(id);
    // }


    // internal string Delete(int id, string userId)
    // {
    //   var original = GetById(id);
    //   if (original.CreatorId != userId)
    //   {
    //     throw new Exception("Invalid Delete Permissions");
    //   }
    //   _repo.Delete(id);
    //   return "delorted";
    // }

    // internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    // {
    //   // we need to pull in the vaultservice and try to get the vault by its id first, this will handle isPrivate
    //   IEnumerable<VaultKeepViewModel> keeps = _repo.GetKeepsByVaultId(id);
    //   return keeps;
    // }

    // internal IEnumerable<Keep> GetKeepsByAccountId(string id)
    // {
    //   return _repo.GetByOwnerId(id);
    // }
  }
}