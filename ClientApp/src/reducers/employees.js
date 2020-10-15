import * as actionType from "../actions/constants";

const defaultState = {
    employees: {
        isLoading: false,
        isCompleted: false,
        data: [],
        error: null
    }
}

const employeesReducer = (state = defaultState, action) => {
    let temporaryState = { ...state };

    switch (action.type) {
        case actionType.GET_EMPLOYEES_REQUEST:
            temporaryState.employees = {
                isLoading: true,
                isCompleted: false,
                data: [],
                error: null
            };
            return temporaryState;

        case actionType.GET_EMPLOYEES_SUCCESS:
            temporaryState.employees = {
                isLoading: false,
                isCompleted: true,
                data: action.value,
                error: null
            };
            return temporaryState;

        case actionType.GET_EMPLOYEES_FAIL:
            temporaryState.employees = {
                isLoading: false,
                isCompleted: true,
                data: [],
                error: action.value
            };
            return temporaryState;

        default:
            return state;
    }
}

export default employeesReducer;