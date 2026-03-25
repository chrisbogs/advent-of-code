package service

import (
	"strconv"
)

// Day1Part1 solves part 1 of day 1.
// Input format: XY where X is 'L' or 'R', Y is an integer.
func Day1Part1(input []string) int {
	const initialValue = 50

	currentValue := initialValue
	passwordCount := 0

	for _, line := range input {
		if len(line) < 2 {
			continue
		}

		direction := line[0]
		number, err := strconv.Atoi(line[1:])
		if err != nil {
			continue
		}

		switch direction {
		case 'L':
			currentValue = ((currentValue - number) % 100 + 100) % 100
		case 'R':
			currentValue = ((currentValue + number) % 100 + 100) % 100
		}

		if currentValue == 0 {
			passwordCount++
		}
	}

	return passwordCount
}

// Day1Part2 solves part 2 of day 1.
// Input format: XY where X is 'L' or 'R', Y is an integer.
func Day1Part2(input []string) int {
	const initialValue = 50

	currentValue := initialValue
	passwordCount := 0

	for _, line := range input {
		if len(line) < 2 {
			continue
		}

		direction := line[0]
		number, err := strconv.Atoi(line[1:])
		if err != nil {
			continue
		}

		oldValue := currentValue

		switch direction {
		case 'L':
			numberOfLoops := number / 100
			passwordCount += numberOfLoops
			currentValue = ((currentValue - number) % 100 + 100) % 100

			if oldValue != 0 && currentValue != 0 && currentValue > oldValue {
				passwordCount++
			}

		case 'R':
			numberOfLoops := number / 100
			passwordCount += numberOfLoops
			currentValue = ((currentValue + number) % 100 + 100) % 100

			if oldValue != 0 && currentValue != 0 && currentValue < oldValue {
				passwordCount++
			}
		}

		if currentValue == 0 {
			passwordCount++
		}
	}

	return passwordCount
}