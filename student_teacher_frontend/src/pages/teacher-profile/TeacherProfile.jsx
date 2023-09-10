import { useEffect, useState } from 'react'
import { useParams, useNavigate } from 'react-router-dom'
import axios from '../../api/axios'
import pic from '../../asset/av.avif'
import CustomButton from '../../components/custom-button/CustomButton'


const TeacherProfile = () => {
	const GET_TEACHER_URL = 'teacher/teacher'
	const { id } = useParams()
	const [teacher, setTeacher] = useState({})
	const [updateDetails, setUpdateDetails] = useState([])
	const navigate = useNavigate()
	const UPDATE_TEACHER_ROUTE = "teacher/teacher"

	const handleTeacherProfile = async () => {
        const response = await axios.get(`${GET_TEACHER_URL}/${id}`).then()
        console.log(response);
		setTeacher(response.data.data)
    }
    
	async function editAction() {
		await axios.put(`${UPDATE_TEACHER_ROUTE}/${id}`, updateDetails)
			.then(res => {
			navigate(`/teacher/${id}`)
		})
		handleTeacherProfile()
	}

    useEffect(() => {
        handleTeacherProfile()
    },[])
	return(
        <div className='profile'>
			<div className='left'>
				<img
					src={pic}
					alt=''
					style={{ width: '100px', height: '100px', borderRadius: '50%' }}
				/>
				<h1 style={{ color: '#e3e3e3' }}>
					{teacher.name} {teacher.surname}
				</h1>
				<div className='other-details' style={{display: 'flex', flexDirection: 'column',
				justifyContent: 'center',
				alignItems: 'center'
			}}>
					<h3>{teacher.teacherNumber}</h3>
					<h3>
						Age: {Math.floor(Math.abs(Date.now() - new Date(teacher.dob)) / (1000
							* 3600 * 24 * 360))}
					</h3>
                    <h3>Salary: ${teacher.salary}</h3>
				</div>
			</div>

			<div className='right'>
			<div className='formControl'>
					<label>Name</label>
					<input
						type='text'
						onChange={(e) => setUpdateDetails({...updateDetails, name: e.target.value})}
						placeholder={teacher.name} />
				</div>
				<div className='formControl'>
					<label>Surname</label>
					<input
						onChange={(e) => setUpdateDetails({ ...updateDetails, surname: e.target.value })}
						type='text' placeholder={teacher.surname} />
				</div>
				<div className='formControl'>
					<label>Student Number</label>
					<input
						type='text'
						onChange={(e) => setUpdateDetails({...updateDetails, studentNumber: e.target.value})}
						placeholder={teacher.teacherNumber} />
				</div>
				<div className='formControl'>
					<label>National Id</label>
					<input
						onChange={(e) => setUpdateDetails({...updateDetails, nationalIdNumber: e.target.value})}
						type='text'
						placeholder={teacher.nationalIdNumber} />
				</div>
				<div className='formControl'>
					<CustomButton title="Edit teacher" action={editAction}/>
				</div>
			</div>
		</div>
    )
}

export default TeacherProfile
