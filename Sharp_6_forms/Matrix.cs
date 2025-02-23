using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6._2
{
    class MatrMake
    {
        int n_str,     //количество строк 
            n_col;     //количество столбцов 
        int[,] matrix; // обрабатываемая матрица
        public MatrMake(int str_n, int col_n)
        {
            n_str = str_n;
            n_col = col_n;
            matrix = new int[str_n, col_n];
        }
        //матрица из DataGridView 
        public void GridToMatrix(DataGridView dgv)
        {
            DataGridViewCell txtCell;
            for (int i = 0; i < n_str; i++)
            {
                for (int j = 0; j < n_col; j++)
                {
                    txtCell = dgv.Rows[i].Cells[j];
                    string s = txtCell.Value.ToString();
                    if (s == "")
                        matrix[i, j] = 0;
                    else
                        matrix[i, j] = Int32.Parse(s);
                }
            }
        }
        //вывод матрицы в DataGridView 
        public void MatrixToGrid(DataGridView dgv)
        {
            //установка размеров 
            int i;
            DataTable matr = new DataTable("matr");
            DataColumn[] cols = new DataColumn[n_col];
            for (i = 0; i < n_col; i++)
            {
                cols[i] = new DataColumn(i.ToString());
                matr.Columns.Add(cols[i]);
            }
            for (i = 0; i < n_str; i++)
            {
                DataRow newRow;
                newRow = matr.NewRow();
                matr.Rows.Add(newRow);
            }
            dgv.DataSource = matr;
            for (i = 0; i < n_col; i++)
                dgv.Columns[i].Width = 50;
            //занесение значений
            DataGridViewCell txtCell;
            for (i = 0; i < n_str; i++)
            {
                for (int j = 0; j < n_col; j++)
                {
                    txtCell = dgv.Rows[i].Cells[j];
                    txtCell.Value = matrix[i, j].ToString();
                }
            }
        }
        public void RemoveRowsWithMaxSum()
        {
            // Находим максимальную сумму среди строк
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

            // Считаем количество строк с максимальной суммой
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

            // Если есть строки для удаления
            if (countRowsToRemove > 0)
            {
                // Создаем массив для хранения индексов строк, которые нужно удалить
                int[] rowsToRemove = new int[countRowsToRemove];
                int index = 0;

                // Заполняем массив индексами строк для удаления
                for (int i = 0; i < n_str; i++)
                {
                    int rowSum = 0;
                    for (int j = 0; j < n_col; j++)
                    {
                        rowSum += matrix[i, j];
                    }
                    if (rowSum == maxSum)
                    {
                        rowsToRemove[index] = i;
                        index++;
                    }
                }

                // Создаем новую матрицу без удаленных строк
                int newRowCount = n_str - countRowsToRemove;
                int[,] newMatrix = new int[newRowCount, n_col];

                int newRowIndex = 0;
                for (int i = 0; i < n_str; i++)
                {
                    bool shouldRemove = false;
                    for (int k = 0; k < countRowsToRemove; k++)
                    {
                        if (i == rowsToRemove[k])
                        {
                            shouldRemove = true;
                            break;
                        }
                    }

                    if (!shouldRemove)
                    {
                        for (int j = 0; j < n_col; j++)
                        {
                            newMatrix[newRowIndex, j] = matrix[i, j];
                        }
                        newRowIndex++;
                    }
                }

                // Обновляем матрицу и количество строк
                matrix = newMatrix;
                n_str = newRowCount;
            }
        }
    }
}
