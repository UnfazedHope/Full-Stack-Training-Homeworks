function multiplyNumeric(obj) {
    for (let i in obj) {
        if (typeof obj[i] === 'number') {
            obj[i] *= 2;
        }
    }
}

// For example let's take 
let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};

multiplyNumeric(menu);

console.log(menu);

/* Here the Output will be :
{
    width: 400,
    height: 600,
    title: "My menu"
}

*/
