import React, { useState } from 'react'
import './studentfom.css'
import SubmitButton from '../submit-button/SubmitButton'
import axios from '../../api/axios'


const StudentForm = ({isopend}) => {
  const toggle = isopend ? "open" : "close"

  const POST_STUDENT_URL = "student/student"
  //student-form details
  const [name, setName] = useState('')
  const [surname, setSurname] = useState('')
  const [nationalIdNumber, setNationalIdNumber] = useState('')
  const [studentNumber, setStudentNumber] = useState('')
  const [dobstring, setDobstring] = useState('')
  const dob = new Date(dobstring)
  //

  const handleSubmitStudent = async (e) =>{
    // e.preventDefault()
    console.log(name, surname)
    try{
      const response = await axios.post(POST_STUDENT_URL, 
        JSON.stringify({name, surname, nationalIdNumber, studentNumber, 
          dob}),
        {
          headers: {"Content-Type" : "application/json"},
          withCredentials: false
        });
        console.log(JSON.stringify(response))
    }
    catch(err){
      
    }
  }




  return (
		<div className={`teacher-form ${toggle}`}>
			<form>
				<div className='form first'>
					<div className='details personal'>
						<span className='title'>Student Details</span>

						<div className='fields'>
							<div className='input-fields'>
								<label style={{ color: 'black' }}>Name</label>
								<input
									type='text'
									placeholder='Enter given name'
									onChange={(e) => setName(e.target.value)}
									required
								/>
							</div>
							<div className='input-fields'>
								<label style={{ color: 'black' }}>Surname</label>
								<input
									type='text'
									placeholder='Enter surname here'
									onChange={(e) => setSurname(e.target.value)}
									required
								/>
							</div>
							<div className='input-fields'>
								<label style={{ color: 'black' }}>National ID</label>
								<input
									type='text'
									placeholder='Enter national identity number'
									onChange={(e) => setNationalIdNumber(e.target.value)}
									required
								/>
							</div>

							<div className='input-fields'>
								<label style={{ color: 'black' }}>Student Number</label>
								<input
									type='text'
									placeholder='Enter national identity number'
									onChange={(e) => setStudentNumber(e.target.value)}
									required
								/>
							</div>

							<div className='input-fields'>
								<label style={{ color: 'black' }}>Gender</label>
								<select className='select-input'>
									<option>Male</option>
									<option>Femele</option>
									<option>Prefer Not Say</option>
								</select>
							</div>

							<div className='input-fields'>
								<label style={{ color: 'black' }}>Date of Birth</label>
								<input
									type='date'
									min='2001-01-01'
									placeholder='Date product was recieved'
									onChange={(e) => setDobstring(e.target.value)}
									required
								/>
							</div>
						</div>
						<SubmitButton buttonAction={handleSubmitStudent} />
					</div>
				</div>
			</form>
		</div>
	)
}

export default StudentForm