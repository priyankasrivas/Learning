var express = require('express');
var app = express();
var sql = require("mssql");
var config = {
    user: 'sa',
     password: 'pass@word1',
    server: 'MININT-68ATAFG\\SQLEXPRESS', 
    database: 'MOLLicenseAllocationTool' 
};

app.get('/', function (req, res) {

sql.connect(config, function (err) {

    if (err) console.log(err);

    // create Request object
    var request = new sql.Request();
       
    // query to the database and get the records
    request.query('select * from GlobalSetting', function (err, recordset) {
        
        if (err) console.log(err)

        // send records as a response
        res.send(recordset);
        
    });
});
});


app.get('/GlobalSetting', function (req, res) {

    sql.connect(config, function() {

        var request = new sql.Request();

        request.query('select * from GlobalSetting', function(err, recordset) {

            if(err) console.log(err);

            res.end(JSON.stringify(recordset)); // Result in JSON format

        });

    });

})
var server = app.listen(5000, function () {
console.log('Server is running..');
});