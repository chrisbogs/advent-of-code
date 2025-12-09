package main

import (
	"adventofcode/service"
	"fmt"
)

func main() {
	fmt.Println(service.Day1Part1(service.ReadLines("input1")));
	fmt.Println(service.Day1Part2(service.ReadLines("input1")));
	
	fmt.Println(service.Day2Part1(service.ReadLines("input2")[0]));
	fmt.Println(service.Day2Part2(service.ReadLines("input2")[0]));
}



