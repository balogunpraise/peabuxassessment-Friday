import React from 'react'
import './custom-button.css'
const CustomButton = ({title, action}) => {
  return (
    <button className='custom-button' onClick={action}>{title}</button>
  )
}

export default CustomButton