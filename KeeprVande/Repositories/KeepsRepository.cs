using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int CreateKeep(Keep keepData)
  {
    string sql = @"
        INSERT INTO keeps (name, description, img, views, creatorId)
        VALUES(@Name, @Description, @Img, @Views, @CreatorId);
        SELECT LAST_INSERT_ID()
        ;";

    int keepId = _db.ExecuteScalar<int>(sql, keepData);

    return keepId;
  }

  internal List<Keep> GetAllKeeps()
  {
    string sql = @"
        SELECT
        kp.*,
        acc.*
        FROM keeps kp
        JOIN accounts acc ON acc.id = kp.creatorId
        ;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(
      sql,
      (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }
    ).ToList();

    return keeps;
  }

  internal Keep GetKeepById(int keepId)
  {
    string sql = @"
        SELECT
        kp.*,
        COUNT(vk.id) AS kept,
        acc.*
        FROM keeps kp 
        LEFT JOIN vaultKeeps vk ON vk.keepId = kp.id
        JOIN accounts acc ON acc.id = kp.creatorId
        WHERE kp.id = @keepId
        GROUP BY kp.id
        ;";

    Keep keep = _db.Query<Keep, Profile, Keep>(
      sql,
      (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      },
      new { keepId }
    ).FirstOrDefault();

    return keep;
  }

  internal List<KeepVaultKeep> GetKeepsByVaultId(int vaultId)
  {
    string sql = @"
      SELECT
      vk.*,
      kp.*,
      acc.*
      FROM vaultKeeps vk
      JOIN keeps kp ON kp.id = vk.keepId
      JOIN accounts acc ON acc.id = vk.creatorId
      WHERE vk.vaultId = @vaultId
      ;";

    List<KeepVaultKeep> keeps = _db.Query<VaultKeep, KeepVaultKeep, Profile, KeepVaultKeep>(
      sql,
      (vaultKeep, keep, profile) =>
      {
        keep.VaultKeepId = vaultKeep.Id;
        keep.Creator = profile;
        return keep;
      },
      new { vaultId }
    ).ToList();

    return keeps;
  }

  internal List<Keep> GetUserKeeps(string profileId)
  {
    string sql = @"
        SELECT
        kp.*,
        COUNT(vk.id) AS kept,
        acc.*
        FROM keeps kp 
        LEFT JOIN vaultKeeps vk ON vk.keepId = kp.id
        JOIN accounts acc ON acc.id = kp.creatorId
        WHERE kp.creatorId = @profileId
        GROUP BY kp.id
        ;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(
      sql,
      (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      },
      new { profileId }
    ).ToList();

    return keeps;
  }

  internal Keep EditKeep(Keep originalKeep)
  {
    string sql = @"
        UPDATE keeps 
        SET
        name = @Name,
        description = @Description,
        img = @Img,
        views = @Views
        WHERE id = @Id;
        SELECT
        kp.*,
        COUNT(vk.id) AS kept,
        acc.*
        FROM keeps kp 
        LEFT JOIN vaultKeeps vk ON vk.keepId = kp.id
        JOIN accounts acc ON acc.id = kp.creatorId
        WHERE kp.id = @Id
        GROUP BY kp.id
        ;";

    Keep keep = _db.Query<Keep, Profile, Keep>(
      sql,
      (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      },
      originalKeep).FirstOrDefault();

    return keep;
  }

  internal void RemoveKeep(int keepId)
  {
    string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";

    _db.Execute(sql, new { keepId });
  }

}
