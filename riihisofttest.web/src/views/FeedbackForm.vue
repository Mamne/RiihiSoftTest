<template>
  <div>
    <h2>Anna palautetta</h2>
    <form @submit.prevent="submitFeedback">
      <input v-model="feedback.sendersName" placeholder="Nimi" required />
      <input v-model="feedback.sendersEmail" type="email" placeholder="Sähköposti" required />
      <textarea v-model="feedback.text" placeholder="Viesti" required></textarea>
      <button type="submit">Lähetä</button>
    </form>
  </div>
</template>

<script>
  import axios from 'axios';

  export default {
    data() {
      return {
        feedback: { sendersName: '', sendersEmail: '', text: '' },
      };
    },
    methods: {
      async submitFeedback() {
        try {
          await axios.post('https://localhost:7185/api/feedback', this.feedback);
          alert('Palautteesi on lähetetty!');
          this.feedback = { sendersName: '', sendersEmail: '', text: '' };
        } catch (error) {
          console.error('Axios error:', error.response || error.message);
          alert('Virhe palautteen lähettämisessä.');
        }
      }
    }
  };
</script>
