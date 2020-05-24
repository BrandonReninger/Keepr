<template>
  <div class="home">
    <div class="row justify-content-center">
      <div class="col-6">
        <create-keep></create-keep>
      </div>
    </div>
    <div class="row">
      <div class="col-3" v-for="publicKeep in publicKeeps" :key="publicKeep.id">
        <div class="card" style="18rem;">
          <img :src="publicKeep.img" class="card-img-top img-fluid" />
          <div class="card-body">
            <h5 class="card-title">{{publicKeep.name}}</h5>
          </div>
          <ul class="list-group list-group-flush">
            <li class="list-group-item">{{publicKeep.views}}</li>
            <li class="list-group-item">{{publicKeep.shares}}</li>
            <li class="list-group-item">{{publicKeep.keeps}}</li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import CreateKeep from "../components/CreateKeep.vue";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    // user() {
    //   console.log(this.$store.state.user);
    //   return this.$store.state.user;
    // },
    publicKeeps() {
      // console.log(this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: { CreateKeep }
};
</script>
