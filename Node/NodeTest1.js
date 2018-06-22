var http = require('http');
var myDateTime= require('./Module1');
http.createServer(function (req, res) {
    res.writeHead(200, {'Content-Type': 'text/plain'});
    res.write("The current Date and Time " + myDateTime.MyDateTime() );
    res.write(req.url);
    res.end('Hello World!');
}).listen(8080);