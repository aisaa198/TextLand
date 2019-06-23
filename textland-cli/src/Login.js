import React from 'react';
import './App.css';

export class Login extends React.Component {
	state = {
		email: '',
		password: '',
		user: null,
	};
	
	handleLoginChange = (event) => {
		this.setState({
			email: event.target.value
		});
	}

	handlePasswordChange = (event) => {
		this.setState({
			password: event.target.value
		});
	}
	
	logIn = () => {
		fetch('http://localhost:9000/api/users/LogIn?email=' + this.state.email + '&password=' + this.state.password)
			.then(res => res.json())
			.then(json => this.setState({
				user: json
			}));
	}
	
	renderHello = () => {
		if (this.state.user !== null) return <div>Hello, {this.state.user.Name}!</div>
	}

	render(){
		return (
			<div>
				<div><label>Email: </label><input className="email" value={this.state.email} onChange={this.handleLoginChange} type="text"></input></div>
				<div><label>Password: </label><input className="password" value={this.state.password} onChange={this.handlePasswordChange} type="text"></input></div>
				<button onClick={this.logIn}>Log In!</button>
				{this.renderHello()}
			</div>
			
		);
	}
}
