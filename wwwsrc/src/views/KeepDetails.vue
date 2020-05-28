<template>
  <div class="KeepDetails container-fluid">
    <div class="card" style="width: 18rem;">
      <img v-if="publicKeep.img" :src="publicKeep.img" class="card-img-top" alt="..." />
      <div class="card-body">
        <h5 class="card-title">{{publicKeep.name}}</h5>
        <p class="card-text">{{publicKeep.description}}</p>
      </div>
      <ul class="list-group list-group-flush">
        <li class="list-group-item">views: {{publicKeep.views}}</li>
        <li class="list-group-item">shares: {{publicKeep.shares}}</li>
        <li class="list-group-item">saves: {{publicKeep.keeps}}</li>
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
      <button
        v-show="this.publicKeep.userId == this.$auth.user.sub"
        @click="deleteKeep()"
        class="btn btn-danger"
      >DELETE</button>
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
      // console.log(this.$auth.user);
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
      let dataObject = {
        vaultId: vaultId,
        keep: this.publicKeep,
        keepId: this.publicKeep.id
      };
      let editObject = JSON.parse(JSON.stringify(this.publicKeep));
      editObject.keeps = editObject.keeps++;

      this.$store.dispatch("saveKeepToVault", dataObject);
      this.$store.commit("setVaultKeeps");
      this.$store.dispatch("getVaultKeeps", vaultId);
      this.$store.dispatch("saveCount", editObject);
    },
    deleteKeep(id) {
      console.log("delete", this.publicKeep.id);
      this.$store.dispatch("deleteKeep", this.publicKeep.id);
      this.$router.push({ name: "home" });
    }
  },
  components: {}
};
</script>


<style scoped>
</style>