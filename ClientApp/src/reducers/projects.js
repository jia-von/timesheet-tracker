import * as actionType from "../actions/constants";

// set the default state to be used if state is not provided to the userAccountsReducer
const defaultState = {
    projects: {
        isLoading: false,
        isCompleted: false,
        error: null,
        data: []
    },
    projectByID: {
        isLoading: false,
        isCompleted: false,
        error: null,
        data: null
    },
    createProject: {
        isLoading: false,
        isCompleted: false,
        error: null,
        data: null
    },
    modifyProject: {
        isLoading: false,
        isCompleted: false,
        error: null,
        data: null,
        deleted: false
    }
}

const projectsReducer = (state = defaultState, action) => {
    let tempState = { ...state };
    switch (action.type) {
        // get project By ID cases
        case actionType.GET_PROJECT_BY_ID_REQUEST:
            tempState.projectByID = {
                isLoading: true,
                isCompleted: false,
                error: null,
                data: null
            };
            return tempState;

        case actionType.GET_PROJECT_BY_ID_SUCCESS:
            tempState.projectByID = {
                isLoading: false,
                isCompleted: true,
                error: null,
                data: action.value
            };
            return tempState;

        case actionType.GET_PROJECT_BY_ID_FAIL:
            tempState.projectByID = {
                isLoading: false,
                isCompleted: true,
                error: action.value,
                data: null
            };
            return tempState;

        // get projects cases
        case actionType.GET_PROJECTS_REQUEST:
            tempState.projects = {
                isLoading: true,
                isCompleted: false,
                error: null,
                data: []
            };
            return tempState;

        case actionType.GET_PROJECTS_SUCCESS:
            tempState.projects = {
                isLoading: false,
                isCompleted: true,
                error: null,
                data: action.value
            };
            return tempState;

        case actionType.GET_PROJECTS_FAIL:
            tempState.projects = {
                isLoading: false,
                isCompleted: true,
                error: action.value,
                data: []
            };
            return tempState;

        // create project cases
        case actionType.CREATE_PROJECT_REQUEST:
            tempState.createProject = {
                isLoading: true,
                isCompleted: false,
                error: null,
                data: null
            };
            return tempState;

        case actionType.CREATE_PROJECT_SUCCESS:
            tempState.createProject = {
                isLoading: false,
                isCompleted: true,
                error: null,
                data: action.value
            };
            return tempState;

        case actionType.CREATE_PROJECT_FAIL:
            tempState.createProject = {
                isLoading: false,
                isCompleted: true,
                error: action.value,
                data: null
            };
            return tempState;

        // edit and delete case
        case actionType.MODIFY_PROJECT_REQUEST:
            tempState.modifyProject = {
                isLoading: true,
                isCompleted: false,
                error: null,
                data: null,
                deleted: false
            };
            return tempState;

        case actionType.MODIFY_PROJECT_SUCCESS:
            tempState.modifyProject = {
                isLoading: false,
                isCompleted: true,
                error: null,
                data: action.value,
                deleted: action.deleted
            };
            return tempState;

        case actionType.MODIFY_PROJECT_FAIL:
            tempState.modifyProject = {
                isLoading: false,
                isCompleted: true,
                error: action.value,
                data: null,
                deleted: false
            };
            return tempState

        // default case
        default:
            return state;
    }
}

export default projectsReducer;