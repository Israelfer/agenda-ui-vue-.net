import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import PrimeVue from 'primevue/config';

// Importando e registrando os componentes PrimeVue
import PrimeButton from 'primevue/button';
import PrimeDataTable from 'primevue/datatable';
import PrimeColumn from 'primevue/column';
import PrimeInputText from 'primevue/inputtext';
import PrimeDialog from 'primevue/dialog';
import PrimePassword from 'primevue/password';

const app = createApp(App);

app.use(router);
app.use(PrimeVue);

app.component('PrimeButton', PrimeButton);
app.component('DataTable', PrimeDataTable);
app.component('PrimeColumn', PrimeColumn);
app.component('PrimeInputText', PrimeInputText);
app.component('PrimeDialog', PrimeDialog);
app.component('PrimePassword', PrimePassword);

app.mount('#app');
