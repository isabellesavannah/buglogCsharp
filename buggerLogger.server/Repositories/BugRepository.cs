using System.Collections.Generic;
using System.Data;
using System.Linq;
using buggerLogger.Models;
using Dapper;

namespace buggerLogger.Repositories
{
  public class BugRepository
  {
    private readonly IDbConnection _db;
    public BugRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Bug> GetAll()
    {
        string sql = @"
        SELECT
        b.*,
        prof.*
        FROM bug b
        JOIN profile prof ON b.creatorId = prof.id";
        return _db.Query<Bug, Profile, Bug>(sql, (bug, Profile) =>
        {
            bug.Creator = Profile;
            return bug;
        }, splitOn: "id");
    }
  

    // //      1 SELECT 
    // //      4 wlist.*,
    // //      6 prof.*
    // //      2 FROM wishlists wlist
    // //      5 JOIN profiles prof ON wlist.creatorId = prof.id
    // //      3 WHERE wlist.id = @id";
    // internal Vault GetById(int id)
    // {
    //   string sql = @" 
    //   SELECT 
    //   v.*,
    //   prof.*
    //   FROM vaults v
    //   JOIN profiles prof ON v.creatorId = prof.id
    //   WHERE v.id = @id";
    //   return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    //   {
    //     vault.Creator = profile;
    //     return vault;
    //   }, new { id }, splitOn: "id").FirstOrDefault();
    // }

    // internal Vault Create(Vault newVault)
    // {
    //   string sql = @"
    //   INSERT INTO vaults 
    //   (name, description, isPrivate, creatorId) 
    //   VALUES 
    //   (@Name, @Description, @IsPrivate, @creatorId);
    //   SELECT LAST_INSERT_ID();";
    //   int id = _db.ExecuteScalar<int>(sql, newVault);
    //   newVault.Id = id;
    //   return newVault;
    // }

    // internal Vault Edit(Vault updated)
    // {
    //   string sql = @"
    //     UPDATE vaults
    //     SET
    //      Name = @Name,
    //      description = @description
    //     WHERE id = @Id;";
    //   _db.Execute(sql, updated);
    //   return updated;
    // }

    // internal void Delete(int id)
    // {
    //   string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
    //   _db.Execute(sql, new { id });
    // }

    // internal IEnumerable<Vault> GetVaultByProfileId(string id)
    // {
    //   string sql = @"
    //   SELECT
    //   vault.*,
    //   profile.*
    //   FROM vaults vault
    //   JOIN profiles profile ON vault.creatorId = profile.id
    //   WHERE vault.creatorId = @id AND isPrivate = 0;";
    //   return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    //   {
    //     vault.Creator = profile;
    //     return vault;
    //   }, new { id }, splitOn: "id");
    // }

    // internal IEnumerable<Vault> GetByOwnerId(string id)
    // {
    //   string sql = @"
    //   SELECT 
    //   vault.*,
    //   profile.*
    //   FROM vaults vault
    //   JOIN profiles profile ON vault.creatorId = profile.id
    //   WHERE vault.creatorId = @id;";
    //   return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    //   {
    //     vault.Creator = profile;
    //     return vault;
    //   }, new { id }, splitOn: "id");
    // }
  }
}