import Navbar from './components/navbar/Navbar'
import Teacher from './pages/teacher/Teacher'
import { Routes, Route } from 'react-router-dom'
import './App.css'
import Student from './pages/student/Student'
import Profile from './pages/Profile/Profile'
import TeacherProfile from './pages/teacher-profile/TeacherProfile'

function App() {
	return (
		<>
			<Navbar />
			<Routes>
				<Route path='/' element={<Teacher />} />
				<Route path='student' element={<Student />} />
				<Route path='student/:id' element={<Profile />} />
				<Route path='teacher/:id' element={<TeacherProfile />} />
			</Routes>
		</>
	)
}

export default App
