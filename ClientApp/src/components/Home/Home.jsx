import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import "./Home.css";
import Nav from "../Nav/Nav";
import { getUserProjectsByIDFunc, getAllProjectsFunc } from "../../actions/projects";
import complete from "./complete.svg";

class Home extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            redirect: false,
            projectDetails: null
        };
    }

    
    componentDidMount() {
        // get the projects depending on if a student or instructor is logged in
        if (this.props.authentication.signIn.data != null)
        if (this.props.authentication.signIn.data.instructor) {
            this.props.getInstructorProjects(this.props.authentication.signIn.data.token);
        } else {
            this.props.getStudentProjects(this.props.authentication.signIn.data.id, this.props.authentication.signIn.data.token);
        }
        
    }


    renderProjects() {
        let projects = this.props.projects.projects;
        let errors = this.props.projects.projects.error;

        if (errors === null) {
            // if loading is complete and results were received, display them
            if (projects.data.length > 0 && projects.isCompleted) {
                console.log("firstcase");
                return projects.data.map(
                    (project) => {
                        return <div className="project" key={project.id} onClick={
                            () => {
                                this.setState({
                                    redirect: "/project-detail",
                                    projectDetails: project
                                })
                            }
                        } >
                            <div className="projectBody">
                                <div className="projectCheck"></div>
                                <div className="projectTitle">
                                    <h3>{project.projectName}</h3>
                                    <p>Time spent: {project.totalHours} hours </p>
                                    <p>{project.dateCreated}</p>
                                    <p>{project.dueCreated}</p>
                                </div>
                            </div>
                            <div class="projectLabel overdue"></div>

                        </div>
                    }
                );
            }
            // if loading is complete and no results were received
            else if (projects.isCompleted && projects.data.length === 0) {
                return <div className="noProjects">
                    <img src={complete} alt="no tasks left"/>
                    <p> No projects. Create some or wait for them to be assigned to you. </p>
                    </div>
            }
            // if request is loading 
            else if (projects.isLoading) {
               return  <p>Loading</p>
            }
        }
        // display errors
        else {
            return <p> oops something went wrong: {errors} </p>
        }
    }

    // renders the home page to logged in users
    renderHomePage() {
        return (
            <div className="home">
                <Nav />
                <div>
                    <div className="headerText"> <h1>Projects</h1> </div>
                    <div className="projectsContainer">
                        {this.renderProjects()}
                        </div>
                    
                </div>
            </div>);   
    }

    render() {
        // if user is logged in
        if (this.props.authentication.signIn.data !== null) {
        // if redirect is true, redirect to the desired page
            if (this.state.redirect) {
            // inject data into the next component's props, read more  here: https://reactrouter.com/web/api/Redirect
            return <Redirect to={{
                pathname: this.state.redirect,
                state: {  projectDetails: this.state.projectDetails }
            }}
            />
        }
        // if redirect is false, display the home page
        else {
            return this.renderHomePage();
        }
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
        projects: state.projectsReducer
    }
}

// add the redux async actions to props
function mapDispatchToProps(dispatch) {
    return {
        getStudentProjects: getUserProjectsByIDFunc(dispatch),
        getInstructorProjects: getAllProjectsFunc(dispatch)
    }
}



// export the Component
export default connect(mapStateToProps, mapDispatchToProps)(Home);