Prerequest : there should be MS SQL server instance up and running on localhost. If SQL server is on some other machine,
please configure orionDB configuration property in file appsettings.json .

1. Start REST server application TextParsingServer.API. Browser will also start, pass test data to server, and show resulting integer.
Check value apiUrl in config file appsettings.json, make sure the port is the same as in browser.

2. Start console application TextParsingClient. It expects one of three parameter values for launching :
- C (console);
- F (file);
- DB (database).
(If you start it from VS, it will pass F as parameter.)

Application reads string value from appropriate source, and passes it to server. It writes resulting value to console.