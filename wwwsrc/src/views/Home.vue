<template>
  <div class="home">
    <div class="row justify-content-center">
      <div class="col-6">
        <create-keep v-show="this.$auth.user"></create-keep>
      </div>
    </div>
    <div class="row ml-2 mr-2">
      <keeps
        class="col-3"
        v-for="publicKeep in publicKeeps"
        :key="publicKeep.id"
        :keepData="publicKeep"
      ></keeps>
    </div>
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