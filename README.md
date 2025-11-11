# Coding attempts for the Advent of Code programming challenges

## Architecture

This project contains:
- **Blazor WebAssembly Client** (`/client`) - C# UI component-based frontend
- **TypeScript/React Client** (`/ts-client`) - Modern TypeScript/React frontend (NEW!)
- **ASP.NET Core Backend** (`/server`) - REST API server
- **Shared Logic** (`/shared`) - Puzzle solutions and utilities
- **Tests** (`/tests`) - Unit tests

## Running the Application

### Option 1: Blazor Client

From the `/client` folder:
```bash
dotnet run
```

### Option 2: TypeScript Client (Recommended)

From the `/ts-client` folder:
```bash
npm install
npm run dev
```

The app will be available at `http://localhost:3000`

### Run Backend Server

From the `/server` folder:
```bash
dotnet run
```

Server will be available at `http://localhost:5000`

### Run Tests

```bash
dotnet test
```

## Quick Start

1. Start the backend server (from `/server`):
   ```bash
   dotnet run
   ```

2. Start the TypeScript client (from `/ts-client`):
   ```bash
   npm install
   npm run dev
   ```

3. Open `http://localhost:3000` in your browser

## Development

For detailed information about each component, see their respective README files:
- `ts-client/README.md` - TypeScript client documentation
- Server API controllers - See `/server/Controllers`
