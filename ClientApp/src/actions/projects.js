﻿import * as actionType from "./constants";
import axios from "axios";

// Tutorial from 4.1-react-redux-to-do-app @link: https://github.com/TECHCareers-by-Manpower/4.1-react-redux-to-do-app
// create a function to handle all the processes of a request

// finds a single project with matching ID
const getProjectByID = async (dispatch, id, key) => {
    dispatch({ type: actionType.GET_PROJECT_BY_ID_REQUEST });

    try {
        let response = await axios({
            url: "project/id",
            method: "get",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                id
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.GET_PROJECT_BY_ID_SUCCESS, value: data });
    } catch (error) {
        let errorMessage = "";

        if (error.response.status === 403) { errorMessage = "Unauthorized Request."; }
        else if (typeof (error.response.data) === "object") { errorMessage = error.response.data.errors; }
        else { errorMessage = error.response.data; }

        dispatch({ type: actionType.GET_PROJECT_BY_ID_FAIL, value: errorMessage });
    }
}

const getProjectByIDFunc = (dispatch) => {
    return (id, key) => getProjectByID(dispatch, id, key);
}

// returns all projects belonging to a user ID
const getUserProjectsByID = async (dispatch, id, key) => {
    dispatch({ type: actionType.GET_PROJECTS_REQUEST });

    try {
        let response = await axios({
            url: "project/student",
            method: "get",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                id
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.GET_PROJECTS_SUCCESS, value: data });
    } catch (error) {
        let errorMessage = "";

        if (error.response.status === 403) { errorMessage = "Unauthorized Request."; }
        else if (typeof (error.response.data) === "object") { errorMessage = error.response.data.errors; }
        else { errorMessage = error.response.data; }

        dispatch({ type: actionType.GET_PROJECTS_FAIL, value: errorMessage });
    }
}

// create a "Factory" that returns the get user projects by id function
const getUserProjectsByIDFunc = (dispatch) => {
    return (id, key) => getUserProjectsByID(dispatch, id, key);
}

// get all projects (instructors only)
// returns all the projects in the DB 
const getAllProjects = async (dispatch, key) => {
    dispatch({ type: actionType.GET_PROJECTS_REQUEST });

    try {
        let response = await axios({
            url: "project/instructor",
            method: "get",
            headers: {
                Authorization: `Bearer ${key}`
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.GET_PROJECTS_SUCCESS, value: data });
    } catch (error) {
        let errorMessage = "";

        if (error.response.status === 403) { errorMessage = "Unauthorized Request."; }
        else if (typeof (error.response.data) === "object") { errorMessage = error.response.data.errors; }
        else { errorMessage = error.response.data; }

        dispatch({ type: actionType.GET_PROJECTS_FAIL, value: errorMessage });
    }
}

const getAllProjectsFunc = (dispatch) => {
    return (key) => getAllProjects(dispatch, key);
}

// create a new project for one student
const createStudentProject = async (dispatch, projectName, dueDate, employeeID, key) => {
    dispatch({ type: actionType.CREATE_PROJECT_REQUEST });

    try {
        let response = await axios({
            url: "project/instructor/create",
            method: "post",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                projectName,
                dueDate,
                employeeID
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.CREATE_PROJECT_SUCCESS, value: data });
    } catch (error) {
        let errorMessage = "";

        if (error.response.status === 403) { errorMessage = "Unauthorized Request."; }
        else if (typeof (error.response.data) === "object") { errorMessage = error.response.data.errors; }
        else { errorMessage = error.response.data; }

        dispatch({ type: actionType.CREATE_PROJECT_FAIL, value: errorMessage });

    }
}

const createStudentProjectFunc = (dispatch) => {
    return (projectName, dueDate, employeeID, key) => createStudentProject(dispatch, projectName, dueDate, employeeID, key);
}

// create a project for all students in a cohort
const createCohortProject = async (dispatch, projectName, dueDate, cohort, isCohortProject, key) => {
    dispatch({ type: actionType.CREATE_PROJECT_REQUEST });

    try {
        let response = await axios({
            url: "project/instructor/createbycohort",
            method: "get",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                projectName,
                dueDate,
                cohort,
                isCohortProject
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.CREATE_PROJECT_SUCCESS, value: data });
    } catch (error) {
        let errorMessage = "";

        if (error.response.status === 403) { errorMessage = "Unauthorized Request."; }
        else if (typeof (error.response.data) === "object") { errorMessage = error.response.data.errors; }
        else { errorMessage = error.response.data; }

        dispatch({ type: actionType.CREATE_PROJECT_FAIL, value: errorMessage });
    }
}

const createCohortProjectFunc = (dispatch) => {
    return (projectName, dueDate, cohort, isCohortProject, key) => createCohortProject(dispatch, projectName, dueDate, cohort, isCohortProject, key);
}

// add hours to a project
const updateProject = async (dispatch, projectID, design, doing, codeReview, testing, deliverables, key) => {
    dispatch({ type: actionType.MODIFY_PROJECT_REQUEST });

    try {
        let response = await axios({
            url: "project/student/update",
            method: "patch",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                projectID,
                design,
                doing,
                codeReview,
                testing,
                deliverables
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.MODIFY_PROJECT_SUCCESS, value: data, deleted: false });
    } catch (error) {
        if (typeof (error.response.data) === "object") {
            dispatch({ type: actionType.MODIFY_PROJECT_FAIL, value: error.response.data.errors });
        } else {
            dispatch({ type: actionType.MODIFY_PROJECT_FAIL, value: error.response.data });
        }
    }
}

const updateProjectFunc = (dispatch) => {
    return (projectID, design, doing, codeReview, testing, deliverables, key) => updateProject(dispatch, projectID, design, doing, codeReview, testing, deliverables, key);
}

// delete a project
const deleteProject = async (dispatch, projectID, key) => {
    dispatch({ type: actionType.MODIFY_PROJECT_REQUEST });

    try {
        let response = await axios({
            url: "project/student/archive",
            method: "patch",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                projectID
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.MODIFY_PROJECT_SUCCESS, value: data, deleted: true });
    } catch (error) {
        if (typeof (error.response.data) === "object") {
            dispatch({ type: actionType.MODIFY_PROJECT_FAIL, value: error.response.data.errors });
        } else {
            dispatch({ type: actionType.MODIFY_PROJECT_FAIL, value: error.response.data });
        }
    }
}

const deleteProjectFunc = (dispatch) => {
    return (projectID, key) => deleteProject(dispatch, projectID, key);
}


// complete a project
const completeProject = async (dispatch, projectID, key) => {
    dispatch({ type: actionType.COMPLETE_PROJECT_REQUEST });

    try {
        let response = await axios({
            url: "project/student/complete",
            method: "patch",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                projectID
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.COMPLETE_PROJECT_SUCCESS, value: data});
    } catch (error) {
        if (typeof (error.response.data) === "object") {
            dispatch({ type: actionType.COMPLETE_PROJECT_FAIL, value: error.response.data.errors });
        } else {
            dispatch({ type: actionType.COMPLETE_PROJECT_FAIL, value: error.response.data });
        }
    }
}

const completeProjectFunc = (dispatch) => {
    return (projectID, key) => completeProject(dispatch, projectID, key);
}


export { getProjectByIDFunc, getAllProjectsFunc, getUserProjectsByIDFunc, createStudentProjectFunc, createCohortProjectFunc, updateProjectFunc, deleteProjectFunc, completeProjectFunc }