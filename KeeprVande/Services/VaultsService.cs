using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Services;

public class VaultsService
{
  private readonly VaultsRepository _vaultsRepository;
  private readonly ProfilesService _profilesService;

  public VaultsService(VaultsRepository vaultsRepository, ProfilesService profilesService)
  {
    _vaultsRepository = vaultsRepository;
    _profilesService = profilesService;
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

  internal List<Vault> GetUserVaults(string profileId, string userId)
  {
    _profilesService.GetProfileById(profileId);

    List<Vault> vaultList = _vaultsRepository.GetUserVaults(profileId);

    if (profileId == userId)
    {
      return vaultList;
    }

    List<Vault> vaults = vaultList.FindAll(v => v.IsPrivate == false);

    return vaults;
  }

  // internal List<Vault> GetMyVaults(string userId)
  // {
  //   List<Vault> vaults = _vaultsRepository.GetMyVaults(userId);

  //   return vaults;
  // }

  internal Vault EditVault(Vault vaultData, int vaultId, string userId)
  {
    Vault originalVault = GetVaultById(vaultId, userId);

    if (originalVault.CreatorId != userId)
    {
      throw new Exception("You are not the creator of this vault. You may not edit it.");
    }

    originalVault.Name = vaultData.Name ?? originalVault.Name;
    originalVault.Description = vaultData.Description ?? originalVault.Description;
    originalVault.Img = vaultData.Img ?? originalVault.Img;
    originalVault.IsPrivate = vaultData.IsPrivate ?? originalVault.IsPrivate;

    Vault vault = _vaultsRepository.EditVault(originalVault);

    return vault;
  }

  internal void RemoveVault(int vaultId, string userId)
  {
    Vault vaultToRemove = GetVaultById(vaultId, userId);

    if (vaultToRemove.CreatorId != userId)
    {
      throw new Exception("You are not the creator of this vault. You may not remove it.");
    }

    _vaultsRepository.RemoveVault(vaultId);
  }

}
