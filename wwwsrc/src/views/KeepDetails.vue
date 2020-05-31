<template>
  <div class="KeepDetails container-fluid">
    <div class="row justify-content-center mt-2 mb-2">
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
        <div class="dropdown d-flex justify-content-center">
          <button
            class="btn btn-secondary dropdown-toggle mt-2 mb-2"
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
          class="btn btn-danger btn-sm"
        >DELETE</button>
      </div>
    </div>
  </div>
</template>

//NOTE probably turn this into a modal rather than view route

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
      this.publicKeep.keeps++;
      let dataObject = {
        vaultId: vaultId,
        keep: this.publicKeep,
        keepId: this.publicKeep.id
      };
      // let editObject = JSON.parse(JSON.stringify(this.publicKeep));
      // editObject.keeps = editObject.keeps++;

      this.$store.dispatch("saveKeepToVault", dataObject);
      this.$store.commit("setVaultKeeps");
      // this.$store.commit("setUserKeeps", );
      this.$store.dispatch("getVaultKeeps", vaultId);
      this.$store.dispatch("editKeep", dataObject.keep);
    },
    deleteKeep(id) {
      if (confirm("Are you sure? This will delete card from your vault.")) {
        this.$store.dispatch("deleteKeep", this.publicKeep.id);
        this.$router.push({ name: "home" });
      } else {
      }
    }
  },
  components: {}
};
</script>


<style scoped>
</style>