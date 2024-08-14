import { createRouter, createWebHistory } from 'vue-router';
import ContactList from '../views/ContactList.vue';
import ContactForm from '../views/ContactForm.vue';

const routes = [
  { path: '/', component: ContactList },
  { path: '/new', component: ContactForm },
  { path: '/edit/:id', component: ContactForm },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;