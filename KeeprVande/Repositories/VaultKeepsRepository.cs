using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Repositories;

public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int CreateVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
        INSERT INTO vaultKeeps(creatorId, vaultId, keepId)
        VALUES(@CreatorId, @VaultId, @KeepId);
        SELECT LAST_INSERT_ID()
        ;";

    int vaultKeepId = _db.ExecuteScalar<int>(sql, vaultKeepData);

    return vaultKeepId;
  }

  internal VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    string sql = "SELECT * FROM vaultKeeps WHERE id = @vaultKeepId;";

    VaultKeep vaultKeep = _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultKeepId });

    return vaultKeep;
  }

  internal void RemoveVaultKeep(int vaultKeepId)
  {
    string sql = "DELETE FROM vaultKeeps WHERE id = @vaultKeepId LIMIT 1;";

    _db.Execute(sql, new { vaultKeepId });
  }
}
