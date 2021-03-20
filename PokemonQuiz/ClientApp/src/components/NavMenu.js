import React, { Component, useEffect, useState } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

const NavMenu = ({ username }) => {
    const [collapsed, setCollapsed] = useState(false);

    const toggleNavbar = (e) => {
        setCollapsed(!collapsed);
    }

    const logout = async (e) => {
        e.preventDefault();
        await fetch('/auth/logout', { method: "POST" });
        window.location.reload();
    }

    const navItems = [
        { to: '/', text: 'Home', showIfLoggedIn: true, showIfLoggedOut: true },
        { to: '/login', text: 'Login', showIfLoggedIn: false, showIfLoggedOut: true },
        { to: '/register', text: 'Register', showIfLoggedIn: false, showIfLoggedOut: true },
        { to: '#', text: 'Logout', showIfLoggedIn: true, showIfLoggedOut: false, onClick: logout },
        { to: '/quiz', text: 'Quiz', showIfLoggedIn: true, showIfLoggedOut: false },
        { to: '/users', text: 'Users', showIfLoggedIn: true, showIfLoggedOut: false },
    ]

    return (
        <div>
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white box-shadow mb-0" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">PokemonQuiz</NavbarBrand>
                        <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={collapsed} navbar>
                            <ul className="navbar-nav flex-grow">
                                {navItems.map(el => {
                                    const loggedIn = username ? true : false;
                                    if ((el.showIfLoggedIn && loggedIn) || (el.showIfLoggedOut && !loggedIn)) {
                                        return (
                                            <NavItem>
                                                <NavLink onClick={el.onClick} tag={Link} className="text-dark" to={el.to}>{el.text}</NavLink>
                                            </NavItem>
                                        );
                                    }
                                })}
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
            <div className="bg-white border-bottom">
                <Container>
                    {username && <div className="text-right">Logged in as {username}</div>}
                </Container>
            </div>

        </div>
    );
}

export default NavMenu;