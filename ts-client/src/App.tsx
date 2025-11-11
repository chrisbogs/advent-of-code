import { useState, useEffect } from 'react'
import './App.css'
import YearResults from './components/YearResults'
import { fetchDayPart } from './services/api'

interface Day {
  day: number;
  part1: string;
  part2: string;
}

interface YearData {
  year: number;
  days: Day[];
}

function App() {
  const [selectedYear, setSelectedYear] = useState<number>(2024)
  const [yearData, setYearData] = useState<YearData | null>(null)
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  const years = Array.from({ length: 11 }, (_, i) => 2025 - i)

  useEffect(() => {
    loadYearData(selectedYear)
  }, [selectedYear])

  const loadYearData = async (year: number) => {
    setLoading(true)
    setError(null)
    try {
      // Generate 25 days and fetch part 1 & 2 for each
      const days: Day[] = []
      for (let day = 1; day <= 25; day++) {
        try {
          const part1 = await fetchDayPart(year, day, 1)
          const part2 = await fetchDayPart(year, day, 2)
          days.push({ day, part1, part2 })
        } catch (err) {
          // If fetch fails for a day, push empty results
          days.push({ day, part1: '', part2: '' })
        }
      }
      setYearData({ year, days })
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to load year data')
    } finally {
      setLoading(false)
    }
  }

  return (
    <>
      <main>
        <h1>Advent of Code Solutions</h1>
        
        <nav>
          {years.map((year) => (
            <button
              key={year}
              onClick={() => setSelectedYear(year)}
              style={{
                backgroundColor: selectedYear === year ? '#646cff' : '#1a1a1a',
                borderColor: selectedYear === year ? '#646cff' : 'transparent',
              }}
            >
              {year}
            </button>
          ))}
        </nav>

        {error && <div className="error">{error}</div>}
        
        {loading && <div className="loading">Loading...</div>}
        
        {yearData && !loading && (
          <YearResults year={yearData.year} days={yearData.days} />
        )}
      </main>
    </>
  )
}

export default App
