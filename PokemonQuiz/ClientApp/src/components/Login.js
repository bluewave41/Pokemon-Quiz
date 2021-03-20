import React, { useState } from 'react';
import './Register.css';
import { useHistory } from 'react-router-dom';

const Register = (props) => {
    const [user, setUser] = useState({ username: '', password: '' });
    const [error, setError] = useState('');
    const history = useHistory();

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

        const response = await fetch('/auth/login', options);
        if (!response.ok) {
            return setError(await response.text());
        }
        else {
            window.location.replace('/');
        }
    }

    return (
        <div>
            <h1>Login</h1>
            <form>
                <label>Username: </label><input type="text" name="username" onChange={onChange} />
                <label>Password: </label><input type="text" name="password" onChange={onChange} />
                <button onClick={onSubmit}>Submit</button>
            </form>
            <p>{error}</p>
        </div>
    )
}

export default Register;