import * as actionType from "./constants";
import axios from "axios";

// returns a list of employees by role (instructor or student) 
// returns all employees if role doesnt match an available role & isnt empty/whitespace
const getEmployees = async (dispatch, role, key) => {
    dispatch({ type: actionType.GET_EMPLOYEES_REQUEST });

    try {
        let response = await axios({
            url: "employee/instructor/all",
            method: "get",
            headers: {
                Authorization: `Bearer ${key}`
            },
            params: {
                input: role
            }
        });
        let data = await response.data;
        dispatch({ type: actionType.GET_EMPLOYEES_SUCCESS, value: data });
    } catch (error) {
        dispatch({ type: actionType.GET_EMPLOYEES_FAIL, value: error.response.data });
    }
}

const getEmployeesFunc = (dispatch) => {
    return (role, key) => getEmployees(dispatch, role, key);
}

export { getEmployeesFunc };