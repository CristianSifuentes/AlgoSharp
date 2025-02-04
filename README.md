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

# **Particle Physics Simulation with Advanced LINQ**

## **Overview**
This information details an advanced implementation of **Particle Physics Simulation** using **LINQ (Language Integrated Query)** in **C#**. The simulation models subatomic particle behavior, interactions, and energy states while utilizing **advanced LINQ techniques** for efficient data querying, transformation, and processing.

## **Scenario**
### **Problem Statement**
In modern **particle physics simulations**, researchers often deal with vast datasets containing information about particles such as **mass, charge, spin, energy levels**, and **collisions**. An efficient simulation must:

1. **Filter particles** based on energy thresholds.
2. **Group particles** by categories such as charge and spin.
3. **Compute statistical values**, such as average energy or total momentum.
4. **Model interactions** based on energy conservation and quantum mechanics.
5. **Sort and rank particles** based on physical properties.

To implement these requirements, we use **advanced LINQ techniques** such as **grouping, projections, aggregation, parallel queries (PLINQ), and deferred execution**.

---

## **Explanation**

### **Particle Class Design**
To simulate particles, we create a class that models physical properties:

```csharp
public class Particle
{
    public string Name { get; set; }
    public double Mass { get; set; }   // Measured in MeV/c^2
    public double Charge { get; set; } // Positive, Negative, or Neutral
    public double Spin { get; set; }
    public double Energy { get; set; } // Energy in MeV
    
    public Particle(string name, double mass, double charge, double spin, double energy)
    {
        Name = name;
        Mass = mass;
        Charge = charge;
        Spin = spin;
        Energy = energy;
    }
}
```

### **Creating a Particle Dataset**
We generate a list of particles to process:

```csharp
List<Particle> particles = new()
{
    new Particle("Proton", 938.27, 1, 1/2.0, 1000),
    new Particle("Neutron", 939.56, 0, 1/2.0, 950),
    new Particle("Electron", 0.511, -1, 1/2.0, 500),
    new Particle("Positron", 0.511, 1, 1/2.0, 520),
    new Particle("Muon", 105.66, -1, 1/2.0, 2000)
};
```

### **Filtering Particles by Energy Threshold**
We filter particles that exceed a specific energy threshold:

```csharp
var highEnergyParticles = particles.Where(p => p.Energy > 1000);
```

### **Grouping Particles by Charge**
Using **LINQ GroupBy**, we categorize particles:

```csharp
var groupedByCharge = particles.GroupBy(p => p.Charge);

foreach (var group in groupedByCharge)
{
    Console.WriteLine($"Charge: {group.Key}");
    foreach (var particle in group)
        Console.WriteLine($"  - {particle.Name}, Energy: {particle.Energy} MeV");
}
```

### **Computing Statistical Values (Average Energy)**
```csharp
double avgEnergy = particles.Average(p => p.Energy);
Console.WriteLine($"Average Particle Energy: {avgEnergy} MeV");
```

### **Sorting Particles by Energy (Descending Order)**
```csharp
var sortedByEnergy = particles.OrderByDescending(p => p.Energy);
```

### **Parallel Processing with PLINQ (Parallel LINQ)**
To optimize performance, we use **PLINQ**:

```csharp
var highEnergyParallel = particles.AsParallel().Where(p => p.Energy > 1000);
```

PLINQ speeds up processing by distributing operations across multiple threads, which is useful for large datasets in physics simulations.

---

## **Advanced LINQ Highlights**

### **1. Deferred Execution**
LINQ queries are not executed until their results are iterated or explicitly requested using `.ToList()`, `.ToArray()`, or `.Count()`.

```csharp
var filteredParticles = particles.Where(p => p.Energy > 1000);
Console.WriteLine("Query defined but not executed.");

// Now the query executes
foreach (var p in filteredParticles)
    Console.WriteLine(p.Name);
```

### **2. Lambda Expressions for Compact Querying**
Instead of writing verbose loops, LINQ allows concise expressions:
```csharp
var electrons = particles.Where(p => p.Name == "Electron");
```

### **3. LINQ Joins for Complex Queries**
If particles interact and we need to join datasets, we use **LINQ joins**:
```csharp
var interactions = from p1 in particles
                   join p2 in particles on p1.Charge equals -p2.Charge
                   where p1.Energy > 500
                   select new { P1 = p1.Name, P2 = p2.Name };
```

### **4. Projection with SelectMany**
```csharp
var particleNames = particles.SelectMany(p => p.Name.ToCharArray());
```

### **5. Using `Aggregate` for Complex Computation**
```csharp
double totalMass = particles.Aggregate(0.0, (sum, p) => sum + p.Mass);
```

---

## **Summary**
This information provides a step-by-step implementation of a **Particle Physics Simulation** using **Advanced LINQ** features. We covered:

✔ **Filtering, Grouping, and Sorting Particles** using LINQ.  
✔ **Parallel Processing with PLINQ** for performance optimization.  
✔ **Statistical Computation** using LINQ Aggregate and Average.  
✔ **LINQ Joins and Projection Techniques** for complex queries.  

Using these concepts, you can efficiently simulate and analyze particle interactions in a structured, high-performance manner.


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

