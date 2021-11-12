Banking Management System

Use Cases
1. Customer register and update profile
2. Apply for loan and get details of all applied loans

Technology Stack Used
- .Net 5
- Entity Framework Core with Code First Apporach
- ASP.NET Core Web API
- Xunit for unit tests

Best Practices
- Layered architecture
- Used repository pattern with Unit of work pattern
- Automapper
- Serilog for logging
- Rijndael Cipher for encryption of password
- APIs are protected using Jwt Bearer token based authentication
- Automapper used for mapping property of different class types
- Used global exception handler
- Used attribute class for global level model validation
- Used annotation based model validation
- Used TDD (using Xunit)