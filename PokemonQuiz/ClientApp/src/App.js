import React, { useState, useEffect } from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import { Home } from './components/Home';
import Register from './components/Register';
import Login from './components/Login';
import Quiz from './components/Quiz';
import UserList from './components/UserList';
import PrivateRoute from './components/PrivateRoute';

import './custom.css';


const App = (props) => {
    const [username, setUsername] = useState();
    const [isLoaded, setIsLoaded] = useState(false);

    useEffect(() => {
        async function getInfo() {
            const response = await fetch('/user/getUsername');
            console.log(response);
            if (response.ok) {
                setUsername(await response.text());
                setIsLoaded(true);
            }
        }
        getInfo();
    }, []);

    if (!isLoaded) {
        return null;
    }

    return (
        <Layout username={username}>
            <Route exact path='/' component={Home} />
            <Route path='/register' component={Register} />
            <Route path='/login' component={Login} />
            <PrivateRoute path='/quiz' component={Quiz} loggedIn={username ? true : false} />
            <PrivateRoute path='/users' component={UserList} loggedIn={username ? true : false} />
        </Layout>
    )
}

export default App;