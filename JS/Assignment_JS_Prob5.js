// 1st step - Create an array styles with items "James" and "Brennie"
let styles = ["James", "Brennie"];
console.log(styles);                                                     // ["James", "Brennie"]

// 2nd step - Append "Robert" to the end
styles.push("Robert");
console.log(styles);                                                     // ["James", "Brennie", "Robert"]

// 3rd step - Replace the value in the middle by "Calvin"
let middleIndex = Math.floor(styles.length / 2);                         // used this logic which will work in every condition
styles[middleIndex] = "Calvin";
console.log(styles);                                                     // ["James", "Calvin", "Robert"]

// 4th step - Remove the first value of the array and show it
let firstValue = styles.shift();
console.log(firstValue);                                                 // "James"
console.log(styles);                                                     // ["Calvin", "Robert"]

// 5th step - Prepend "Rose" and "Regal" to the array
styles.unshift("Rose", "Regal");
console.log(styles);                                                     // ["Rose", "Regal", "Calvin", "Robert"]
