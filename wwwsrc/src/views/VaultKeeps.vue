<template>
  <div class="VaultKeeps">
    <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.vaultKeepId"></div>
  </div>
</template>


<script>
import Keeps from "../components/Keeps.vue";
export default {
  name: "VaultKeeps",
  data() {
    return {};
  },
  mounted() {
    // this.$store.dispatch("getActiveVault", this.$route.params.vaultId);
    console.log("vaultKeep");
    this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId);
  },
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {},
  components: { Keeps }
};
</script>


<style scoped>
</style>