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
