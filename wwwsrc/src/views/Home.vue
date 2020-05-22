<template>
  <div class="home row">
    <div class="col-3" v-for="publicKeep in publicKeeps" :key="publicKeep.id">
      <div class="card" style="18rem;">
        <img :src="publicKeep.img" class="card-img-top img-fluid" />
        <div class="card-body">
          <h5 class="card-title">{{publicKeep.Name}}</h5>
        </div>
        <ul class="list-group list-group-flush">
          <li class="list-group-item">{{publicKeep.views}}</li>
          <li class="list-group-item">{{publicKeep.shares}}</li>
          <li class="list-group-item">{{publicKeep.keeps}}</li>
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
      // console.log(this.$store.state.publicKeeps);
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
