using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KeeprVande.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth0Provider;
  public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth0Provider)
  {
    _vaultKeepsService = vaultKeepsService;
    _auth0Provider = auth0Provider;
  }

  [Authorize]
  [HttpPost]

  public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

      vaultKeepData.CreatorId = userInfo.Id;

      VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(vaultKeepData);

      return Ok(vaultKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpDelete("vaultKeepId")]

  public async Task<ActionResult<string>> RemoveVaultKeep(int vaultKeepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

      _vaultKeepsService.RemoveVaultKeep(vaultKeepId, userInfo.Id);

      return Ok("VaultKeep successfully removed.");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
