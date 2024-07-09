function checkEmailId(str) {
    // Convert the string to lowercase (make the function case-insensitive)
    str = str.toLowerCase();

    // Get the positions of '@' and '.'
    let atIndex = str.indexOf('@');
    let dotIndex = str.indexOf('.', atIndex + 1);

    // Logic to check if '@' and '.' exists
    if (atIndex > 0 && dotIndex > atIndex + 1) {
        return true;
    } else {
        return false;
    }
}

// For example let's take below tests for this function
console.log(checkEmailId("vish@example.com"));   // true
console.log(checkEmailId("vish.example@com"));   // false
console.log(checkEmailId("vish@examplecom"));    // false
console.log(checkEmailId("vish@example.c"));     // true
console.log(checkEmailId("vish@.com"));          // false
console.log(checkEmailId("VISH@EXAMPLE.COM"));   // true
