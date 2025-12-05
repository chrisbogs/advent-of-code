package service

import (
	"bufio"
	"os"
	"strings"
)

// Reads lines from given filename one by one and returns an array of lines.
func ReadLines(filename string) []string {
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

// Overload for tests:
// Reads lines from given string (simulating the file contents) one by one and returns an array of lines.
func ReadLinesFromContents(contents string) []string {
	return strings.Split(contents, "\n")
}