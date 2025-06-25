# Job Application Tracker API

This project is an API for a Job Application Tracker system. It is designed to help users manage and track their job applications efficiently.

## Project Structure

The solution is divided into three main layers:

1. **API Layer**
   - Handles HTTP requests and responses.
   - Exposes endpoints for interacting with job applications.

2. **Data & Business Layer**
   - Contains the core business logic and data access code.
   - Responsible for processing application data, enforcing business rules, and interacting with the database or storage.

3. **Test Layer**
   - Contains the unit test code for the business layers.

## Assumptions

1. No authentication or authorization is required.
2. Only in-memory database is used. Thus, persistence is only limited to the application's lifecycle.
3. Swagger is used for API documentation and exposed publicly.


## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version compatible with the project)

### Running the Application

1. Open a terminal (CLI) and navigate to the root directory of the project.
2. Run the following command to start the API:

   ```bash
   dotnet run --project JobApplicationTracker.API
   ```

3. The API will start and listen for HTTP requests. By default, it runs on `http://localhost:5178`.

4. Open your browser and navigate to `http://localhost:5178/swagger` to access the API documentation.
