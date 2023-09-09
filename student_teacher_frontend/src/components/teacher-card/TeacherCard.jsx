import axios from '../../api/axios'
import '../card/card.css'
import { Link } from 'react-router-dom'
import { FaTrash, FaEdit } from 'react-icons/fa'

const TeacherCard = ({
	id,
	name,
	surname,
	identity,
	number,
	dob,
	route,
}) => {
	const DELETE_ROUTE = route
	const handleDelete = async () => {
		try {
			console.log(id)
			const response = await axios.delete(`${DELETE_ROUTE}/${id}`)
			console(response.data.data)
		} catch (err) {
			console.log(err)
		}
	}

	// const handleViewProfile = async () => {
	//   try {

	//   }
	//   catch (err) {
	//     console.log(err)
	//   }
	// }

	return (
		<div key={id} className='card'>
			<div
				style={{
					display: 'flex',
					width: '100%',
					justifyContent: 'space-between',
					alignItems: 'center',
				}}
			>
				<h2 style={{ color: 'teal' }}>
					{name} {surname}
				</h2>
				<div
					style={{
						display: 'flex',
						gap: '10px',
						justifyContent: 'space-between',
					}}
				>
					<Link to={`/teacher/${id}`}>
						<FaEdit style={{ color: 'teal', cursor: 'pointer' }} />
					</Link>
					<FaTrash
						onClick={handleDelete}
						style={{ color: 'red', cursor: 'pointer' }}
					/>
				</div>
			</div>
			<p>{number}</p>
			<small>{dob}</small>
		</div>
	)
}

export default TeacherCard
