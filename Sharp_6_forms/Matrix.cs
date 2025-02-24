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
                    matrix[i, j] = int.Parse(dgv.Rows[i].Cells[j].Value.ToString());
                }
            }
        }

        // Вывод матрицы в DataGridView
        public void MatrixToGrid(DataGridView dgv)
        {
            DataTable matr = new DataTable("matr");
            for (int i = 0; i < n_col; i++)
            {
                matr.Columns.Add(i.ToString(), typeof(int));
            }
            for (int i = 0; i < n_str; i++)
            {
                DataRow newRow = matr.NewRow();
                for (int j = 0; j < n_col; j++)
                {
                    newRow[j] = matrix[i, j];
                }
                matr.Rows.Add(newRow);
            }
            dgv.DataSource = matr;
            for (int i = 0; i < n_col; i++)
            {
                dgv.Columns[i].Width = 50;
            }
        }

        // Удаление строк с максимальной суммой
        public void RemoveRowsWithMaxSum()
        {
            int maxSum = int.MinValue;
            for (int i = 0; i < n_str; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < n_col; j++)
                {
                    rowSum += matrix[i, j];
                }
                if (rowSum > maxSum)
                {
                    maxSum = rowSum;
                }
            }

            int countRowsToRemove = 0;
            for (int i = 0; i < n_str; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < n_col; j++)
                {
                    rowSum += matrix[i, j];
                }
                if (rowSum == maxSum)
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
                    int rowSum = 0;
                    for (int j = 0; j < n_col; j++)
                    {
                        rowSum += matrix[i, j];
                    }
                    if (rowSum != maxSum)
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