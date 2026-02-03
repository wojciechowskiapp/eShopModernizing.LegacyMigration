import { defineConfig } from 'vite';
import { resolve } from 'path';

export default defineConfig({
  build: {
    outDir: 'wwwroot/dist',
    emptyOutDir: true,
    manifest: true,
    rollupOptions: {
      input: {
        jquery: resolve(__dirname, 'src/js/jquery-{version}.js'),
        jqueryval: resolve(__dirname, 'src/js/jquery.validate*'),
        modernizr: resolve(__dirname, 'src/js/modernizr-*'),
        bootstrap: resolve(__dirname, 'src/js/bootstrap.js'),
        Content-css: resolve(__dirname, 'src/css/bootstrap.css')
      }
    }
  },
  server: {
    port: 5173,
    strictPort: true
  },
  resolve: {
    alias: {
      '@': resolve(__dirname, 'src'),
      '~/Scripts': resolve(__dirname, 'src/js'),
      '~/Content': resolve(__dirname, 'src/css')
    }
  }
});