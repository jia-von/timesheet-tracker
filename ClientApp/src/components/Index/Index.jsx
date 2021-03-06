﻿import React from "react";
import { connect } from "react-redux";
import { withRouter, Redirect } from "react-router-dom";
import Workers from "./Workers";
import Metrics from "./Metrics";
import "./Index.css";
// import the function "factories" so we can use them when mapping dispatch to props
import { signInFunc, signUpFunc } from "../../actions/userAccounts";

class Index extends React.Component {
  static displayName = Index.name;

  constructor(props) {
    super(props);
      this.state = {
      redirect: null,
      emailSignIn: "",
      passwordSignIn: "",
      emailSignInError: "",
      passwordSignInError: "",
      signInHasErrors: false,
      signUpForm: "",
      firstNameSignUp: "",
      lastNameSignUp: "",
      emailSignUp: "",
      passwordSignUp: "",
      confirmPasswordSignUp: "",
      isInstructor: false,
      cohortSignUp: "",
      firstNameSignUpError : "",
      lastNameSignUpError: "",
      emailSignUpError: "",
      passwordSignUpError: "",
      confirmPasswordSignUpError: "",
      cohortSignUpError: "",
      signUpHasErrors: false
    };
  }

  // validate sign in form and dispatch redux action
  handleSignIn(event) {
    event.preventDefault();
      let isInvalid = this.validateSignIn();
      // if the form fields arent invalid, dispatch signIn from props
      if (!isInvalid) { this.props.signIn(this.state.emailSignIn, this.state.passwordSignIn); }

  }

  // validate sign up form and dispatch redux action 
  handleSignUp(event) {
      event.preventDefault();
      // if the form fields arent invalid, dispatch the signUp from props
    let isInvalid = this.validateSignUp();
      if (!isInvalid) {
          this.props.signUp(
              this.state.firstNameSignUp,
              this.state.lastNameSignUp,
              this.state.emailSignUp,
              this.state.passwordSignUp,
              (this.state.isInstructor ? "instructor" : "student"),
              this.state.cohortSignUp
          );
      }
  }

  // update the state when a form field is changed
  handleFormInputChange(event) {
    this.setState({
      [event.target.name]: event.target.value,
      [event.target.name + "Error"]: "",
    });
  }

  // validate sign in form
  validateSignIn() {
    let emailSignInError = "";
    let passwordSignInError = "";
    let signInHasErrors = false;
    // validate email field 
    switch (this.state.emailSignIn.trim()) {
      case "":
        signInHasErrors = true;
        emailSignInError = "Email address cannot be empty/whitespace.";
        break;
      default:
        /* CITATION: BORROWED REGEX FOR VALIDATING EMAIL ADDRESSES BELOW */
        const emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        /* END CITATION */
        if (!this.state.emailSignIn.match(emailRegex)) {
          signInHasErrors = true;
          emailSignInError = "A valid email address is required.";
        }
        break;
    }
// validate password field
    switch (this.state.passwordSignIn.trim()) {
      case "":
        signInHasErrors = true;
        passwordSignInError = "Password cannot be empty/whitespace.";
        break;
      default:
        break;
    }

    this.setState({ signInHasErrors, emailSignInError, passwordSignInError });
    return signInHasErrors;
  }

  // validate sign up form
  validateSignUp() {
    let signUpHasErrors = false;
    let firstNameSignUpError  = "";
    let lastNameSignUpError = "";
    let emailSignUpError = "";
    let passwordSignUpError = "";
    let confirmPasswordSignUpError = "";
    let cohortSignUpError = "";

    // validate first name field
    switch(this.state.firstNameSignUp.trim()){
      case "":
        signUpHasErrors = true;
        firstNameSignUpError = "First Name cannot be empty/whitespace";
        break;
      default:
        if (this.state.firstNameSignUp.match(/[0-9]/)) {
          signUpHasErrors = true;
          firstNameSignUpError = "First Name cannot contain numbers";
        } else if (this.state.firstNameSignUp.trim().length > 50 ) {
          signUpHasErrors = true;
          firstNameSignUpError = "First Name must be less than 50 characters";
        }
        break;
    }

    // validate last name field
    switch(this.state.lastNameSignUp.trim()){
      case "":
        signUpHasErrors = true;
        lastNameSignUpError = "Last Name cannot be empty/whitespace";
        break;
      default:
        if (this.state.lastNameSignUp.match(/[0-9]/)) {
          signUpHasErrors = true;
          lastNameSignUpError = "Last Name cannot contain numbers";
        } else if (this.state.lastNameSignUp.trim().length > 50 ) {
          signUpHasErrors = true;
          lastNameSignUpError = "Last Name must be less than 50 characters";
        }
        break;
    }

    // validate email field
    switch(this.state.emailSignUp.trim()){
      case "":
        signUpHasErrors = true;
        emailSignUpError = "Email cannot be empty/whitespace";
        break;
      default:
        if (!this.state.emailSignUp.match(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)) {
          signUpHasErrors = true;
          emailSignUpError = "A valid email is required";
        } else if (this.state.emailSignUp.trim().length > 50 ) {
          signUpHasErrors = true;
          emailSignUpError = "Email must be less than 50 characters";
        }
        break;
    }

    // validate the password field
    switch(this.state.passwordSignUp.trim()){
      case "":
        signUpHasErrors = true;
        passwordSignUpError = "Password cannot be empty/whitespace";
        break;
      default:
        if (this.state.passwordSignUp.trim().length < 6) {
          signUpHasErrors = true;
          passwordSignUpError = "Password cannot be less than 6 characters";
        } else if (this.state.passwordSignUp.trim().length > 50 ) {
          signUpHasErrors = true;
          passwordSignUpError = "Password must be less than 50 characters";
        }
        break;
    }

    // confirm passwords match in both password fields
    if (this.state.passwordSignUp.trim() !== this.state.confirmPasswordSignUp.trim()){
      signUpHasErrors = true;
      confirmPasswordSignUpError = "Passwords do not match";
    }

    // validate cohort field if this not an instructor
    if (!this.state.isInstructor){
      if (this.state.cohortSignUp.trim() === "") {
        signUpHasErrors = true;
        cohortSignUpError = "Cohorts are required for students";
      }
      // ensure no alphabets in cohort
      else if (this.state.cohortSignUp.trim().toLowerCase().match(/[a-z]/)){
        signUpHasErrors = true;
        cohortSignUpError = "Cohorts cannot contain alphabets";
      }
      // ensure can be parsed to a float
      else if (isNaN(parseFloat(this.state.cohortSignUp.trim()))){
        signUpHasErrors = true;
        cohortSignUpError = "Cohorts must be floats (eg 4.1)";
      }
    }

    this.setState({ signUpHasErrors, firstNameSignUpError, lastNameSignUpError, emailSignUpError, passwordSignUpError, confirmPasswordSignUpError, cohortSignUpError });
    return signUpHasErrors;
    }

  

    // this will be responsible for dismissing the form values and closing the sign up form if successful
    // note a conditional is required when setting state in component did update to prevent infiniteloop
    componentDidUpdate(perviousProps) {
      // if we were loading SIGN UP previously, have now completed and have no errors, lets close the form and delete the entries in fields
      if (perviousProps.store.signUp.isLoading === true && this.props.store.signUp.isCompleted === true && this.props.store.signUp.error == null) {
        this.setState({
          signUpForm: "",
          firstNameSignUp: "",
          lastNameSignUp: "",
          emailSignUp: "",
          passwordSignUp: "",
          confirmPasswordSignUp: "",
          isInstructor: false,
          cohortSignUp: "",
        });
      }

      // if we were SIGN IN loading, have completed and have no sign in errors, clear the form fields
        // we also set the Redirect state value to the page we wish signed in users to be taken to
      if (perviousProps.store.signIn.isLoading === true && this.props.store.signIn.isCompleted === true && this.props.store.signIn.error == null) {
        this.setState({
          emailSignIn: "",
            passwordSignIn: "",
            redirect: "/home"
        });
      }
    }


  render() {
    
     // specify the status message to show for sign up form
      let signUpStatusMessage = "";
      if (this.props.store.signUp.isLoading) { signUpStatusMessage = "Loading"; }
      else {
          if (this.props.store.signUp.isCompleted && this.props.store.signUp.error != null) {
              signUpStatusMessage = this.props.store.signUp.error;
          } else if (this.props.store.signUp.isCompleted && this.props.store.signUp.data != null) {
              signUpStatusMessage = "Success";
          }
      }

      // specify the status message to show for sign up form
      let signInStatusMessage = "";
      if (this.props.store.signIn.isLoading) { signInStatusMessage = "Loading"; }
      else if (this.props.store.signIn.isCompleted && this.props.store.signIn.error != null) {
              signInStatusMessage = this.props.store.signIn.error;
          }
        

      // If this.state.redirect is null, the user is not signed in
      // if this.state.redirect has a value, the user is signed in and should be taken to home page
      if (this.state.redirect) {
          return <Redirect to={this.state.redirect} />
      }
      else {
          return (
              <div className="index">
                  <div className="login">
                      <Workers className="workers" />

                      <h1>Sign In</h1>

                      <form
                          onSubmit={(e) => {
                              this.handleSignIn(e);
                          }}
                      >
                          <div>
                              <label htmlFor="emailSignIn" className="sr-only">
                                  Email Address
              </label>
                              <input
                                  className={
                                      this.state.emailSignInError.length > 0 ? "error" : ""
                                  }
                                  type="email"
                                  placeholder="Email"
                                  name="emailSignIn"
                                  id="emailSignIn"
                                  value={this.state.emailSignIn}
                                  onChange={(e) => this.handleFormInputChange(e)}
                              />
                              <div className="error-message">{this.state.emailSignInError}</div>
                          </div>

                          <div>
                              <label htmlFor="passwordSignIn" className="sr-only">
                                  Password
              </label>
                              <input
                                  className={
                                      this.state.passwordSignInError.length > 0 ? "error" : ""
                                  }
                                  type="password"
                                  placeholder="Password"
                                  name="passwordSignIn"
                                  id="passwordSignIn"
                                  value={this.state.passwordSignIn}
                                  onChange={(e) => this.handleFormInputChange(e)}
                              />
                              <div className="error-message">
                                  {this.state.passwordSignInError}
                              </div>
                          </div>

                          <button type="submit" disabled={this.props.store.signIn.isLoading}>Go</button>
                          <div className="statusMessage">{signInStatusMessage}</div>
                      </form>

                      <p className="text-center">
                          No account?{" "}
                          <button
                              onClick={() => {
                                  this.setState({ signUpForm: "active" });
                              }}
                          >
                              Create an account
            </button>
                      </p>

                      {/* SIGN UP FORM START */}
                      <div className={"signUp " + this.state.signUpForm}>
                          <div>
                              <button
                                  onClick={() => {
                                      this.setState({ signUpForm: "" });
                                  }}
                              >
                                  <i className="fas fa-arrow-down"></i>
                                  <p className="sr-only">Close</p>
                              </button>
                          </div>
                          <div>
                              <h2>Sign Up</h2>
                              <form onSubmit={(e) => this.handleSignUp(e)}>
                                  <div>
                                      <label htmlFor="firstNameSignUp" className="sr-only">
                                          First Name
                  </label>
                                      <input
                                          className={
                                              this.state.firstNameSignUpError.length > 0 ? "error" : ""
                                          }
                                          type="text"
                                          placeholder="First Name"
                                          name="firstNameSignUp"
                                          id="firstNameSignUp"
                                          value={this.state.firstNameSignUp}
                                          onChange={(e) => this.handleFormInputChange(e)}
                                      />
                                      <div className="error-message">{this.state.firstNameSignUpError}</div>
                                  </div>

                                  <div>
                                      <label htmlFor="lastNameSignUp" className="sr-only">
                                          Last Name
                  </label>
                                      <input
                                          className={
                                              this.state.lastNameSignUpError.length > 0 ? "error" : ""
                                          }
                                          type="text"
                                          placeholder="Last Name"
                                          name="lastNameSignUp"
                                          id="lastNameSignUp"
                                          value={this.state.lastNameSignUp}
                                          onChange={(e) => this.handleFormInputChange(e)}
                                      />
                                      <div className="error-message">{this.state.lastNameSignUpError}</div>
                                  </div>

                                  <div>
                                      <label htmlFor="emailSignUp" className="sr-only">
                                          Email
                  </label>
                                      <input
                                          className={
                                              this.state.emailSignUpError.length > 0 ? "error" : ""
                                          }
                                          type="email"
                                          placeholder="Email"
                                          name="emailSignUp"
                                          id="emailSignUp"
                                          value={this.state.emailSignUp}
                                          onChange={(e) => this.handleFormInputChange(e)}
                                      />
                                      <div className="error-message">{this.state.emailSignUpError}</div>
                                  </div>

                                  <div>
                                      <label htmlFor="passwordSignUp" className="sr-only">
                                          Password
                  </label>
                                      <input
                                          className={
                                              this.state.passwordSignUpError.length > 0 ? "error" : ""
                                          }
                                          type="password"
                                          placeholder="Password"
                                          name="passwordSignUp"
                                          id="passwordSignUp"
                                          value={this.state.passwordSignUp}
                                          onChange={(e) => this.handleFormInputChange(e)}
                                      />
                                      <div className="error-message">{this.state.passwordSignUpError}</div>
                                  </div>

                                  <div>
                                      <label htmlFor="confirmPasswordSignUp" className="sr-only">
                                          Confirim Password
                  </label>
                                      <input
                                          className={
                                              this.state.confirmPasswordSignUpError.length > 0 ? "error" : ""
                                          }
                                          type="password"
                                          placeholder="Confirm Password"
                                          name="confirmPasswordSignUp"
                                          id="confirmPasswordSignUp"
                                          value={this.state.confirmPasswordSignUp}
                                          onChange={(e) => this.handleFormInputChange(e)}
                                      />
                                      <div className="error-message">{this.state.confirmPasswordSignUpError}</div>
                                  </div>

                                  <div className="instructor-row">
                                      <input
                                          checked={this.state.isInstructor}
                                          type="checkbox"
                                          name="isInstructor"
                                          id="isInstructor"
                                          onChange={(e) =>
                                              this.setState({ isInstructor: !this.state.isInstructor })
                                          }
                                      />
                                      <label htmlFor="isInstructor">I'm an Instructor</label>
                                  </div>

                                  <div>
                                      <label htmlFor="cohortSignUp" className="sr-only">
                                          Cohort
                  </label>
                                      <input
                                          className={
                                              this.state.cohortSignUpError.length > 0 ? "error" : ""
                                          }
                                          disabled={this.state.isInstructor}
                                          type="text"
                                          placeholder="Cohort"
                                          name="cohortSignUp"
                                          id="cohortSignUp"
                                          value={this.state.cohortSignUp}
                                          onChange={(e) => this.handleFormInputChange(e)}
                                      />
                                      <div className="error-message">{this.state.cohortSignUpError}</div>
                                  </div>

                                  <button type="submit" disabled={this.props.store.signUp.isLoading}>Create Account</button>

                                  <div className="statusMessage">{signUpStatusMessage}</div>
                              </form>
                          </div>
                      </div>
                      {/* SIGN UP FORM END */}
                  </div>

                  <div className="desktopImage">
                      <Metrics className="metrics" />
                  </div>
              </div>
          );
      }
  }
}

// map only values from userAccountsReducer in redux to this component's props
function mapStateToProps(state) {
  return {
    store: state.userAccountsReducer,
  }
}

// map the function "factories" from dispatch to this component's props
function mapDispatchToProps(dispatch) {
    return {
        signIn: signInFunc(dispatch),
        signUp: signUpFunc(dispatch)
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(withRouter(Index));
