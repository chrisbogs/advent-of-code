package service

import (
	"strings"
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay5Part1(t *testing.T) {
	input := `3-5
10-14
16-20
12-18

1
5
8
11
17
32`
	actual := Day5Part1(strings.Split(input, "\n"))

	assert.Equal(t, 3, actual)
}

func TestDay5Part2(t *testing.T) {
	input := `12522931128722-17835086076404`
	actual := Day5Part2(strings.Split(input, "\n"))
	assert.Equal(t, 17835086076404-12522931128722 + 1, actual)
}

func TestDay5Part2A(t *testing.T) {
	input := `1-3
	1-3
	1-4
	5-6`
	actual := Day5Part2(strings.Split(input, "\n"))
	assert.Equal(t, 6, actual)
}
