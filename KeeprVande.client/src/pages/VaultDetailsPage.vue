<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">
        <h1>
          Vault Page
        </h1>
      </div>
    </section>
  </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { vaultsService } from '../services/VaultsService.js';
import Pop from '../utils/Pop.js';
import { onUnmounted, watchEffect } from 'vue';

export default {
  setup(){

    const route = useRoute()

    async function setActive(){
      try {
        const vaultId = route.params.vaultId;

        await vaultsService.setActive(vaultId);
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
    })

    onUnmounted(() => {
      clearVault()
    })

    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>
