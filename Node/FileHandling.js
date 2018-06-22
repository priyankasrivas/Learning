
var fs = require('fs');
fs.writeFile("NwTextFile.txt","New Hello Content !", function(err)
{
if(err) throw err;
console.log("Saved!");
});