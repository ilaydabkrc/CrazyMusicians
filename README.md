# Crazy Musicians API

A simple ASP.NET Core Web API for managing a list of funny and crazy musicians!

## Features
- Basic CRUD operations (Create, Read, Update, Delete)
- Search musicians by name or profession ([FromQuery] example)
- Validation for all input data
- RESTful routing style

## Endpoints
- `GET /api/musicians` - Get all musicians
- `GET /api/musicians/{id}` - Get musician by ID
- `GET /api/musicians/search?name=...&profession=...` - Search musicians
- `POST /api/musicians` - Add a new musician
- `PUT /api/musicians/{id}` - Update a musician
- `PATCH /api/musicians/{id}/funfact` - Update only the fun fact
- `DELETE /api/musicians/{id}` - Delete a musician

## Example Data
The API starts with 10 crazy musicians, each with a unique profession and fun fact.

---

