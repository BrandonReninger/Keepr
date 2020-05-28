<template>
  <div class="VaultKeeps">
    <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id"></div>
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
    this.$store.dispatch("getActiveVault", this.$route.params.vaultId);
    this.$store.dispatch("getVaultKeeps", this.vaultKeep.id);
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {},
  components: { Keeps }
};
</script>


<style scoped>
</style>