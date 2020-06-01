<template>
  <div class="create-keep border border-white rounded">
    <form @submit.prevent="createKeep()">
      <h3 class="text-center">Create a Keep</h3>
      <div class="form-group">
        <label for="name">Name:</label>
        <input
          type="text"
          name="name"
          class="form-control"
          placeholder="Enter name...."
          v-model="newKeep.name"
        />
      </div>
      <div class="form-group">
        <label for="description">Description:</label>
        <input
          type="text"
          name="description"
          class="form-control"
          placeholder="Describe...."
          v-model="newKeep.description"
        />
      </div>
      <div class="form-group">
        <label for="img">ImgUrl:</label>
        <input
          type="text"
          name="img"
          class="form-control"
          placeholder="paste img url...."
          v-model="newKeep.img"
        />
      </div>
      <!-- <div class="form-group">
        <label for="checkbox">Mark as Public?</label>
        <input type="checkbox" id="checkbox" v-model="newKeep.isPrivate" />
      </div>-->
      <div class="row justify-content-center mb-2">
        <button class="btn btn-primary" type="submit">Create Keep</button>
      </div>
    </form>
  </div>
</template>

//NOTE try to make card just an image and have stats pop up on hover

<script>
export default {
  name: "create-keep",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {},
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>