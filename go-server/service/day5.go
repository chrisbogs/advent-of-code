package service

import (
	"fmt"
)

func Day5Part1(input []string) int {
	ranges, availableIds := ParseInput(input)
	// Add optimization: preprocess ranges? remove overlaps
	// return # availableIds not in ranges
	count := numberOverlap(availableIds, ranges)
	return count
}

func numberOverlap(availableIds []int, ranges []myRange) int {
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

	type localSet map[int]struct{}
	final := make(localSet)
	for _, r := range ranges {
		println("range 1, length", r.End-r.Start)
		for v := r.Start; v <= r.End; v++ {
			final[v] = struct{}{}
			// println(v)
		}
	}

	return len(final)
}

// func makeRange(r myRange) []int {
// 	result := make([]int, r.End-r.Start+1)
// 	for i := range result {
// 		result[i] = r.Start + i
// 	}
// 	return result
// }

type myRange struct {
	Start int
	End   int
}

func ParseInput(input []string) ([]myRange, []int) {
	var ranges []myRange
	var availableIds []int
	var i int

	for i = 0; i < len(input); i++ {
		if input[i] == "" {
			break
		}
		var start, end int
		fmt.Sscanf(input[i], "%d-%d", &start, &end)
		ranges = append(ranges, myRange{Start: start, End: end})
	}
	i++ // skip over newline
	for ; i < len(input); i++ {
		var availableId int
		fmt.Sscanf(input[i], "%d", &availableId)
		availableIds = append(availableIds, availableId)
	}

	return ranges, availableIds
}
