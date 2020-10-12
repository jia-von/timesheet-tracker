import * as actionType from "../actions/constants";

// set the default state to be used if state is not provided to the userAccountsReducer
const defaultState = {
    projects: {
        isLoading: false,
        isCompleted: false,
        error: null,
        data: []
    }
}

const projectsReducer = (state = defaultState, action) => {
    let tempState = { ...state };
    switch (action.type) {
        
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
            }

        case actionType.GET_PROJECTS_FAIL:
            tempState.projects = {
                isLoading: false,
                isCompleted: true,
                error: action.value,
                data: []
            }

        default:
            return tempState;
    }
}

export default projectsReducer;