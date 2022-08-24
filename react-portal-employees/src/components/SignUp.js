import React from 'react'
import { Link } from 'react-router-dom'

function SignUp() {
  return (
    <div>
          <div>
            <h2>Sign Up </h2> 
          </div>
          <form>
            <div>
                <label>Login</label>
                <input type='login'/>
            </div>
            <div>
                <label>Password</label>
                <input type='password'  />
            </div>
            <div>
                <label>Password Сonfirmation</label>
                <input type='password'  />
            </div>
            <button>Sign Up</button>
            <div>
                <p>
                 Do you have an account? <Link to='/login'>Sing In Here</Link>
                </p>
            </div>
          </form>
    </div>
  )
}

export default SignUp;
