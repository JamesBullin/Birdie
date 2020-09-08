

# Birdie

Minigolf Ball Collection Manager

## Project Goals

* Create a three-tier application that can store and display information about minigolf balls. 
* The user interface would allow a user to:
  * view the details about each ball;
  * add a new ball to the database;
  * update the details of each ball;
  * delete a ball from the database.
* If time allows, additional features could be implemented including search functionality, comparison, user accounts and collections. The full list of requirements and stretch goals can be found on the Project Board Wishlist column.

## Database Schema

![image-20200907233419830](https://github.com/JamesBullin/Birdie/blob/master/BirdieDBSchema.png)

Arrow indicates a many-to-one relationship from Ball to Colour.

# Sprint 1: Wednesday 2 Sep 2020

## Goals:

* Create a solution and three projects for a three-tier application.
* Implement interface using MVVM (Model View ViewModel) with Caliburn.Micro framework.
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

# Sprint 2: Thursday 3 Sep 2020

## Goals

* Testing and Implementation of CRUD Operations
* Create Wireframes
* Create Basic UI
* Allow users to select a ball from the database and display it's information in the UI.

## Review

* Lots of CRUD Operations were created
  * Tests were not created for new 
* Rudimentary ball selection and display created
* List of Colours and manufacturers available to the UI

Did not start:

* Wireframes and UI design

## Retrospective

I had a breakthrough with connecting the database to the UI! But I need to find a way to display normalised data. The UI is still not designed, so I'll do that in the next sprint. However, I'm pleased that there is now some UI functionality.

# Sprint 3: Friday 4 Sep 2020

## Goals

* Resolve issues with displaying normalised data
* Finish and Test CRUD operations
* Make Wireframe
* Create window

## Review

* Resolved displaying normalised data.
* I started designing the user interface using wireframe.io, but quickly realised it would be quicker to design and implement it together using XAML.
* I struggled to add the functionality to the window.

## Retrospective

My initial database schema was too big. It had four linked tables, whereas the minimum requirements for the project was two linked tables. The CRUD functionality was manageable for me at the model-database layers, but connecting it to the UI was too much. Next Sprint, I plan to restart work on the application and stick to the minimum requirements, with the aim to quickly deliver the minimum viable product.

# Sprint 4: Saturday Morning: 5 Sep 2020

## Goals

* Start building from scratch, using the original as a template

* Created MVP database
* Connected database to Models Project using Entity Framework

## Review

* Solution created with UI, Business, Model, and Test projects
* Caliburn Micro framework implemented
* Minimal database created and connected with Entity Framework

Much quicker than the first time.

## Retrospective

Cutting the project scope down to the bare minimum has really improved my development speed. This sprint was achieved in 1/3 of the time I spent on the previous sprints. I am confident I will deliver the MVP and have time to make additional improvements.

# Sprint 5: Saturday Afternoon: 5 Sep 2020

## Goals

* Write basic CRUD Tests
* Implement CRUD functionality from the business layer
* Ensure all methods pass basic Crud tests

## Review

* CRUD Tests written
* CRUD operations written and tested in the business layer

## Retrospective

I found it very helpful to split the task of implementing the database into getting the business-to-database functionality working, and then focussing on UI-business layers. I will do the latter in the next sprint.

# Sprint 6: Saturday Evening: 5 Sep 2020

## Goals:

* Create Skeletal User interface
* Implement CRUD functionality from the UI to the business layer

## Review

* Minigolf balls can be read and deleted
* The name can be updated
* These operations have been manually tested.
* Their colour cannot yet be changed or assigned.

## Retrospective

Creating a new ball requires assigning a colour to it. Hopefully when I do that tomorrow, it will make altering colours for the other methods possible. The ViewModel is getting very messy with many methods and UI Control toggles for every control's visibility and isEnabled. This will make the UI poorly maintainable and extensible. If time allows, I will refactor the code behind. I have added that item to the Wishlist.

# Sprint 7: Sunday 6 Sep 2020

## Goals

* Add colour change functionality
* Add new ball

## Review

* Users can change the colour of each minigolf ball from the user interface
* Users can add a new ball.
* The Colour combo box now responds to user selecting a ball, and automatically displays its colour.

## Retro

My unit tests are inaccurate. Sometimes they pass when my UI fails, and vice versa. This is because my mock data does not accurately reflect the data coming from the UI. My mock data has an ID and Colour ID assigned, whereas the data from the UI has a Colour assigned, but not ID or ColourID. The UI uses classes from the Models project; one way to resolve the problem is to only have the objects in the models and business layer, but this would make the UI more complicated and require refactoring.

Resolved an issue with an unresponsive combo box. The SelectedBall's colour wasn't automatically shown. To resolve this, I overrided the base methods ToString(), Equals(), and GetHashCode().

# Sprint 8: Monday: 7 Sep 2020

## Goals

* Complete Manual testing of UI and fix any bugs that arise
* Improve the UI
  * Increase font size
  * Add background image.
  * Centre the alignment of the text
  * Make the Datagrid columns bigger and responsive
* Filter minigolf balls by colour
* Prepare for presentation

## Review

* Many bugs found and fixed
  * Disable buttons and datagrid when in edit, add, or delete mode
  * Check that a Name and Colour is assigned in add mode
* Users can filter balls by colour
  * Button added to display all balls
* Presentation prepared
  * Powerpoint created
* Project finished
  * Readme updated
  * Committed and pushed to Github

## Retrospective

Unit tests cannot find the bugs with the UI, and due to mocking, can't always find problems with data entry. However, due to the reduced scope of my project, I was able to finish the wrap-up tasks in good time. 

# Project Review

* The minimum viable product was delivered on time.
* Some additional functionality was implemented. However, I didn't have time to implement much more than the minimum requirements.
* Each CRUD operation is covered by multiple unit tests.
* The UI should be slimmed down; some functionality should be moved to the Business layer where it can be covered by unit tests.

# Project Retrospective

Sticking to the MVP is essential to meeting deadlines delivering value. Reduce the requirements to the bear essentials and focus on them before anything else. Testing is key to development. The red-green-refactor method was great for quickly implementing functionality without being side-tracked. Although Unit testing is great, it won't catch all UI bugs and may be misleading. Writing effective and useful unit tests will take practice and more learning. For now, manual testing is important to catch the bugs my unit tests won't catch.

I didn't have time to refactor the UI code. In its current state, the UI is not DRY, and does not conform to OOP best practices. Given more time, I would complete some items on the Project Board Wishlist, including refactoring the UI to move some functionality to the business layer, making the application less database-intensive, and limiting the scope of the model objects to the data-access and business layers.
