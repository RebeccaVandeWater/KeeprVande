using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeeprVande.Services;

public class ProfilesService
{
  private readonly ProfilesRepository _profilesRepository;

  public ProfilesService(ProfilesRepository profilesRepository)
  {
    _profilesRepository = profilesRepository;
  }

  internal Profile GetProfileById(string profileId)
  {
    Profile profile = _profilesRepository.GetProfileById(profileId);

    if (profile == null)
    {
      throw new Exception("INVALID ID");
    }

    return profile;
  }
}
