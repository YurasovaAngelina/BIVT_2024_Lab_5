using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);
        answer = Combinations(n, k);
        // end

        return answer;
    }
    public static int Factorial(int n)
    {
        if (n <= 1)
            return 1;
        else
            return n * Factorial(n - 1);
    }
    public static int Combinations(int n, int k)
    {
        int C = Factorial(n) / (Factorial(k) * Factorial(n - k));
        return C;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);
        if (first[0] >= (first[1] + first[2])) return -1;
        if (first[1] >= (first[0] + first[2])) return -1;
        if (first[2] >= (first[0] + first[1])) return -1;
        if (second[0] >= (second[1] + second[2])) return -1;
        if (second[1] >= (second[0] + second[2])) return -1;
        if (second[2] >= (second[0] + second[1])) return -1;
        double a1 = GeronArea(first[0], first[1], first[2]), a2 = GeronArea(second[0], second[1], second[2]);
        if (a1 > a2) return 1;
        else if (a1 < a2) return 2;
        else return 0;
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public static double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return S;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        double d1 = GetDistance(v1, a1, time), d2 = GetDistance(v2, a2, time);
        if (d1 > d2) return 1;
        else if (d1 < d2) return 2;
        else return 0;
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    public static double GetDistance(double v, double a, double t)
    {
        double S = v * t + (a * t * t) / 2;
        return S;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;


        // code here

        // use GetDistance(v, a, t); t - hours
        int k = 1;
        while (GetDistance(v1, a1, k) > GetDistance(v2, a2, k))
            k++;
        answer = k;
        // end
        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!
        int A_max = FindMaxIndex(A), B_max = FindMaxIndex(B), A_c = 0, B_c = 0;
        double A_sum = 0, B_sum = 0, A_sr, B_sr;
        for (int i = A_max + 1; i < A.Length; i++)
        {
            A_sum += A[i];
            A_c++;
        }
        A_sr = A_sum / A_c;
        for (int i = B_max + 1; i < B.Length; i++)
        {
            B_sum += B[i];
            B_c++;
        }
        B_sr = B_sum / B_c;
        if (A.Length - A_max > B.Length - B_max)
            A[A_max] = A_sr;
        if (A.Length - A_max < B.Length - B_max)
            B[B_max] = B_sr;
        // end
    }
    public static int FindMaxIndex(double[] array)
    {
        int indexmax = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] > array[indexmax])
                indexmax = i;
        return indexmax;
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        int A_max = FindDiagonalMaxIndex(A), B_max = FindDiagonalMaxIndex(B), a = A.GetLength(0);
        for (int i = 0; i < a; i++)
        {
            int temp = B[i, B_max];
            B[i, B_max] = A[A_max, i];
            A[A_max, i] = temp;
        }
        // end
    }
    public static int FindDiagonalMaxIndex(int[,] matrix)
    {
        int indexmax = 0, a = matrix.GetLength(0);
        for (int i = 1; i < a; i++)
            if (matrix[i, i] > matrix[indexmax, indexmax])
                indexmax = i;
        return indexmax;
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);
        int A_max = FindMax(A), B_max = FindMax(B);
        A = DeleteElement(A, A_max);
        B = DeleteElement(B, B_max);
        int[] a = new int[A.Length + B.Length];
        for (int i = 0; i < A.Length; i++)
            a[i] = A[i];
        for (int i = 0; i < B.Length; i++)
            a[A.Length + i] = B[i];
        A = a;
        // end
    }
    public static int FindMax(int[] array)
    {
        int indexmax = 0;
        for (int i = 1; i < array.Length; i++)
            if (array[i] > array[indexmax])
                indexmax = i;
        return indexmax;
    }
    public static int[] DeleteElement(int[] array, int index)
    {
        int[] array2 = new int[array.Length - 1];
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (i < index)
                array2[i] = array[i];
            else
                array2[i] = array[i + 1];
        }
        return array2;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);
        int A_max = FindMax(A), B_max = FindMax(B);
        SortArrayPart(A, A_max);
        SortArrayPart(B, B_max);
        // end
    }
    public static int[] SortArrayPart(int[] array, int startIndex)
    {
        for (int i = startIndex + 1; i < array.Length; i++)
        {
            int key = array[i], j = i - 1;
            while (j > startIndex && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
        return array;
    }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);
        int max = matrix[0, 0], min = matrix[0, 0], j_max = 0, j_min = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i >= j)
                {
                    if (max < matrix[i, j])
                    {
                        j_max = j;
                        max = matrix[i, j];
                    }
                }
                else
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                        j_min = j;
                    }
                }
            }
        }
        if (j_max == j_min)
            matrix = RemoveColumn(matrix, j_max);
        else
        {
            matrix = RemoveColumn(matrix, j_max);
            matrix = RemoveColumn(matrix, j_min - 1);
        }
        // end
    }
    public static int[,] RemoveColumn(int[,] matrix, int columnIndex)
    {
        int count = 0;
        int[,] matrix2 = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j == columnIndex)
            {
                continue;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix2[i, count] = matrix[i, j];
            }
            count++;
        }
        matrix = matrix2;
        return matrix;
    }
    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);
        int A_max = FindMaxColumnIndex(A), B_max = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int temp = A[i, A_max];
            A[i, A_max] = B[i, B_max];
            B[i, B_max] = temp;
        }
        // end
    }
    public static int FindMaxColumnIndex(int[,] matrix)
    {
        int max = matrix[0, 0], j_max = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    j_max = j;
                }
            }
        }
        return j_max;
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);
        for (int i = 0; i < matrix.GetLength(0); i++)
            SortRow(matrix, i);
        // end
    }
    public static int[,] SortRow(int[,] matrix, int rowIndex)
    {
        int gap = matrix.GetLength(1) / 2;
        while (gap > 0)
        {
            for (int j = gap; j < matrix.GetLength(1); j++)
            {
                int key = matrix[rowIndex, j], c = j - gap;
                while (c >= 0 && matrix[rowIndex, c] > key)
                {
                    matrix[rowIndex, c + gap] = matrix[rowIndex, c];
                    c -= gap;
                }
                matrix[rowIndex, c + gap] = key;
            }
            gap /= 2;
        }
        return matrix;
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);
        SortNegative(A);
        SortNegative(B);
        // end
    }
    public static int[] SortNegative(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                int key = array[i], j = i - 1;
                while (j >= 0)
                {
                    if (key > array[j])
                    {
                        array[i] = array[j];
                        array[j] = key;
                        i = j;
                    }
                    j--;
                }
            }
        }
        return array;
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);
        SortDiagonal(A);
        SortDiagonal(B);
        // end
    }
    public static int[,] SortDiagonal(int[,] matrix)
    {
        int[] a = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            a[i] = matrix[i, i];
        }
        int gap = matrix.GetLength(0) / 2;
        while (gap > 0)
        {
            for (int i = gap; i < matrix.GetLength(0); i++)
            {
                int key = a[i], j = i - gap;
                while (j >= 0 && a[j] > key)
                {
                    a[j + gap] = a[j];
                    j -= gap;
                }
                a[j + gap] = key;
            }
            gap /= 2;
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
            matrix[i, i] = a[i];
        return matrix;
    }
    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10
        A = RemoveCountNull(A);
        B = RemoveCountNull(B);
        // end
    }
    public static int[,] RemoveCountNull(int[,] matrix)
    {
        for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, j] == 0)
                    count++;
            if (count == 0)
                matrix = RemoveColumn(matrix, j);
        }
        return matrix;
    }
    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
            rows[i] = CountNegativeInRow(matrix, i);
        for (int i = 0; i < matrix.GetLength(1); i++)
            cols[i] = FindMaxNegativePerColumn(matrix, i);
        // end
    }
    public static int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int c = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
            if (matrix[rowIndex, j] < 0)
                c++;
        return c;
    }
    public static int FindMaxNegativePerColumn(int[,] matrix, int columnIndex)
    {
        int mx = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] < 0)
                if (matrix[i, columnIndex] > mx || mx == 0)
                    mx = matrix[i, columnIndex];
        }
        return mx;
    }
    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);
        int a = 0, b = 0;
        FindMaxIndex(A, out a, out b);
        A = SwapColumnDiagonal(A, b);
        FindMaxIndex(B, out a, out b);
        B = SwapColumnDiagonal(B, b);
        // end
    }
    public static int FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        row = 0;
        column = 0;
        int mx = -1234567;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > mx)
                {
                    mx = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
        return column;
    }
    public static int[,] SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = temp;
        }
        return matrix;
    }
    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22
        int A_max = FindRowWithMaxNegativeCount(A), B_max = FindRowWithMaxNegativeCount(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[A_max, j];
                A[A_max, j] = B[B_max, j];
                B[B_max, j] = temp;
            }
        }
        // end
    }
    public static int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int max = -1234567, index_max = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (CountNegativeInRow(matrix, i) > max)
            {
                max = CountNegativeInRow(matrix, i);
                index_max = i;
            }
        }
        return index_max;
    }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        // end
    }
    public static int FindSequence(int[] array, int A, int B)
    {
        bool increasing = true;
        bool decreasing = true;
        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1])
                decreasing = false;
            if (array[i] > array[i + 1])
                increasing = false;
        }
        if (increasing) return 1;
        if (decreasing) return -1;
        else return 0;
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search
        answerFirst = FindSequence2(first, 0, first.Length - 1);
        answerSecond = FindSequence2(second, 0, second.Length - 1);
        // end
    }
    public static int[,] FindSequence2(int[] array, int A, int B)
    {
        int c = 0;
        for (int i = A; i < B; i++)
            for (int j = i + 1; j <= B; j++)
                if (FindSequence(array, i, j) != 0)
                    c++;
        int k = 0;
        int[,] array2 = new int[c, 2];
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    array2[k, 0] = i;
                    array2[k, 1] = j;
                    k++;
                }
            }
        }
        return array2;
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search
        int[,] first2 = FindSequence2(first, 0, first.Length - 1);
        int[,] second2 = FindSequence2(second, 0, second.Length - 1);
        answerFirst = FindSequence3(first2);
        answerSecond = FindSequence3(second2);
        // end
    }
    public static int[] FindSequence3(int[,] matrix)
    {
        int max = -1234567, index_max = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int length = Math.Abs(matrix[i, 0] - matrix[i, 1]);
            if (length > max)
            {
                max = length;
                index_max = i;
            }
        }
        int[] matrix2 = new int[2];
        matrix2[0] = matrix[index_max, 0];
        matrix2[1] = matrix[index_max, 1];
        return matrix2;
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0)
                sortStyle = SortAscending;
            else
                sortStyle = SortDescending;
            sortStyle(matrix, i);
        }
        // end
    }
    public delegate int[,] SortRowStyle(int[,] matrix, int rowIndex);
    public static int[,] SortAscending(int[,] matrix, int rowIndex)
    {
        for (int i = 1; i < matrix.GetLength(1); i++)
        {
            int key = matrix[rowIndex, i], j = i - 1;
            while (j >= 0 && matrix[rowIndex, j] > key)
            {
                matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                j--;
            }
            matrix[rowIndex, j + 1] = key;
        }
        return matrix;
    }
    public static int[,] SortDescending(int[,] matrix, int rowIndex)
    {
        for (int i = 1; i < matrix.GetLength(1); i++)
        {
            int key = matrix[rowIndex, i], j = i - 1;
            while (j >= 0 && matrix[rowIndex, j] < key)
            {
                matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                j--;
            }
            matrix[rowIndex, j + 1] = key;
        }
        return matrix;
    }
    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)
        GetTriange triangle;
        if (isUpperTriangle)
            triangle = GetUpperTriange;
        else
            triangle = GetLowerTriange;
        answer = GetSum(triangle, matrix);
        // end

        return answer;
    }
    public delegate int[] GetTriange(int[,] matrix);
    public static int[] GetUpperTriange(int[,] matrix)
    {
        int c = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = i; j < matrix.GetLength(1); j++)
                c++;
        int[] matrix2 = new int[c];
        int k = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                matrix2[k] = matrix[i, j] * matrix[i, j];
                k++;
            }
        return matrix2;
    }
    public static int[] GetLowerTriange(int[,] matrix)
    {
        int c = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = i; j < matrix.GetLength(1); j++)
                c++;
        int[] matrix2 = new int[c];
        int k = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j <= i; j++)
            {
                matrix2[k] = matrix[i, j] * matrix[i, j];
                k++;
            }
        return matrix2;
    }
    public static int GetSum(GetTriange array, int[,] matrix)
    {
        int sum = 0;
        int[] array2 = array(matrix);
        for (int i = 0; i < array2.Length; i++)
            sum += array2[i];
        return sum;
    }
        public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        FindElementDelegate r_d = FindDiagonalMaxIndex;
        FindElementDelegate d_d = FindalFirstRowMaxIndex;
        matrix = SwapColumns(matrix, r_d, d_d);
        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);
    public static int FindalFirstRowMaxIndex(int[,] matrix)
    {
        int max = -1234567;
        int j_max = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > max)
            {
                max = matrix[0, j];
                j_max = j;
            }
        }
        return j_max;
    }
    public static int[,] SwapColumns(int[,] matrix, FindElementDelegate diag, FindElementDelegate fr)
    {
        int index_d = diag(matrix);
        int index_f = fr(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int a = matrix[i, index_d];
            matrix[i, index_d] = matrix[i, index_f];
            matrix[i, index_f] = a;
        }
        return matrix;
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex searchArea = default(FindIndex);

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)
        searchArea = FindMaxBelowDiagonalIndex;
        FindIndex searchArea2 = default(FindIndex);
        searchArea2 = FindMinAboveDiagonalIndex;
        matrix = RemoveColumns(matrix, searchArea, searchArea2);
        // end
    }
    public delegate int FindIndex(int[,] matrix);
    public static int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int mx = -1234567, j_mx = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > mx)
                {
                    mx = matrix[i, j];
                    j_mx = j;
                }
            }
        }
        return j_mx;
    }
    public static int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int mn = 1234567, j_mn = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < mn)
                {
                    mn = matrix[i, j];
                    j_mn = j;
                }
            }
        }
        return j_mn;
    }
    public static int[,] RemoveColumns(int[,] matrix, FindIndex below, FindIndex above)
    {
        int beloww = below(matrix), abovee = above(matrix);
        if (beloww > abovee)
        {
            matrix = RemoveColumn(matrix, beloww);
            matrix = RemoveColumn(matrix, abovee);
        }
        else if (beloww < abovee)
        {
            matrix = RemoveColumn(matrix, abovee);
            matrix = RemoveColumn(matrix, beloww);
        }
        else
            matrix = RemoveColumn(matrix, beloww);
        return matrix;
    }
    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);
        GetNegativeArray searcherRows = GetNegativeCountPerRow;
        GetNegativeArray searcherCols = GetMaxNegativePerColumn;
        FindNegative(matrix, searcherRows, searcherCols, out rows, out cols);
        // end
    }
    public delegate int GetNegativeArray(int[,] matrix, int index);
    public static int GetNegativeCountPerRow(int[,] matrix, int index)
    {
        int c = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
            if (matrix[index, j] < 0)
                c++;
        return c;
    }
    public static int GetMaxNegativePerColumn(int[,] matrix, int index)
    {
        int max = -1234567;
        for (int i = 0; i < matrix.GetLength(0); i++)
            if (matrix[i, index] < 0 && matrix[i, index] > max)
                max = matrix[i, index];
        return max;
    }
    public static void FindNegative(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
            rows[i] = searcherRows(matrix, i);
        for (int i = 0; i < matrix.GetLength(1); i++)
            cols[i] = searcherCols(matrix, i);
    }
    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);
        IsSequence increasing = FindIncreasingSequence;
        IsSequence decreasing = FindDecreasingSequence;
        answerFirst = DefineSequence(first, increasing, decreasing);
        answerSecond = DefineSequence(second, increasing, decreasing);
        // end
    }
    public delegate bool IsSequence(int[] array, int left, int right);
    public static bool FindIncreasingSequence(int[] array, int A, int B)
    {
        bool increasing = true;
        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1])
                increasing = true;
            else
            {
                increasing = false;
                break;
            }
        }
        return increasing;
    }
    public static bool FindDecreasingSequence(int[] array, int A, int B)
    {
        bool decreasing = true;
        for (int i = A; i < B; i++)
        {
            if (array[i] > array[i + 1])
                decreasing = true;
            else
            {
                decreasing = false;
                break;
            }
        }
        return decreasing;
    }
    public static int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1)) return 1;
        else if (findDecreasingSequence(array, 0, array.Length - 1)) return -1;
        else return 0;
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);
        IsSequence increasing = FindIncreasingSequence;
        IsSequence decreasing = FindDecreasingSequence;
        answerFirstIncrease = FindLongestSequence(first, increasing);
        answerFirstDecrease = FindLongestSequence(first, decreasing);
        answerSecondIncrease = FindLongestSequence(second, increasing);
        answerSecondDecrease = FindLongestSequence(second, decreasing);
        // end
    }
    public static int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int[] array2 = new int[2];
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (sequence(array, i, j))
                {
                    if (j - i > array2[1] - array2[0])
                    {
                        array2[0] = i;
                        array2[1] = j;
                    }
                }
            }
        }
        return array2;
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
