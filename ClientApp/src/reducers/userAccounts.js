// import all the constants to be used for indicating action types
import * as actionType from "../actions/constants";
// set the default state to be used if state is not provided to the userAccountsReducer
const defaultState = {
    signIn: {
        isLoading: false,
        isCompleted: false,
        error: null,
        data: null
    },
    signUp: {
        isLoading: false,
        isCompleted: false,
        error: null,
        data: null
    }
};

/**
 * this reducer handles interaction (CRUD) with the API controller and makes data available for the timesheet tracker react frontend
 * @param {object} state state value to be modified based on the desired action
 * @param {object} action action with type and obtional value. specifies how to mutate the state
 */
const userAccountsReducer = (state = defaultState, action) => {
    // add a temporarystate to be used for mutations without affecting the original state value
    const tempState = { ...state };

    switch (action.type) {
        // SIGN IN CASES 
        case actionType.SIGN_IN_REQUEST:
            tempState.signIn = {
                isLoading: true,
                isCompleted: false,
                error: null,
                data: null
            };
            return tempState;

        case actionType.SIGN_IN_SUCCESS:
            tempState.signIn = {
                isLoading: false,
                isCompleted: true,
                error: null,
                data: action.value
            };
            return tempState;

        case actionType.SIGN_IN_FAIL:
            tempState.signIn = {
                isLoading: false,
                isCompleted: true,
                error: action.value,
                data: null
            };
            return tempState;

        // SIGN OUT CASE
        case actionType.SIGN_OUT:
            tempState.signIn = {
                isLoading: false,
                isCompleted: false,
                error: null,
                data: null
            }
            return tempState;

        // SIGN UP CASES 
        case actionType.SIGN_UP_REQUEST:
            tempState.signUp = {
                isLoading: true,
                isCompleted: false,
                error: null,
                data: null
            };
            return tempState;

        case actionType.SIGN_UP_SUCCESS:
            tempState.signUp = {
                isLoading: false,
                isCompleted: true,
                error: null,
                data: action.value
            };
            return tempState;

        case actionType.SIGN_UP_FAIL:
            tempState.signUp = {
                isLoading: false,
                isCompleted: true,
                error: action.value,
                data: null
            };
            return tempState;

        default:
            return state;
    }
};

export default userAccountsReducer;