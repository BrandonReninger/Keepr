<template>
  <div class="keeps">
    <div type="button" @click="keepDetails()">
      <div class="card" style="18rem;">
        <img v-if="keepData.img" :src="keepData.img" class="card-img-top img-fluid" />
        <div class="card-body">
          <h5 class="card-title">{{keepData.name}}</h5>
        </div>
        <ul class="list-group list-group-flush">
          <li class="list-group-item">views: {{keepData.views}}</li>
          <li class="list-group-item">shares: {{keepData.shares}}</li>
          <li class="list-group-item">saves: {{keepData.keeps}}</li>
        </ul>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keeps",
  props: ["keepData"],
  data() {
    return {};
  },
  mounted() {},
  computed: {
    publicKeeps() {
      // console.log(this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    keepDetails() {
      this.$store.commit("setActivePublicKeep");
      this.$store.dispatch("getActivePublicKeep", this.keepData.id);
      this.$router.push({
        name: "KeepDetails",
        params: { keepId: this.keepData.id }
      });
    }
  },
  components: {}
};
</script>


<style scoped>
.card-columns {
  column-count: 3;
}
</style>