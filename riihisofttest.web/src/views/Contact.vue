<template>
  <div class="contact">
    <h2>Yhteystiedot</h2>
    <p>Voit ottaa minuun yhteyttä seuraavasti:</p>

    <ul>
      <li><strong>Sähköposti:</strong> info@example.com</li>
      <li><strong>Puhelin:</strong> +358 123 456 789</li>
      <li><strong>Osoite:</strong> Esimerkkikatu 12, 00100 Helsinki</li>
    </ul>

    <div class="back-button-container">
      <router-link to="/" class="back-button">Palaa etusivulle</router-link>
    </div>
  </div>
</template>

<style scoped>
  .contact {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    max-width: 500px;
    margin: 0 auto;
    text-align: center;
    padding: 20px;
    background: var(--color-background-soft);
    border: 1px solid var(--color-border);
    border-radius: 8px;
  }

  h2 {
    color: var(--color-heading);
    font-size: 2em;
  }

  ul {
    text-align: left;
    margin: 20px 0;
    padding: 0;
    list-style-type: none;
  }

  li {
    margin-bottom: 8px;
  }  

  p {
    color: var(--color-text);
    margin-top: 15px;
  }

  .back-button-container {
    display: flex;
    justify-content: center;
    margin-top: 20px;
  }
</style>
