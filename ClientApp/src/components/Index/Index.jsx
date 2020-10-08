import React from "react";
import { connect } from "react-redux";
//import { withRouter } from "react-router-dom";
//import {} from "../../actions/timesheetTracker";
import workers from "./workers.svg";
import metrics from "./metrics.svg";

import "./Index.css";

class Index extends React.Component {
  static displayName = Index.name;

  constructor(props) {
    super(props);
    this.state = {
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
    };
  }

  handleSignIn(event) {
    event.preventDefault();
    this.validateSignIn();
    console.log("sign in");
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
    switch (this.state.emailSignIn.trim()) {
      case "":
        signInHasErrors = true;
        emailSignInError = "Email address cannot be empty.";
        break;
      default:
        /* CITATION: BORROWED REGEX FOR VALIDATING EMAIL ADDRESSES BELOW */
        const emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        /* END CITATION */
        if (!this.state.emailSignIn.match(emailRegex)) {
          signInHasErrors = true;
          emailSignInError = "A valid email address is required.";
        }
    }

    switch (this.state.passwordSignIn.trim()) {
      case "":
        signInHasErrors = true;
        passwordSignInError = "Password cannot be empty.";
        break;
      default:
        break;
    }

    this.setState({ signInHasErrors, emailSignInError, passwordSignInError });
    return signInHasErrors;
  }

  render() {
    /*
        let message =
      this.props.store.message === ""
        ? "Default message"
        : this.props.store.message;
    */

    return (
      <div className="index">
        <div className="login">
          <img src={workers} alt="display for the timesheet login section" />

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

            <button type="submit">Go</button>
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
              <form>
                <div>
                  <label htmlFor="firstNameSignUp" className="sr-only">
                    First Name
                  </label>
                  <input
                    type="text"
                    placeholder="First Name"
                    name="firstNameSignUp"
                    id="firstNameSignUp"
                    value={this.state.firstNameSignUp}
                    onChange={(e) => this.handleFormInputChange(e)}
                  />
                  <div className="error-message"></div>
                </div>

                <div>
                  <label htmlFor="lastNameSignUp" className="sr-only">
                    Last Name
                  </label>
                  <input
                    type="text"
                    placeholder="Last Name"
                    name="lastNameSignUp"
                    id="lastNameSignUp"
                    value={this.state.lastNameSignUp}
                    onChange={(e) => this.handleFormInputChange(e)}
                  />
                  <div className="error-message"></div>
                </div>

                <div>
                  <label htmlFor="emailSignUp" className="sr-only">
                    Email
                  </label>
                  <input
                    type="email"
                    placeholder="Email"
                    name="emailSignUp"
                    id="emailSignUp"
                    value={this.state.emailSignUp}
                    onChange={(e) => this.handleFormInputChange(e)}
                  />
                  <div className="error-message"></div>
                </div>

                <div>
                  <label htmlFor="passwordSignUp" className="sr-only">
                    Password
                  </label>
                  <input
                    type="password"
                    placeholder="Password"
                    name="passwordSignUp"
                    id="passwordSignUp"
                    value={this.state.passwordSignUp}
                    onChange={(e) => this.handleFormInputChange(e)}
                  />
                  <div className="error-message"></div>
                </div>

                <div>
                  <label htmlFor="confirmPasswordSignUp" className="sr-only">
                    Confirim Password
                  </label>
                  <input
                    type="password"
                    placeholder="Confirm Password"
                    name="confirmPasswordSignUp"
                    id="confirmPasswordSignUp"
                    value={this.state.confirmPasswordSignUp}
                    onChange={(e) => this.handleFormInputChange(e)}
                  />
                  <div className="error-message"></div>
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
                    disabled={this.state.isInstructor}
                    type="text"
                    placeholder="Cohort"
                    name="cohortSignUp"
                    id="cohortSignUp"
                    value={this.state.cohortSignUp}
                    onChange={(e) => this.handleFormInputChange(e)}
                  />
                  <div className="error-message"></div>
                </div>

                <button type="submit">Create Account</button>
              </form>
            </div>
          </div>
          {/* SIGN UP FORM END */}
        </div>

        <div className="desktopImage">
          <img src={metrics} alt="charts and metrics" />
        </div>
      </div>
    );
  }
}

// map redux to this component's props
function mapStateToProps(state) {
  return {
    store: state,
  };
}
export default connect(mapStateToProps)(Index);
