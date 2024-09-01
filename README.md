# AtulaDotNetTest

This project is a basic ASP.NET Core web application demonstrating CRUD operations with a login system. The application manages products and categories, utilizing .NET Identity for user authentication and authorization.
## Features
User Authentication:
  - Login page with client-side and server-side validation.
  - Extended `ApplicationUser` class to include `FirstName` and `LastName`.
  - Seeded an admin user for initial access.

Product Management:
  - Create, Read, Update, and Delete (CRUD) operations for products.
  - Products can be associated with categories using a many-to-many relationship.
  - Admin user can manage products through the UI.

 Category Management:
  - Products are organized into categories.

## Admin User
The application includes a pre-seeded admin user for testing purposes:
Email: `admin@example.com`
Password: ` Admin@123`   
Access the application:
   - Navigate to `/Account/Login` to log in as the admin.
   - After logging in, you will be redirected to the Products page to perform CRUD operations.

## Future Enhancements
- Implement FluentValidation for backend model validation.
- Enhance the UI with more detailed error messages and validation feedback.
