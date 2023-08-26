using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepsRepository;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsService vaultsService)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
    _vaultsService = vaultsService;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId, vaultKeepData.CreatorId);

    if (vault.CreatorId != vaultKeepData.CreatorId)
    {
      throw new Exception("You are not the creator of this vault. You may not save a keep in it.");
    }

    int vaultKeepId = _vaultKeepsRepository.CreateVaultKeep(vaultKeepData);

    VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);

    return vaultKeep;
  }

  internal VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    VaultKeep vaultKeep = _vaultKeepsRepository.GetVaultKeepById(vaultKeepId);

    if (vaultKeep == null)
    {
      throw new Exception("INVALID ID");
    }

    return vaultKeep;
  }

  internal void RemoveVaultKeep(int vaultKeepId, string userId)
  {
    VaultKeep vaultKeepToRemove = GetVaultKeepById(vaultKeepId);

    if (vaultKeepToRemove.CreatorId != userId)
    {
      throw new Exception("You are not the creator of this vault keep. You may not remove it.");
    }

    _vaultKeepsRepository.RemoveVaultKeep(vaultKeepId);
  }
}
