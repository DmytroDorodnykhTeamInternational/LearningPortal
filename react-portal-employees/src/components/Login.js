import React from 'react'
import { Link } from 'react-router-dom'

function Login() {
  return (
    <div className=''>
          <div>
            <h2 className=''>Sign In </h2>
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
            <button>Sign In</button>
            <div>
                <p className=''>
                    Don`t have an account? <Link to='/signup' className=''>Sing Up Here</Link>
                </p>
            </div>
          </form>
    </div>
  )
}

export default Login;
