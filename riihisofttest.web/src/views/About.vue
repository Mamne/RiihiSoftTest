<template>
  <div class="about">
    <h2>Tietoa meistä</h2>
    <p>Tämä on esittelysivu. Ohessa kuva yhdestä onnistuneimmista juustokakuistani: Appelsiini-mangojuustokakku.</p>
    <div class="back-button-container">
      <router-link to="/" class="back-button">Palaa etusivulle</router-link>
    </div>
    <img src="@/components/MAJK.jpg" alt="Juustokakku" class="ck-image" />
  </div>
</template>

<style scoped>
  .about {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    min-height: 100vh;
    text-align: center;
    padding: 20px;
  }

  .ck-image {
    max-width: 100%;
    height: auto;
    margin-top: 20px;
    border-radius: 10px;
  }

  .back-button-container {
    display: flex;
    justify-content: center;
    margin-top: 20px;
  }
</style>
