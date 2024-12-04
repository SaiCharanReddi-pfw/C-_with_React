# C-_with_React

## Project Overview

The Application is designed to display hierarchical property data fetched from an API in a React application. It allows users to view detailed information about properties, their spaces, and rent roll in a structured, collapsible format.

### Key Features
- Fetch data from a C# API endpoint.
- Display hierarchical data (`Property -> Spaces -> RentRoll`).
- Collapsible sections for properties and spaces.
- Clean, responsive UI for seamless interaction.

---

## Setup Instructions

### Prerequisites
- **npm** (v7 or above)
- **ReactJs**
- **Dotnet Framework 5 or above**
  

### Steps to Run the Application
1. Clone the repository:
    ```bash
    git clone <repository-url>
    cd property-management
    ```
2. Install dependencies:
    ```bash
    npm install
    ```
3. Start the development server in C#:

4. Start the Client:
    ```bash
    npm start
    ```
5. Open the application in a browser at `http://localhost:3000`.

---

## Backend Integration

### API Endpoint

- API Endpoint is created using ASP.NET Core Web Api.
- Uses the provided Blob URL and SAS token to retrieve the JSON data.
- Deserializes the data into the C# model.
- Returns the structured data as a JSON response.
- **Endpoint**: `https://localhost:7116/api/properties`

### Data Structure
The API is expected to return JSON data in the following format:
```json
[
  {
    "propertyId": "P101",
    "propertyName": "The Grand Plaza",
    "features": [...],
    "highlights": [...],
    "transportation": [...],
    "spaces": [
      {
        "spaceId": "S101",
        "spaceName": "Suite 101",
        "rentRoll": [...]
      }
    ]
  }
]
```


### Error Handling
If the API call fails, an error message is displayed on the UI.
Handles scenarios where the data is null or undefined gracefully.

## SAS Token Handling

### What is an SAS Token?
A Shared Access Signature (SAS) token provides secure access to Azure Blob Storage resources.

### Usage in Backend
The SAS token is used to authenticate and fetch data from Azure Blob Storage in the backend.
### Assumptions
The SAS token is valid and configured correctly.
The token is renewed before expiration to ensure uninterrupted access.
### Security Note
DO NOT hardcode sensitive tokens in the source code.
Use environment variables or a secure configuration mechanism to store tokens.

## Assumptions

- The API endpoint is accessible when the application is used.
- Data returned by the API conforms to the provided JSON structure.
- The SAS token is properly configured and does not expire during usage.

## Potential Enhancements

- Add pagination or filtering for large datasets.
- Enhance UI styling using CSS frameworks like Bootstrap or Material-UI.
- Implement unit tests using Jest or React Testing Library.
- Add user authentication for additional security.
