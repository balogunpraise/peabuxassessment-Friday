import { useEffect, useState } from 'react'
import CustomButton from '../../components/custom-button/CustomButton'
import TeacherForm from '../../components/teacher-form/TeacherForm'
import './teacher.css'
import Card from '../../components/card/Card'
import axios from '../../api/axios'

const Teacher = () => {

  const GET_TEACHER = "/teacher"
  const [formOpened, setFormOpend] = useState(false)
  const [data, setData] = useState([]);


  // const getData = async () => {
  //   try{
  //     const response = await axios.get(GET_TEACHER);
  //     //setData(response.data);
  //     console.log(response)
  //   }
  //   catch(err){
  //      console.log(err)
  //   }

  // };


  // useEffect(() => {
  //   axios.get('http://localhost:5288/teacher').then(response => {
  //     console.log(response.data);
  //   });
  // }, []);

  useEffect(() => {
    const url = "http://localhost:5288/Teacher/teacher";

    const fetchData = async () => {
      try 
      {
        const response = await fetch(url);
        //const json = await response.json();
        console.log(response);
      } 
      catch (error) {
        console.log("error", error);
      }
    };

    fetchData();
}, []);



  const handlerSubmit = () =>{
    setFormOpend(!formOpened)
  }

  // useEffect(() => {
  //   getData();
  // }, []);

  return (
    <div className='teacher'>
      <div className="action-button">
        <CustomButton title="Add new teacher" action={handlerSubmit}/>
      </div>
      <TeacherForm isopend={formOpened}/>
      {/* <div className='card-pane'>
        {
          data.map((item, index) => (
            <Card key={index} id={item.Id} 
              name={item.Name} 
              surname={item.Surname} 
              identity={item.NationalId} 
              number={item.TeacherNumber}
              dob={item.DOB}/>
          ))
        }
      </div> */}
    </div>
  )
}

export default Teacher