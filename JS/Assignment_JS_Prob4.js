function truncate(str, maxlength) {
    if (str.length > maxlength) {
        return str.slice(0, maxlength-1) + "...";                 // make its length equal to maxlength 
    } else {
        return str;
    }
}

// Testing this function
console.log(truncate("What I'd like to tell on this topic is:", 20));               // Output : "What I'd like to te..."
console.log(truncate("Hi everyone!", 20));                                          // Output : "Hi everyone!"
