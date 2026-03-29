import { useQuery } from '@tanstack/react-query'
import { fetchDayPart } from '../services/api'

interface Day {
  day: number;
  part1: string;
  part2: string;
}

interface YearData {
  year: number;
  days: Day[];
}

const fetchYearData = async (year: number): Promise<YearData> => {
  const days: Day[] = []
  for (let day = 1; day <= 25; day++) {
    try {
      const part1 = await fetchDayPart(year, day, 1)
      const part2 = await fetchDayPart(year, day, 2)
      days.push({ day, part1, part2 })
    } catch {
      // If fetch fails for a day, push empty results
      days.push({ day, part1: '', part2: '' })
    }
  }
  return { year, days }
}

export const useYearData = (year: number) => {
  return useQuery({
    queryKey: ['yearData', year],
    queryFn: () => fetchYearData(year),
    staleTime: 5 * 60 * 1000, // 5 minutes
    gcTime: 10 * 60 * 1000, // 10 minutes
  })
}