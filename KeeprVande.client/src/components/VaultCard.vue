<template>
  <router-link :to="{name: 'Vault Details', params:{vaultId: vaultProp.id}}">
    <div class="vault-img d-flex align-items-end" :title="vaultProp.name">
        <p class="vault-name ps-3">
          {{ vaultProp.name }}
        </p>
    </div>
  </router-link>
</template>


<script>
import { computed } from 'vue';
import { Vault } from '../models/Vault.js';

export default {
  props:{
    vaultProp: {type: Vault, required:true}
  },

  setup(props){
    return {
      vaultImg: computed(() => `url(${props.vaultProp.img})`)
    }
  }
}
</script>


<style lang="scss" scoped>
.vault-img{
  background-image: v-bind(vaultImg);
  background-position: center;
  background-size: cover;
  border-radius: 5%;
  height: 20vh;
  border: none;
  width: 100%
}

.vault-name{
  font-family: 'Elsie', cursive;
  font-weight: 600;
  font-size: larger;
  color: rgb(239, 231, 221);
  text-shadow: 2px 2px 2px black;
}
</style>