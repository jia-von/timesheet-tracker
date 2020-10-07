// set the default state to be used if state is not provided to the timesheetTrackerReducer
// this will be the case for initial loads of the app (before api calls/user interactions)
const defaultState = { message: "" };

/**
 * this reducer handles interaction (CRUD) with the API controller and makes data available for the timesheet tracker react frontend
 * @param {object} state state value to be modified based on the desired action
 * @param {object} action action with type and obtional value. specifies how to mutate the state
 */
const timesheetTrackerReducer = (state = defaultState, action) => {
  // add a temporarystate to be used for mutations without affecting the original state value
  const tempState = { ...state };

  switch (action.type) {
    case "SAMPLE":
      tempState.message = action.value;
      return tempState;

    default:
      return state;
  }
};

export default timesheetTrackerReducer;
