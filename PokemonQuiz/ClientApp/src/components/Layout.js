import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';

const Layout = (props) => {
    return (
        <div>
            <NavMenu username={props.username}/>
            <Container>
                {props.children}
            </Container>
        </div>
    )
}
export default Layout;