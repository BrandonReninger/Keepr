<template>
  <div class="home">
    <div class="row justify-content-center">
      <div class="col-6">
        <create-keep></create-keep>
      </div>
    </div>
    <div class="row">
      <div class="col-3" v-for="publicKeep in publicKeeps" :key="publicKeep.id">
        <div class="card" style="18rem;">
          <img :src="publicKeep.img" class="card-img-top img-fluid" />
          <div class="card-body">
            <h5 class="card-title">{{publicKeep.name}}</h5>
          </div>
          <ul class="list-group list-group-flush">
            <li class="list-group-item">{{publicKeep.views}}</li>
            <li class="list-group-item">{{publicKeep.shares}}</li>
            <li class="list-group-item">{{publicKeep.keeps}}</li>
          </ul>
          <select>
            <option disabled value>Please select one</option>
            <option
              class="dropdown-item"
              type="button"
              v-for="vault in vaults"
              :key="vault.id"
              @click="saveKeepToVault(vault.id)"
            >{{vault.name}}</option>
          </select>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import CreateKeep from "../components/CreateKeep.vue";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
    this.$store.dispatch("getVaultsByUserId");
  },
  computed: {
    publicKeeps() {
      // console.log(this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    },
    vaults() {
      console.log(this.$store.state.vaults);
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    saveKeepToVault(vaultId) {}
  },
  components: { CreateKeep }
};
</script>