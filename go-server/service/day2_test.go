package service

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay2Part1(t *testing.T) {
	expected := 1227775554
	input := `11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
1698522-1698528,446443-446449,38593856-38593862,565653-565659,
824824821-824824827,2121212118-2121212124`
	actual := Day2Part1(input)
	assert.Equal(t, expected, actual)
}

// func TestDay2Part2(t *testing.T) {
// 	expected := 6
// 	input := `L68
// L30
// R48
// L5
// R60
// L55
// L1
// L99
// R14
// L82`
// 	actual := Day1Part2(ReadLinesFromContents(input))
// 	assert.Equal(t, expected, actual)
// }

func TestIsPalindrome(t *testing.T) {
	assert.Equal(t, true, IsPalinDrome("11"))
	// assert.Equal(t, true, IsPalinDrome("1"))
	// assert.Equal(t, true, IsPalinDrome("101"))
	// assert.Equal(t, true, IsPalinDrome("1234321"))
	// assert.Equal(t, true, IsPalinDrome("123321"))
	// assert.Equal(t, false, IsPalinDrome("1231"))
}
