import DayResult from './DayResult'

interface Day {
  day: number;
  part1: string;
  part2: string;
}

interface YearResultsProps {
  year: number;
  days: Day[];
}

function YearResults({ year, days }: YearResultsProps) {
  const sortedDays = [...days].sort((a, b) => a.day - b.day)
  
  return (
    <div>
      <h2>Year {year}</h2>
      <div className="results-grid">
        {sortedDays.map((day) => (
          <DayResult key={day.day} day={day.day} part1={day.part1} part2={day.part2} />
        ))}
      </div>
      {days.length === 0 && <p>No results available for this year.</p>}
    </div>
  )
}

export default YearResults
