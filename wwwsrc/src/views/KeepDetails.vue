<template>
  <div class="KeepDetails container-fluid">
    <div class="card" style="width: 18rem;">
      <img src class="card-img-top" alt="..." />
      <div class="card-body">
        <h5 class="card-title">{{publicKeep.name}}</h5>
        <p class="card-text">{{publicKeep.description}}</p>
      </div>
      <ul class="list-group list-group-flush">
        <li class="list-group-item">Cras justo odio</li>
        <li class="list-group-item">Dapibus ac facilisis in</li>
        <li class="list-group-item">Vestibulum at eros</li>
      </ul>
    </div>
  </div>
</template>


<script>
export default {
  name: "KeepDetails",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getActivePublicKeep", this.$route.params.keepId);
  },
  computed: {
    publicKeep() {
      console.log(this.$store.state.activePublicKeep);
      return this.$store.state.activePublicKeep;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>