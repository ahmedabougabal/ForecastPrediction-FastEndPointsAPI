# fastEndPointsAPIs


## request endpoint response pattern

![image](https://github.com/user-attachments/assets/0fa28557-2dd9-4106-8acd-28e0012b6430)

---
## mappers 
specialized classes to ease the manual conversion of data between different types of objects
within the application.

where these objects are request DTOs, domain entities, and response DTOs.

DTOs are type of objects that are meant for transferring data between different layers
of an application (like between presentation layer and business logic layer).

## in the context of APIs:
- request DTOs : are the type of data objects that come from client to server
- response DTOs : type of data being sent to the client
- nutshell : request DTOs would be the objects that hold the data coming in from the client, and response DTOs would be the objects that hold the data being sent back to the client.

- domain entities are the objects that represent the core business concepts in the application. 


now discussing mappers : they are used to transform request DTOs into domain entities
and then transform those domain entities into response DTOs.

nutshell : don't expose those domain entities instead, use mappers to control what data to be sent and recieved.


-- mapper classes are used as singletons according to documentation.
please refer to this documentation link : 
https://fast-endpoints.com/docs/domain-entity-mapping#mapping-logic-in-a-separate-class

--- 
## adds endpoints documentation as per fastendpoints docs manual 
![image](https://github.com/user-attachments/assets/ed02cdc9-e9c0-44d4-8d48-104d016df52f)




