import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import './App.css'
import Header from './components/Header'

function App() {
    

      return (
          <Router>
              <Routes>
                  <Route exact path="/" component={Home} />
              </Routes>
                  
          </Router>
      )
}

export default App
