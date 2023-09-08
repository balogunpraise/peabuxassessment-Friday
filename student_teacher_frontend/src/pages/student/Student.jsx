import { useEffect, useState } from 'react'
import CustomButton from '../../components/custom-button/CustomButton'
import './student.css'
import Card from '../../components/card/Card'
import axios from '../../api/axios'
import StudentForm from '../../components/student-form/StudentForm'

const Student = () => {

  const GET_STUDENT = "student/student"
  const [formOpened, setFormOpend] = useState(false)
  const [data, setData] = useState([]);



  const getData = async () => {
    try{
      const response = await axios.get(GET_STUDENT);
      setData(response.data.data);
    }
    catch(err){
       console.log(err)
    }

  };

  useEffect(() => {
    getData();
  }, []);

  const handlerSubmit = () =>{
    setFormOpend(!formOpened)
  }
  return (
    <div className='student'>
      <div className="action-button">
        <CustomButton title="Add new student" action={handlerSubmit}/>
      </div>
      <StudentForm isopend={formOpened}/>
      <div className='card-container'>
        {
          data.map((item) => (
            <Card key={item.id} id={item.id} 
              name={item.name} 
              surname={item.surname} 
              identity={item.nationalIdNumber} 
              number={item.teacherNumber}
              dob={item.dob}/>
          ))
        }
      </div>
     
    </div>
  )
}

export default Student