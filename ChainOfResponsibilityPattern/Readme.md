# Chain of responsibility
It's a behavioral design pattern, that enables passing request along a chain handlers. Each handler gets a change to deal with the request, then pass it to the next hanlder in line.

## Examples 
Think about how a web framework processes a request. First the web serveer receives the request, then it hands the request over to the application. The application can have multiple middlewear configured to receive and process a request.

## Variations
There are two ways you can implement Chain of responsibility pattern. In terms of handlers ability to respond
- All hanlders get a chance to process the request.
- It goes along the chain unless a hanlder is capable of responding the request.


