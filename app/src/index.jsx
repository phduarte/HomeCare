import React from "react";
import {createRoot} from "react-dom/client";
import './img/favicon.ico'
import './css/index.css'
import './css/bootstrap.min.css'
import App from './components/App'

createRoot(
    document.getElementById('main')
).render(<App />)