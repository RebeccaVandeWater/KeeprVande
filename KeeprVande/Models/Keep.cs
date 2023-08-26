using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Models;

public class Keep : RepoItem<int>
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; }
  public int Kept { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}

public class KeepVaultKeep : Keep
{
  public int VaultKeepId { get; set; }
}
