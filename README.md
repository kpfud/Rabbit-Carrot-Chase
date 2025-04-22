# Rabbit-Carrot-Chase

This is a C# console application based on a common programming interview question. The rabbit is placed in a matrix representing a field of carrots and must eat as many as possible by following a greedy movement algorithm.

## Project Description

Each cell in the matrix contains an integer value representing the number of carrots in that square. The rabbit starts in the middle of the field (or closest to the middle if the field has an even size) and follows these rules:

1. The rabbit can move **up**, **down**, **left**, or **right** (no diagonal movement).
2. The rabbit cannot backtrack.
3. On each move, the rabbit chooses the neighboring cell with the **highest number of carrots**.
4. The rabbit stops when no unvisited neighboring cell contains carrots.

## Features

- Hardcoded matrices
- Matrix traversal without recursion
- Greedy algorithm to maximize carrot collection
- Console output of the rabbit's path and total carrots eaten

## Skills Demonstrated

- C# control flow and logic
- Matrix manipulation
- Greedy pathfinding algorithm
- Clean, single-file implementation

## 🚀 How to Run

1. Clone the repo:
```bash
git clone https://github.com/kpfundstein/rabbit-carrot-chase.git
