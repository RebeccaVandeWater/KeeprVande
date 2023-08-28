<template>
  <div class="container" v-if="activeVault">
    <section class="row justify-content-center mt-5">
      <div class="col-12 vault-img d-flex align-items-center justify-content-end flex-column rounded" :title="activeVault.name">
        <p class="vault-name-font m-0">
          {{ activeVault.name }}
        </p>
        <p class="vault-text-font">
          by {{ activeVault.creator.name.toLowerCase() }}
        </p>
      </div>
    </section>
    <section class="row mt-2">
      <div class="col-12">
        <section class="row justify-content-center">
          <div class="col-3 d-flex justify-content-center align-items-center">
            <p class="keep-num-bg fw-semibold px-2 py-1 rounded-pill m-0">
              {{ keeps?.length }} Keeps
            </p>
          </div>
        </section>
      </div>
    </section>
    <section class="row">

    </section>
  </div>
  <div class="container" v-else>
    <section class="row">
      <div class="col-12">
        <h1>
          Loading... <i class="mdi mdi-loading mdi-spin"></i>
        </h1>
      </div>
    </section>
  </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { vaultsService } from '../services/VaultsService.js';
import Pop from '../utils/Pop.js';
import { computed, onUnmounted, watchEffect } from 'vue';
import { router } from '../router.js';
import { AppState } from '../AppState.js';

export default {
  setup(){

    const route = useRoute()

    async function setActive(){
      try {
        const vaultId = route.params.vaultId;

        await vaultsService.setActive(vaultId);
      }
      catch (error) {
        Pop.error(error.response.data);
        if(error.response.data.includes('!')){
          router.push({name:'Home'})
        }
      }
    }

    async function getVaultKeeps(){
      try {
        const vaultId = route.params.vaultId;

        await vaultsService.getVaultKeeps(vaultId);
      }
      catch (error) {
        Pop.error(error.message);
      }
    }

    function clearVault(){
      vaultsService.clearVault();
    }

    watchEffect(() => {
      route.params.vaultId;
      setActive();
      getVaultKeeps();
    })

    onUnmounted(() => {
      clearVault()
    })

    return {
      activeVault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps),
      vaultImg: computed(() => `url(${AppState.activeVault?.img})`)
    }
  }
}
</script>


<style lang="scss" scoped>
.vault-img{
  background-image: v-bind(vaultImg);
  background-position: center;
  background-size: cover;
  height: 20vh;
  width: 30%;
}

.keep-num-bg{
  background-color: #B7C5B3;
  width: fit-content;
}

.btn-style{
  position: absolute;

}
</style>
