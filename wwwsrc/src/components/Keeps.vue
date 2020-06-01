<template>
  <div class="keeps mt-3">
    <div type="button" @click="keepDetails()">
      <div class="card" style="18rem;">
        <img v-if="keepData.img" :src="keepData.img" class="card-img-top img-fluid" />
        <div class="card-body">
          <h5 class="card-title text-center d-flex flex nowrap">{{keepData.name}}</h5>
        </div>
        <hr />
        <div class="d-flex justify-content-between ml-3 mr-3">
          <i class="fas fa-eye"></i>
          <p>{{keepData.views}}</p>
          <i class="fas fa-share-square"></i>
          <p>{{keepData.shares}}</p>
          <i class="fas fa-save"></i>
          <p>{{keepData.keeps}}</p>
        </div>
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
      this.keepData.views++;
      this.$store.commit("setActivePublicKeep");
      this.$store.dispatch("getActivePublicKeep", this.keepData.id);
      this.$store.dispatch("editKeep", this.keepData);
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