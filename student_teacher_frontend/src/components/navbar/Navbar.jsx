import './navbar.css'
import { Link } from 'react-router-dom'

const Navbar = () => {
  return (
    <header>
      <div className="container">
        <div className="logo">
          <h1>LO<span>GO</span></h1>
        </div>
        <div className="links">
          <ul>
            <li><Link style={{textDecoration: "none"}} className='btn1' to="/">Teachers</Link></li>
            <li><Link style={{textDecoration: "none"}} className='btn1' to="/student">Students</Link></li>
          </ul>
        </div>
        {/* <div className='hamburger'><MenuIcon /></div> */}
      </div>
    </header>
  )
}

export default Navbar