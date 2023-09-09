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
				<h1 style={{ color: '#e3e3e3' }}>
					{student.name} {student.surname}
				</h1>
				<div className='other-details' style={{display: 'flex', flexDirection: 'column',
				justifyContent: 'center',
				alignItems: 'center'
			}}>
					<h3>{student.studentNumber}</h3>
					<h3>
						Age: {Math.floor(Math.abs(Date.now() - new Date(student.dob)) / (1000
							* 3600 * 24 * 360))}
					</h3>
				</div>
			</div>

			<div className='right'></div>
		</div>
	)
}

export default Profile
