import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import Nav from "../Nav/Nav"
import "./CreateProject.css";
import { createStudentProjectFunc, createCohortProjectFunc } from "../../actions/projects";
import { getEmployeesFunc } from "../../actions/employees";

class CreateProject extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            redirect: false,
            projectName: "",
            dueDate: "",
            employeeID: "",
            cohort: "",
            isCohortProject: false,
            projectNameError: "",
            dueDateError: "",
            employeeIDError: "",
            cohortError: "",
            formHasErrors: false
        };
    }

    componentDidMount() {
        // get a list of all the employees & IDs  on first load
        this.props.getEmployees("student", this.props.authentication.signIn.data.token)
    }

    componentDidUpdate(previousProps) {
        // if we were loading, have completed and have no errors, clear the form fields
        // we also set the Redirect state value to the home page
        if (previousProps.authentication.signIn.data.isLoading === true && this.props.authentication.signIn.data.isCompleted === true && this.props.authentication.signIn.data.error == null) {
            this.setState({
                projectName: "",
                dueDate: "",
                employeeID: "",
                cohort: "",
                redirect: "/home"
            });
        }
    }

    // handle create project form submit
    handleSubmit(event) {
        event.preventDefault();
        let isInvalid = this.validateForm();
        // if forms are valid
        if (!isInvalid) {
            // if this is a cohort project
            if (this.state.isCohortProject) {
                this.props.createCohortProject(this.state.projectName.trim(), this.state.dueDate.trim(), this.state.cohort.trim(), this.state.isCohortProject, this.props.authentication.signIn.data.token);
            }
            // else if this is a student project
            else {
                this.props.createStudentProject(this.state.projectName.trim(), this.state.dueDate.trim(), this.state.employeeID.trim(), this.props.authentication.signIn.data.token);
            }
        }
    }

    // update the state on form input change
    handleFormInputChange(event) {
        this.setState({
            [event.target.name]: event.target.value,
            [event.target.name + "Error"]: ""
        });
    }

    validateForm() {
        let hasErrors = false;
        let projectNameError = "";
        let dueDateError = "";
        let employeeIDError = "";
        let cohortError = "";

        // validate project name
        if (this.state.projectName.trim() === "") {
            hasErrors = true;
            projectNameError = "Name cannot be empty or whitespace";
        } else if (this.state.projectName.trim().length > 50) {
            hasErrors = true;
            projectNameError = "Names cannot be greater than 50 characters";
        }
        // validate due date
        if (this.state.dueDate.trim() === "") {
            hasErrors = true;
            dueDateError = "Due Date must be provided";
        } else if (Date.parse(this.state.dueDate.trim()) < Date.now()) {
            hasErrors = true;
            dueDateError = "Due date must be a future date"
        }

        if (this.state.isCohortProject) {
            // validate cohort
            if (this.state.cohort.trim() === "") {
                hasErrors = true;
                cohortError = "A cohort is required for Cohort projects";
            } else if (this.state.cohort.trim().toLowerCase().match(/[a-z]/)) {
                hasErrors = true;
                cohortError = "Cohorts cannot contain alphabets";
            }
            else if (isNaN(parseFloat(this.state.cohort.trim()))) {
                hasErrors = true;
                cohortError = "Cohorts must be floats (eg 4.1)";
            }
        }
        // validate employee id
        else {
            
            if (this.state.employeeID.trim() === "") {
                hasErrors = true;
                employeeIDError = "An Employee is required for individual projects";
            }
        }

        this.setState({
                formHasErrors: hasErrors,
                projectNameError,
                dueDateError,
                employeeIDError,
                cohortError
        });
        return hasErrors;
    }

    renderCreateProject() {
        // specify the status message
        let statusMessage = "";
        if (this.props.projects.createProject.isLoading) { statusMessage = "Loading"; }
        else if (this.props.projects.createProject.isCompleted && this.props.projects.createProject.error != null) {
            statusMessage = this.props.projects.createProject.error;
        }
        else if (this.props.projects.createProject.isCompleted && this.props.projects.createProject.error == null && this.props.projects.createProject.data != null) {
            statusMessage = this.props.projects.createProject.data;
        }

        return (
            <div className="createProject">
                <Nav />
                <div>
                    <div className="headerText"> <h1>Create A Project</h1> </div>
                    <div className="createProjectContainer">
                        <form onSubmit={(e) => { this.handleSubmit(e); }}>
                            <div className="inputGroup">
                                <label htmlFor="projectName">Project Name:</label>
                                <input
                                    className={this.state.projectNameError.length > 0 ? "error" : ""}
                                    type="text"
                                    placeholder="Project Name"
                                    name="projectName"
                                    id="projectName"
                                    value={this.state.projectName}
                                    onChange={(e) => this.handleFormInputChange(e)}
                                />
                                <div className="error-message">{this.state.projectNameError}</div>
                            </div>

                            <div className="inputGroup">
                                <label htmlFor="dueDate">Due Date:</label>
                                <input
                                    className={this.state.dueDateError.length > 0 ? "error" : ""}
                                    type="datetime-local"
                                    name="dueDate"
                                    id="dueDate"
                                    value={this.state.dueDate}
                                    onChange={(e) => this.handleFormInputChange(e)}
                                />
                                <div className="error-message">{this.state.dueDateError}</div>
                            </div>

                            <div className="cohort-row">
                                <input
                                    checked={this.state.isCohortProject}
                                    type="checkbox"
                                    name="isCohortProject"
                                    id="isCohortProject"
                                    onChange={(e) =>
                                        this.setState({ isCohortProject: !this.state.isCohortProject })
                                    }
                                />
                                <label htmlFor="isCohortProject">This is a cohort project</label>
                            </div>

                            
                            <div className="inputGroup">
                                <label htmlFor="employeeID">Employee ID:</label>
                                <select
                                    className={this.state.employeeIDError.length > 0 ? "error" : ""}
                                    name="employeeID"
                                    id="employeeID"
                                    value={this.state.employeeID}
                                    onChange={(e) => this.handleFormInputChange(e)}
                                    disabled={this.state.isCohortProject}
                                >
                                    <option value="">--Select A Student--</option>

                                    {this.props.employees.map((student) => {
                                        return (<option value={student.id} key={student.id}>{`${student.firstName} ${student.lastName}`}</option>)
                                         })
                                    }

                                </select>
                                <div className="error-message">{this.state.employeeIDError}</div>
                                </div>

                            <div className="inputGroup">
                                <label htmlFor="cohort">Cohort:</label>
                                <input
                                    className={this.state.cohortError.length > 0 ? "error" : ""}
                                    type="text"
                                    name="cohort"
                                    id="cohort"
                                    value={this.state.cohort}
                                    onChange={(e) => this.handleFormInputChange(e)}
                                    disabled={!this.state.isCohortProject}
                                />
                                <div className="error-message">{this.state.cohortError}</div>
                            </div>

                            <button type="submit" disabled={this.props.projects.createProject.isLoading}>Create Project</button>
                            <div className="statusMessage">{statusMessage}</div>
                        </form>
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
                    state: {  }
                }}
                />);
            }
            // if redirect is false, display the home page
            else {
                return this.renderCreateProject();
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
        createStudentProject: createStudentProjectFunc(dispatch),
        createCohortProject: createCohortProjectFunc(dispatch),
        getEmployees: getEmployeesFunc(dispatch)
    }
}

// add the redux store to props
function mapStateToProps(state) {
    return {
        authentication: state.userAccountsReducer,
        employees: state.employeesReducer.employees.data,
        projects: state.projectsReducer
    }
}

// export the Component
export default connect(mapStateToProps, mapDispatchToProps)(CreateProject);