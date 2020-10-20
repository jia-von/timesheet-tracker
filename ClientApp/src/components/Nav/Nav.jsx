import React from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import "./Nav.css";
import { signOutFunc } from "../../actions/userAccounts";
import IO from "./io";

class Nav extends React.Component {

    constructor(props) {
        super(props);
        this.state = {linksAreVisible: false};
    }

    componentDidMount() {
        // do something on initial page load
    }

    toggleLinks() {
        this.setState({linksAreVisible: !this.state.linksAreVisible})
    }

    render() {
        // generate the classes for nav links/buttons
        let homeClass = this.props.locationUrl === "/home" ? "home currentPage" : "home";
        let accountClass = this.props.locationUrl === "/account" ? "navLink currentPage" : "navLink";
        let createProjectClass = this.props.locationUrl === "/create-project" ? "navLink currentPage" : "navLink";

        let linksClass = this.state.linksAreVisible ? "secondary active" : "secondary";
        let createProject = this.props.isInstructor ? <Link className={createProjectClass} to="/create-project">Create Project</Link> : "";

        return (<nav className="navBar">
            <div className="primary">
                <Link className={homeClass} to="/home" sr-only="Home"><IO className="logo" /> Home</Link>
                
                <button className="menu" onClick={(e) => { this.toggleLinks(); }} sr-only="Expand Nav Bar"><i className="fas fa-bars"></i></button>
            </div>
            <div className={linksClass}>
                <Link className={accountClass} to="/account" >Account</Link>
                {createProject}
                <button className="navLink" onClick={() => this.props.signOut()} >Sign Out</button>
            </div>
        </nav>);
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
        isInstructor: state.userAccountsReducer.signIn.data.instructor
    }
}

// export the Component
export default connect(mapStateToProps, mapDispatchToProps)(Nav);