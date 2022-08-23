import React, { Component } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Home from './components/home';
import About from './components/about';
import Contact from './components/contact';
import './App.css';
import SignUp from './components/SignUp';
import Login from './components/Login';

class App extends Component {

  render() {
    return (
      <Router>
        <div className="App">
          <ul className="App-header">
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/about">About Us</Link>
            </li>
            <li>
              <Link to="/contact">Contact Us</Link>
            </li>
          </ul>
          <Routes>
            <Route exact path="/" element={<Home />}></Route>
            <Route exact path="/about" element={<About />}></Route>
            <Route exact path="/contact" element={<Contact />}></Route>
          </Routes>
        </div>
      </Router>
    );
  }

    render() {
        return (
            <Router>
                <Routes>
                        <Route exact path='/' element={< Home />}/>
                        <Route exact path='/about' element={< About />}/>
                        <Route exact path='/contact' element={< Contact />}/>
                        <Route exact path='/login' element={<Login/>}/>
                        <Route exact path='/signup' element={<SignUp/>}/>
                    </Routes>
                    <div className="App">
                    <ul className="App-header">
                        <li>
                            <Link to="/">Home</Link>
                        </li>
                        <li>
                            <Link to="/about">About Us</Link>
                        </li>
                        <li>
                            <Link to="/contact">Contact Us</Link>
                        </li>
                        <li>
                            <Link to="/login">Log In</Link>
                        </li>
                        <li>
                            <Link to="/signup">Sign Up</Link>
                        </li>
                    </ul>                   
                </div>
            </Router>
        );
    }
}

export default App;
