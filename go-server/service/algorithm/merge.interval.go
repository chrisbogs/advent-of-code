package algorithm

import (
	"sort"
)

func MergeIntervals(ranges []Range) []Range {
	if len(ranges) <= 1 {
		return ranges
	}

	// sort intervals
	sort.Slice(ranges, func(i, j int) bool {
		return ranges[i].Start < ranges[j].Start
	})

	// go through and merge the intervals if they overlap
	prevRange := ranges[0]
	var mergedRanges []Range
	for i := 1; i < len(ranges); i++ {
		if prevRange.End >= ranges[i].Start {
			// merge them
			prevRange.End = ranges[i].End
		} else {
			prevRange = ranges[i]
		}
		mergedRanges = append(mergedRanges, prevRange)

	}
	return mergedRanges
}
