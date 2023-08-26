using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Repositories;

public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetProfileById(string profileId)
  {
    string sql = "SELECT * FROM accounts WHERE id = @profileId;";

    Profile profile = _db.QueryFirstOrDefault<Profile>(sql, new { profileId });

    return profile;
  }
}
