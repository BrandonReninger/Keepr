<template>
  <div class="create-vault">
    <form class="border border-rounded bg-transparent" @submit.prevent="createVault()">
      <h3 class="text-center">Create New Vault</h3>
      <div class="form-group">
        <label for="name">Name:</label>
        <input
          type="text"
          name="name"
          class="form-control"
          placeholder="Enter vault name...."
          v-model="newVault.name"
        />
      </div>
      <div class="form-group">
        <label for="description">Description:</label>
        <input
          type="text"
          name="description"
          class="form-control"
          placeholder="Enter vault description...."
          v-model="newVault.description"
        />
      </div>
      <button type="submit" class="btn btn-primary">Create Vault</button>
    </form>
  </div>
</template>


<script>
export default {
  name: "create-vault",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {},
  methods: {
    createVault() {
      this.$store.dispatch("createVault", this.newVault);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>