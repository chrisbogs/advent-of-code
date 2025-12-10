package service

import "fmt"

func Day5Part1(input []string) int {
	ranges, availableIds := ParseInput(input)
	count := 0
	// Add optimization: preprocess ranges? remove overlaps
	// return # availableIds not in ranges
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
