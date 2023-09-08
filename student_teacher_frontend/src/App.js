import Navbar from './components/navbar/Navbar';
import Teacher from './pages/teacher/Teacher';
import {Routes, Route } from 'react-router-dom';
import './App.css'
import Student from './pages/student/Student';

function App() {
  return (
    <>
      <Navbar />
        <Routes>
          <Route path="/" element={<Teacher />} />
          <Route path="student" element={<Student/>}/>
        </Routes>
    </>
  )
}

export default App;
