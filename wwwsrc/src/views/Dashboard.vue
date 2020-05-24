<template>
  <div class="dashboard">
    <h1>Your Vaults</h1>
    <div class="row justify-content-center">
      <div class="col-6">
        <create-vault></create-vault>
      </div>
    </div>
    <div class="col-3 shadow" v-for="vault in vaults" :key="vault.id">
      <div class="card" style="width: 18rem;">
        <div class="card-body">
          <h5 class="card-title">{{vault.name}}</h5>
          <p class="card-text">{{vault.description}}</p>
        </div>
        <button @click="deleteVault(vault.id)" class="btn btn-danger">DELETE VAULT</button>
      </div>
    </div>
  </div>
</template>

<script>
import CreateVault from "../components/CreateVault.vue";
export default {
  mounted() {
    this.$store.dispatch("getVaultsByUserId");
  },
  computed: {
    vaults() {
      console.log(this.$store.state.vaults);
      return this.$store.state.vaults;
    },
    user() {
      console.log(this.$store.state.user);
      return this.$store.state.user;
    }
  },
  methods: {
    deleteVault(vaultId) {
      this.$store.dispatch("deleteVault", vaultId);
    }
  },
  components: { CreateVault }
};
</script>

<style></style>
