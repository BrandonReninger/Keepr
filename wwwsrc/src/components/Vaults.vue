<template>
  <div class="vaults row">
    <div class="col-3 shadow">
      <div class="card" style="width: 18rem;">
        <div class="card-body">
          <h5 class="card-title">{{vaultData.name}}</h5>
          <p class="card-text">{{vaultData.description}}</p>
        </div>
        <button @click="deleteVault(vaultData.id)" class="btn btn-danger">DELETE VAULT</button>
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
  mounted() {},
  computed: {
    userVaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    // getVaultKeeps() {
    //   this.$store.commit("setVaultKeeps");
    //   this.$store.dispatch("getActiveVault", this.vaultData.id);
    //   this.$router.push({
    //     name: "VaultKeeps",
    //     params: { vaultId: this.vaultData.id }
    //   });
    // },

    deleteVault(vaultId) {
      this.$store.dispatch("deleteVault", vaultId);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>