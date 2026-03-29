package service

import (
	"strconv"
)

// Day3Part1 finds the first maximum digit and the maximum digit after it,
// then combines them to form a number. Sums these numbers for all input lines.
func Day3Part1(input []string) int {
	sum := 0
	for _, line := range input {
		// Find max digit using index less than len(line)-1
		maxValue, index := -1, -1
		for i := 0; i < len(line)-1; i++ {
			val, _ := strconv.Atoi(string(line[i]))
			if val > maxValue {
				maxValue = val
				index = i
			}
		}

		// Find second digit (max after the first max)
		secondDigit := -1
		for i := index + 1; i < len(line); i++ {
			val, _ := strconv.Atoi(string(line[i]))
			if val > secondDigit {
				secondDigit = val
			}
		}

		numStr := strconv.Itoa(maxValue) + strconv.Itoa(secondDigit)
		num, _ := strconv.Atoi(numStr)
		sum += num
	}
	return sum
}

// Day3Part2 finds the 12 largest digits across the line and combines them.
func Day3Part2(input []string) int {
	sum := 0

	for _, line := range input {
		// Convert string to slice of integers
		convertedLine := make([]int, 0, len(line))
		for i := 0; i < len(line); i++ {
			num, _ := strconv.Atoi(string(line[i]))
			convertedLine = append(convertedLine, num)
		}

		// Find the 12 largest digits one by one
		digits := make([]int, 0)
		newIndex := 0
		for i := 1; i <= 12; i++ {
			maxVal, idx := FindMax(newIndex, 12-i, convertedLine)
			newIndex = idx
			digits = append(digits, maxVal)
		}

		// Combine the digits into a number
		numStr := ""
		for _, digit := range digits {
			numStr += strconv.Itoa(digit)
		}
		num, _ := strconv.Atoi(numStr)
		sum += num
	}
	return sum
}

// FindMax returns the maximum value in arr[start:end] and the next search position.
// Parameters:
// - start: starting index for search
// - nthDigit: offset for end index (end = len(arr) - nthDigit)
// - arr: array of integers to search
func FindMax(start int, nthDigit int, arr []int) (int, int) {
	maxValue := -1
	index := -1
	end := len(arr) - nthDigit
	for i := start; i < end; i++ {
		val := arr[i]
		if val > maxValue {
			maxValue = val
			index = i
		}
	}
	return maxValue, index + 1
}
