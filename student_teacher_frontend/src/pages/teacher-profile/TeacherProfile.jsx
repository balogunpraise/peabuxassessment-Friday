import { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import axios from '../../api/axios'


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
	return <div>{teacher.name}</div>
}

export default TeacherProfile
