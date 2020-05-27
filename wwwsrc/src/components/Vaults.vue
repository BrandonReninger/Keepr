<template>
  <div class="vaults row">
    <div class="col-3 shadow" @click="getVaultKeeps()">
      <div class="card" style="width: 18rem;">
        <div class="card-body">
          <h5 class="card-title">{{vaultData.name}}</h5>
          <p class="card-text">{{vaultData.description}}</p>
        </div>
        <button @click="deleteVault(vault.id)" class="btn btn-danger">DELETE VAULT</button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vaults",
  props: ["vaultData"],
  data() {
    return {};
  },
  computed: {
    userVaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    getVaultKeeps() {
      this.$store.commit("setActiveVault");
      this.$store.dispatch("getActiveVault", this.vaultData.id);
      this.$router.push({
        name: "VaultKeeps",
        params: { vaultId: this.vaultData.id }
      });
    }
  },
  components: {}
};
</script>


<style scoped>
</style>