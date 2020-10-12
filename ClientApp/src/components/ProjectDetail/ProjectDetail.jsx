import React from "react";
import axios from "axios";
import { connect } from "react-redux";
import "./ProjectDetail.css";
import { getAllProjectsFunc, getUserProjectsByIDFunc } from "../../actions/projects";

class Home extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    componentDidMount() {
        // do something on initial page load
    }

    render() {

        return (<div></div>);
    }
}


// add the redux async actions to props
mapDispatchToProps(dispatch) {
    return {
        getAllProjects: getAllProjectsFunc(dispatch),
        getAllUserProjectsByID: getUserProjectsByIDFunc(dispatch)
    }
}

// add the redux store to props
mapStateToProps(state) {
    return {
        projects: state.projects
    }
}

// export the Component
export default connect(mapStateToProps, mapDispatchToProps)(ProjectDetail);