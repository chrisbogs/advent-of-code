package service

import (
	"strings"
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay4Part1(t *testing.T) {
	input := `..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.`
	actual := Day4Part1(strings.Split(input, "\n"))

	assert.Equal(t, 13, actual)
}

// func TestDay3Part1A(t *testing.T) { assert.Equal(t, 98, Day3Part1([]string{"987654321111111"})) }
func TestLessThanFourAdjacentFilled1(t *testing.T) {
	assert.Equal(t, true, LessThanFourAdjacentFilled(
		ParseGrid(strings.Split(`..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.`, "\n")), 0, 2, 10))
}

func TestDay4Part2(t *testing.T) {
	input := `..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.`
	actual := Day4Part2(strings.Split(input, "\n"))

	assert.Equal(t, 43, actual)
}
