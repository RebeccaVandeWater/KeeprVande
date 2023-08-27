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
@import url('https://fonts.googleapis.com/css2?family=Elsie:wght@400;900&display=swap');

:root{
  --main-height: calc(100vh - 32px - 64px);
  --darkGreen: color(#2F463E);
  --lightGreen: color(#618173);
  --softGreen: color(#B7C5B3);
  --cream: color(#F9F2DC);
  --tan: color(#CFB8AA);
}

.tan-btn{
  background-color: #CFB8AA;
  color: black;
  font-weight: 600;
  border-radius: 10px;
  border: none;
}

.tan-btn:hover{
  background-color: #e2c8b8;
}

.clear-btn{
  background-color: #f8f9fa;
  color: black;
  font-weight: 600;
  border-radius: 10px;
  border: none;
}

.clear-btn:hover{
  border: 1px solid #7da895;
}

.header-font{
  font-family: 'Elsie', cursive;
  font-weight: 900;
  font-size: larger;
}

.dropdown-style{
  background-color: #B7C5B3;
  font-weight: 600;
}

.avatar-sm{
  height: 2.5rem;
  width: 2.5rem;
  object-fit: cover;
  object-position: center;
  border-radius: 50%;
}

// .masonry-style{
//   columns: 2 600px;
//   column-gap: 1rem;
//   div{
//     width: 150px;
//     margin: 0 1rem 1rem 0;
//     display: inline-block;
//     width: 100%;
//   }
//   @for $i from 1 through 26{
//     div:nth-child(#{$i}){
//       $h: (random(400) + 100) + px;
//       height: $h;
//       line-height: $h;
//     }
//   }
// }

// .masonry-style{
//   display: grid;
//   gap: 3px;
//   grid-template-columns: repeat(auto-fill, minmax(120px, 1fr));
//   grid-template-rows: auto;
// }

@media(min-width: 768px){
  // .masonry-style{
  // columns: 4 300px;
  // column-gap: 1rem;
  // div{
  //   width: 150px;
  //   margin: 0 1rem 1rem 0;
  //   display: inline-block;
  //   width: 100%;
  // }
  // @for $i from 1 through 26{
  //   div:nth-child(#{$i}){
  //     $h: (random(300) + 100) + px;
  //     height: $h;
  //     line-height: $h;
  //   }
  // }
  // }
}

</style>
