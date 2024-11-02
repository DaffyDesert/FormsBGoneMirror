# Project Title: Forms-B-Gone

> The goal of this application is to simplify the management of school-related forms. By moving the process online, parents can easily complete and submit forms, teachers can track form completion, and administrators can effectively manage the documents and user permissions, reducing paperwork and improving efficiency.

## Team Members & Roles

* **Tim Albert:** Security Lead
* **Alex DeAngelis:** Team Lead & Testing Lead
* **Julianne Montague:** SE Lead & Project Coordinator
* **Trent Wells:** Coding Lead

## Features by User Role

### Administrator
* <span style="color: green;">(Complete)</span> **Form Management:** Full CRUD operations over school documents.
* <span style="color: red;">(Not Started)</span> **Student/Staff Management:** Manage student and teacher access levels with full CRUD operations.

### Teacher
* <span style="color: green;">(Complete)</span> **View Form Status:** View the completion status of student forms, with the ability to filter students by class or search by name for easier management.
* <span style="color: red;">(Not Started)</span> **Specialized Form Request** ***(Optional):*** Request special forms (e.g., field trip or movie forms) with admin approval required.

### Parent
* <span style="color: green;">(Complete)</span> **Fill in Forms:** Log in, view, and complete forms for their children online. 

## Getting Started

### Dependencies

* Since the program has not been deployed yet, you'll need the following prerequisites in order to run it:
	
	* Visual Studio 2022 (the free, standard version is fine. Not Visual Studio Code)
	* .NET 8.0 framework (installable through the Visual Studio Installer on Windows)
* When you import the solution, Visual Studio should automatically restore your dependency packages.
* Heres a list of those packages in the event that the restore fails:

<details><summary>Package List</summary>

	- BCrypt.Net-Next v 4.0.3
	- Microsoft.AspNetCore.Authentication.JwtBearer v 8.0.8
	- Microsoft.AspNetCore.Components.Authorization v 8.0.8
	- Microsoft.EntityFrameworkCore v 8.0.8
	- Microsoft.EntityFrameworkCore.Design v 8.0.8
	- Microsoft.EntityFrameworkCore.SqlServer v 8.0.8
	- Microsoft.EntityFrameworkCore.Tools v 8.0.8
	- Microsoft.Extensions.DependencyInjection v 8.0.0
	- Microsoft.Extensions.Hosting v 8.0.0
	- Microsoft.IdentityModel.Tokens v 8.0.2
	- Swashbuckle.AspNetCore v 6.8.0
	- System.IdentityModel.Tokens.Jwt v 8.0.2

</details>

### Installing

* To install the program, follow these steps:
	* Download the .zip file of this repository
	* Extract the zip to any location of your choosing
	* Open the `FormsBGone.sln` file with Visual Studio 2022
	* If that didn't work, open Visual Studio 2022 manually
	* Select "Open a project or solution"
	* Navigate to the location of this project
	* Select the `FormsBGone.sln` file

### Executing program

* Since the program has not been published as an executable, you'll need to launch it through Visual Studio
* Follow the Install instructions above, then press the green play icon at the top of the screen.
	* The text next to the play icon should say "https"
	* If the text reads "Select Startup Items", click that and select "https"
* If that option doesn't work or is grayed out, open the Solution Explorer
	* If the solution explorer is not present in your workspace, go to View > Solution Explorer
* Expand the `FormsBGone.csproj` section in the Solution Explorer
* Double-click `Program.cs`
* The play button should work now

## Testing Instructions

* To run the tests, open the solution in Visual studio using the install instructions above
* With the solution open, navigate to Test > Test Explorer
* Here you can see all tests in the project organized by file-system heirarchy
* Run any test you wish, or all at once, from this menu

## Demonstration Video

[Watch the demo video of Sprint 2](https://www.youtube.com/watch?v=jUfXuz36ozI)
