package service

import "strings"

// Day4Part1 counts how many rolls of paper can be accessed (fewer than 4 adjacent rolls).
func Day4Part1(input []string) int {
	grid := parseGrid(input)
	return processGrid(grid)
}

// Day4Part2 repeatedly removes accessible rolls until none remain.
func Day4Part2(input []string) int {
	grid := parseGrid(input)
	count := 1 // Start with 1 to account for first iteration

	for marked := -1; marked != 0; marked = processGrid(grid) {
		count += marked
	}

	return count
}

// processGrid marks and counts rolls that can be accessed (fewer than 4 adjacent filled positions).
func processGrid(grid [][]string) int {
	count := 0
	size := len(grid)

	for x := range size {
		for y := range size {
			if grid[x][y] == "@" && lessThanFourAdjacentFilled(grid, x, y, size) {
				grid[x][y] = "x" // Mark as processed
				count++
			}
		}
	}

	return count
}

// lessThanFourAdjacentFilled checks if a cell has fewer than 4 adjacent filled cells.
func lessThanFourAdjacentFilled(grid [][]string, x, y, size int) bool {
	const minAdjacentThreshold = 4
	var xs = []int{-1, 0, 1}
	var ys = []int{-1, 0, 1}

	count := 0

	for _, j := range xs {
		for _, i := range ys {
			// Skip the center cell itself
			if i == 0 && j == 0 {
				continue
			}

			// Skip out-of-bounds cells
			newX, newY := x+i, y+j
			if newX < 0 || newX >= size || newY < 0 || newY >= size {
				continue
			}

			// Count adjacent filled cells
			if grid[newX][newY] == "@" {
				count++
				if count >= minAdjacentThreshold {
					return false
				}
			}
		}
	}

	return count < minAdjacentThreshold
}

// parseGrid converts input lines into a 2D grid.
func parseGrid(input []string) [][]string {
	var grid [][]string

	for _, line := range input {
		line = strings.TrimSpace(line)
		if len(line) == 0 {
			continue
		}

		row := make([]string, 0, len(line))
		for _, ch := range line {
			row = append(row, string(ch))
		}
		grid = append(grid, row)
	}

	return grid
}

// Deprecated: Use private functions instead.
func LessThanFourAdjacentFilled(grid [][]string, x int, y int, width int) bool {
	return lessThanFourAdjacentFilled(grid, x, y, width)
}

func ParseGrid(input []string) [][]string {
	return parseGrid(input)
}

func ProcessGrid(grid [][]string) int {
	return processGrid(grid)
}
