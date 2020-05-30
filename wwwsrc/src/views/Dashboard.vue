<template>
  <div class="dashboard">
    <h1>Your Vaults</h1>
    <div class="row justify-content-center">
      <div class="col-6">
        <create-vault></create-vault>
      </div>
    </div>
    <vaults class="mt-3" v-for="vault in vaults" :key="vault.id" :vaultData="vault"></vaults>
    <keeps v-for="userKeep in userKeeps" :key="userKeep.id" :keepData="userKeep"></keeps>
  </div>
</template>

<script>
import CreateVault from "../components/CreateVault.vue";
import Vaults from "../components/Vaults.vue";
import Keeps from "../components/Keeps.vue";
export default {
  name: "dashboard",
  props: ["vaultData"],
  mounted() {
    this.$store.dispatch("getVaultsByUserId");
    this.$store.dispatch("getPublicKeeps");
    this.$store.dispatch("getUserKeeps", this.$auth.user.sub);
    // this.$store.dispatch("getVaultKeeps", this.vault.id);
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },

    userKeeps() {
      return this.$store.state.userKeeps;
    },

    publicKeeps() {
      console.log("userkeeps", this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    }
    // vaultKeeps() {
    //   console.log("vaultKeeps", this.$store.state.vaultKeeps);
    //   return this.$store.state.vaultKeeps;
    // },
    // user() {
    //   console.log(this.$store.state.user);
    //   return this.$store.state.user;
    // }
  },
  methods: {},
  components: { CreateVault, Vaults, Keeps }
};
</script>

<style></style>
