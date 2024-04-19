# SimpleAuthNet API Documentation

This documentation provides an overview of the SimpleAuthNet API, an authentication and authorization system built with ASP.NET using .NET 8.

## Table of Contents
- [Authentication](#authentication)
  - [Register](#register)
  - [Login](#login)
  - [Refresh Token](#refresh-token)
  - [Logout](#logout)
- [User Profile](#user-profile)
  - [Get User Profile](#get-user-profile)
- [Weather Forecast](#weather-forecast)
  - [Get Weather Forecast](#get-weather-forecast)

## Authentication

### Register

Registers a new user.

**URL:** `/User/Register`

**Method:** `POST`

**Request Body:**
```json
{
  "email": "user@example.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "isSucceed": true,
  "messages": {},
  "data": true
}
```

### Login

Authenticates a user and returns an access token and refresh token.

**URL:** `/User/Login`

**Method:** `POST`

**Request Body:**
```json
{
  "email": "user@example.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "isSucceed": true,
  "messages": {},
  "data": {
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "refreshToken": "abc123..."
  }
}
```

### Refresh Token

Refreshes the access token using a refresh token.

**URL:** `/User/RefreshToken`

**Method:** `POST`

**Request Body:**
```json
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "abc123..."
}
```

**Response:**
```json
{
  "isSucceed": true,
  "messages": {},
  "data": {
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "refreshToken": "def456..."
  }
}
```

### Logout

Logs out the currently authenticated user.

**URL:** `/User/Logout`

**Method:** `POST`

**Response:**
```json
{
  "isSucceed": true,
  "messages": {},
  "data": true
}
```

## User Profile

### Get User Profile

Retrieves the profile information of the authenticated user.

**URL:** `/User/Profile`

**Method:** `POST`

**Headers:**
- `Authorization: Bearer <access_token>`

**Response:**
```json
"username@example.com"
```

## Weather Forecast

### Get Weather Forecast

Retrieves a weather forecast.

**URL:** `/api/WeatherForecast`

**Method:** `GET`

**Headers:**
- `Authorization: Bearer <access_token>`

**Response:**
```json
[
  {
    "date": "2023-06-01T00:00:00",
    "temperatureC": 25,
    "summary": "Warm"
  },
  ...
]
```


## Build Process

To build the SimpleAuthNet project using the `dotnet` CLI, follow these steps:

1. Ensure that you have the .NET SDK installed on your machine. You can download it from the official Mixcrosoft website: [.NET SDK](https://dotnet.microsoft.com/download)

2. Clone this repository to your local machine using the following command:
  ```
  git clone [repository_url]
  ```

3. Open a terminal or command prompt and navigate to the root directory of the SimpleAuthNet project.
  ```
  cd SimpleAuthNet
  ```

4. Run the following command to restore the project dependencies:
   ```
   dotnet restore
   ```

5. Once the dependencies are restored, run the following command to build the project:
   ```
   dotnet build
   ```

   This command will compile the project and generate the output in the `bin` directory.

6. (Optional) If you want to run the tests, use the following command:
   ```
   dotnet test
   ```

   This will execute the unit tests defined in the project.

7. To run the application, use the following command:
   ```
   dotnet run
   ```

   This will start the application, and you can access it via the specified URL (e.g., `http://localhost:5023`).

That's it! You have now successfully built and run the SimpleAuthNet project using the `dotnet` CLI.
