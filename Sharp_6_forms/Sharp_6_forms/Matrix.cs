using System;
using System.Data;
using System.Windows.Forms;

namespace lab6._2
{
    class MatrMake
    {
        private int n_str, n_col; // Количество строк и столбцов
        private int[,] matrix;    // Матрица

        public MatrMake(int str_n, int col_n)
        {
            if (str_n <= 0 || col_n <= 0)
            {
                throw new ArgumentException("Размеры матрицы должны быть положительными числами.");
            }

            n_str = str_n;
            n_col = col_n;
            matrix = new int[str_n, col_n];
        }

        // Заполнение матрицы из DataGridView
        public void GridToMatrix(DataGridView dgv)
        {
            for (int i = 0; i < n_str; i++)
            {
                for (int j = 0; j < n_col; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null && int.TryParse(dgv.Rows[i].Cells[j].Value.ToString(), out int value))
                    {
                        matrix[i, j] = value;
                    }
                    else
                    {
                        matrix[i, j] = 0; // или другое значение по умолчанию
                    }
                }
            }
        }

        // Вывод матрицы в DataGridView
        public void MatrixToGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            for (int i = 0; i < n_col; i++)
            {
                dgv.Columns.Add(i.ToString(), i.ToString());
            }

            for (int i = 0; i < n_str; i++)
            {
                dgv.Rows.Add();
                for (int j = 0; j < n_col; j++)
                {
                    dgv.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }

            for (int i = 0; i < n_col; i++)
            {
                dgv.Columns[i].Width = 50;
            }
        }

        // Удаление строк с максимальной суммой
        public void RemoveRowsWithMaxSum()
        {
            int[] rowSums = new int[n_str];
            int maxSum = int.MinValue;

            // Вычисляем сумму для каждой строки и находим максимальную сумму
            for (int i = 0; i < n_str; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < n_col; j++)
                {
                    rowSum += matrix[i, j];
                }
                rowSums[i] = rowSum;
                if (rowSum > maxSum)
                {
                    maxSum = rowSum;
                }
            }

            // Подсчитываем количество строк для удаления
            int countRowsToRemove = 0;
            for (int i = 0; i < n_str; i++)
            {
                if (rowSums[i] == maxSum)
                {
                    countRowsToRemove++;
                }
            }

            if (countRowsToRemove > 0)
            {
                int[,] newMatrix = new int[n_str - countRowsToRemove, n_col];
                int newRowIndex = 0;
                for (int i = 0; i < n_str; i++)
                {
                    if (rowSums[i] != maxSum)
                    {
                        for (int j = 0; j < n_col; j++)
                        {
                            newMatrix[newRowIndex, j] = matrix[i, j];
                        }
                        newRowIndex++;
                    }
                }
                matrix = newMatrix;
                n_str = newRowIndex;
            }
        }

        // Получение количества строк
        public int GetStr()
        {
            return n_str;
        }

        // Получение количества столбцов
        public int GetCol()
        {
            return n_col;
        }
    }
}