<template>
  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body row" v-if="activeKeep">
          <div class="col-12 col-md-6">
            <img :src="activeKeep.img" :alt="activeKeep.name" class="img-fluid img-style">
          </div>
          <div class="col-12 col-md-6 d-flex flex-column justify-content-between">
            <section class="row justify-content-center fs-5">
              <div class="col-3">
                <span>
                  <i class="mdi mdi-eye-outline"></i>
                  {{ activeKeep.views }}
                </span>
              </div>
              <div class="col-3">
                <span>
                  <i class="mdi mdi-alpha-k-box-outline"></i>
                  {{ activeKeep.kept }}
                </span>
              </div>
            </section>
            <section class="row">
              <div class="col-12">
                <p class="header-font">
                  {{ activeKeep.name }}
                </p>
              </div>
              <div class="col-12">
                <p class="text-secondary">
                  {{ activeKeep.description }}
                </p>
              </div>
            </section>
            <section class="row justify-content-between">
              <div class="col-4">
                <!-- FIXME Get account vaults, v-for through their names, finish this form -->
                <form class="d-flex">
                  <select class="form-select" aria-label="Select Vault" title="Save in a vault">
                    <option selected>Open this select menu</option>
                    <option value="1">One</option>
                    <option value="2">Two</option>
                    <option value="3">Three</option>
                  </select>
                  <button class="ms-1 tan-btn" role="submit" title="Save Keep">
                    save
                  </button>
                </form>
              </div>
              <!-- FIXME Close the modal when routed to the creator's profile -->
              <div class="col-8">
                <router-link :to="{name: 'Profile', params:{profileId: activeKeep.creatorId}}">
                  <img :src="activeKeep.creator.picture" :alt="activeKeep.creator.name" class="img-fluid avatar-sm">
                  <span class="fw-bold text-dark ps-2">{{ activeKeep.creator.name }}</span>
                </router-link>
              </div>
            </section>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup(){
    return {
      activeKeep: computed(() => AppState.activeKeep)
    }
  }
}
</script>


<style lang="scss" scoped>
.img-style{
  border-top-left-radius: 2.5%;
  border-bottom-left-radius: 2.5%;
  height: max-content;
  width: max-content;
}
</style>