package service

import (
	"strconv"
)

func Day3Part1(input []string) int {
	sum := 0
	for _, line := range input {
		// find max 2 digits with their indices
		maxValue, index := -1, -1
		secondDigit := -1
		for i := 0; i < len(line)-1; i++ {
			val, _ := strconv.Atoi(string(line[i]))
			if val > maxValue {
				maxValue = val
				index = i
			}
		}

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

func Day3Part2(input []string) int {
	sum := 0
	combined := ""
	for _, line := range input {
		combined += line
	}
	parsedInts := make([]int, len(combined))
	for i, char := range combined {
		parsedInts[i], _ = strconv.Atoi(string(char))
	}

	digits := make([]int, 0)
	newIndex := 0
	maxVal := -1
	for i := range 12 {
		maxVal, newIndex = FindMax(newIndex, 12-i, parsedInts)
		println(newIndex, 12-i, maxVal, newIndex)
		digits = append(digits, maxVal)
	}

	numStr := ""
	for _, digit := range digits {
		numStr += strconv.Itoa(digit)
	}
	num, _ := strconv.Atoi(numStr)
	sum += num

	return sum
}

func FindMax(start int, n int, arr []int) (int, int) {
	maxValue := -1
	index := -1
	for i := start; i < len(arr)-n; i++ {
		val := arr[i]
		if val > maxValue {
			maxValue = val
			index = i
		}
	}
	return maxValue, index + 1
}
