# Project:

## Goals

Create a three-tier application that can store and display information about minigolf balls. The user interface would allow a user to view the details about each ball, add a new ball to the database, and update the details of each ball. Admin can delete a ball from the database. If time allows, additional features could be implemented including search functionality, comparison, user accounts and collections. The full list of requirements and stretch goals can be found on the Project Board.

## Review

## Retrospectives

# Sprint 1:

## Goals:

* Create a solution and three projects for a three-tier application.
* Implement interface using MVVM (Model View ViewModel) with Caliburn.Micro framwork.
  * Demonstrate it works with dummy data in the ViewModel.
* Create a minimal database
* Scaffold the class models in the Models project
* Write basic CRUD operations
  * Create Unit tests
* Create wire frames for the main window
  * Viewing the details of a minigolf balls and a list of all minigolf balls in the database

## Review:

* A very basic user interface was implemented
* Scaffolding the database proved difficult.
  * The default project of the package manager console was changed to the Models project, which resolved the problem.
* Tests for database access (CRUD) operations were created

Did Not Start:

* Implementation of CRUD Operations
* Wire frames

## Retrospective

Unforeseen delays in connecting the database led to delays in implementing the methods to query the database from the application. The user interface is yet to be designed. These will be completed during the next sprint and constitute the minimal viable product.

# Sprint 2

* Testing and Implementation of CRUD Operations
* Create Wireframes
* Create Basic UI
* Allow users to select a ball from the database and display it's information in the UI.