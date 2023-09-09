import { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import axios from '../../api/axios'
import './profilec.css'
import pic from '../../asset/av.avif'

const Profile = () => {
	const GET_STUDENT_ROUTE = 'student/student'
	const { id } = useParams()
	//console.log(id)
	const [student, setStudent] = useState({})

	const getProfile = async () => {
		const response = await axios.get(`${GET_STUDENT_ROUTE}/${id}`).then()
		console.log(response)
		setStudent(response.data.data)
	}

	useEffect(() => {
		getProfile()
	},[])

	return (
		<div className='profile'>
			<div className='left'>
				<img
					src={pic}
					alt=''
					style={{ width: '100px', height: '100px', borderRadius: '50%' }}
				/>
				<h3 style={{ color: '#e3e3e3' }}>
					{student.name} {student.surname}
				</h3>
				<div className='other-details'>
					<p>{student.dob}</p>
					<p>{student.studentNumber}</p>
					<p>
						Age: {Math.floor(Math.abs(Date.now() - new Date(student.dob)) / (1000
							* 3600 * 24 * 360))}
					</p>
				</div>
			</div>

			<div className='right'></div>
		</div>
	)
}

export default Profile
