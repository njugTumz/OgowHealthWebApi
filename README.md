# Health Web API Documentation

## Overview
The Health Web API provides endpoints for managing health facilities, health workers, and patients. It supports CRUD operations and offline synchronization with a central cloud database when connectivity is available.

## Base URL
https://ogohmsapi.azurewebsites.net/


## Authentication
Include information about authentication methods, such as API keys, OAuth, or JWT tokens, if applicable.

## Endpoints

### Health Facilities

- **Get All Facilities**
  - **Endpoint:** `GET /api/HealthFacility`
  - **Description:** Retrieve a list of all health facilities.


- **Get Facility by ID**
  - **Endpoint:** `GET /api/HealthFacility/{id}`
  - **Description:** Retrieve details of a specific health facility by ID.

- **Create a Facility**
  - **Endpoint:** `POST /api/HealthFacility`
  - **Description:** Create a new health facility.


- **Update a Facility**
  - **Endpoint:** `PUT /api/HealthFacility/{id}`
  - **Description:** Update an existing health facility by ID.


- **Delete a Facility**
  - **Endpoint:** `DELETE /api/HealthFacility/{id}`
  - **Description:** Delete a health facility by ID.

## Error Handling
Errors are returned as a JSON object with an error code and message. Common error codes include:
- `400 Bad Request`: Invalid request data.
- `404 Not Found`: Resource not found.
- `500 Internal Server Error`: Unexpected server error.

## Rate Limiting
The API may enforce rate limits to ensure fair usage. If a rate limit is exceeded, a `429 Too Many Requests` response will be returned.

## Changelog
- **v1.0.0**: Initial release with support for managing facilities, workers, and patients.

## Support
To Be Added.
