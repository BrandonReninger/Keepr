import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost") ?
  "https://localhost:5001/" :
  "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    vaultKeeps: [],
    vaults: []
  },
  mutations: {
    setPublicKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps;
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getPublicKeeps({
      commit
    }) {
      try {
        let res = await api.get('keeps')
        commit('setPublicKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async getVaultKeeps({
      commit
    }, vaultId) {
      try {
        let res = await api.get('vaults/' + vaultId + '/keeps')
      } catch (error) {
        console.error(error)
      }
    },

    async saveKeepToVault({
      dispatch
    }, vaultId) {
      try {
        let res = await api.post('keepvaults' + vaultId)
        dispatch('getVaultKeeps')
      } catch (error) {
        console.error(error)
      }
    },

    //NOTE probably add a dispatch for privatekeeps once we're at that point
    async createKeep({
      dispatch
    }, newKeep) {
      try {
        let res = await api.post('keeps', newKeep)
        dispatch('getPublicKeeps')
      } catch (error) {
        console.error(error)
      }
    },

    async getVaultsByUserId({
      commit
    }, user) {
      try {
        let res = await api.get('vaults/user')
        commit('setVaults', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async createVault({
      dispatch
    }, newVault) {
      try {
        let res = await api.post('vaults', newVault)
        dispatch('getVaults')
      } catch (error) {
        console.error(error)
      }
    },

    async deleteVault({
      dispatch
    }, vaultId) {
      try {
        await api.delete('vaults/' + vaultId)
        dispatch('getVaults')
      } catch (error) {
        console.error(error)
      }
    }

  }
});