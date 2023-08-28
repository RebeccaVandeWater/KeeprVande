import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async getProfileVaults(profileId) {
    const res = await api.get(`api/profiles/${profileId}/vaults`)

    logger.log('[GOT PROFILE VAULTS]', res.data)

    AppState.vaults = res.data.map(pojo => new Vault(pojo))
  }

  async setActive(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)

    logger.log('[GOT VAULT BY ID]', res.data)

    AppState.activeVault = new Vault(res.data)
  }

  async getVaultKeeps(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`);

    logger.log('[GOT VAULT KEEPS]', res.data)

    AppState.keeps = res.data.map(pojo => new Keep(pojo))
  }

  clearVault() {
    AppState.activeVault = null;
    AppState.keeps = [];
  }

}

export const vaultsService = new VaultsService