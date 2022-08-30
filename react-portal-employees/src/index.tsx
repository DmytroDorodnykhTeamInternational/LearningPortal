import React from 'react';
import ReactDOM from 'react-dom/client';
import ResponsiveAppBar from './components/navBar';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <ResponsiveAppBar />
  </React.StrictMode>
);
