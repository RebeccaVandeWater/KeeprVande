<template>
  <nav class="navbar navbar-expand-lg navbar-dark px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex align-items-center">
        <button class="green-btn" title="Home">
          Home
        </button>
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse d-flex justify-content-between" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>
          <div class="btn-group">
            <button class="clear-btn fs-5 dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false" title="Create">
              Create
            </button>
            <ul class="dropdown-menu dropdown-style">
              <li class="ps-2">
                new keep
              </li>
              <li  class="dropdown-divider"></li>
              <li class="ps-2">
                new vault
              </li>
            </ul>
          </div>
        </li>
      </ul>
      <div>
        <p class="m-0">
          Keepr
        </p>
      </div>
      <!-- LOGIN COMPONENT HERE -->
      <div>
        <Login />
      </div>
    </div>
  </nav>
</template>

<script>
import Login from './Login.vue';
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }

.dropdown-style{
  background-color: #B7C5B3;
  font-weight: 600;
}
}
</style>
