<template>
  <div class="container bg-white" v-if="activeProfile">
    <section class="row">
      <div class="col-12 text-center">
        <div class="mt-5">
          <img :src="activeProfile.coverImg" :alt="activeProfile.name" class="img-fluid coverImg-style">
        </div>
        <div>
          <div>
            <img :src="activeProfile.picture" :alt="activeProfile.name" class="img-fluid avatar-md avatar-style">
          </div>
          <div>
            <p class="fs-3 fw-bold">
              {{ activeProfile.name }}
            </p>
          </div>
          <div>
            <p class="fw-semibold">
              {{ vaults?.length }} Vaults | {{ keeps?.length }} Keeps
            </p>
          </div>
        </div>
      </div>
    </section>
    <section class="row">
      <div class="col-12">
        <p class="fs-4 fw-semibold">
          Vaults
        </p>
      </div>
      <div class="col-md-3 col-6 my-2" v-for="vault in vaults" :key="vault.id">
        <VaultCard :vaultProp="vault" />
      </div>
    </section>
    <section class="row mt-3">
      <div class="col-12">
        <p class="fs-4 fw-semibold">
          Keeps
        </p>
      </div>
    </section>
  </div>
  <div class="container-fluid bg-white" v-else>
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
import Pop from '../utils/Pop.js';
import {profilesService} from '../services/ProfilesService.js'
import { computed, onUnmounted, watchEffect } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState.js';
import { keepsService } from '../services/KeepsService.js';
import {vaultsService} from '../services/VaultsService.js'
import { Modal } from 'bootstrap';
import VaultCard from '../components/VaultCard.vue';

export default {
    setup() {
        const route = useRoute();
        async function getProfile() {
            try {
                Modal.getOrCreateInstance('#keepModal')?.hide();
                const profileId = route.params.profileId;
                await profilesService.getProfile(profileId);
            }
            catch (error) {
                Pop.error(error.message);
            }
        }
        async function getProfileKeeps() {
            try {
                const profileId = route.params.profileId;
                await keepsService.getProfileKeeps(profileId);
            }
            catch (error) {
                Pop.error(error.message);
            }
        }
        async function getProfileVaults() {
            try {
                const profileId = route.params.profileId;
                await vaultsService.getProfileVaults(profileId);
            }
            catch (error) {
                Pop.error(error.message);
            }
        }
        function clearProfile() {
            try {
                profilesService.clearProfile();
            }
            catch (error) {
                Pop.error(error.message);
            }
        }
        watchEffect(() => {
            route.params.profileId;
            getProfile();
            getProfileKeeps();
            getProfileVaults();
        });
        onUnmounted(() => {
            clearProfile();
        });
        return {
            activeProfile: computed(() => AppState.activeProfile),
            keeps: computed(() => AppState.keeps),
            vaults: computed(() => AppState.vaults)
        };
    },
    components: { VaultCard }
}
</script>


<style lang="scss" scoped>
.coverImg-style{
  object-fit: cover;
  object-position: center;
  height: 20vh;
  width: 100%;
}

.avatar-style{
  position: relative;
  top: -3.5vh;
}
</style>