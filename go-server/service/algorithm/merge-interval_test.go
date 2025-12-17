package algorithm

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestMergeIntervals1(t *testing.T) {
	input := []Range{
		{Start: 1, End: 3},
		{Start:1, End: 3}, 
		{Start:1, End: 4}}

	result := MergeIntervals(input)
	
	assert.Equal(t, 1, len(result))
	assert.Equal(t, 1, result[0].Start)
	assert.Equal(t, 4, result[0].End)
}

func TestMergeIntervals2(t *testing.T) {
	input := []Range{
		{Start: 1, End: 3},
		{Start:1, End: 3}}

	result := MergeIntervals(input)
	
	assert.Equal(t, 1, len(result))
	assert.Equal(t, 1, result[0].Start)
	assert.Equal(t, 3, result[0].End)
}

func TestMergeIntervals3(t *testing.T) {
	input := []Range{
		{Start: 1, End: 3},
		{Start:1, End: 3},
		{Start:1, End: 4},
		{Start:5, End: 6}}

	result := MergeIntervals(input)
	
	assert.Equal(t, 2, len(result))
	assert.Equal(t, 1, result[0].Start)
	assert.Equal(t, 4, result[0].End)
	assert.Equal(t, 5, result[1].Start)
	assert.Equal(t, 6, result[1].End)
}

func TestMergeIntervalsTouching(t *testing.T) {
	input := []Range{
		{Start: 1, End: 5},
		{Start:3, End: 4}}

	result := MergeIntervals(input)
	
	assert.Equal(t, 1, len(result))
	assert.Equal(t, 1, result[0].Start)
	assert.Equal(t, 5, result[0].End)
}

func TestMergeIntervals4(t *testing.T) {
	input := []Range{
		{Start: 1, End: 7},
		{Start:3, End: 8},
		{Start:5, End: 10}}

	result := MergeIntervals(input)
	
	assert.Equal(t, 1, len(result))
	assert.Equal(t, 1, result[0].Start)
	assert.Equal(t, 10, result[0].End)
}