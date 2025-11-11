import { useState } from 'react'

interface DayResultProps {
  day: number;
  part1: string;
  part2: string;
}

function DayResult({ day, part1, part2 }: DayResultProps) {
  const [selectedPart, setSelectedPart] = useState<1 | 2>(1)

  const displayResult = selectedPart === 1 ? part1 : part2
  const hasResult = displayResult && displayResult.trim().length > 0

  return (
    <div className="result-card">
      <h3>Day {day}</h3>
      <div style={{ display: 'flex', gap: '0.5rem', marginBottom: '1rem' }}>
        <button
          onClick={() => setSelectedPart(1)}
          style={{
            padding: '0.4rem 0.8rem',
            fontSize: '0.9em',
            backgroundColor: selectedPart === 1 ? '#646cff' : '#333',
            color: selectedPart === 1 ? '#fff' : '#aaa',
            border: `1px solid ${selectedPart === 1 ? '#646cff' : '#555'}`,
            borderRadius: '4px',
            cursor: 'pointer',
          }}
        >
          Part 1
        </button>
        <button
          onClick={() => setSelectedPart(2)}
          style={{
            padding: '0.4rem 0.8rem',
            fontSize: '0.9em',
            backgroundColor: selectedPart === 2 ? '#646cff' : '#333',
            color: selectedPart === 2 ? '#fff' : '#aaa',
            border: `1px solid ${selectedPart === 2 ? '#646cff' : '#555'}`,
            borderRadius: '4px',
            cursor: 'pointer',
          }}
        >
          Part 2
        </button>
      </div>
      <div>
        {hasResult ? (
          <code style={{ wordBreak: 'break-all', display: 'block' }}>{displayResult}</code>
        ) : (
          <p style={{ color: '#999', fontStyle: 'italic' }}>Not completed</p>
        )}
      </div>
    </div>
  )
}

export default DayResult
