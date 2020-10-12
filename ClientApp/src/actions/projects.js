import * as actionType from "./constants";
import axios from "axios";

// create a function to handle all the processes of a request
const getUserProjectsByID = async (dispatch, id) => {
    dispatch({ type: actionType.GET_PROJECTS_REQUEST });

    try {
        let response = await axios({
            url: "TODO",
            method: "get",
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
    return (id) => getUserProjectsByID(dispatch, id);
}

// get all projects (instructors onl) 
const getAllProjects = async () => {
    dispatch({ type: actionType.GET_PROJECTS_REQUEST });

    try {
        let response = await axios({
            url: "TODO",
            method: "get"
        });
        let data = await response.data;
        dispatch({ type: actionType.GET_PROJECTS_SUCCESS, value: data });
    } catch (error) {
        dispatch({ type: actionType.GET_PROJECTS_FAIL, value: error.response.data });
    }
}

const getAllProjectsFunc = (dispatch) => {
    return () => getAllProjects(dispatch);
}


export { getAllProjectsFunc, getUserProjectsByIDFunc }