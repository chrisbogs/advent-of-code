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
	mergedRanges := []Range{ ranges[0] }
	prevIndex := 0
	for i := 1; i < len(ranges); i++ {
		println("current: ", ranges[i].Start, ranges[i].End, "prevRange: ", mergedRanges[prevIndex].Start, mergedRanges[prevIndex].End)
		if mergedRanges[prevIndex].End >= ranges[i].Start {
			// merge them
			println("updating end to: ", mergedRanges[prevIndex].End, ranges[i].End)
			mergedRanges[prevIndex].End = max(ranges[i].End, mergedRanges[prevIndex].End)
		} else {
			println("previous range becomes this.")
			mergedRanges = append(mergedRanges, ranges[i])
			println("appending ", mergedRanges[prevIndex].Start, ranges[i].End)
			prevIndex++
		}
		println("mergedRanges ", len(mergedRanges), mergedRanges[0].End)

	}
	return mergedRanges
}
