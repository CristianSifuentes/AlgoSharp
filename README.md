# Advanced C# Concepts and Applications

## Table of Contents
1. [Advanced Math Test: Implementing Matrix Operations](#advanced-math-test-implementing-matrix-operations)
2. [Particle Physics Simulation with Advanced LINQ](#particle-physics-simulation-with-advanced-linq)
3. [LINQ Mastery Roadmap](#roadmap-to-linq-mastery)
4. [Molecule Analysis Using C#](#problem-description-molecule-analysis)
5. [Matrix Algebra Framework](#scenario-matrix-algebra-framework)
6. [Advanced C# Simulations](#advanced-csharp-programs)
   - [Nuclear Decay Simulation Framework](#advanced-csharp-program-nuclear-decay-simulation-framework)
   - [Mechanical Physics Simulation Framework](#advanced-csharp-program-mechanical-physics-simulation-framework)
7. [C# Generic Constraints: `where T : struct`](#where-t-struct)
8. [Understanding Indexers](#indexer)
9. [Clean Code Principles](#what-is-clean-code)
10. [Banking System with Clean Architecture](#scenario-banking-system)
11. [Mathematical Concept: Matrix Operations with Clean Code](#mathematical-concept-matrix-operations-clean-architecture-and-clean-code-principles)

---

# Advanced Math Test: Implementing Matrix Operations

## **Overview**

This test evaluates your ability to implement core **matrix operations** using **C#**. You will be required to perform **matrix multiplication**, **matrix transposition**, and **determinant calculation**, applying various **C# concepts** such as object-oriented programming (OOP), generics, interfaces, and LINQ.

## **Test Instructions**

### **Objective**

Your task is to create a `Matrix` class that supports:

- **Matrix Multiplication**: Implement logic to multiply two matrices.
- **Matrix Transpose**: Implement a method to transpose a given matrix.
- **Matrix Determinant**: Implement an algorithm to calculate the determinant of a matrix.

### **Requirements**

1. **Use OOP principles**: Implement encapsulation, polymorphism, and abstraction.
2. **Implement Exception Handling**: Prevent invalid operations (e.g., incompatible matrices for multiplication, non-square matrices for determinant calculation).
3. **Efficient Computation**: Use optimized algorithms for determinant computation.
4. **LINQ Usage**: Apply LINQ methods where applicable.
5. **Testing**: Include a test suite that validates all matrix operations.

---

## **Matrix Multiplication**

### **Definition**

Matrix multiplication of two matrices **A (m×n)** and **B (n×p)** results in a matrix **C (m×p)** such that:

```math
C[i,j] = \sum_{k=0}^{n-1} A[i,k] \times B[k,j]
```

### **Implementation Steps**

1. Validate that the number of columns in `A` matches the number of rows in `B`.
2. Create a result matrix `C` with dimensions `(m × p)`.
3. Perform the dot product computation for each element of `C`.

### **C# Implementation**

```csharp
public class Matrix
{
    private readonly double[,] _data;
    public int Rows { get; }
    public int Columns { get; }

    public Matrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _data = new double[rows, columns];
    }

    public double this[int row, int col]
    {
        get => _data[row, col];
        set => _data[row, col] = value;
    }

    public static Matrix Multiply(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
            throw new InvalidOperationException("Matrix dimensions are incompatible for multiplication.");

        Matrix result = new Matrix(a.Rows, b.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < b.Columns; j++)
                for (int k = 0; k < a.Columns; k++)
                    result[i, j] += a[i, k] * b[k, j];

        return result;
    }
}
```

---

## **Transpose a Matrix**

### **Definition**

The **transpose** of a matrix **A (m×n)** is a new matrix **Aᵀ (n×m)** where:

```math
Aᵀ[i,j] = A[j,i]
```

### **Implementation Steps**

1. Create a new matrix `T` with reversed dimensions `(n×m)`.
2. Swap rows with columns.

### **C# Implementation**

```csharp
public Matrix Transpose()
{
    Matrix transposed = new Matrix(Columns, Rows);
    for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Columns; j++)
            transposed[j, i] = _data[i, j];

    return transposed;
}
```

---

## **Matrix Determinant**

### **Definition**

The **determinant** of a square matrix **A (n×n)** is a scalar value calculated recursively:

```math
det(A) = \sum_{j=0}^{n-1} (-1)^j A[0,j] det(A_{0j})
```

where **A₀ⱼ** is the minor of `A` obtained by removing row `0` and column `j`.

### **Implementation Steps**

1. Base case: If `n == 1`, return the single element.
2. Base case: If `n == 2`, return `ad - bc`.
3. Use recursion to calculate the determinant for larger matrices.

### **C# Implementation**

```csharp
public double Determinant()
{
    if (Rows != Columns)
        throw new InvalidOperationException("Determinant can only be calculated for square matrices.");

    return CalculateDeterminant(_data);
}

private double CalculateDeterminant(double[,] matrix)
{
    int size = matrix.GetLength(0);
    if (size == 1) return matrix[0, 0];
    if (size == 2) return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);

    double determinant = 0;
    for (int j = 0; j < size; j++)
    {
        double[,] minor = GetMinor(matrix, 0, j);
        determinant += Math.Pow(-1, j) * matrix[0, j] * CalculateDeterminant(minor);
    }
    return determinant;
}
```
---

## Particle Physics Simulation with Advanced LINQ

### Scenario
This simulation models the behavior of subatomic particles using LINQ for data processing and aggregation.

### Features
- Parallel LINQ (PLINQ) for performance optimization
- Advanced filtering and projection
- Grouping and aggregation of particle data

---

## Roadmap to LINQ Mastery

### **Basic LINQ Characteristics**
- LINQ queries (Where, Select, OrderBy)
- IEnumerable vs IQueryable
- Deferred execution

### **Medium LINQ Characteristics**
- Grouping and Joining
- Projection with SelectMany
- Aggregation methods (Sum, Count, Average)

### **Advanced LINQ Characteristics**
- Expression trees
- PLINQ (Parallel LINQ)
- Custom IQueryable Providers

### **Expert-Level LINQ Characteristics**
- LINQ to SQL & Entity Framework optimizations
- Asynchronous LINQ queries
- Query performance tuning

---

## Problem Description: Molecule Analysis

This problem involves analyzing complex molecular structures using LINQ and object-oriented programming to efficiently manage chemical bonds and reactions.

---

## Scenario: Matrix Algebra Framework

A complete implementation of a matrix algebra framework using object-oriented programming and generics for mathematical operations.

---

## Advanced C# Programs

### Advanced C# Program: Nuclear Decay Simulation Framework
- Uses generics, events, and LINQ to simulate radioactive decay.
- Models alpha, beta, and gamma decay with time-based simulation.

### Advanced C# Program: Mechanical Physics Simulation Framework
- Implements Newtonian mechanics with force, acceleration, and velocity calculations.
- Uses parallel computing for real-time physics processing.

---

## Understanding `where T : struct`

### What It Means
- Ensures that `T` is a **value type**.
- Cannot be a reference type (`class`).
- Used for performance optimizations in generics.

### Example
```csharp
public class ValueWrapper<T> where T : struct
{
    private T value;
    public ValueWrapper(T val) => value = val;
}
```

---

## Understanding Indexers

Indexers allow objects to be accessed using array-like syntax:

```csharp
public class Matrix
{
    private double[,] data;
    public double this[int row, int col] => data[row, col];
}
```

---

## What is Clean Code?

### Key Characteristics of Clean Code
- Readability and simplicity
- Maintainability
- Consistency in style

### Principles of Clean Code
- **KISS** (Keep It Simple, Stupid)
- **DRY** (Don't Repeat Yourself)
- **YAGNI** (You Aren't Gonna Need It)

### Benefits of Clean Code
- Easier debugging and maintenance
- Better collaboration among developers
- Faster development cycles

---

## Scenario: Banking System

### Features
- **Account Management**: Supports savings and checking accounts.
- **Transaction Handling**: Secure deposit, withdrawal, and transfers.
- **Reporting**: Asynchronous generation of financial summaries.

### Clean Architecture Applied
| **Layer**          | **Responsibility**                                  |
|--------------------|--------------------------------------------------|
| **Entities**       | Core business logic (BankAccount, Transaction). |
| **Use Cases**      | Application-specific logic (Deposit, Withdraw). |
| **Adapters**      | Converts domain models for external systems. |
| **Frameworks**    | Database, API, or UI integration. |

---

## Mathematical Concept: Matrix Operations - Clean Architecture and Clean Code Principles

### Design
- **Encapsulation**: Matrix properties are private.
- **Dependency Injection**: Used for repository pattern.
- **Asynchronous Processing**: Optimized matrix calculations with multi-threading.

---

## Summary
This document covers **advanced C# programming concepts**, including:
- **Mathematical Simulations**
- **Physics Simulations with LINQ**
- **Clean Code and Architecture Principles**
- **Banking System Implementation**
- **Advanced Usage of Generics and Indexers**

This knowledge base serves as a comprehensive guide for **mastering C#** at an advanced level.

