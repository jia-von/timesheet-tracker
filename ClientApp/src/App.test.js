import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import App from './App';

import { BrowserRouter } from "react-router-dom";
import { createStore, combineReducers } from "redux";
import { Provider } from "react-redux";
import timesheetTrackerReducer from "./reducers/timesheetTracker";
import userAccountsReducer from "./reducers/userAccounts";
import projectsReducer from "./reducers/projects";
import employeesReducer from "./reducers/employees";


// combine all reducers we want to use
const combinedReducer = combineReducers({
    userAccountsReducer,
    timesheetTrackerReducer,
    projectsReducer,
    employeesReducer
})

// create the redux store with the combination of all reducers
const timesheetTrackerStore = createStore(combinedReducer);

const Root = (store) => (
    <Provider store={store.store}>
        <BrowserRouter >
            <App />
        </BrowserRouter>
    </Provider>
);

it('renders without crashing', async () => {
  const div = document.createElement('div');
  ReactDOM.render(
      <Root store={timesheetTrackerStore} />, div);
  await new Promise(resolve => setTimeout(resolve, 1000));
});
