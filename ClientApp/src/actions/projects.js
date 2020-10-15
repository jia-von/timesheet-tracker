import * as actionType from "./constants";
import axios from "axios";

// create a function to handle all the processes of a request
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
        dispatch({ type: actionType.GET_PROJECTS_FAIL, value: error.response.data });
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
        dispatch({ type: actionType.GET_PROJECTS_FAIL, value: error.response.data });
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
        dispatch({ type: actionType.CREATE_PROJECT_FAIL, value: error.response.data });
    }
}

const createStudentProjectFunc = (dispatch) => {
    return (projectName, dueDate, employeeID, key) => createStudentProject(dispatch, projectName, dueDate, employeeID, key);
}

// create a project for a cohort
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
        dispatch({ type: actionType.CREATE_PROJECT_FAIL, value: error.response.data });
    }
}

const createCohortProjectFunc = (dispatch) => {
    return (projectName, dueDate, cohort, isCohortProject, key) => createCohortProject(dispatch, projectName, dueDate, cohort, isCohortProject, key);
}

export { getAllProjectsFunc, getUserProjectsByIDFunc, createStudentProjectFunc, createCohortProjectFunc }