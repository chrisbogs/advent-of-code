package service

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay2Part1A(t *testing.T) {	assert.Equal(t, 33, Day2Part1("11-22"))}
func TestDay2Part1B(t *testing.T) {	assert.Equal(t, 99, Day2Part1("95-115"))}
func TestDay2Part1C(t *testing.T) {	assert.Equal(t, 1010, Day2Part1("998-1012"))}
func TestDay2Part1D(t *testing.T) {	assert.Equal(t, 1188511885, Day2Part1("1188511880-1188511890"))}
func TestDay2Part1E(t *testing.T) {	assert.Equal(t, 222222, Day2Part1("222220-222224"))}
func TestDay2Part1F(t *testing.T) {	assert.Equal(t, 0, Day2Part1("1698522-1698528"))}

func TestDay2Part1(t *testing.T) {
	expected := 1227775554
	input := `11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124`
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
	assert.Equal(t, true, isRepeatedTwice("11"))
	assert.Equal(t, false, isRepeatedTwice("1"))
	assert.Equal(t, true, isRepeatedTwice("1010"))
	assert.Equal(t, true, isRepeatedTwice("12341234"))
	assert.Equal(t, true, isRepeatedTwice("22"))
}
