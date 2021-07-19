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
  
    internal IEnumerable<Bug> GetBugByProfileId(string id)
    {
      string sql = @"
      SELECT
      bug.*,
      profile.*
      FROM bugs bug
      JOIN bugProfiles profile ON bug.creatorId = profile.id
      WHERE bug.creatorId = @id";
      return _db.Query<Bug, Profile, Bug>(sql, (bug, profile) =>
      {
        bug.Creator = profile;
        return bug;
      }, new { id }, splitOn: "id");
    }

    internal Bug CreateBug(Bug newBug)
    {
      string sql = @"
      INSERT INTO bugs
      (closed, description, title, creatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newBug);
      newBug.Id = id;
      return newBug;
    }
  }
}