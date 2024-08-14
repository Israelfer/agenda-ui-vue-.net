<template>
  <div class="contact-list">
    <DataTable :value="contacts" data-key="id" :rows="10">
      <Column field="name" header="Nome"></Column>
      <Column field="email" header="Email"></Column>
      <Column field="phone" header="Telefone"></Column>
      <Column header="Ações">
        <template #body="slotProps">
          <Button icon="pi pi-pencil" class="p-button-text" @click="editContact(slotProps.rowData)"></Button>
          <Button icon="pi pi-trash" class="p-button-text" @click="deleteContact(slotProps.rowData.id)"></Button>
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

export default {
  components: {
    DataTable,
    Column,
    Button
  },
  setup() {
    const contacts = ref([]);

    // Função para buscar contatos da API
    const fetchContacts = async () => {
      try {
        const response = await apiClient.get('/Contacts');
        contacts.value = response.data;
      } catch (error) {
        console.error('Failed to fetch contacts', error);
      }
      
    };

    const editContact = (contact) => {
      console.log('Edit contact', contact);
      // Aqui você pode redirecionar para uma página de edição ou abrir um modal
    };

    const deleteContact = async (id) => {
      try {
        await api.delete(`/contacts/${id}`);
        contacts.value = contacts.value.filter(contact => contact.id !== id);
      } catch (error) {
        console.error('Failed to delete contact', error);
      }
    };

    onMounted(() => {
      fetchContacts();
    });

    return {
      contacts,
      editContact,
      deleteContact
    };
  }
};
</script>

<style scoped>
.contact-list {
  width: 90%;
  margin: 0 auto;
}
</style>
