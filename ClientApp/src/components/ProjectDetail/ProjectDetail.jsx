import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import Nav from "../Nav/Nav"
import "./ProjectDetail.css";
import { updateProjectFunc, deleteProjectFunc, getProjectByIDFunc } from "../../actions/projects";
import { Bar } from "react-chartjs-2";

class ProjectDetail extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            design: 0,
            doing: 0,
            codeReview: 0,
            testing: 0,
            deliverables: 0,
            hasErrors: false,
            designError: "",
            doingError: "",
            codeReviewError: "",
            testingError: "",
            deliverablesError: "",
            redirect: false
        };
    }

    componentDidMount() {
        // do something on initial page load
        // use passed ID to pull the project info
        console.log("mounted");
        this.props.getProjectByID(this.props.location.state.projectDetails.id, this.props.authentication.signIn.data.token);
    }

    componentDidUpdate(previousProps) {
        // if project hours have been added, use ID to pull project info and clear the form fields 
        if (previousProps.projects.modifyProject.isLoading === true && this.props.projects.modifyProject.isCompleted === true && this.props.projects.modifyProject.error === null && this.props.projects.modifyProject.deleted === false) {
            this.props.getProjectByID(this.props.location.state.projectDetails.id, this.props.authentication.signIn.data.token);
            this.setState({
                design: 0,
                doing: 0,
                codeReview: 0,
                testing: 0,
                deliverables: 0,
            });
        }
        // if deleted, set redirect to home after time interval
        if (previousProps.projects.modifyProject.isLoading === true && this.props.projects.modifyProject.isCompleted === true && this.props.projects.modifyProject.error === null && this.props.projects.modifyProject.deleted === true) {
            setTimeout(this.redirectToHome, 4000);
        }
    }

    redirectToHome = () => {
        this.setState({ redirect: "home" });
    }

    // update state when input fields are changed
    handleInputchange(event) {
        this.setState({
            [event.target.name]: event.target.value === "" ? 0 : event.target.value,
            [event.target.name + "Error"]: ""
        });
    }

    // delete this project
    handleDelete(projectID) {
        this.props.deleteProject(projectID, this.props.authentication.signIn.data.token);
    }

    // update this project
    handleUpdate(event, projectID) {
        event.preventDefault();
        let isInvalid = this.validateInputs();
        if (!isInvalid) {
            this.props.updateProject(projectID, this.state.design, this.state.doing, this.state.codeReview, this.state.testing, this.state.deliverables, this.props.authentication.signIn.data.token);
        }
    }

    // we will only be validating that no alphanumeric characters are passed
    // and that at least one value is not null/whitespace
    // user may want to update only some of the hours & api expects all values to be passed.
    // null/whitespace will be substituted with 0 on api call
    validateInputs() {
        let hasErrors = false;
        let designError = "";
        let doingError = "";
        let codeReviewError = "";
        let testingError = "";
        let deliverablesError = "";

        // check if all fields are empty
        if (this.state.doing === 0 && this.state.design === 0 && this.state.codeReview === 0 && this.state.testing === 0 && this.state.deliverables === 0) {
            hasErrors = true;
            designError = "At least one field must contain hours";
            doingError = "At least one field must contain hours";
            codeReviewError = "At least one field must contain hours";
            testingError = "At least one field must contain hours";
            deliverablesError = "At least one field must contain hours";
        }

        // check if any fields contain alphabets
        if (this.state.doing.toString().toLowerCase().match(/[a-z]/)) {
            hasErrors = true;
            doingError = "Hour values should be numeric eg 1.25";
        }
        if (this.state.design.toString().toLowerCase().match(/[a-z]/)) {
            hasErrors = true;
            designError = "Hour values should be numeric eg 1.25";
        }
        if (this.state.codeReview.toString().toLowerCase().match(/[a-z]/)) {
            hasErrors = true;
            codeReviewError = "Hour values should be numeric eg 1.25";
        }
        if (this.state.testing.toString().toLowerCase().match(/[a-z]/)) {
            hasErrors = true;
            testingError = "Hour values should be numeric eg 1.25";
        }
        if (this.state.deliverables.toString().toLowerCase().match(/[a-z]/)) {
            hasErrors = true;
            deliverablesError = "Hour values should be numeric eg 1.25";
        }

        this.setState({
            designError,
            doingError,
            codeReviewError,
            testingError,
            deliverablesError,
            hasErrors
        });
        return hasErrors;
    }

    generateBarChart(project) {
        let data = {
            labels: ["Total", "Design", "Doing", "Code Review", "Testing", "Deliverables"],
            datasets: [{
                label: "Hours",
                backgroundColor: 'rgba(153, 206, 255, .75)',
                borderColor: 'rgba(0, 103, 200, .90)',
                borderWidth: 1,
                data: [project.totalHours, project.designHours, project.doingHours, project.codeReviewHours, project.testingHours, project.deliverablesHours],
            }]
        };

        let options = {
            legend: {
                labels: {
                    boxWidth: 20
                }
            }
        }

        return <div className="projectChart"><div>< Bar data={data} options={options}  /></div></div>
    }

    renderProjectDetails() {
        let project = this.props.projects.projectByID.data !== null ? this.props.projects.projectByID.data : "";
        let createdOn = new Date(project.dateCreated);
        let dueOn = new Date(project.dueDate);

        // specify the default status message
        let statusMessage = "";
        // if request is loading
        if (this.props.projects.modifyProject.isLoading) { statusMessage = "Loading"; }
        // if completed and errors exist
        else if (this.props.projects.modifyProject.isCompleted && this.props.projects.modifyProject.error != null) {
            statusMessage = this.props.projects.modifyProject.error;
        }
        // if completed successfully
        else if (this.props.projects.modifyProject.isCompleted && this.props.projects.modifyProject.error == null && this.props.projects.modifyProject.data != null) {
            
                statusMessage = this.props.projects.modifyProject.data;
        }

        return (
            <div className="projectDetail">
                <Nav />
                <div>
                    <div className="headerText"> <h1>{project.projectName}</h1> </div>
                    <div className="projectDetailContainer">
                        {this.generateBarChart(project)}

                        <h2>Project Summary</h2>
                        <p className="projectInfo">Time spent: {project.totalHours} hours </p>
                        <p className="projectInfo">Created on: {createdOn.toUTCString()}</p>
                        <p className="projectInfo">Due on: {dueOn.toUTCString()}</p>

                        <h2>Track Progress</h2>
                        <form onSubmit={(e) => this.handleUpdate(e, project.id)}>
                            <div className="inputGroup">
                                <label htmlFor="design">Design:</label>
                                <input className={this.state.designError.length > 0 ? "error" : ""} type="text" name="design" id="design" autoComplete="off" value={this.state.design} onChange={(e) => this.handleInputchange(e)} onFocus={(e) => e.target.select()} />
                                <div className="error-message">{this.state.designError}</div>
                            </div>
                            <div className="inputGroup">
                                <label htmlFor="doing">Doing:</label>
                                <input className={this.state.doingError.length > 0 ? "error" : ""} type="text" name="doing" id="doing" autoComplete="off" value={this.state.doing} onChange={(e) => this.handleInputchange(e)} onFocus={(e) => e.target.select()}  />
                                <div className="error-message">{this.state.doingError}</div>
                            </div>
                            <div className="inputGroup">
                                <label htmlFor="codeReview">Code Review:</label>
                                <input className={this.state.codeReviewError.length > 0 ? "error" : ""} type="text" name="codeReview" id="codeReview" autoComplete="off" value={this.state.codeReview} onChange={(e) => this.handleInputchange(e)} onFocus={(e) => e.target.select()}  />
                                <div className="error-message">{this.state.codeReviewError}</div>
                            </div>
                            <div className="inputGroup">
                                <label htmlFor="testing">Testing:</label>
                                <input className={this.state.testingError.length > 0 ? "error" : ""} type="text" name="testing" id="testing" autoComplete="off" value={this.state.testing} onChange={(e) => this.handleInputchange(e)} onFocus={(e) => e.target.select()}  />
                                <div className="error-message">{this.state.testingError}</div>
                            </div>
                            <div className="inputGroup">
                                <label htmlFor="deliverables">Deliverables:</label>
                                <input className={this.state.deliverablesError.length > 0 ? "error" : ""} type="text" name="deliverables" id="deliverables" autoComplete="off" value={this.state.deliverables} onChange={(e) => this.handleInputchange(e)} onFocus={(e) => e.target.select()}  />
                                <div className="error-message">{this.state.deliverablesError}</div>
                            </div>
                            <button type="submit">Update Hours</button>
                            <div className="statusMessage">{statusMessage}</div>
                        </form>

                        <button className="deleteProject" onClick={() => this.handleDelete(project.id)}>Delete Project</button>

                    </div>

                </div>
            </div>);
    }

    render() {
        // if user is logged in
        if (this.props.authentication.signIn.data !== null) {
            if (this.state.redirect) {
                return (<Redirect to={{
                    pathname: this.state.redirect,
                    state: { projectDetails: this.state.projectDetails }
                }}
                />);
            }
            // if redirect is false, display the project details page
            else {
                return this.renderProjectDetails();
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
        updateProject: updateProjectFunc(dispatch),
        deleteProject: deleteProjectFunc(dispatch),
        getProjectByID: getProjectByIDFunc(dispatch)
    }
}

// add the redux store to props
function mapStateToProps(state) {
    return {
        authentication: state.userAccountsReducer,
        projects: state.projectsReducer
    }
}

// export the Component
export default connect(mapStateToProps, mapDispatchToProps)(ProjectDetail);