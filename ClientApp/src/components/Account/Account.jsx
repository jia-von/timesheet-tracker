import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import "./Account.css";
import { signOutFunc } from "../../actions/userAccounts";
import Nav from "../Nav/Nav";

class Account extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            firstName: "",
            lastName: "",
            email: "",
            password: "",
            confirmPassword: "",
            passwordActive: "",
            hasErrors: false,
            firstNameError: "",
            lastNameError: "",
            passwordError: "",
            confirmPasswordError: "",
            redirect: false

        };
    }

    componentDidMount() {
        // do something on initial page load
        if (this.props.authentication.signIn.data != null) {
            let user = this.props.authentication.signIn.data;
            this.setState({
                firstName: user.firstName,
                lastName: user.lastName,
                email: user.email,
                password: "",
                confirmPassword: "",
            });
        }
    }

    handleSubmit(event) {
        event.preventDefault();
    }

    // update state when input fields are changed
    handleInputchange(event) {
        this.setState({
            [event.target.name]:  event.target.value,
            [event.target.name + "Error"]: ""
        });
    }

    toggleChangePassword() {
        this.setState({
            passwordActive: this.state.passwordActive === "" ? "active" : ""
        });
    }

    renderAccount() {
        return (
            <div className="account">
                <Nav />
                <div className="headerText"> <h1>Account</h1> </div>
                <div className="accountContainer">
                    <form onSubmit={(e) => this.handleSubmit(e)}>
                        <div className="accountRow">
                            <div className="inputGroup">
                                <label htmlFor="firstName">First Name</label>
                                <input type="text" name="firstName" id="firstName" value={this.state.firstName} onChange={(e) => this.handleInputchange(e)} />
                                <div className="error-message">{this.state.firstNameError}</div>
                            </div>
                            <div className="inputGroup">
                                <label htmlFor="lastName">Last Name</label>
                                <input type="text" name="lastName" id="lastName" value={this.state.lastName} onChange={(e) => this.handleInputchange(e)} />
                                <div className="error-message">{this.state.lastNameError}</div>
                            </div>
                        </div>
                        <div className="accountRow">
                            <div className="inputGroup">
                                <label htmlFor="email">Email</label>
                                <input type="text" name="email" id="email" value={this.state.email} disabled />
                                <div className="error-message"></div>
                            </div>
                        </div>
                        <div className="accountRow">
                            <div className="accountColumn">
                                <div className="oldPassword">
                                    <div className="inputGroup">
                                        <label htmlFor="oldPassword">Password</label>
                                        <input type="password" name="oldPassword" id="oldPassword" value="########" disabled />
                                        <div className="error-message"></div>
                                    </div>
                                    <button onClick={(e) => this.toggleChangePassword()}>Change Password</button>
                                </div>
                                <div className={`editPassword ${this.state.passwordActive}`}>
                                    <div className="inputGroup">
                                        <label htmlFor="password">New Password</label>
                                        <input type="password" name="password" id="password" value={this.state.password} onChange={(e) => this.handleInputchange(e)} />
                                        <div className="error-message">{this.state.passwordError}</div>
                                    </div>
                                    <div className="inputGroup">
                                        <label htmlFor="confirmPassword">Confirm Password</label>
                                        <input type="password" name="confirmPassword" id="confirmPassword" value={this.state.confirmPassword} onChange={(e) => this.handleInputchange(e)} />
                                        <div className="error-message">{this.state.confirmPasswordError}</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <button type="submit">Save Changes</button>
                    </form>

                    <button>Delete Account</button>
                </div>
            </div>);
    }

    render() {
        // if user is logged in
        if (this.props.authentication.signIn.data !== null) {
            if (this.state.redirect) {
                return (<Redirect to={{
                    pathname: this.state.redirect,
                    //state: {  }
                }}
                />);
            }
            // if redirect is false, display the account page
            else {
                return this.renderAccount();
            }
        }
        // if user is not logged in redirect
        else {
            return <Redirect to={"/"} />;
        }
    }
}


// add the redux async actions to props
function mapDispatchToProps(dispatch) {
    return {
        signOut: signOutFunc(dispatch)
    }
}

// add the redux store to props
function mapStateToProps(state) {
    return {
        authentication: state.userAccountsReducer
    }
}

// export the Component
export default connect(mapStateToProps, mapDispatchToProps)(Account);