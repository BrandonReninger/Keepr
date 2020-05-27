<template>
  <div class="KeepDetails container-fluid">
    <div class="card" style="width: 18rem;">
      <img :src="publicKeep.img" class="card-img-top" alt="..." />
      <div class="card-body">
        <h5 class="card-title">{{publicKeep.name}}</h5>
        <p class="card-text">{{publicKeep.description}}</p>
      </div>
      <ul class="list-group list-group-flush">
        <li class="list-group-item">{{publicKeep.views}}</li>
        <li class="list-group-item">{{publicKeep.shares}}</li>
        <li class="list-group-item">{{publicKeep.keeps}}</li>
      </ul>
      <div class="dropdown">
        <button
          class="btn btn-secondary dropdown-toggle"
          type="button"
          id="dropdownMenuButton"
          data-toggle="dropdown"
        >Add To Vault</button>
        <div class="dropdown-menu">
          <a
            class="dropdown-item"
            v-show="vault.name"
            v-for="vault in vaults"
            :key="vault.id"
            @click="saveKeepToVault(vault.id)"
          >{{vault.name}}</a>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "KeepDetails",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getActivePublicKeep", this.$route.params.keepId);
    this.$store.dispatch("getVaultsByUserId");
  },
  computed: {
    publicKeep() {
      console.log(this.$store.state.activePublicKeep);
      return this.$store.state.activePublicKeep;
    },
    vaults() {
      // console.log(this.$store.state.vaults);
      return this.$store.state.vaults;
    }
  },
  methods: {
    saveKeepToVault(vaultId) {
      console.log("saveKeepToVault", this.publicKeep);
      this.publicKeep.keeps++;
      let dataObject = {
        vaultId: vaultId,
        keep: this.publicKeep,
        keepId: this.publicKeep.id
      };
      this.$store.dispatch("saveKeepToVault", dataObject);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>