<template>
  <div class="contact-list">
    <DataTable :value="contacts" data-key="id" :rows="10">
      <Column field="name" header="Nome"></Column>
      <Column field="email" header="Email"></Column>
      <Column field="phone" header="Telefone"></Column>
      <Column header="Ações">
        <template #body="slotProps">
          <Button icon="pi pi-pencil" class="p-button-text" @click="editContact(slotProps.data)"></Button>
          <Button icon="pi pi-trash" class="p-button-text" @click="deleteContact(slotProps.data.id)"></Button>
        </template>
      </Column>
    </DataTable>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import apiClient from '../api.js';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import Button from 'primevue/button';
import { useRouter } from 'vue-router';

export default {
  components: {
    DataTable,
    Column,
    Button
  },
  setup() {
    const contacts = ref([]);
    const router = useRouter();

    const fetchContacts = async () => {
      try {
        const response = await apiClient.get('/Contacts');
        contacts.value = response.data;
      } catch (error) {
        console.error('Failed to fetch contacts', error);
      }
    };

    const editContact = (contact) => {
      if (contact && contact.id) {
        router.push(`/edit/${contact.id}`);
      } else {
        console.error('Contact is undefined or does not have an id');
      }
    };

    const deleteContact = async (id) => {
      try {
        await apiClient.delete(`/Contacts/${id}`);
        contacts.value = contacts.value.filter(contact => contact.id !== id);
      } catch (error) {
        console.error('Failed to delete contact', error);
      }
    };

    onMounted(() => {
      fetchContacts();
    });
    console.log('contacts.value ->>', contacts)

    return {
      contacts,
      editContact,
      deleteContact
    };
  }
};
</script>
