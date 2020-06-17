var fs=require("fs")

var array1 = require('./coldData.json');
var array2 = require('./rawData.json');

var expected = array1.map(a => Object.assign(a, array2.find(b => b.clientid == a.clientid)));
console.log(expected);

let json = JSON.stringify(expected);
fs.writeFile('myjsonfile.json', json, function (err){
    if(err) console.log(`error!::${err}`);
});