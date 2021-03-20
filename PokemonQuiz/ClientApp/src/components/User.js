import React from 'react';

const User = ({ user }) => {
    return (
        <tr>
            <td>{user.username}</td>
            <td>{user.correctAnswers}</td>
            <td>{user.incorrectAnswers}</td>
            <td>{user.percentage}</td>
        </tr>
    )
}

export default User;