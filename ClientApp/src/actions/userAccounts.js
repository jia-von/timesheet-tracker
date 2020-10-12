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

// create the action which handles sign out
const signOut = async (dispatch) => {
    // dispatch the request so we know we are beginning a new request
    dispatch({ type: actionType.SIGN_OUT });
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
            }); // TODO use sign up data here for instructor
        } else {
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
            }); // TODO use sign up data here for student
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

export { signInFunc, signUpFunc, signOutFunc }