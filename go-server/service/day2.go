// 11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
// 1698522-1698528,446443-446449,38593856-38593862,565653-565659,
// 824824821-824824827,2121212118-2121212124
// (The ID ranges are wrapped here for legibility; in your input, they appear on a single long line.)

// The ranges are separated by commas (,); each range gives its first ID and last ID separated by a dash (-).

// Since the young Elf was just doing silly patterns, you can find the invalid IDs by looking for any ID which is made only of some sequence of digits repeated twice. So, 55 (5 twice), 6464 (64 twice), and 123123 (123 twice) would all be invalid IDs.

// None of the numbers have leading zeroes; 0101 isn't an ID at all. (101 is a valid ID that you would ignore.)

// Your job is to find all of the invalid IDs that appear in the given ranges. In the above example:

// 11-22 has two invalid IDs, 11 and 22.
// 95-115 has one invalid ID, 99.
// 998-1012 has one invalid ID, 1010.
// 1188511880-1188511890 has one invalid ID, 1188511885.
// 222220-222224 has one invalid ID, 222222.
// 1698522-1698528 contains no invalid IDs.
// 446443-446449 has one invalid ID, 446446.
// 38593856-38593862 has one invalid ID, 38593859.
// The rest of the ranges contain no invalid IDs.
// Adding up all the invalid IDs in this example produces 1227775554.

// What do you get if you add up all of the invalid IDs?
package service

import (
	"strconv"
	"strings"
	"sync"
)

type Range struct {
	Start int
	End   int
}

func Day2Part1(input string) int {
	// ranges := ParseRanges(input)
	// total := 0
	// for _, r := range ranges {
	// 	for i := r.start; i <= r.end; i++ {
	// 		if isRepeatedTwice(strconv.Itoa(i)) {
	// 			total += i
	// 		}
	// 	}
	// }
	// return total

    ranges := ParseRanges(input)
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
        }(r.start, r.end)
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

func isRepeatedTwice(word string) bool {
	if len(word) % 2 == 1 {return false}

	start := 0
	mid := int(len(word) / 2)
	start2 := int(len(word) / 2)

	for start < mid {
		if word[start] != word[start2] {
			return false
		}
		start++
		start2++
	}
	return true
}

func ParseRanges(input string) []struct{ start, end int } {
	var ranges []struct{ start, end int }
	pairs := strings.Split(strings.TrimSpace(input), ",")

	for _, pair := range pairs {
		parts := strings.Split(pair, "-")
		start, _ := strconv.Atoi(parts[0])
		end, _ := strconv.Atoi(parts[1])
		ranges = append(ranges, struct{ start, end int }{start, end})
	}

	return ranges
}
