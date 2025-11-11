import axios from 'axios'

// Vite exposes environment variables on `import.meta.env` in the browser.
// Avoid using `process.env` which isn't available at runtime in the browser.
const API_BASE_URL = ((import.meta as any).env?.VITE_API_URL as string) || 'http://localhost:8885/'

const apiClient = axios.create({
  baseURL: API_BASE_URL,
  timeout: 10000,
})

export interface DayPartResult {
  year: number;
  day: number;
  part: number;
  result: string;
}

// Fetch a specific year/day/part. The server exposes a route like `/Year/{year}/{day}/{part}`
// Example: `GET http://localhost:8885/Year/2015/19/2`.
// The API returns plain text (not JSON), so we configure responseType to ensure
// axios treats it as a string and doesn't parse it as JSON.
export const fetchDayPart = async (year: number, day: number, part: 1 | 2): Promise<string> => {
  try {
    const response = await apiClient.get<string>(`/Year/${year}/${day}/${part}`, {
      responseType: 'text',
    })
    // Ensure the response is always a string
    const result = typeof response.data === 'string' ? response.data : String(response.data)
    return result
  } catch (err: unknown) {
    if (axios.isAxiosError(err)) {
      throw new Error(`Failed to fetch day ${day} part ${part} for ${year}: ${err.message}`)
    }
    throw new Error(String(err))
  }
}
