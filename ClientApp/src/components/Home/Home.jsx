import React from "react";
import axios from "axios";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import "./Home.css";
import Nav from "../Nav/Nav";

class Home extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            redirect: null
        };
    }

    
    componentDidMount() {
        
    }

    // renders all available projects to logged in users
    renderProjects() {
        return (
            <div className="home">
                <Nav />
                <div>
                    <div className="headerText"> <h1>Projects</h1> </div>

                    <div className="projectsContainer">
                        <div className="project">
                            <div class="projectBody">
                                <div class="projectCheck"></div>
                                <div class="projectTitle">
                                    <h3>Project Name</h3>
                                    <p>Time spent: 0 hours </p>
                                </div>
                            </div>
                            <div class="projectLabel overdue"></div>

                        </div>
                    </div>
                </div>
            </div>);   
    }

    render() {
        // if user is logged in
        //if (this.props.authentication.signIn.data !== null) {
        if (true) {
            return this.renderProjects();
        }
        // if user is not logged in redirect
        else {
            return <Redirect to={"/"} />;
        }
    }
}


// add the redux store to props
function mapStateToProps(state) {
    return {
        authentication: state.userAccountsReducer,
    }
}

// add the redux async actions to props
function mapDispatchToProps(dispatch) {
    return {
    }
}



// export the Component
export default connect(mapStateToProps, mapDispatchToProps)(Home);