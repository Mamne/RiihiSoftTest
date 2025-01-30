<template>
  <div class="home">
    <h1>Welcome to Our Website</h1>
    <p>We are glad you're here. Explore our site to know more about us!</p>

    <div class="links">
      <router-link to="/about" class="link">About Us</router-link>
      <router-link to="/contact" class="link">Contact Us</router-link>
      <router-link to="/feedback" class="link">Give Feedback</router-link>
      <router-link to="/feedback-list" class="link">View Feedback</router-link>
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
    text-align: center;
    padding: 20px;
  }

  h1 {
    color: #2c3e50;
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
    color: #42b983;
    margin: 0 15px;
    text-decoration: none;
  }

    .link:hover {
      text-decoration: underline;
    }
</style>
