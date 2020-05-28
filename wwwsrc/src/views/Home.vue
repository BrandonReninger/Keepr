<template>
  <div class="home">
    <div class="row justify-content-center">
      <div class="col-6">
        <create-keep></create-keep>
      </div>
    </div>
    <keeps v-for="publicKeep in publicKeeps" :key="publicKeep.id" :keepData="publicKeep"></keeps>
  </div>
</template>

<script>
import CreateKeep from "../components/CreateKeep.vue";
import Keeps from "../components/Keeps.vue";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
    // this.$store.dispatch("getActivePublicKeep");
  },
  computed: {
    publicKeeps() {
      // console.log(this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    },

    activePublicKeep() {
      return this.$store.state.activePublicKeep;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    created() {
      this.$store.disptach("getPublicKeeps");
    }
  },
  components: { CreateKeep, Keeps }
};
</script>