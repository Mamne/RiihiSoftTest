<template>
  <div class="home">
    <h1>Tervetuloa Nikon testisivulle!</h1>
    <p>Tällä sivulla voit antaa palautetta, tai lukea jo annettuja palautteita.</p>

    <div class="links">
      <router-link to="/about" class="link">Minusta</router-link>
      <router-link to="/contact" class="link">Yhteystiedot</router-link>
      <router-link to="/feedback" class="link">Anna palautetta</router-link>
      <router-link to="/feedback-list" class="link">Lue palautteita</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Home',
};
</script>

<style scoped>
  .home {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    min-height: 100vh;
    text-align: center;
    padding: 20px;
  }

  h1 {
    color: var(--color-heading);
    font-size: 2.5em;
  }

  p {
    font-size: 1.2em;
    margin: 20px 0;
  }

  .links {
    margin-top: 30px;
  }

  .link {
    font-size: 1.1em;
    color: var(--vt-c-indigo);
    margin: 0 15px;
    text-decoration: none;
  }

    .link:hover {
      text-decoration: underline;
    }
</style>
