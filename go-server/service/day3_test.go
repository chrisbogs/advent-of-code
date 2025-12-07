package service

import (
	"strings"
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay3Part1(t *testing.T) {
	expected := 357
	input := `987654321111111
811111111111119
234234234234278
818181911112111`
	actual := Day3Part1(strings.Split(input, "\n"))

	assert.Equal(t, expected, actual)
}
func TestDay3Part1A(t *testing.T) { assert.Equal(t, 98, Day3Part1([]string{"987654321111111"})) }
func TestDay3Part1B(t *testing.T) { assert.Equal(t, 89, Day3Part1([]string{"811111111111119"})) }
func TestDay3Part1C(t *testing.T) { assert.Equal(t, 78, Day3Part1([]string{"234234234234278"})) }
func TestDay3Part1D(t *testing.T) { assert.Equal(t, 92, Day3Part1([]string{"818181911112111"})) }
