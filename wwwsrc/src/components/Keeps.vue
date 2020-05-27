<template>
  <div class="keeps">
    <div class="row">
      <div class="col-3" type="button" @click="keepDetails()">
        <div class="card" style="18rem;">
          <img :src="keepData.img" class="card-img-top img-fluid" />
          <div class="card-body">
            <h5 class="card-title">{{keepData.name}}</h5>
          </div>
          <ul class="list-group list-group-flush">
            <li class="list-group-item">{{keepData.views}}</li>
            <li class="list-group-item">{{keepData.shares}}</li>
            <li class="list-group-item">{{keepData.keeps}}</li>
          </ul>

          <!-- <div class="dropdown">
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
          </div>-->
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keeps",
  props: ["keepData"],
  data() {
    return {};
  },
  mounted() {},
  computed: {
    publicKeeps() {
      // console.log(this.$store.state.publicKeeps);
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    keepDetails() {
      console.log(this.keepData.id);
      this.$store.commit("setActivePublicKeep");
      this.$store.dispatch("getActivePublicKeep", this.keepData.id);
      this.$router.push({
        name: "KeepDetails",
        params: { keepId: this.keepData.id }
      });
    }

    // saveKeepToVault(vaultId) {
    //   this.activePublicKeep.keeps++;
    //   let dataObject = {
    //     vaultId: vaultId,
    //     keep: this.activePublicKeep,
    //     keepId: this.activePublicKeep.id
    //   };
    //   this.$store.dispatch("saveKeepToVault", dataObject);
    // }
  },
  components: {}
};
</script>


<style scoped>
</style>