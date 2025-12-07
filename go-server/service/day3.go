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
