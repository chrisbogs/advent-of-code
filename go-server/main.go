package main

import (
	"adventofcode/service"
	"fmt"
)

func main() {
	fmt.Println(service.Day1Part1(service.ReadLines("input1")))
	fmt.Println(service.Day1Part2(service.ReadLines("input1")))
	fmt.Println("3: ", service.Day3Part1(service.ReadLines("input3")))
	fmt.Println("3: ", service.Day3Part2(service.ReadLines("input3")))
}
