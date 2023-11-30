# `RequestDelegateGenerator` enum parsing case-sensitive

## Minimal reproduction

```console
$ dotnet run
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: ~/request-delegate-generator-enum-parsing-case-sensitive
info: System.Net.Http.HttpClient.Default.LogicalHandler[100]
      Start processing HTTP request GET http://localhost:5000/Hello
info: System.Net.Http.HttpClient.Default.ClientHandler[100]
      Sending HTTP request GET http://localhost:5000/Hello
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/1.1 GET http://localhost:5000/Hello - - -
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'HTTP: GET hello'
info: Microsoft.AspNetCore.Http.Result.ContentResult[2]
      Write content with HTTP Response ContentType of text/plain; charset=utf-8
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'HTTP: GET hello'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished HTTP/1.1 GET http://localhost:5000/Hello - 200 5 text/plain;+charset=utf-8 22.0026ms
info: System.Net.Http.HttpClient.Default.ClientHandler[101]
      Received HTTP response headers after 88.8918ms - 200
info: System.Net.Http.HttpClient.Default.LogicalHandler[101]
      End processing HTTP request after 95.2184ms - 200
info: System.Net.Http.HttpClient.Default.LogicalHandler[100]
      Start processing HTTP request GET http://localhost:5000/hello
info: System.Net.Http.HttpClient.Default.ClientHandler[100]
      Sending HTTP request GET http://localhost:5000/hello
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/1.1 GET http://localhost:5000/hello - - -
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'HTTP: GET hello'
info: Microsoft.AspNetCore.Http.Result.ContentResult[2]
      Write content with HTTP Response ContentType of text/plain; charset=utf-8
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'HTTP: GET hello'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished HTTP/1.1 GET http://localhost:5000/hello - 200 5 text/plain;+charset=utf-8 0.3689ms
info: System.Net.Http.HttpClient.Default.ClientHandler[101]
      Received HTTP response headers after 1.9361ms - 200
info: System.Net.Http.HttpClient.Default.LogicalHandler[101]
      End processing HTTP request after 2.0082ms - 200
info: System.Net.Http.HttpClient.Default.LogicalHandler[100]
      Start processing HTTP request GET http://localhost:5000/Some
info: System.Net.Http.HttpClient.Default.ClientHandler[100]
      Sending HTTP request GET http://localhost:5000/Some
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/1.1 GET http://localhost:5000/Some - - -
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'HTTP: GET {enum}'
info: Microsoft.AspNetCore.Http.Result.ContentResult[2]
      Write content with HTTP Response ContentType of text/plain; charset=utf-8
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'HTTP: GET {enum}'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished HTTP/1.1 GET http://localhost:5000/Some - 200 4 text/plain;+charset=utf-8 4.1449ms
info: System.Net.Http.HttpClient.Default.ClientHandler[101]
      Received HTTP response headers after 4.7427ms - 200
info: System.Net.Http.HttpClient.Default.LogicalHandler[101]
      End processing HTTP request after 4.7711ms - 200
info: System.Net.Http.HttpClient.Default.LogicalHandler[100]
      Start processing HTTP request GET http://localhost:5000/some
info: System.Net.Http.HttpClient.Default.ClientHandler[100]
      Sending HTTP request GET http://localhost:5000/some
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/1.1 GET http://localhost:5000/some - - -
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'HTTP: GET {enum}'
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'HTTP: GET {enum}'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished HTTP/1.1 GET http://localhost:5000/some - 400 0 - 0.4718ms
info: System.Net.Http.HttpClient.Default.ClientHandler[101]
      Received HTTP response headers after 1.1324ms - 400
info: System.Net.Http.HttpClient.Default.LogicalHandler[101]
      End processing HTTP request after 1.208ms - 400
Unhandled exception. System.Net.Http.HttpRequestException: Response status code does not indicate success: 400 (Bad Request).
   at System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode()
   at Program.<Main>$(String[] args) in /_/Program.cs:line 44
   at Program.<Main>(String[] args)
```
