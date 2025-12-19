package service

import (
	"strings"
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay6Part1(t *testing.T) {
	input := `123 328  51 64 
 45 64  387 23 
  6 98  215 314
*   +   *   + `
	actual := Day6Part1(strings.Split(input, "\n"))

	assert.Equal(t, 4277556, actual)
}

func TestParsing(t *testing.T) {
	input := []string{"123", "134", "*"}
	actual := ParseValuesAndOperands(input)

	assert.Equal(t, 1, len(actual))
	assert.Equal(t, "*", actual[0].Operand)
	assert.Equal(t, []int{123, 134}, actual[0].Values)
}

func TestParsing2(t *testing.T) {
	input := []string{"123 234", "134 345", "* +"}
	actual := ParseValuesAndOperands(input)

	assert.Equal(t, 2, len(actual))
	assert.Equal(t, "*", actual[0].Operand)
	assert.Equal(t, []int{123, 134}, actual[0].Values)

	assert.Equal(t, "+", actual[1].Operand)
	assert.Equal(t, []int{234, 345}, actual[1].Values)
}
