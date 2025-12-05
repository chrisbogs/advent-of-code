package service

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay1Part1(t *testing.T) {
    expected := 3
	input := `L68
L30
R48
L5
R60
L55
L1
L99
R14
L82`
    actual := Day1Part1(ReadLinesFromContents(input))

    assert.Equal(t, expected, actual)
}


func TestDay1Part2(t *testing.T) {
    expected := 6
	input := `L68
L30
R48
L5
R60
L55
L1
L99
R14
L82`
    actual := Day1Part2(ReadLinesFromContents(input))

    assert.Equal(t, expected, actual)
}
func TestDay1Part2B(t *testing.T) {
    expected := 10
	input := `R1000`
    actual := Day1Part2(ReadLinesFromContents(input))

    assert.Equal(t, expected, actual)
}
