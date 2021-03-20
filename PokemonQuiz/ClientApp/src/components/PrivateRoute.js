import React from 'react';
import { Route, Redirect } from 'react-router';

const PrivateRoute = ({ component, ...rest }) => {
    return (
        {...rest.loggedIn ? 
            <Route component={component} { ...rest } /> :
            <Redirect to="/" />
        }    
    )
}

export default PrivateRoute;