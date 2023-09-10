import { useState } from 'react'
import './teacherform.css'
import SubmitButton from '../submit-button/SubmitButton'
import axios from '../../api/axios'

const TeacherForm = ({ isopend }) => {
	const POST_TEACHER_URL = 'teacher/teacher'
	//student-form details
	const [name, setName] = useState('')
	const [surname, setSurname] = useState('')
	const [nationalIdNumber, setNationalIdNumber] = useState('')
	const [teacherNumber, setTeacherNumber] = useState('')
	const [title, setTitle] = useState(1)
	const [salary, setSalary] = useState(0)
	const [dobstring, setDobstring] = useState('')
	const dob = new Date(dobstring)

	const handleSelected = (e) => {
		setTitle(e.target.value)
	}

	const handleSubmitTeacher = async (e) => {
		console.log(title)
		//e.preventDefault()
		try {
			const response = await axios.post(
				POST_TEACHER_URL,
				JSON.stringify({
					name,
					surname,
					nationalIdNumber,
					title,
					teacherNumber,
					salary,
					dob,
				}),
				{
					headers: { 'Content-Type': 'application/json' },
					withCredentials: false,
				}
			)
			console.log(JSON.stringify(response))
		} catch (err) {}
	}

	const titleOpt = [
		{ label: 'Mr', value: 1 },
		{ label: 'Mrs', value: 2 },
		{ label: 'Miss', value: 3 },
		{ label: 'Prof', value: 4 },
		{ label: 'Dr', value: 5 },
	]

	const toggle = isopend ? 'open' : 'close'
	return (
		<div className={`teacher-form ${toggle}`}>
			<form>
				<div className='form first'>
					<div className='details personal'>
						<span className='title'>Teacher Details</span>

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
									onChange={(e) => setNationalIdNumber(e.target.value)}
									placeholder='Enter national identity number'
									required
								/>
							</div>

							<div className='input-fields'>
								<label style={{ color: 'black' }}>Teacher Number</label>
								<input
									onChange={(e) => setTeacherNumber(e.target.value)}
									type='text'
									placeholder='Enter national identity number'
									required
								/>
							</div>

							<div className='input-fields'>
								<label style={{ color: 'black' }}>Title</label>
								<select
									value={title}
									onChange={handleSelected}
									// className='select-input'
								>
									{titleOpt.map((opt) => (
										<option key={opt.value} value={opt.value}>
											{opt.label}
										</option>
									))}
								</select>
							</div>
							<div className='input-fields'>
								<label style={{ color: 'black' }}>Date of Birth</label>
								<input
									type='date'
									max='2002-01-01'
									onChange={(e) => setDobstring(e.target.value)}
									placeholder='Date product was recieved'
									required
								/>
							</div>
							<div className='input-fields'>
								<label style={{ color: 'black' }}>Salary</label>
								<input
									onChange={(e) => setSalary(e.target.value)}
									type='number'
									placeholder='Enter Salary'
									required
								/>
							</div>
						</div>
						<SubmitButton buttonAction={handleSubmitTeacher} />
					</div>
				</div>
			</form>
		</div>
	)
}

export default TeacherForm
