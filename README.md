# Eventbaz Services

## Overview

**Eventbaz Services** is a RESTful Web API built using .NET Core 8, designed to manage entertainment events, associated photos, categories, and geographic locations. The project follows the Onion architecture, ensuring a clean separation of concerns and promoting testability and maintainability. The API includes functionalities for adding, updating, archiving, and retrieving events, along with handling associated photos. It also features logging with Serilog and API documentation with Swagger.

## Features

- **Event Management**
  - Add new entertainment events.
  - Update event details and timestamps.
  - Archive events.
  - Retrieve all events with sorting by the last updated time.
  - Define geographic locations for events (latitude and longitude).
  - Display nearby events on a map based on the user's location.

- **Photo Management**
  - Upload photos for events.
  - Delete photos associated with events.

- **Category Management**
  - Assign categories to events (e.g., sports, music, technology).
  - Organize events into categories for easier searching and filtering.

- **Lazy Loading**
  - Automatic loading of related data only when accessed, enhancing performance.

- **Location-based Event Discovery**
  - Find and display nearby events on a map based on the user's location.

- **Logging**
  - Integrated with Serilog for comprehensive request and error logging.

- **API Documentation**
  - Swagger UI for interactive API documentation and testing.

## Getting Started

### Prerequisites

- .NET Core 8.0 SDK
- SQL Server (or any other compatible database)
- Visual Studio or any other IDE supporting .NET Core

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/amirhosseinmirmohammad/Eventbaz.git
