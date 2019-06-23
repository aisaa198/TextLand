import React from 'react';
import './App.css';
import { Login } from './Login.js';

class App extends React.Component {
	
	render(){
		return (
			<div>
				<h1>TEXTLAND</h1>
				<Login></Login>
			</div>
		);
	}
}

export default App;
