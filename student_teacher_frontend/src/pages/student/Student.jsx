import { useEffect, useState } from 'react'
import CustomButton from '../../components/custom-button/CustomButton'
import TeacherForm from '../../components/teacher-form/TeacherForm'
import './student.css'
import StudentForm from '../../components/student-form/StudentForm'

const Student = () => {

  const GET_TEACHER = "/teacher"
  const [formOpened, setFormOpend] = useState(false)
  const [data, setData] = useState([]);


  const handlerSubmit = () =>{
    setFormOpend(!formOpened)
  }
  return (
    <div className='student'>
      <div className="action-button">
        <CustomButton title="Add new student" action={handlerSubmit}/>
      </div>
      <StudentForm isopend={formOpened}/>
    </div>
  )
}

export default Student