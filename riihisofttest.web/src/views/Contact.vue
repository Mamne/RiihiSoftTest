<template>
  <div class="contact">
    <h2>Yhteystiedot</h2>
    <p>Voit ottaa meihin yhteyttä seuraavasti:</p>

    <ul>
      <li><strong>Sähköposti:</strong> info@example.com</li>
      <li><strong>Puhelin:</strong> +358 123 456 789</li>
      <li><strong>Osoite:</strong> Esimerkkikatu 12, 00100 Helsinki</li>
    </ul>

    <h3>Ota yhteyttä</h3>
    <form @submit.prevent="sendMessage">
      <input v-model="contact.name" placeholder="Nimi" required />
      <input v-model="contact.email" type="email" placeholder="Sähköposti" required />
      <textarea v-model="contact.message" placeholder="Viesti" required></textarea>
      <button type="submit">Lähetä</button>
    </form>

    <p v-if="responseMessage">{{ responseMessage }}</p>
  </div>
</template>

<script>
export default {
  data() {
    return {
      contact: { name: '', email: '', message: '' },
      responseMessage: ''
    };
  },
  methods: {
    sendMessage() {
      this.responseMessage = 'Viesti lähetetty! Otamme sinuun yhteyttä pian.';
      this.contact = { name: '', email: '', message: '' };
    }
  }
};
</script>

<style scoped>
  .contact {
    max-width: 500px;
    margin: auto;
    text-align: center;
    padding: 20px;
  }

  form {
    display: flex;
    flex-direction: column;
    gap: 10px;
  }

  button {
    background-color: #007bff;
    color: white;
    padding: 10px;
    border: none;
    cursor: pointer;
  }

    button:hover {
      background-color: #0056b3;
    }
</style>
