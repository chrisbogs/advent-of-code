package service

import (
	"bufio"
	"fmt"
	"log/slog"
	"os"
	"strings"
)

// ReadLines reads lines from a file and returns them as a slice.
// Returns an error if the file cannot be read.
func ReadLines(filename string) ([]string, error) {
	file, err := os.Open(filename)
	if err != nil {
		return nil, fmt.Errorf("failed to open file %q: %w", filename, err)
	}
	defer file.Close()

	var lines []string
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		lines = append(lines, strings.TrimSpace(scanner.Text()))
	}

	if err := scanner.Err(); err != nil {
		return nil, fmt.Errorf("error reading file %q: %w", filename, err)
	}

	return lines, nil
}

// ReadLinesFromContents simulates file reading from a string.
// Useful for testing without file I/O.
func ReadLinesFromContents(contents string) []string {
	var lines []string
	for _, line := range strings.Split(contents, "\n") {
		trimmmed := strings.TrimSpace(line)
		if trimmmed != "" {
			lines = append(lines, trimmmed)
		}
	}
	return lines
}

// MustReadLines is a wrapper around ReadLines that panics if an error occurs.
// Use only when file reading errors should be fatal.
func MustReadLines(filename string) []string {
	lines, err := ReadLines(filename)
	if err != nil {
		slog.Error("failed to read file", "error", err)
		panic(err)
	}
	return lines
}