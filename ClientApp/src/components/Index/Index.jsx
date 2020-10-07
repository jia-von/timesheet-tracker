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
      signUpForm: "",
      firstNameSignUp: "",
      emailSignUp: "",
      passwordSignUp: "",
      confirmPasswordSignUp: "",
    };
  }

  handleSignIn(event) {
    event.preventDefault();
    console.log("sign in");
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
            <label htmlFor="emailSignIn" className="sr-only">
              Email Address
            </label>
            <input
              type="email"
              placeholder="Email"
              name="emailSignIn"
              id="emailSignIn"
              value={this.state.emailSignIn}
              onChange={(e) => this.setState({ emailSignIn: e.target.value })}
            />
            <label htmlFor="passwordSignIn" className="sr-only">
              Password
            </label>
            <input
              type="password"
              placeholder="Password"
              name="passwordSignIn"
              id="passwordSignIn"
              value={this.state.passwordSignIn}
              onChange={(e) =>
                this.setState({ passwordSignIn: e.target.value })
              }
            />
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
                <label htmlFor="firstNameSignUp" className="sr-only">
                  First Name
                </label>
                <input
                  type="text"
                  placeholder="First Name"
                  name="firstNameSignUp"
                  id="firstNameSignUp"
                  value={this.state.firstNameSignUp}
                  onChange={(e) =>
                    this.setState({ firstNameSignUp: e.target.value })
                  }
                />

                <label htmlFor="lastNameSignUp" className="sr-only">
                  Last Name
                </label>
                <input
                  type="text"
                  placeholder="Last Name"
                  name="lastNameSignUp"
                  id="lastNameSignUp"
                  value={this.state.lastNameSignUp}
                  onChange={(e) =>
                    this.setState({ lastNameSignUp: e.target.value })
                  }
                />

                <label htmlFor="emailSignUp" className="sr-only">
                  Email
                </label>
                <input
                  type="email"
                  placeholder="Email"
                  name="emailSignUp"
                  id="emailSignUp"
                  value={this.state.emailSignUp}
                  onChange={(e) =>
                    this.setState({ emailSignUp: e.target.value })
                  }
                />

                <label htmlFor="passwordSignUp" className="sr-only">
                  Password
                </label>
                <input
                  type="password"
                  placeholder="Password"
                  name="passwordSignUp"
                  id="passwordSignUp"
                  value={this.state.passwordSignUp}
                  onChange={(e) =>
                    this.setState({ passwordSignUp: e.target.value })
                  }
                />

                <label htmlFor="confirmPasswordSignUp" className="sr-only">
                  Confirim Password
                </label>
                <input
                  type="password"
                  placeholder="Confirm Password"
                  name="confirmPasswordSignUp"
                  id="confirmPasswordSignUp"
                  value={this.state.confirmPasswordSignUp}
                  onChange={(e) =>
                    this.setState({ confirmPasswordSignUp: e.target.value })
                  }
                />

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
