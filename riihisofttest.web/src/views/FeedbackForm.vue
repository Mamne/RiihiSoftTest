<template>
  <div class="feedback-form">
    <h2>Anna palautetta</h2>
    <form @submit.prevent="submitFeedback">
      <input v-model="feedback.sendersName" placeholder="Nimi" required />
      <input v-model="feedback.sendersEmail" type="email" placeholder="Sähköposti" required />
      <textarea v-model="feedback.text" placeholder="Viesti" required></textarea>
      <button type="submit" :disabled="isSubmitting">
        {{ isSubmitting ? 'Lähetetään...' : 'Lähetä' }}
      </button>
      <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
      <p v-if="successMessage" class="success">{{ successMessage }}</p>
    </form>
    <div class="back-button-container">
      <router-link to="/" class="back-button">Palaa etusivulle</router-link>
    </div>
  </div>
</template>

<script>
  import axios from 'axios';

  export default {
    data() {
      return {
        feedback: { sendersName: '', sendersEmail: '', text: '' },
        isSubmitting: false,
        errorMessage: '',
        successMessage: ''
      };
    },
    methods: {
      async submitFeedback() {
        if (this.isSubmitting) return;
        this.isSubmitting = true;
        this.errorMessage = '';
        this.successMessage = '';

        try {
          await axios.post('https://localhost:7185/api/feedback', this.feedback);
          this.successMessage = 'Palautteesi on lähetetty!';
          this.feedback = { sendersName: '', sendersEmail: '', text: '' };
        } catch (error) {
          this.errorMessage = 'Virhe palautteen lähettämisessä.';
        } finally {
          this.isSubmitting = false;
        }
      }
    }
  };
</script>

<style scoped>
  .feedback-form {
    max-width: 400px;
    margin: 0 auto;
    padding: 20px;
    border: 1px solid var(--color-border);
    border-radius: 8px;
    background: var(--color-background-soft);
  }

  input, textarea {
    width: 100%;
    margin-bottom: 10px;
    padding: 8px;
    border: 1px solid var(--color-border);
    border-radius: 4px;
    background: var(--color-background);
  }

  button {
    width: 100%;
    padding: 10px;
    background-color: var(--vt-c-indigo);
    color: var(--vt-c-white);
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }

    button:disabled {
      background-color: var(--color-border);
    }

  .error {
    color: var(--vt-c-black-soft);
    margin-top: 10px;
  }

  .success {
    color: var(--vt-c-black);
    margin-top: 10px;
  }

  .back-button-container {
    display: flex;
    justify-content: center;
    margin-top: 15px;
  }

  .back-button {
    padding: 10px 20px;
    background-color: var(--vt-c-indigo);
    color: var(--vt-c-white);
    text-decoration: none;
    border-radius: 4px;
    text-align: center;
  }

    .back-button:hover {
      background-color: var(--vt-c-black-soft);
    }
</style>
