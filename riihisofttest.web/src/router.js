import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '@/views/HomePage.vue';
import About from '@/views/About.vue';
import Contact from '@/views/Contact.vue';
import FeedbackForm from '@/views/FeedbackForm.vue';
import FeedbackList from '@/views/FeedbackList.vue';

const routes = [
  { path: '/', component: HomePage },
  { path: '/about', component: About },
  { path: '/contact', component: Contact },
  { path: '/feedback', component: FeedbackForm },
  { path: '/feedback-list', component: FeedbackList },
];

const router = createRouter({ history: createWebHistory(), routes });
export default router;
