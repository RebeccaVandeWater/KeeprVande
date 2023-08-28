import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {
  async getKeeps() {
    const res = await api.get('api/keeps')

    logger.log('[GOT KEEPS]', res.data)

    AppState.keeps = res.data.map(pojo => new Keep(pojo))
  }

  async setActive(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)

    logger.log('[GOT KEEP BY ID]', res.data)

    AppState.activeKeep = new Keep(res.data)
  }

  async getProfileKeeps(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`)

    logger.log('GOT PROFILE KEEPS', res.data)

    AppState.keeps = res.data.map(pojo => new Keep(pojo))
  }

  clearKeep() {
    AppState.activeKeep = null;
  }

}

export const keepsService = new KeepsService