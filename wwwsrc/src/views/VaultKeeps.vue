<template>
  <div class="VaultKeeps">
    <keeps :keepData="vaultKeep" v-for="vaultKeep in vaultKeeps" :key="vaultKeep.vaultKeepId"></keeps>
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