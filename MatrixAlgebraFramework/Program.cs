 class Program {
        static void Main() { 
            // Create and populate matrices
            var matrixA =  new Matrix(2,2);
            matrixA.Populate(new double[, ] {{1, 2},{3, 4}});

            var matrixB = new Matrix(2, 2);
            matrixB.Populate(new double[,] {{5, 6},{7, 8}});
            
            Console.WriteLine("Matrix A:");
            matrixA.Display();

        }

 }