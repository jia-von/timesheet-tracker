﻿// declare constansts to be used to determine type for async reducer actions
// Tutorial from 4.1-react-redux-to-do-app @link: https://github.com/TECHCareers-by-Manpower/4.1-react-redux-to-do-app
const SIGN_IN_REQUEST = "SIGN_IN_REQUEST";
const SIGN_IN_SUCCESS = "SIGN_IN_SUCCESS";
const SIGN_IN_FAIL = "SIGN_IN_FAIL";

const SIGN_UP_REQUEST = "SIGN_UP_REQUEST";
const SIGN_UP_SUCCESS = "SIGN_UP_SUCCESS";
const SIGN_UP_FAIL = "SIGN_UP_FAIL";

const SIGN_OUT = "SIGN_OUT";

const UPDATE_ACCOUNT_REQUEST = "UPDATE_ACCOUNT_REQUEST";
const UPDATE_ACCOUNT_SUCCESS = "UPDATE_ACCOUNT_SUCCESS";
const UPDATE_ACCOUNT_FAIL = "UPDATE_ACCOUNT_FAIL";

const DELETE_ACCOUNT_REQUEST = "DELETE_ACCOUNT_REQUEST";
const DELETE_ACCOUNT_SUCCESS = "DELETE_ACCOUNT_SUCCESS";
const DELETE_ACCOUNT_FAIL = "DELETE_ACCOUNT_FAIL";

const GET_PROJECTS_REQUEST = "GET_PROJECTS_REQUEST";
const GET_PROJECTS_SUCCESS = "GET_PROJECTS_SUCCESS";
const GET_PROJECTS_FAIL = "GET_PROJECTS_FAIL";

const GET_PROJECT_BY_ID_REQUEST = "GET_PROJECT_BY_ID_REQUEST";
const GET_PROJECT_BY_ID_SUCCESS = "GET_PROJECT_BY_ID_SUCCESS";
const GET_PROJECT_BY_ID_FAIL = "GET_PROJECT_BY_ID_FAIL";

const CREATE_PROJECT_REQUEST = "CREATE_PROJECT_REQUEST";
const CREATE_PROJECT_SUCCESS = "CREATE_PROJECT_SUCCESS";
const CREATE_PROJECT_FAIL = "CREATE_PROJECT_FAIL";

const MODIFY_PROJECT_REQUEST = "MODIFY_PROJECT_REQUEST";
const MODIFY_PROJECT_SUCCESS = "MODIFY_PROJECT_SUCCESS";
const MODIFY_PROJECT_FAIL = "MODIFY_PROJECT_FAIL";

const COMPLETE_PROJECT_REQUEST = "COMPLETE_PROJECT_REQUEST";
const COMPLETE_PROJECT_SUCCESS = "COMPLETE_PROJECT_SUCCESS";
const COMPLETE_PROJECT_FAIL = "COMPLETE_PROJECT_FAIL";

const GET_EMPLOYEES_REQUEST = "GET_EMPLOYEES_REQUEST";
const GET_EMPLOYEES_SUCCESS = "GET_EMPLOYEES_SUCCESS";
const GET_EMPLOYEES_FAIL = "GET_EMPLOYEES_FAIL";

export {
    SIGN_IN_REQUEST, SIGN_IN_SUCCESS, SIGN_IN_FAIL, SIGN_UP_REQUEST, SIGN_UP_SUCCESS, SIGN_UP_FAIL, SIGN_OUT,
    UPDATE_ACCOUNT_REQUEST, UPDATE_ACCOUNT_SUCCESS, UPDATE_ACCOUNT_FAIL,
    DELETE_ACCOUNT_REQUEST, DELETE_ACCOUNT_SUCCESS, DELETE_ACCOUNT_FAIL,
    GET_PROJECTS_FAIL, GET_PROJECTS_REQUEST, GET_PROJECTS_SUCCESS, CREATE_PROJECT_REQUEST, CREATE_PROJECT_SUCCESS, CREATE_PROJECT_FAIL,
    GET_PROJECT_BY_ID_REQUEST, GET_PROJECT_BY_ID_SUCCESS, GET_PROJECT_BY_ID_FAIL,
    MODIFY_PROJECT_REQUEST, MODIFY_PROJECT_SUCCESS, MODIFY_PROJECT_FAIL,
    COMPLETE_PROJECT_REQUEST, COMPLETE_PROJECT_SUCCESS, COMPLETE_PROJECT_FAIL,
    GET_EMPLOYEES_SUCCESS, GET_EMPLOYEES_REQUEST, GET_EMPLOYEES_FAIL,
    
}