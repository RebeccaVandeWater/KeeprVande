using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KeeprVande.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth0Provider;
  private readonly KeepsService _keepsService;
  public VaultsController(VaultsService vaultsService, Auth0Provider auth0Provider, KeepsService keepsService)
  {
    _vaultsService = vaultsService;
    _auth0Provider = auth0Provider;
    _keepsService = keepsService;
  }

  [Authorize]
  [HttpPost]

  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

      vaultData.CreatorId = userInfo.Id;

      Vault vault = _vaultsService.CreateVault(vaultData, userInfo?.Id);

      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{vaultId}")]

  public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

      Vault vault = _vaultsService.GetVaultById(vaultId, userInfo?.Id);

      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{vaultId}/keeps")]

  public async Task<ActionResult<List<KeepVaultKeep>>> GetKeepsByVaultId(int vaultId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

      List<KeepVaultKeep> keeps = _keepsService.GetKeepsByVaultId(vaultId, userInfo?.Id);

      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpPut("{vaultId}")]
  public async Task<ActionResult<Vault>> EditVault([FromBody] Vault vaultData, int vaultId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

      Vault vault = _vaultsService.EditVault(vaultData, vaultId, userInfo.Id);

      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpDelete("{vaultId}")]

  public async Task<ActionResult<string>> RemoveVault(int vaultId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

      _vaultsService.RemoveVault(vaultId, userInfo.Id);

      return Ok("Vault successfully removed.");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
