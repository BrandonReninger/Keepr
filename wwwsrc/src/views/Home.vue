<template>
  <div class="home row">
    <div class="col-3">
      <div class="card" style="18rem;">
        <img :src="publicKeeps.img" class="card-img-top img-fluid" />
        <div class="card-body">
          <h5 class="card-title">{{publicKeeps.Name}}</h5>
        </div>
        <ul class="list-group list-group-flush">
          <li class="list-group-item">{{publicKeeps.views}}</li>
          <li class="list-group-item">{{publicKeeps.shares}}</li>
          <li class="list-group-item">{{publicKeeps.keeps}}</li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
