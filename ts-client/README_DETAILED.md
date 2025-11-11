# TypeScript Client for Advent of Code

A modern TypeScript/React client for the Advent of Code solution viewer, built with Vite and React 18.

## Overview

This is an alternative to the Blazor WebAssembly client, providing a lightweight, fast TypeScript/React-based interface for browsing Advent of Code solutions.

## Project Structure

```
ts-client/
├── src/
│   ├── components/        # React components
│   │   ├── DayResult.tsx
│   │   └── YearResults.tsx
│   ├── services/         # API services
│   │   └── api.ts
│   ├── App.tsx          # Main app component
│   ├── App.css          # App styles
│   ├── index.css        # Global styles
│   └── main.tsx         # Entry point
├── index.html           # HTML template
├── vite.config.ts       # Vite configuration
├── tsconfig.json        # TypeScript configuration
├── package.json         # Dependencies
└── README.md            # Documentation
```

## Getting Started

### Prerequisites

- Node.js 16+ and npm/yarn installed
- Backend server running on `http://localhost:8885`

### Installation & Development

1. Navigate to the ts-client directory:
   ```bash
   cd ts-client
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   npm run dev
   ```
   
### Build for Production

```bash
npm run build
```

Output will be in the `dist/` directory.

### Preview Production Build

```bash
npm run preview
```

### Run Tests

```bash
npm test
```

### Lint Code

```bash
npm run lint
```

## Configuration

### Environment Variables

Create a `.env.local` file in the `ts-client` directory to customize settings:

```env
VITE_API_URL=http://your-server:5000/api
```

The `.env.local` file is included in `.gitignore` and won't be committed.