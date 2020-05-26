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
          <div class="dropdown">
            <button
              class="btn btn-secondary dropdown-toggle"
              type="button"
              id="dropdownMenu2"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >Save to a vault</button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
              <button
                v-for="vault in vaults"
                :key="vault.id"
                class="dropdown-item"
                type="button"
                @click="saveKeepToVault(vault.id)"
              >{{vault.name}}</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

//NOTE make a v-for with available vaults at saveKeep call in a dropdown or something, start there tomorrow

<script>
import CreateKeep from "../components/CreateKeep.vue";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    publicKeeps() {
      // console.log(this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    },
    vaults() {
      // console.log(this.$store.state.vaults);
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },

    saveKeepToVault(vaultId) {
      this.$store.dispatch("saveKeep", vaultId);
    }
  },
  components: { CreateKeep }
};
</script>
