<template>
  <button type="button" class="keep-img d-flex flex-grow-1 align-items-end justify-content-between rounded" data-bs-toggle="modal" data-bs-target="#keepModal" role="button" title="View Keep" @click="setActive(keepProp.id)">
    <div class="p-2">
      <p class="m-0 keep-name fs-4">
        {{ keepProp.name }}
      </p>
    </div>
    <div class="p-2">
      <img :src="keepProp.creator.picture" :alt="keepProp.creator.name" class="img-fluid avatar-sm" :title="keepProp.creator.name">
    </div>
  </button>
</template>


<script>
import { computed } from 'vue';
import { Keep } from '../models/Keep.js';
import { keepsService } from '../services/KeepsService.js';

export default {
  props:{
    keepProp: {type: Keep, required: true}
  },

  setup(props){
    return {
      keepImg: computed(() => `url(${props.keepProp.img})`),
      setActive(keepId){
        keepsService.setActive(keepId);
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.keep-img{
  background-image: v-bind(keepImg);
  background-position: center;
  background-size: cover;
  border-radius: 5%;
  height: 40vh;
  border: none;
  width: 100%
}

.keep-name{
  font-family: 'Elsie', cursive;
  font-weight: 900;
  font-size: larger;
  color: whitesmoke;
  text-shadow: 2px 2px 2px black;
}
</style>
