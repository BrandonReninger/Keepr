<template>
  <div class="vaults row">
    <div class="col-3 card-columns" @click.prevent="getVaultKeeps(vaultData.id)">
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
    getVaultKeeps() {
      this.$store.commit("setVaultKeeps");
      this.$router.push({
        name: "VaultKeeps",
        params: { vaultId: this.vaultData.id }
      });
    },

    deleteVault(vaultId) {
      if (confirm("Are you sure? This will delete everyting")) {
      }
      this.$store.dispatch("deleteVault", vaultId);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>