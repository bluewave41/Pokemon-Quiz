import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <div>
            <h1>Welcome to Pokemon Quiz!</h1>
            <p>Pokemon Quiz is the best way to train your knowledge of the first 151 Pokemon.</p>
            <p>Here you will be tested on various Pokemon attributes such as: </p>
            <ul>
                <li>Pokedex IDs</li>
                <li>Evolutions</li>
                <li>Evolution Methods</li>
            </ul>
        </div>
    );
  }
}
