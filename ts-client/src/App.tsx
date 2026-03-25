import { useState } from 'react'
import YearResults from './components/YearResults'
import { useYearData } from './hooks/useYearData'
import styles from './App.module.css'

function App() {
    const [selectedYear, setSelectedYear] = useState<number>(2023)
    const { data: yearData, isLoading, error } = useYearData(selectedYear)

  const years = Array.from({ length: 11 }, (_, i) => 2025 - i)

  return (
      <div className={styles.app}>
          <h1>Advent of Code Solutions</h1>

          <nav className={styles.yearSelector}>
              {years.map((year) => (
                  <button
                      key={year}
                      onClick={() => setSelectedYear(year)}
                      className={selectedYear === year ? styles.activeYear : styles.yearButton}
            >
                      {year}
            </button>
              ))}
          </nav>

          {error && <div className={styles.error}>{(error as Error).message}</div>}

          {isLoading && <div className={styles.loading}>Loading...</div>}

          {yearData && !isLoading && (
              <YearResults year={yearData.year} days={yearData.days} />
          )}
      </div>
  )
}

export default App
