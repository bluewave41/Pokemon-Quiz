import React, { useState, useEffect } from 'react';
import User from './User';

const UserList = (props) => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        async function getUsers() {
            const response = await fetch('/user/get');
            setUsers(await response.json());
        }
        getUsers();
    }, []);

    return (
        <div>
            <h1>User List</h1>
            <table className="table">
                <thead>
                    <tr>
                        <th>
                            Username
                        </th>
                        <th>
                            Correct Answers
                        </th>
                        <th>
                            Incorrect Answers
                        </th>
                        <th>
                            Percentage
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(el => (
                        <User user={el} />
                    ))}
                </tbody>
            </table>
        </div>
    )
}

export default UserList;