import React from 'react'
import './teacherform.css'

const TeacherForm = ({isopend}) => {
  const toggle = isopend ? "open" : "close"
  return (
    <div className={`teacher-form ${toggle}`}>
      <form>
        <div className="form first">
          <div className="details personal">
            <span className="title">Teacher Details</span>

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
                <label style={{color: "black"}}>Teacher Number</label>
                <input type='text' placeholder='Enter national identity number' required/>
              </div>

              
              <div className="input-fields">
                <label style={{color: "black"}}>Title</label>
                <select className='select-input'>
                  <option>Mr</option>
                  <option>Mrs</option>
                  <option>Miss</option>
                  <option>Dr</option>
                  <option>Prof</option>
                </select> 
              </div>
              <div className="input-fields">
                <label style={{color: "black"}}>Date of Birth</label>
                <input type='date' placeholder='Date product was recieved' required/>
              </div>
              <div className="input-fields">
                <label style={{color: "black"}}>Salary</label>
                <input type='number' placeholder='Enter Salary' required/>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  )
}

export default TeacherForm