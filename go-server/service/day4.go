package service

//The rolls of paper (@) are arranged on a large grid; the Elves even have a helpful diagram (your puzzle input) indicating where everything is located.
//The forklifts can only access a roll of paper if there are fewer than four rolls of paper in the eight adjacent positions.

func Day4Part1(input []string) int {
	grid := ParseGrid(input)
	return ProcessGrid(grid)
}

// Traverse grid once to mark the cells that are valid with x
func ProcessGrid(grid [][]string) int {
	count := 0
	width := len(grid)
	// traverse the grid and check all 8 adjacent cells
	for x := range width {
		for y := range width {
			// println(x, y, grid[y][x])
			if grid[x][y] == "@" &&
				LessThanFourAdjacentFilled(grid, x, y, width) {
				// println("found ", x, y)
				grid[x][y] = "x"
				count++
			}
		}
	}
	return count
}

func Day4Part2(input []string) int {
	// Keep repeating the removal process
	grid := ParseGrid(input)
	count := 1
	for marked := -1; marked != 0; marked = ProcessGrid(grid) {
		count += marked
	}
	return count
}

func LessThanFourAdjacentFilled(grid [][]string, x int, y int, width int) bool {
	// if less than 4 adjacent cells are marked (true) then this is a valid position
	// 0,0 0,1 0,2
	// 1,0 1,1 1,2
	// 2,0 2,1 2,2
	countOfAdjacentMarked := 0
	xs := []int{-1, 0, 1}
	ys := []int{-1, 0, 1}
	// println("beginning check")
	for _, j := range xs {
		for _, i := range ys {
			// exclude invalid indices
			if x+i < 0 || x+i > width-1 || y+j < 0 || y+j > width-1 || (i == 0 && j == 0) {
				continue
			}

			// println(x+i, y+j, grid[x+i][y+j])
			if grid[x+i][y+j] == "@" {
				countOfAdjacentMarked++
				if countOfAdjacentMarked >= 4 {
					return false
				}
			}
		}
	}
	return countOfAdjacentMarked < 4
}
func printGrid(grid [][]string) {
	for _, row := range grid {
		for _, cell := range row {
			print(cell)
		}
		println()
	}
}

func ParseGrid(input []string) [][]string {
	var grid [][]string

	for i := 0; i < len(input); i++ {
		line := input[i]
		row := make([]string, len(line))
		for i := 0; i < len(line); i++ {
			row[i] = string(line[i])
		}
		grid = append(grid, row)
	}

	return grid
}
