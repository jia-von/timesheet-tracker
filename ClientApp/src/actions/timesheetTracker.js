/**
 * sign a user in
 * @param {object} value an object with email and password
 */
const sample = (value) => {
  return {
    type: "SIGN_IN",
    value: value,
  };
};

/**
 * sign a new user up
 * @param {object} value an object with all fields required for a new user
 */
const signUp = (value) => {
    return {
        type: "SIGN_UP",
        value: value
    }
}

export { sample };
