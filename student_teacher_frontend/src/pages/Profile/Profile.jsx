import { useEffect, useState } from 'react'
import { useParams, useNavigate } from 'react-router-dom'
import axios from '../../api/axios'
import './profilec.css'
import pic from '../../asset/av.avif'
import CustomButton from '../../components/custom-button/CustomButton'
import { SecurityUpdate } from '@mui/icons-material'


const Profile = () => {
	const GET_STUDENT_ROUTE = 'student/student'
	const { id } = useParams()
	const UPDATE_STUDENT_ROUTE = "student/student"
	const navigate = useNavigate()
	//console.log(id)
	const [student, setStudent] = useState({})
	const [updateDetails, setUpdateDetails] = useState([])

	const getProfile = async () => {
		const response = await axios.get(`${GET_STUDENT_ROUTE}/${id}`).then()
		console.log(response)
		setStudent(response.data.data)
	}

	async function editAction() {
		await axios.put(`${UPDATE_STUDENT_ROUTE}/${id}`, updateDetails)
			.then(res => {
			navigate('/')
		})
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
					<h3>{student.nationalIdNumber}</h3>
				</div>
			</div>

			<div className='right'>
				<div className='formControl'>
					<label>Name</label>
					<input
						type='text'
						onChange={(e) => setUpdateDetails({...updateDetails, name: e.target.value})}
						placeholder={student.name} />
				</div>
				<div className='formControl'>
					<label>Surname</label>
					<input
						onChange={(e) => setUpdateDetails({ ...updateDetails, surname: e.target.value })}
						type='text' placeholder={student.surname} />
				</div>
				<div className='formControl'>
					<label>Student Number</label>
					<input
						type='text'
						onChange={(e) => SecurityUpdate({...updateDetails, studentNumber: e.target.value})}
						placeholder={student.studentNumber} />
				</div>
				<div className='formControl'>
					<label>National Id</label>
					<input
						onChange={(e) => setUpdateDetails({...updateDetails, nationalIdNumber: e.target.value})}
						type='text'
						placeholder={student.nationalIdNumber} />
				</div>
				<div className='formControl'>
					<CustomButton title="Edit Student" action={editAction}/>
				</div>
			</div>
		</div>
	)
}

export default Profile
