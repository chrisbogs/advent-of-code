package service

import (
	"strconv"
	"strings"
)

type Equation struct {
	Operand string
	Values  []int
}

func Day6Part1(input []string) int {
	equations := ParseValuesAndOperands(input)
	result := 0
	var total int

	for _, x := range equations {
		// solve each equation
		// println(x.Operand)
		if x.Operand == "+" {
			total = 0
		} else {
			total = 1
		}
		for _, s := range x.Values {
			if x.Operand == "+" {
				total += s
			} else {
				total *= s
			}
			// println(s)

		}
		// println(total)
		result += total
	}
	return result
}

func ParseValuesAndOperands(input []string) []Equation {
	// find out how many equations there are:
	var equations []Equation
	for _, x := range input {
		tokens := strings.Fields(x)
		switch string(tokens[0]) {
		case "+":
			for z := 0; z < len(tokens); z++ {
				equations[z].Operand = tokens[z]
			}
		case "*":
			for z := 0; z < len(tokens); z++ {
				equations[z].Operand = tokens[z]
			}
		default:
			for idx, s := range tokens {
				num, _ := strconv.Atoi(s)
				if len(equations)-1 < idx {
					equations = append(equations, Equation{Values: []int{}})
				}
				equations[idx].Values = append(equations[idx].Values, num)
			}
		}
	}
	return equations
}
