package service

import (
	"strconv"
)

func Day1Part1(input []string) int{
	// Parse
	// input: XY where X is a character: 'L', 'R', Y is an int

	var currentValue, password int = 50, 0;
	// Follow instructions
	for _, line := range input {
		firstCharacter := line[0];
		number, _ := strconv.Atoi(line[1:])
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

func Day1Part2(input []string) int{
	// Parse
	// input: XY where X is a character: 'L', 'R', Y is an int

	var currentValue, password int = 50, 0;
	// Follow instructions
	for _, line := range input {
		firstCharacter := line[0];
		number, _ := strconv.Atoi(line[1:])
		// fmt.Println(string(firstCharacter), number)

		oldValue := currentValue
		switch (firstCharacter){
		case 'L':
			numberOfLoops := int(number / 100)
			password += numberOfLoops
			// println("numberOfLoops", numberOfLoops)
			currentValue = ((currentValue - number) % 100 + 100) % 100 
			if oldValue != 0 && currentValue != 0 && currentValue > oldValue {
				// we've passed 0 at least once
				// println("+1")
				password += 1
			}

		case 'R':
			numberOfLoops := int(number / 100)
			password += numberOfLoops
			// println("numberOfLoops", numberOfLoops)
			currentValue = ((currentValue + number) % 100 + 100) % 100
			if oldValue != 0 && currentValue != 0 && currentValue < oldValue {
				// we've passed 0 at least once
				// println("+1")
				password += 1
			}
		}
		// keep track of when the intermediate number is 0
		if currentValue == 0 {
			// println("password++")
			password++;
		}
		// fmt.Println("Current value", currentValue)
		// fmt.Println("password", password)
		// println()
	}
	return password
}