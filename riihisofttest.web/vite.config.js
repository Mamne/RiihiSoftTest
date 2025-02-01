import { defineConfig } from 'vite';
import { fileURLToPath, URL } from 'node:url'
import plugin from '@vitejs/plugin-vue';
//import path from 'path';

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [plugin()],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
    server: {
        port: 50995,
    }
})
