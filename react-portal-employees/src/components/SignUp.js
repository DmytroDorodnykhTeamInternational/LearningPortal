import React from 'react'
import { Link } from 'react-router-dom'

function SignUp() {
  return (
    <div className=''>
          <div>
            <h2 className=''>Sign Up </h2> 
          </div>
          <form>
            <div className=''>
                <label className=''>Login</label>
                <input type='login'/>
            </div>
            <div className=''>
                <label className=''>Password</label>
                <input className='' type='password'  />
            </div>
            <div className=''>
                <label className=''>Password Сonfirmation</label>
                <input className='' type='password'  />
            </div>
            <button>Sign Up</button>
            <div>
                <p className=''>
                 Do you have an account? <Link to='/login' className=''>Sing In Here</Link>
                </p>
            </div>
          </form>
    </div>
  )
}

export default SignUp;
