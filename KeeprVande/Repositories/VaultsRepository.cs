using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int CreateVault(Vault vaultData)
  {
    string sql = @"
        INSERT INTO vaults(name, description, img, isPrivate, creatorId)
        VALUES(@Name, @Description, @Img, @IsPrivate, @CreatorId);
        SELECT LAST_INSERT_ID()
        ;";

    int vaultId = _db.ExecuteScalar<int>(sql, vaultData);

    return vaultId;
  }

  internal Vault GetVaultById(int vaultId)
  {
    string sql = @"
        SELECT 
        vau.*,
        acc.*
        FROM vaults vau
        JOIN accounts acc ON acc.id = vau.creatorId
        WHERE vau.id = @vaultId
        ;";

    Vault vault = _db.Query<Vault, Profile, Vault>(
      sql,
      (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      },
      new { vaultId }
    ).FirstOrDefault();

    return vault;
  }

  internal List<Vault> GetUserVaults(string profileId)
  {
    string sql = @"
        SELECT 
        vau.*,
        acc.*
        FROM vaults vau
        JOIN accounts acc ON acc.id = vau.creatorId
        WHERE vau.creatorId = @profileId
        ;";

    List<Vault> vaults = _db.Query<Vault, Profile, Vault>(
      sql,
      (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      },
      new { profileId }
    ).ToList();

    return vaults;
  }

  internal Vault EditVault(Vault originalVault)
  {
    string sql = @"
        UPDATE vaults 
        SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @isPrivate;
        SELECT 
        vau.*,
        acc.*
        FROM vaults vau
        JOIN accounts acc ON acc.id = vau.creatorId
        WHERE vau.id = @Id
        ;";

    Vault vault = _db.Query<Vault, Profile, Vault>(
      sql,
      (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      },
      originalVault
    ).FirstOrDefault();

    return vault;
  }

  internal void RemoveVault(int vaultId)
  {
    string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";

    _db.Execute(sql, new { vaultId });
  }

}
