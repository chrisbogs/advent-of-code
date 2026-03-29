package service

import (
	"strconv"
	"strings"
	"sync"
)

// Range represents a range of IDs to check.
type Range struct {
	Start int
	End   int
}

// Day2Part1WithFirstLine is a wrapper that extracts the first line from input.
func Day2Part1WithFirstLine(input []string) int {
	if len(input) == 0 {
		return 0
	}
	return Day2Part1(input[0])
}

// Day2Part2WithFirstLine is a wrapper that extracts the first line from input.
func Day2Part2WithFirstLine(input []string) int {
	if len(input) == 0 {
		return 0
	}
	return Day2Part2(input[0])
}

// Day2Part1 finds all invalid IDs (repeated digits) in ranges and sums them.
func Day2Part1(input string) int {
	ranges := parseRanges(input)
	results := make(chan int, 100)
	var wg sync.WaitGroup

	// Launch a goroutine for each range
	for _, r := range ranges {
		wg.Add(1)
		go func(start, end int) {
			defer wg.Done()
			for i := start; i <= end; i++ {
				if isRepeatedTwice(strconv.Itoa(i)) {
					results <- i
				}
			}
		}(r.Start, r.End)
	}

	// Close results channel when all goroutines finish
	go func() {
		wg.Wait()
		close(results)
	}()

	// Sum all results from channel
	total := 0
	for val := range results {
		total += val
	}
	return total
}

// isRepeatedTwice checks if a string is made of a pattern repeated exactly twice.
func isRepeatedTwice(word string) bool {
	if len(word)%2 == 1 {
		return false
	}

	mid := len(word) / 2
	for i := 0; i < mid; i++ {
		if word[i] != word[mid+i] {
			return false
		}
	}
	return true
}

// parseRanges parses a comma-separated string of ranges (e.g., "1-10,20-30").
func parseRanges(input string) []Range {
	var ranges []Range
	pairs := strings.Split(strings.TrimSpace(input), ",")

	for _, pair := range pairs {
		parts := strings.Split(pair, "-")
		if len(parts) != 2 {
			continue
		}

		start, err1 := strconv.Atoi(strings.TrimSpace(parts[0]))
		end, err2 := strconv.Atoi(strings.TrimSpace(parts[1]))

		if err1 != nil || err2 != nil {
			continue
		}

		ranges = append(ranges, Range{start, end})
	}

	return ranges
}

// Day2Part2 finds all invalid IDs (only repeated digits) in ranges and sums them.
func Day2Part2(input string) int {
	ranges := parseRanges(input)
	results := make(chan int, 100)
	var wg sync.WaitGroup

	// Launch a goroutine for each range
	for _, r := range ranges {
		wg.Add(1)
		go func(start, end int) {
			defer wg.Done()
			for i := start; i <= end; i++ {
				if onlyRepeatedDigits(strconv.Itoa(i)) {
					results <- i
				}
			}
		}(r.Start, r.End)
	}

	// Close results channel when all goroutines finish
	go func() {
		wg.Wait()
		close(results)
	}()

	// Sum all results from channel
	total := 0
	for val := range results {
		total += val
	}
	return total
}

// onlyRepeatedDigits checks if a string is made only of a sequence of digits repeated at least twice.
// Examples: 12341234, 123123123, 1212121212, 1111111 are all valid.
func onlyRepeatedDigits(word string) bool {
	maxPossibleSubstringLength := len(word) / 2
	for i := 1; i <= maxPossibleSubstringLength; i++ {
		if isOnlyRepeatedSequence(word, word[:i], i) {
			return true
		}
	}
	return false
}

// isOnlyRepeatedSequence checks if a string is made only of a repeated pattern.
// The substring length must be a divisor of the string length.
func isOnlyRepeatedSequence(s, pattern string, length int) bool {
	if len(s)%length != 0 {
		return false
	}

	for idx := 0; idx < len(s); idx++ {
		if s[idx] != pattern[idx%length] {
			return false
		}
	}
	return true
}

// Exported functions for backward compatibility with existing tests.
func OnlyRepeatedDigits(word string) bool {
	return onlyRepeatedDigits(word)
}

func IsOnlyRepeatedSequence(s, pattern string, length int) bool {
	return isOnlyRepeatedSequence(s, pattern, length)
}