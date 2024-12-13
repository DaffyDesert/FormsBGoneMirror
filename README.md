# Project Title: Forms-B-Gone

**Be aware:** This repository is from an old school project. The SQL data source we used is no longer available.

> The goal of this application is to simplify the management of school-related forms. By moving the process online, parents can easily complete and submit forms, teachers can track form completion, and administrators can effectively manage the documents and user permissions, reducing paperwork and improving efficiency.

## Team Members & Roles

* **Tim Albert:** Security Lead
* **Alex DeAngelis:** Team Lead & Testing Lead
* **Julianne Montague:** SE Lead & Project Coordinator
* **Trent Wells:** Coding Lead

## Features by User Role

### Administrator
* <span style="color: green;">(Complete)</span> **Form Management:** Full CRUD operations over school documents.
* <span style="color: green;">(Complete)</span> **Student/Staff Management:** Manage student and teacher access levels with full CRUD operations.
* <span style="color: green;">(Complete)</span> **Parent Management:** Manage parent accounts with full CRUD operations.

### Teacher
* <span style="color: green;">(Complete)</span> **View Form Status:** View the completion status of student forms, with the ability to filter students by class or search by name for easier management.

### Parent
* <span style="color: green;">(Complete)</span> **Fill in Forms:** Log in, view, and complete forms for their children online. 

## User Documentation

[Forms-B-Gone User Manual](https://docs.google.com/document/d/1L7YCnLll8Kl8gXU1WruQHR0ikdp4gpfzPfapcY5MwRI/edit?tab=t.0#heading=h.vs6rphuip182)

## File Overview

### **FormsBGone**

#### 1. **FormsBGone.csproj**
   - This is the main project file for the **FormsBGone** web application. It references all the necessary services, components, controllers, and models.

#### 2. **Connected Services**
   - Contains services connected to external APIs or other services that the application communicates with (if applicable).

#### 3. **Dependencies**
   - Lists the NuGet packages and external libraries that are required for the application to function properly.

#### 4. **Properties**
   - Contains properties for the project, including settings for assembly information and other configurations.

#### 5. **wwwroot**
   - Contains static files like images, CSS, and JavaScript files that are publicly accessible in the web application.
   - **bootstrap**: Contains the Bootstrap CSS framework files.
   - **Images**: Contains images used in the web application.
   - **uploads**: Holds student ID files and forms uploaded by users.
     - Includes:
       - Base Folder with all empty pdfs 
       - Folders of all students with their forms
       - **app.css**: Custom styles for the application.
       - **favicon.png**: The favicon for the app.

#### 6. **Components**
   - Contains Blazor components used to render parts of the UI.
   - **Layout**
     - `MainLayout.razor`: The main layout for the app that defines the layout structure for pages.
   - **Pages**
     - **Pages for different sections** of the app, such as:
       - `About.razor`, `AdministratorPage.razor`, `LandingPage.razor`, `ParentDirectory.razor`, etc.
       - Each page represents a different section of the web app and is built using Blazor.
   - **Shared**
     - `NavMenu.razor`: The navigation menu component used across the application.
   - **_Imports.razor**: Contains namespaces that are globally imported across Razor files.
   - **App.razor**: The entry point of the application that defines routing and the layout for the app.
   - **AuthMessageHandler.cs**: Handles authentication messages, likely used for API requests with JWT tokens.
   - **Routes.razor**: Handles routing logic for the application.

#### 7. **Controllers**
   - Contains the main API controller for managing account operations.
   - `AccountController.cs`: Handles API requests related to user authentication and account management.
   - `IAccountController.cs`: Interface for the `AccountController`.

#### 8. **DTOs (Data Transfer Objects)**
   - These classes are used to transfer data between client and server in a structured way.
   - `CustomUserClaims.cs`, `LoginDTO.cs`, `RegisterDTO.cs`, `UserSession.cs`: Handle user-specific data like login details and session management.

#### 9. **Models**
   - Contains the core business models for the application.
   - Includes models for entities like `Account.cs`, `Administrator.cs`, `Form.cs`, `Parent.cs`, `Student.cs`, etc., representing the data used throughout the application.

#### 10. **Repos (Repositories)**
   - Contains classes responsible for data access logic.
   - `AccountLogin.cs`: Handles login-related database queries or business logic.
   - `IAccountLogin.cs`: Interface for account login operations.

#### 11. **Responses**
   - `CustomResponses.cs`: Defines custom response objects, likely used for API responses or error handling.

#### 12. **Services**
   - Contains business logic and operations for different parts of the app.
   - `AccountService.cs`: Handles user account-related services.
   - `IAccountService.cs`: Interface for `AccountService`.

#### 13. **States**
   - Contains state management files.
   - `Constants.cs`: Holds constant values used throughout the app.
   - `CustomAuthenticationStateProvider.cs`: Custom authentication logic for managing user sessions.
   - `DecryptJWTService.cs`: Service for decrypting JWT tokens, likely used for authentication.

#### 14. **appsettings.json**
   - Configuration file containing application settings such as database connections, authentication settings, and other environment variables.

#### 15. **CapstoneContext.cs**
   - Contains the Entity Framework DbContext that interacts with the database to manage the application's data.

#### 16. **Program.cs**
   - The entry point for the application. It configures services and middleware required to run the app.

---

### **FormsBGoneTests**

This project contains unit and integration tests for the **FormsBGone** web application.

#### 1. **FormsBGoneTests.csproj**
   - This is the project file for the test project. It references testing libraries and components required for testing the application.

#### 2. **Dependencies**
   - Lists the dependencies needed for testing, such as Bunit, xUnit, etc.

#### 3. **wwwroot**
   - Contains static files needed for the test environment, similar to the main project.

#### 4. **_Imports.razor**
   - Contains globally imported namespaces used for testing.

#### 5. **appsettings.json**
   - Contains configuration settings specific to the test environment.

#### 6. **BunitTestContext.cs**
   - Context file for configuring Bunit, a testing framework for Blazor components.

#### 7. **Test Files**
   - These files contain tests for different parts of the application, such as:
     - `TestAccountController.cs`, `TestAdministratorPage.razor`, `TestLoginPage.razor`, etc.
     - Each file contains unit or integration tests for the respective component or page in the main project.
