import { useState } from 'react'
import styles from './DayResult.module.css'

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
      <div className={styles.resultCard}>
      <h3>Day {day}</h3>
          <div className={styles.partButtons}>
        <button
          onClick={() => setSelectedPart(1)}
                  className={`${styles.partButton} ${selectedPart === 1 ? styles.active : ''}`}
        >
          Part 1
        </button>
        <button
          onClick={() => setSelectedPart(2)}
                  className={`${styles.partButton} ${selectedPart === 2 ? styles.active : ''}`}
        >
          Part 2
        </button>
      </div>
      <div>
        {hasResult ? (
                  <code className={styles.resultCode}>{displayResult}</code>
        ) : (
                      <p className={styles.noResult}>Not completed</p>
        )}
      </div>
    </div>
  )
}

export default DayResult
