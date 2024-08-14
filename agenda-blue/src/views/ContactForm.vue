<template>
  <div class="contact-form">
    <form @submit.prevent="saveContact">
      <div class="field">
        <label for="name">Nome</label>
        <InputText id="name" v-model="contact.name" required />
      </div>

      <div class="field">
        <label for="email">Email</label>
        <InputText id="email" v-model="contact.email" type="email" required />
      </div>

      <div class="field">
        <label for="phone">Telefone</label>
        <InputMask id="phone" v-model="contact.phone" mask="(99) 99999-9999" required />
      </div>

      <div class="actions">
        <Button label="Salvar" icon="pi pi-check" type="submit" class="p-button-success" />
        <Button label="Cancelar" icon="pi pi-times" class="p-button-secondary" @click="cancel" />
      </div>
    </form>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import apiClient from '../api.js';
import InputText from 'primevue/inputtext';
import InputMask from 'primevue/inputmask';
import Button from 'primevue/button';

const contact = ref({
  id: null,
  name: '',
  email: '',
  phone: '',
});

const route = useRoute();
const router = useRouter();
const contactId = route.params.id;

const fetchContact = async () => {
  if (contactId) {
    try {
      const response = await apiClient.get(`/Contacts/${contactId}`);
      contact.value = response.data;
    } catch (error) {
      console.error('Failed to fetch contact', error);
    }
  }
};

const saveContact = async () => {
  try {
    if (contact.value.id) {
      await apiClient.put(`/Contacts/${contact.value.id}`, {
        name: contact.value.name,
        email: contact.value.email,
        phone: contact.value.phone
      });
    } else {
      await apiClient.post('/Contacts', {
        name: contact.value.name,
        email: contact.value.email,
        phone: contact.value.phone
      });
    }
    router.push('/');
  } catch (error) {
    console.error('Failed to save contact', error);
  }
};


const cancel = () => {
  router.push('/');
};

onMounted(() => {
  fetchContact();
});
</script>

<style scoped>
.contact-form {
  max-width: 500px;
  margin: 0 auto;
}

.field {
  margin-bottom: 1em;
}

.actions {
  display: flex;
  justify-content: space-between;
}
</style>
