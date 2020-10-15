import * as actionType from "./constants";
import axios from "axios";

// create the action which handles all stages of the sign in request
const signIn = async (dispatch, email, password) => {
    // dispatch the request so we know we are beginning a new request
    dispatch({ type: actionType.SIGN_IN_REQUEST });

    // try the request
    try {
        // use post to send the passwords in the data vs the url
        const response = await axios({
            url: "person/authenticate",
            method: "post",
            params: {
                email,
                password
            }
        }); // TODO use email and password here
        const data = await response.data;
        dispatch({ type: actionType.SIGN_IN_SUCCESS, value: data });
    } catch (error) {
        dispatch({ type: actionType.SIGN_IN_FAIL, value: error.response.data })
    }
}

// create a function "factory" which will pass the handler action when called
const signInFunc = dispatch => {
    return (email, password) => signIn(dispatch, email, password);
}

// create a function "factory" which will pass the handler action when called
const signOutFunc = dispatch => {
    return () => dispatch({ type: actionType.SIGN_OUT });
}


// create the action to handle sign up requests
const signUp = async (dispatch, firstName, lastName, email, password, isInstructorString, cohort) => {
    // dispatch to signal start of request
    dispatch({ type: actionType.SIGN_UP_REQUEST });

    // try the request
    try {
        let response;
        // make requests for instructors
        if (isInstructorString === "instructor") {
            response = await axios({
                url: "person/create",
                method: "post",
                params: {
                    firstName,
                    lastName,
                    email,
                    password,
                    isInstructorString,
                    cohort: 0
                }
            });
        }
        // make requests for students
        else {
            response = await axios({
                url: "/person/create",
                method: "post",
                params: {
                    firstName,
                    lastName,
                    email,
                    password,
                    isInstructorString,
                    cohort
                }
            });
        }
        const data = await response.data;
        dispatch({ type: actionType.SIGN_UP_SUCCESS, value: data });
    } catch (error) {
        dispatch({ type: actionType.SIGN_UP_FAIL, value: error.response.data });
    }
}

// create the function factory for sign up
const signUpFunc = dispatch => {
    return (firstName, lastName, email, password, isInstructor, cohort) => signUp(dispatch, firstName, lastName, email, password, isInstructor, cohort )
}

// create the function to handle updating accounts
const updateAccount = async (dispatch, personID, firstName, lastName, currentPassword, newPassword, isUpdatingPassword, key) => {
    dispatch({ type: actionType.UPDATE_ACCOUNT_REQUEST });

    try {
        let response = await axios({
            url: "person/update",
            method: "patch",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                personID,
                firstName,
                lastName,
                currentPassword,
                newPassword,
                isUpdatingPassword
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.UPDATE_ACCOUNT_SUCCESS, value: data });
    } catch (error) {
        dispatch({ type: actionType.UPDATE_ACCOUNT_FAIL, value: error.response.data })
    }
}

const updateAccountFunc = (dispatch) => {
    return (personID, firstName, lastName, currentPassword, newPassword, isUpdatingPassword, key) => 
        updateAccount(dispatch, personID, firstName, lastName, currentPassword, newPassword, isUpdatingPassword, key);
}

// create the function to handle deleting accounts
const deleteAccount = async (dispatch, personID, key) => {
    dispatch({ type: actionType.DELETE_ACCOUNT_REQUEST });

    try {
        let response = await axios({
            url: "person/delete",
            method: "delete",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                personID
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.DELETE_ACCOUNT_SUCCESS, value: data });
    } catch (error) {
        dispatch({ type: actionType.DELETE_ACCOUNT_FAIL, value: error.response.data })
    }
}

const deleteAccountFunc = (dispatch) => {
    return (personID, key) =>
        deleteAccount(dispatch, personID, key);
}

export { signInFunc, signUpFunc, signOutFunc, updateAccountFunc, deleteAccountFunc }