<template>
  <div>
    <h2>Saadut palautteet</h2>
    <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
    <div v-if="feedbackList.length">
      <div v-for="feedback in feedbackList" :key="feedback.id" class="feedback-item">
        <div class="feedback-header">
          <strong>{{ feedback.sendersName }}</strong>
          <span class="feedback-date">{{ new Date(feedback.createdAt).toLocaleString() }}</span>
        </div>
        <div class="feedback-body">
          <p class="feedback-text">{{ feedback.text }}</p>
        </div>
      </div>
    </div>
    <p v-else>Ei palautteita vielä.</p>
    <div v-if="totalPages > 1" class="pagination-container">
      <button class="pagination-button"
              :disabled="currentPage <= 1"
              @click="changePage(currentPage - 1)">
        Edellinen
      </button>
      <span>Page {{ currentPage }} / {{ totalPages }}</span>
      <button class="pagination-button"
              :disabled="currentPage >= totalPages"
              @click="changePage(currentPage + 1)">
        Seuraava
      </button>
    </div>
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
        feedbackList: [],
        errorMessage: '',
        currentPage: 1,
        pageSize: 5,
        totalPages: 1,
      };
    },
    async mounted() {
      await this.fetchFeedback();
    },
    methods: {
      async fetchFeedback() {
        try {
          const apiBaseUrl = import.meta.env.VITE_API_BASE_URL;
          const response = await axios.get(`${apiBaseUrl}/feedback/paginated`, {
            params: {
              pageNumber: this.currentPage,
              pageSize: this.pageSize,
            },
          });

          if (response.data && Array.isArray(response.data.feedbacks)) {
            this.feedbackList = response.data.feedbacks;
            this.totalPages = Math.ceil(response.data.totalCount / this.pageSize);
          } else {
            this.feedbackList = [];
            this.totalPages = 1;
          }
        } catch (error) {
          console.error('Axios error:', error.response || error.message);
          this.errorMessage = 'Virhe haettaessa palautteita.';
        }
      },
            
      changePage(pageNumber) {
        if (pageNumber >= 1 && pageNumber <= this.totalPages) {
          this.currentPage = pageNumber;
          this.fetchFeedback();
        }
      },
    },
  };
</script>

<style scoped>
  .error {
    color: red;
    font-weight: bold;
    margin-top: 20px;
  }

  .feedback-item {
    border: 1px solid var(--color-border);
    border-radius: 8px;
    padding: 15px;
    margin: 15px 0;
    background-color: var(--color-background-soft);
    word-wrap: break-word;
    overflow-wrap: break-word;
    word-break: break-word;
    width: 600px;
    min-width: 600px;
    margin-left: auto;
    margin-right: auto;
  }



  .feedback-header {
    display: flex;
    justify-content: space-between;
    margin-bottom: 10px;
  }

    .feedback-header strong {
      font-size: 1.2em;
      color: var(--color-heading);
    }

  .feedback-date {
    font-size: 0.9em;
    color: var(--color-text-light-2);
  }

  .feedback-body p {
    font-size: 1.1em;
    line-height: 1.6;
    margin: 0;
    color: var(--color-text);
  }

  .back-button-container {
    display: flex;
    justify-content: center;
    margin-top: 20px;
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

  .feedback-text {
    white-space: pre-wrap;
    word-wrap: break-word;
    text-align: left;
  }

  .pagination-container {
    display: flex;
    justify-content: center;
    margin-top: 20px;
  }

  .pagination-button {
    padding: 10px;
    background-color: var(--vt-c-indigo);
    color: var(--vt-c-white);
    border: none;
    border-radius: 4px;
    margin: 0 5px;
  }

    .pagination-button:disabled {
      background-color: var(--vt-c-black-soft);
      cursor: not-allowed;
    }

    .pagination-button:hover:not(:disabled) {
      background-color: var(--vt-c-black-soft);
    }
</style>
