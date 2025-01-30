<template>
  <div>
    <h2>Anna palautetta</h2>
    <form @submit.prevent="submitFeedback">
      <input v-model="feedback.name" placeholder="Nimi" required />
      <input v-model="feedback.email" type="email" placeholder="Sähköposti" required />
      <textarea v-model="feedback.message" placeholder="Viesti" required></textarea>
      <button type="submit">Lähetä</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return { feedback: { name: '', email: '', message: '' } };
  },
  methods: {
    async submitFeedback() {
      await axios.post('http://localhost:5000/api/feedback', this.feedback);
      alert('Palautteesi on lähetetty!');
      this.feedback = { name: '', email: '', message: '' };
    }
  }
};
</script>
