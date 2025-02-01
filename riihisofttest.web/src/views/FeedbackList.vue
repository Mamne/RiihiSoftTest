<template>
  <div>
    <h2>Saadut palautteet</h2>
    <ul v-if="feedbackList.length">
      <li v-for="feedback in feedbackList" :key="feedback.id">
        <strong>{{ feedback.sendersName }}</strong> ({{ feedback.sendersEmail }}): {{ feedback.text }}
        <br />
        <small>Lähetetty: {{ new Date(feedback.createdAt).toLocaleString() }}</small>
      </li>
    </ul>
    <p v-else>Ei palautteita vielä.</p>
  </div>
</template>

<script>
  import axios from 'axios';

  export default {
    data() {
      return {
        feedbackList: [],
        errorMessage: '',
      };
    },
    async mounted() {
      try {
        const response = await axios.get('https://localhost:7185/api/feedback');
        console.log("API Response:", response.data); //Debugging log
        this.feedbackList = response.data;
      } catch (error) {
        console.error('Axios error:', error.response || error.message);
        this.errorMessage = 'Virhe haettaessa palautteita.';
      }
    }
  };
</script>
