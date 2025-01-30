<template>
  <div>
    <h2>Saadut palautteet</h2>
    <ul>
      <li v-for="feedback in feedbacks" :key="feedback.id">
        <strong>{{ feedback.name }}</strong> ({{ feedback.email }}): {{ feedback.message }}
      </li>
    </ul>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return { feedbacks: [] };
  },
  async mounted() {
    const response = await axios.get('http://localhost:5000/api/feedback');
    this.feedbacks = response.data;
  }
};
</script>
