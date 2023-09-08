import './card.css'
import { FaTrash, FaEdit, FaEye } from 'react-icons/fa';


const Card = ({id, name, surname, identity, number, dob}) => {
  return (
    <div key={id} className='card'>
        <div style={{display: "flex", width: "100%", justifyContent: "space-between", alignItems: "center"}}>
            <h2 style={{color: "teal"}}>{name} {surname}</h2>
            <div style={{display: "flex", gap: "10px", justifyContent:"space-between"}}>
                <FaEye style={{color: "#F8C77E", cursor: "pointer"}}/>
                <FaTrash style={{color: "red", cursor: "pointer"}}/>
                <FaEdit style={{color: "teal", cursor: "pointer"}}/>
            </div>
        </div>
        <p>{number}</p>
        <small>{dob}</small>
    </div>
  )
}

export default Card