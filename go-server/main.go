package main

import (
	"adventofcode/service"
	"fmt"
	"log/slog"
	"os"
)

// Runner executes advent of code solutions.
type Runner struct {
	logger *slog.Logger
}

// NewRunner creates a new runner instance.
func NewRunner() *Runner {
	return &Runner{
		logger: slog.New(slog.NewTextHandler(os.Stdout, nil)),
	}
}

// Run executes all available solutions.
func (r *Runner) Run() error {
	solutions := []struct {
		name string
		file string
		part1Func func([]string) int
		part2Func func([]string) int
	}{
		{"Day 1", "input1", service.Day1Part1, service.Day1Part2},
		{"Day 2", "input2", service.Day2Part1WithFirstLine, service.Day2Part2WithFirstLine},
		{"Day 3", "input3", service.Day3Part1, service.Day3Part2},
		{"Day 4", "input4", service.Day4Part1, service.Day4Part2},
	}

	for _, sol := range solutions {
		if err := r.executeSolution(sol.name, sol.file, sol.part1Func, sol.part2Func); err != nil {
			r.logger.Error("failed to execute solution", "name", sol.name, "error", err)
			continue
		}
	}

	return nil
}

func (r *Runner) executeSolution(name, file string, part1 func([]string) int, part2 func([]string) int) error {
	lines, err := service.ReadLines(file)
	if err != nil {
		return err
	}

	r.logger.Info("executing solution", "name", name)
	fmt.Printf("%s Part 1: %d\n", name, part1(lines))
	fmt.Printf("%s Part 2: %d\n", name, part2(lines))

	return nil
}

func main() {
	runner := NewRunner()
	if err := runner.Run(); err != nil {
		slog.Error("runtime error", "error", err)
		os.Exit(1)
	}
}
