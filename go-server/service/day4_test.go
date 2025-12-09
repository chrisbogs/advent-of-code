package service

import (
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
	actual := Day4Part1(input)

	assert.Equal(t, 13, actual)
}
// func TestDay3Part1A(t *testing.T) { assert.Equal(t, 98, Day3Part1([]string{"987654321111111"})) }