import React from 'react';
import { Link } from 'react-router-dom';

function Login() {
  return (
    <div>
      <div>
        <h2>Sign In </h2>
      </div>
      <form>
        <div>
          <label>Login</label>
          <input type="login" />
        </div>
        <div>
          <label>Password</label>
          <input type="password" />
        </div>
        <button>Sign In</button>
        <div>
          <p>
            Don`t have an account? <Link to="/signup">Sing Up Here</Link>
          </p>
        </div>
      </form>
    </div>
  );
}

export default Login;
