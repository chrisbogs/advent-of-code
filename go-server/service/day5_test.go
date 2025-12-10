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
