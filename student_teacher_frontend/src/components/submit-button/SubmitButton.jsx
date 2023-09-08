import './submit-button.css'
import { FaCheck } from 'react-icons/fa'
const SubmitButton = ({buttonAction}) => {
  return (
    <button onClick={buttonAction} className='completebtn'>
        <span className='btnmessage'>Complete</span>
        <FaCheck />
    </button>
  )
}

export default SubmitButton