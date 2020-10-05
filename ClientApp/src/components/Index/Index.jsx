import React from "react";
import { connect } from "react-redux";
import { sample } from "../../actions/timesheetTracker";

class Index extends React.Component {
  render() {
    let message =
      this.props.store.message === ""
        ? "Default message"
        : this.props.store.message;

    return (
      <>
        <h1> Hello World Sample</h1>
        <strong>{message}</strong>
        <button onClick={() => this.props.dispatch(sample())}>
          Dispatch Hello
        </button>
      </>
    );
  }
}

// map redux to this component's props
function mapStateToProps(state) {
  return {
    store: state,
  };
}
export default connect(mapStateToProps)(Index);
