// import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import Home from './pages/Home'
import PostInfoPage from './pages/PostInfoPage'

function App() {

    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home/>} />
                <Route path="/cars/:carId" element={<PostInfoPage/>} />
            </Routes>
        </Router>
    )
}

export default App
