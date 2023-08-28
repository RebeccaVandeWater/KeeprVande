import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async getProfileVaults(profileId) {
    const res = await api.get(`api/profiles/${profileId}/vaults`)

    logger.log('[GOT PROFILE VAULTS]', res.data)

    AppState.vaults = res.data.map(pojo => new Vault(pojo))
  }

}

export const vaultsService = new VaultsService