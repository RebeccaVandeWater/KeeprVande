<template>
<nav class="navbar navbar-expand-md bg-body-tertiary">
  <div class="container-fluid">
    <router-link class="navbar-brand" :to="{ name: 'Home' }">
      <div class="d-flex align-items-center row ms-2 me-1">
        <button class="green-btn" title="Home">
          Home
        </button>
      </div>  
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse " id="navbarNavAltMarkup">
      <div class="navbar-nav row justify-content-between align-items-center flex-grow-1">
        <div class="btn-group dropdown-md dropstart col-3">
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
        <div class="col-3">
          <span class="header-font d-none d-md-block">
            keepr co.
          </span>
        </div>
        <div class="col-3 d-flex justify-content-end">
          <Login />
        </div>
      </div>
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

}
</style>
