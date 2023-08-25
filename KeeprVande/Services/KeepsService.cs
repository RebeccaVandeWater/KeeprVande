using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Services;

public class KeepsService
{
  private readonly KeepsRepository _keepsRepository;

  public KeepsService(KeepsRepository keepsRepository)
  {
    _keepsRepository = keepsRepository;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    int keepId = _keepsRepository.CreateKeep(keepData);

    Keep keep = GetKeepById(keepId);

    return keep;
  }
  internal List<Keep> GetAllKeeps()
  {
    List<Keep> keeps = _keepsRepository.GetAllKeeps();

    return keeps;
  }
  internal Keep GetKeepById(int keepId)
  {
    Keep keep = _keepsRepository.GetKeepById(keepId);

    if (keep == null)
    {
      throw new Exception("INVALID ID");
    }

    return keep;
  }

  internal Keep EditKeep(Keep keepData, string userId, int keepId)
  {
    Keep originalKeep = GetKeepById(keepId);

    if (originalKeep.CreatorId != userId)
    {
      throw new Exception("You are not the creator of this keep. You may not edit it.");
    }

    originalKeep.Name = keepData.Name ?? originalKeep.Name;
    originalKeep.Description = keepData.Description ?? originalKeep.Description;
    originalKeep.Img = keepData.Img ?? originalKeep.Img;

    Keep keep = _keepsRepository.EditKeep(originalKeep);

    return keep;
  }

  internal void RemoveKeep(int keepId, string userId)
  {
    Keep keepToRemove = GetKeepById(keepId);

    if (keepToRemove.CreatorId != userId)
    {
      throw new Exception("You are not the creator of this keep. You may not remove it.");
    }

    _keepsRepository.RemoveKeep(keepId);
  }
}
