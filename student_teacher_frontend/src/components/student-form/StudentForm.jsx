import React from 'react'
import './studentfom.css'
import SubmitButton from '../submit-button/SubmitButton'

const StudentForm = ({isopend}) => {
  const toggle = isopend ? "open" : "close"
  return (
    <div className={`teacher-form ${toggle}`}>
      <form>
        <div className="form first">
          <div className="details personal">
            <span className="title">Student Details</span>

            <div className="fields">
              <div className="input-fields">
                <label style={{color: "black"}}>Name</label>
                <input type='text' placeholder='Enter given name' required/>
              </div>
              <div className="input-fields">
                <label style={{color: "black"}}>Surname</label>
                <input type='text' placeholder='Enter surname here' required/>
              </div>
              <div className="input-fields">
                <label style={{color: "black"}}>National ID</label>
                <input type='text' placeholder='Enter national identity number' required/>
              </div>

              <div className="input-fields">
                <label style={{color: "black"}}>Student Number</label>
                <input type='text' placeholder='Enter national identity number' required/>
              </div>


              <div className="input-fields">
                <label style={{color: "black"}}>Gender</label>
                <select className='select-input'>
                  <option>Male</option>
                  <option>Femele</option>
                  <option>Others</option>
                </select> 
              </div>

              <div className="input-fields">
                <label style={{color: "black"}}>Date of Birth</label>
                <input type='date' placeholder='Date product was recieved' required/>
              </div>
            </div>
            <SubmitButton />
          </div>
        </div>
      </form>
    </div>
  )
}

export default StudentForm