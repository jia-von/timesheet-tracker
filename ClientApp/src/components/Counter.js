import React, { Component } from "react";
import { connect } from "react-redux";
import { sample } from "../actions/timesheetTracker";

class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1,
    });
  }

  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p aria-live="polite">
          Current count: <strong>{this.state.currentCount}</strong>
        </p>

        <button className="btn btn-primary" onClick={this.incrementCounter}>
          Increment
        </button>

        <p aria-live="polite">
          Current message: <strong>{this.props.message}</strong>
        </p>
        <button
          className="btn btn-primary"
          onClick={() => {
            this.props.dispatch(sample());
          }}
        >
          Increment
        </button>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    message: state.message,
  };
}
export default connect(mapStateToProps)(Counter);
