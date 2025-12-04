package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func main() {
	fmt.Println(day1Part1(readLines("input1")));
}

// Reads lines from given filename one by one and returns an array of lines.
func readLines(filename string) []string {
    file, err := os.Open(filename)
    if err != nil {
        panic(err)
    }
    defer file.Close()

    var lines []string
    scanner := bufio.NewScanner(file)
    for scanner.Scan() {
        lines = append(lines, scanner.Text())
    }
    return lines
}

func day1Part1(input []string) int{
	// Parse
	// input: XY where X is a character: 'L', 'R', Y is an int 0-99
// 	input := []string{
// 		"L68",
// "L30",
// "R48",
// "L5",
// "R60",
// "L55",
// "L1",
// "L99",
// "R14",
// "L82"}

	var currentValue, password int = 50, 0;
	// Follow instructions
	for i:= 0; i < len(input); i++ {
		firstCharacter := input[i][0];
		number, _ := strconv.Atoi(input[i][1:])
		// fmt.Printf("%c%d, ", firstCharacter, number)

		switch (firstCharacter){
		case 'L':
			currentValue = ((currentValue - number) % 100 + 100) % 100 
		case 'R':
			currentValue = ((currentValue + number) % 100 + 100) % 100
		}
		// fmt.Println((currentValue))
		// keep track of when the intermediate number is 0
		if currentValue == 0 {
			password++;
		}
	}
	return password
}