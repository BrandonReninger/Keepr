<template>
  <div class="dashboard">
    <h1>Your Vaults</h1>
    <div class="row justify-content-center">
      <div class="col-6">
        <create-vault></create-vault>
      </div>
    </div>
    <vaults v-for="vault in vaults" :key="vault.id" :vaultData="vault"></vaults>
  </div>
</template>

<script>
import CreateVault from "../components/CreateVault.vue";
import Vaults from "../components/Vaults.vue";
export default {
  name: "dashboard",
  props: ["vaultData"],
  mounted() {
    console.log(this.vaultData);
    this.$store.dispatch("getVaultsByUserId");
    // this.$store.dispatch("getVaultKeeps", this.vault.id);
  },
  computed: {
    vaults() {
      console.log(this.$store.state.vaults);
      return this.$store.state.vaults;
    }
    // vaultKeeps() {
    //   console.log("vaultKeeps", this.$store.state.vaultKeeps);
    //   return this.$store.state.vaultKeeps;
    // },
    // keeps() {
    //   return this.$store.state.publicKeeps;
    // }
    // user() {
    //   console.log(this.$store.state.user);
    //   return this.$store.state.user;
    // }
  },
  methods: {},
  components: { CreateVault, Vaults }
};
</script>

<style></style>
