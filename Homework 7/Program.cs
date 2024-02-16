class Program
{
    static void Main()
    {
        char[,] matrix = new char[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                matrix[i, j] = '1';
            }
        }

        Console.WriteLine("Matrix 0:");
        PrintMatrix(matrix);

        int queenCount = 0;

        while (HasFP(matrix))
        {
            int randomX, randomY;
            do
            {
                Random random = new Random();
                randomX = random.Next(8);
                randomY = random.Next(8);
            } while (matrix[randomX, randomY] != '1');


            matrix[randomX, randomY] = 'X';


            MarkCells(matrix, randomX, randomY);

            queenCount++;
            Console.WriteLine($"Matrix {queenCount} ({randomX}, {randomY}):");
            PrintMatrix(matrix);
        }
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < 8; i++)
        {

            for (int j = 0; j < 8; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void MarkCells(char[,] matrix, int queenX, int queenY)
    {

        for (int i = 0; i < 8; i++)
        {
            if (matrix[queenX, i] != 'X')
                matrix[queenX, i] = '0';

            if (matrix[i, queenY] != 'X')
                matrix[i, queenY] = '0';
        }


        for (int i = queenX - 1, j = queenY - 1;
        i >= 0 && j >= 0; i--, j--)
        {
            if (matrix[i, j] != 'X')
                matrix[i, j] = '0';
        }
        for (int i = queenX + 1, j = queenY + 1;
        i < 8 && j < 8; i++, j++)
        {
            if (matrix[i, j] != 'X')
                matrix[i, j] = '0';
        }


        for (int i = queenX - 1, j = queenY + 1;
        i >= 0 && j < 8; i--, j++)
        {
            if (matrix[i, j] != 'X')
                matrix[i, j] = '0';
        }
        for (int i = queenX + 1, j = queenY - 1;
        i < 8 && j >= 0; i++, j--)
        {
            if (matrix[i, j] != 'X')
                matrix[i, j] = '0';
        }
    }

    static bool HasFP(char[,] matrix)
    {

        foreach (char cell in matrix)
        {

            if (cell == '1')
                return true;
        }
        return false;
    }
}