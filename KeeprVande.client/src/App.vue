<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
  --darkGreen: color(#2F463E);
  --lightGreen: color(#618173);
  --softGreen: color(#B7C5B3);
  --cream: color(#F9F2DC);
  --tan: color(#CFB8AA);
}

.green-btn{
  background-color: #618173;
  color: black;
  font-weight: 600;
  border-radius: 10px;
  border: none;
}

.green-btn:hover{
  background-color: #7da895;
}

.clear-btn{
  background-color: none;
  color: black;
  font-weight: 600;
  border-radius: 10px;
  border: none;
}

.clear-btn:hover{
  border: 1px solid #7da895;
}

</style>
