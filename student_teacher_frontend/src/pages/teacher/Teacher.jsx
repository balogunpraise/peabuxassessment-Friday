import { useEffect, useState } from 'react'
import CustomButton from '../../components/custom-button/CustomButton'
import TeacherForm from '../../components/teacher-form/TeacherForm'
import './teacher.css'
import Card from '../../components/card/Card'
import axios from '../../api/axios'

const Teacher = () => {
	const GET_TEACHER = 'teacher/teacher'
	const [formOpened, setFormOpend] = useState(false)
	const [returnData, setReturnData] = useState([])

	const getData = async () => {
		try {
			const response = await axios.get(GET_TEACHER)
			setReturnData(response.data.data)
		} catch (err) {
			console.log(err)
		}
	}

	const handlerSubmit = () => {
		setFormOpend(!formOpened)
	}

	useEffect(() => {
		getData()
	}, [])

	return (
		<div className='teacher'>
			<div className='action-button'>
				<CustomButton title='Add new teacher' action={handlerSubmit} />
			</div>
			<TeacherForm isopend={formOpened} />
			{returnData.map((item) => (
				<Card
					key={item.id}
					id={item.id}
					name={item.name}
					surname={item.surname}
					identity={item.nationalIdNumber}
					number={item.teacherNumber}
					dob={item.dob}
				/>
			))}
		</div>
	)
}

export default Teacher
