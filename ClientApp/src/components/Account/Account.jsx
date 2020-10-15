import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import "./Account.css";
import { updateAccountFunc, deleteAccountFunc } from "../../actions/userAccounts";
import Nav from "../Nav/Nav";

class Account extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            currentPasswordDisabled: true,
            firstName: "",
            lastName: "",
            email: "",
            password: "",
            currentPassword: "########",
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

    // handle deleting a user account 
    handleDelete(event) {
        this.props.deleteAccount(this.props.authentication.signIn.data.id, this.props.authentication.signIn.data.token);
    }

    // handle updating a user account
    handleSubmit(event) {
        event.preventDefault();
        let isInvalid = this.validateForm();
        let isUpdatingPassword = "false";
        // if the change password field is not disable, we want to update password
        if (!this.state.currentPasswordDisabled) { isUpdatingPassword = "true"; }
        // if form is valid, make the api call
        if (!isInvalid) {
            // if we want to update only names
            if (this.state.currentPasswordDisabled) {
                // call api with new names and dummy password
                this.props.updateAccount(this.props.authentication.signIn.data.id, this.state.firstName, this.state.lastName, "*", "********", isUpdatingPassword, this.props.authentication.signIn.data.token);
            }
            else {
                // call api with all information included
                this.props.updateAccount(this.props.authentication.signIn.data.id, this.state.firstName, this.state.lastName, this.state.currentPassword, this.state.password, isUpdatingPassword, this.props.authentication.signIn.data.token);
            }
        }
    }

    // update state when input fields are changed
    handleInputchange(event) {
        this.setState({
            [event.target.name]: event.target.value,
            [event.target.name + "Error"]: ""
        });
    }

    toggleChangePassword() {
        // clear the password placeholder if equal to ########
        if (this.state.currentPassword === "########") {
            this.setState({
                passwordActive: this.state.passwordActive === "" ? "active" : "",
                currentPasswordDisabled: !this.state.currentPasswordDisabled,
                currentPassword: ""
            });
        } else {
            this.setState({
                passwordActive: this.state.passwordActive === "" ? "active" : "",
                currentPasswordDisabled: !this.state.currentPasswordDisabled
            });
        }
    }

    validateForm() {
        let hasErrors = false;
        let firstNameError = "";
        let lastNameError = "";
        let passwordError = "";
        let confirmPasswordError = "";
        let currentPasswordError = "";

        // validate first name field
        switch (this.state.firstName.trim()) {
            case "":
                hasErrors = true;
                firstNameError = "First Name cannot be empty/whitespace";
                break;
            default:
                if (this.state.firstName.match(/[0-9]/)) {
                    hasErrors = true;
                    firstNameError = "First Name cannot contain numbers";
                } else if (this.state.firstName.trim().length > 50) {
                    hasErrors = true;
                    firstNameError = "First Name must be less than 50 characters";
                }
                break;
        }

        // validate last name field
        switch (this.state.lastName.trim()) {
            case "":
                hasErrors = true;
                lastNameError = "Last Name cannot be empty/whitespace";
                break;
            default:
                if (this.state.lastName.match(/[0-9]/)) {
                    hasErrors = true;
                    lastNameError = "Last Name cannot contain numbers";
                } else if (this.state.lastName.trim().length > 50) {
                    hasErrors = true;
                    lastNameError = "Last Name must be less than 50 characters";
                }
                break;
        }

        // if we want to update passwords
        if (!this.state.currentPasswordDisabled) {
            //validate a value was entered for the current password
            if (this.state.currentPassword.trim() === "") {
                hasErrors = true;
                currentPasswordError = "Your current password is required.";
            }

            // validate the new password field
            switch (this.state.password.trim()) {
                case "":
                    hasErrors = true;
                    passwordError = "Password cannot be empty/whitespace";
                    break;
                default:
                    if (this.state.password.trim().length < 6) {
                        hasErrors = true;
                        passwordError = "Password cannot be less than 6 characters";
                    } else if (this.state.password.trim().length > 50) {
                        hasErrors = true;
                        passwordError = "Password must be less than 50 characters";
                    }
                    break;
            }

            // confirm passwords match in both password fields
            if (this.state.password.trim() !== this.state.confirmPassword.trim()) {
                hasErrors = true;
                confirmPasswordError = "New passwords do not match";
            }
        }

        this.setState({
            hasErrors,
            firstNameError,
            lastNameError,
            currentPasswordError,
            passwordError,
            confirmPasswordError
        });
        return hasErrors;
    }

    renderAccount() {
        // specify the default status message
        let statusMessage = "";
        // if request is loading
        if (this.props.authentication.updateAccount.isLoading) { statusMessage = "Loading"; }
        // if completed and errors exist
        else if (this.props.authentication.updateAccount.isCompleted && this.props.authentication.updateAccount.error != null) {
            statusMessage = this.props.authentication.updateAccount.error;
        }
        // if completed successfully
        else if (this.props.authentication.updateAccount.isCompleted && this.props.authentication.updateAccount.error == null && this.props.authentication.updateAccount.data != null) {
            statusMessage = this.props.authentication.updateAccount.data;
        }

        // specify the default status message
        let deleteStatusMessage = "";
        // if request is loading
        if (this.props.authentication.deleteAccount.isLoading) { deleteStatusMessage = "Loading"; }
        // if completed and errors exist
        else if (this.props.authentication.deleteAccount.isCompleted && this.props.authentication.deleteAccount.error != null) {
            deleteStatusMessage = this.props.authentication.deleteAccount.error;
        }
        // if completed successfully
        else if (this.props.authentication.deleteAccount.isCompleted && this.props.authentication.deleteAccount.error == null && this.props.authentication.deleteAccount.data != null) {
            deleteStatusMessage = this.props.authentication.deleteAccount.data;
        }

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
                                        <label htmlFor="currentPassword">Current Password</label>
                                        <input type="password" name="currentPassword" id="currentPassword" value={this.state.currentPassword} onChange={(e) => this.handleInputchange(e)} disabled={this.state.currentPasswordDisabled} />
                                        <div className="error-message">{this.state.currentPasswordError}</div>
                                    </div>
                                    <button onClick={(e) => { e.preventDefault(); this.toggleChangePassword() }}>Change Password</button>
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
                        <div className="statusMessage">{statusMessage}</div>
                    </form>

                    <button onClick={(e) => this.handleDelete()}>Delete Account</button>
                    <div className="statusMessage">{deleteStatusMessage}</div>
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
        updateAccount: updateAccountFunc(dispatch),
        deleteAccount: deleteAccountFunc(dispatch)
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