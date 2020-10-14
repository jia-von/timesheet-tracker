import React from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom"
import "./Nav.css";
import { signOutFunc } from "../../actions/userAccounts";

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
        let linksClass = this.state.linksAreVisible ? "secondary active" : "secondary";

        return (<nav className="navBar">
            <div className="primary">
                <Link className="home" to="/home" sr-only="Home"><i className="fas fa-home"></i></Link>
                { /* TODO display the add new project button to only instructors */}
                <Link className="navButton" to="/create-project" sr-only="Add a new project"><i className="fas fa-plus"></i></Link>
                <button className="menu" onClick={(e) => { this.toggleLinks(); }} sr-only="Expand Nav Bar"><i className="fas fa-bars"></i></button>
            </div>
            <div className={linksClass}>
                <a className="" href="#" >Account</a>
                <a className="" href="#" >Account</a>
                <a className="" href="#" >Account</a>
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

    }
}

// export the Component
export default connect(mapStateToProps, mapDispatchToProps)(Nav);