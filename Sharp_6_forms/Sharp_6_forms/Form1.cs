using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace lab6._2
{
    public partial class Form1 : Form
    {
        // Переменные для хранения размеров матрицы
        private int str_n;     // Количество строк
        private int col_n;     // Количество столбцов
        private int n_str_res; // Количество строк в результирующей матрице
        private int n_col_res; // Количество столбцов в результирующей матрице

        public Form1()
        {
            InitializeComponent();

            // Подключаем обработчики событий
            btnCreate.Click += btnCreate_Click;
            btnLoadMatrix.Click += btnLoadMatrix_Click;
            btnTask.Click += btnTask_Click;
            btnSaveOriginal.Click += btnSaveOriginal_Click;
            btnSaveResult.Click += btnSaveResult_Click;
        }

        // Обработчик для создания матрицы
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSize.Text, out int size) && size > 0)
            {
                // Устанавливаем размеры матрицы
                str_n = size;
                col_n = size;

                // Очищаем DataGridView и добавляем столбцы
                dataGridViewInput.Rows.Clear();
                dataGridViewInput.Columns.Clear();

                for (int i = 0; i < size; i++)
                {
                    dataGridViewInput.Columns.Add(i.ToString(), i.ToString());
                }

                // Добавляем строки
                for (int i = 0; i < size; i++)
                {
                    dataGridViewInput.Rows.Add();
                }

                // Устанавливаем ширину столбцов
                for (int i = 0; i < size; i++)
                {
                    dataGridViewInput.Columns[i].Width = 50;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректный размер матрицы.");
            }
        }

        // Обработчик для загрузки матрицы из файла
        private void btnLoadMatrix_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "Загрузить матрицу";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);

                    // Чтение размеров матрицы
                    string[] dimensions = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    str_n = int.Parse(dimensions[0]);
                    col_n = int.Parse(dimensions[1]);

                    // Создание DataTable для отображения в DataGridView
                    DataTable matr = new DataTable("matr");
                    for (int i = 0; i < col_n; i++)
                    {
                        matr.Columns.Add(i.ToString(), typeof(int));
                    }

                    // Заполнение DataTable данными из файла
                    for (int i = 1; i <= str_n; i++)
                    {
                        string[] values = lines[i].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        DataRow newRow = matr.NewRow();
                        for (int j = 0; j < col_n; j++)
                        {
                            newRow[j] = int.Parse(values[j]);
                        }
                        matr.Rows.Add(newRow);
                    }

                    // Привязываем DataTable к DataGridView
                    dataGridViewInput.DataSource = matr;
                    for (int i = 0; i < col_n; i++)
                    {
                        dataGridViewInput.Columns[i].Width = 50;
                    }
                }
            }
        }

        // Обработчик для выполнения задачи (удаление строк с максимальной суммой)
        private void btnTask_Click(object sender, EventArgs e)
        {
            if (dataGridViewInput.RowCount > 0)
            {
                MatrMake mt = new MatrMake(str_n, col_n);
                mt.GridToMatrix(dataGridViewInput);

                // Удаление строк с максимальной суммой
                mt.RemoveRowsWithMaxSum();

                // Отображение результата
                n_str_res = mt.GetStr();
                n_col_res = mt.GetCol();
                mt.MatrixToGrid(dataGridViewResult);

                dataGridViewResult.Visible = true;
            }
            else
            {
                MessageBox.Show("Сначала создайте или загрузите матрицу.");
            }
        }

        // Обработчик для сохранения исходной матрицы
        private void btnSaveOriginal_Click(object sender, EventArgs e)
        {
            SaveMatrix(dataGridViewInput, "Сохранить исходную матрицу");
        }

        // Обработчик для сохранения результирующей матрицы
        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            SaveMatrix(dataGridViewResult, "Сохранить результирующую матрицу");
        }

        // Метод для сохранения матрицы в файл
        private void SaveMatrix(DataGridView dgv, string title)
        {
            if (dgv.RowCount > 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    saveFileDialog.Title = title;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            writer.WriteLine($"{dgv.RowCount} {dgv.ColumnCount}");
                            for (int i = 0; i < dgv.RowCount; i++)
                            {
                                for (int j = 0; j < dgv.ColumnCount; j++)
                                {
                                    writer.Write(dgv.Rows[i].Cells[j].Value);
                                    if (j < dgv.ColumnCount - 1)
                                        writer.Write("\t");
                                }
                                writer.WriteLine();
                            }
                        }
                        MessageBox.Show("Матрица сохранена.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет данных для сохранения.");
            }
        }
    }
}