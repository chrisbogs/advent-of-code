package service

//The rolls of paper (@) are arranged on a large grid; the Elves even have a helpful diagram (your puzzle input) indicating where everything is located.
//The forklifts can only access a roll of paper if there are fewer than four rolls of paper in the eight adjacent positions.

func Day4Part1(input []string) int {
	grid := parseGrid(input)

	return 0
}

func parseGrid(input[] string) [][]bool {
	var grid [][]bool
	
	for i := 0; i < len(input); i++ {
		line := input[i]
		row := make([]bool, len(line))
		for i, char := range line {
			row[i] = char == '@'
		}
		grid = append(grid, row)
	}
	
	return grid
}

