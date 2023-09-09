import { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import axios from '../../api/axios'
import pic from '../../asset/av.avif'


const TeacherProfile = () => {
	const GET_TEACHER_URL = 'teacher/teacher'
	const { id } = useParams()
	const [teacher, setTeacher] = useState({})

	const handleTeacherProfile = async () => {
        const response = await axios.get(`${GET_TEACHER_URL}/${id}`).then()
        console.log(response);
		setTeacher(response.data.data)
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

			<div className='right'></div>
		</div>
    )
}

export default TeacherProfile
