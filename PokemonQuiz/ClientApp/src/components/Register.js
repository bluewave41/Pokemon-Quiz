import React, { useState } from 'react';
import './Register.css';
    
const Register = (props) => {
    const [user, setUser] = useState({ username: '', password: '' });
    const [message, setMessage] = useState('');

    const onChange = (e) => {
        setUser({
            ...user,
            [e.target.name]: e.target.value
        });
    }

    const onSubmit = async (e) => {
        e.preventDefault();

        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        }

        const response = await fetch('/auth/register', options);
        setMessage(await response.text());
    }

    return (
        <div>
            <h1>Register</h1>
            <form>
                <label>Username: </label><input type="text" name="username" onChange={onChange} />
                <label>Password: </label><input type="password" name="password" onChange={onChange} />
                <button onClick={onSubmit}>Submit</button>
            </form>
            <p>{message}</p>
        </div>
    )
}

export default Register;