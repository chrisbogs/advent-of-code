package service

import (
	"adventofcode/service/algorithm"
	"fmt"
)

func Day5Part1(input []string) int {
	ranges, availableIds := ParseInput(input)
	// Add optimization: preprocess ranges? remove overlaps
	// return # availableIds not in ranges
	count := numberOverlap(availableIds, ranges)
	return count
}

func numberOverlap(availableIds []int, ranges []algorithm.Range) int {
	count := 0
	for _, x := range availableIds {
		for _, r := range ranges {
			if x >= r.Start && x <= r.End {
				count++
				break
			}
		}
	}
	return count
}

func Day5Part2(input []string) int {
	ranges, _ := ParseInput(input)

	count := 0
	for _, x := range algorithm.MergeIntervals(ranges) {
		count += x.End - x.Start + 2
	}

	return count
	//899735370124688 too high
	//624606889503130 incorrect

}

func ParseInput(input []string) ([]algorithm.Range, []int) {
	var ranges []algorithm.Range
	var availableIds []int
	var i int

	for i = 0; i < len(input); i++ {
		if input[i] == "" {
			break
		}
		var start, end int
		fmt.Sscanf(input[i], "%d-%d", &start, &end)
		ranges = append(ranges, algorithm.Range{Start: start, End: end})
	}
	i++ // skip over newline
	for ; i < len(input); i++ {
		var availableId int
		fmt.Sscanf(input[i], "%d", &availableId)
		availableIds = append(availableIds, availableId)
	}

	return ranges, availableIds
}
