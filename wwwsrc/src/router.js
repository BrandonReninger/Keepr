import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
// @ts-ignore
import KeepDetails from "./views/KeepDetails.vue";
// @ts-ignore
import VaultKeeps from "./views/VaultKeeps";
import {
  authGuard
} from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [{
      path: "/",
      name: "home",
      component: Home,
      beforeEnter: authGuard
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard
    },
    {
      path: "/KeepDetails/:keepId",
      name: "KeepDetails",
      component: KeepDetails,
      beforeEnter: authGuard
    }
    // },
    // {
    //   path: "/VaultKeeps/:vaultId",
    //   name: "VaultKeeps",
    //   component: VaultKeeps,
    //   beforeEnter: authGuard
    // }
  ]
});