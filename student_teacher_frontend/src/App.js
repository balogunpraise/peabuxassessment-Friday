import Navbar from './components/navbar/Navbar';
import Teacher from './pages/teacher/Teacher';
import {Routes, Route } from 'react-router-dom';
import './App.css'

function App() {
  return (
    <>
      <Navbar />
        <Routes>
          <Route path="/" element={<Teacher />} />
        </Routes>
    </>
  )
}

export default App;
