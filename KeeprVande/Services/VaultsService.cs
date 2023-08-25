using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Services;

public class VaultsService
{
  private readonly VaultsRepository _vaultsRepository;

  public VaultsService(VaultsRepository vaultsRepository)
  {
    _vaultsRepository = vaultsRepository;
  }

  internal Vault CreateVault(Vault vaultData, string userId)
  {
    int vaultId = _vaultsRepository.CreateVault(vaultData);

    Vault vault = GetVaultById(vaultId, userId);

    return vault;
  }

  internal Vault GetVaultById(int vaultId, string userId)
  {
    Vault vault = _vaultsRepository.GetVaultById(vaultId);

    if (vault == null)
    {
      throw new Exception("INVALID ID");
    }

    if (vault.IsPrivate == true && vault.CreatorId != userId)
    {
      throw new Exception("INVALID ID!");
    }

    return vault;
  }
}
