# TypeScript Client for Advent of Code

A modern TypeScript/React client for viewing and interacting with Advent of Code solutions.

## Project Structure

```
src/
├── components/        # React components
│   ├── DayResult.tsx
│   └── YearResults.tsx
├── services/         # API services
│   └── api.ts
├── App.tsx          # Main app component
├── main.tsx         # Entry point
└── index.css        # Global styles
```

## Getting Started

### Prerequisites

- Node.js 16+ and npm/yarn
- Running backend server on `http://localhost:5000`

### Installation

```bash
npm install
```

### Development

```bash
npm run dev
```

The client will be available at `http://localhost:3000` with API proxy to `http://localhost:5000`.

### Build

```bash
npm run build
```

### Preview

```bash
npm run preview
```

## Environment Variables

Create a `.env.local` file to override the API URL:

```
VITE_API_URL=http://your-server:5000/api
```

## Features

- Browse Advent of Code solutions by year
- View completed challenges and results
- Responsive grid layout
- Real-time loading states and error handling

## API Integration

The client communicates with the backend through the following endpoints:

- `GET /api/year` - Fetch all years
- `GET /api/year/{year}` - Fetch specific year results
