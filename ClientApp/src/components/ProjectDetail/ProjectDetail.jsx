import React from "react";
import axios from "axios";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import Nav from "../Nav/Nav"
import "./ProjectDetail.css";
import { getAllProjectsFunc, getUserProjectsByIDFunc } from "../../actions/projects";

class ProjectDetail extends React.Component {

    constructor(props) {
        super(props);
        this.state = {redirect: false};
    }

    componentDidMount() {
        // do something on initial page load
    }

    render() {
        let project = this.props.location.state ?  this.props.location.state.projectDetails : "";

        // if user is logged in
        if (this.props.authentication.signIn.data !== null) {
            if (this.state.redirect) {
                return ( <Redirect to={{
                    pathname: this.state.redirect,
                    state: { projectDetails: this.state.projectDetails }
                }}
                />);
            }
            // if redirect is false, display the home page
            else {
                return (
                    <div className="projectDetail">
                        <Nav />
                        <div>
                            <div className="headerText"> <h1>{project.projectName}</h1> </div>
                            <div className="projectDetailContainer">
                                <p>Time spent: {project.totalHours} hours </p>
                                <p>{project.dateCreated}</p>
                                <p>{project.dueCreated}</p>
                            </div>

                        </div>
                    </div>);
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
        getAllProjects: getAllProjectsFunc(dispatch),
        getAllUserProjectsByID: getUserProjectsByIDFunc(dispatch)
    }
}

// add the redux store to props
function mapStateToProps(state) {
    return {
        authentication: state.userAccountsReducer,
        projects: state.projects
    }
}

// export the Component
export default connect(mapStateToProps, mapDispatchToProps)(ProjectDetail);