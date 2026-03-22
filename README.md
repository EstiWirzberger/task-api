Task Manager – Home Assignment
Overview

This project is a simple Task Management system built as part of a Full Stack home assignment.

The system includes:

Angular client application (StackBlitz)
.NET Web API server
Data stored in JSON file
Full CRUD functionality

The application allows users to:

Add tasks
Edit tasks
Delete tasks
View task list
Manage task priority, due date and status
Links
Angular Client (StackBlitz)

https://stackblitz.com/~/github.com/EstiWirzberger/task-manager.ui

The StackBlitz project uses a mock data service to allow the application to run independently in the browser environment.

.NET Web API (GitHub)

https://github.com/EstiWirzberger/task-api

The server implements REST API endpoints and stores the data in a JSON file.

Technologies Used
Client
Angular 17 (Standalone Components)
Reactive Forms
TypeScript
Bootstrap 5
RxJS
Server
.NET 8 Web API
C#
REST API
JSON file storage
Application Structure
Client Side

The Angular application is built using component-based architecture:

components:

task-form component – handles task creation and editing using Reactive Forms
task-list component – displays tasks and provides edit/delete actions

services:

task.service – handles data operations (CRUD)
supports both real API and mock data mode

models:

task model defines the structure of the task entity
Server Side

The .NET API provides endpoints for managing tasks.

Data is stored in:
Data/tasks.json

API Endpoints

GET /tasks
Returns all tasks

POST /tasks
Creates a new task

PUT /tasks/{id}
Updates an existing task

DELETE /tasks/{id}
Deletes a task

How to Run the Server
Open the server project in Visual Studio or VS Code
Run the application:
dotnet run
The API will run locally, for example:
https://localhost:7290/tasks
Notes

Due to browser security limitations in StackBlitz, the Angular project uses a mock data service to simulate API calls.

The full backend implementation is available in the GitHub repository.

The architecture allows switching between mock data and real API by changing a single configuration flag in the service.

Project Features
Reactive Forms validation
Component-based architecture
Separation of concerns
REST API design
JSON data persistence
Responsive layout using Bootstrap
Edit and update existing tasks
Clean form reset after save
