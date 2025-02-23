//10.Óäàëèòü ñòðîêè, ñîäåðæàùèå âñå ðàâíûå ýëåìåíòû. 
using lab6._2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab6._2
{
    public partial class Form1 : Form
    {
        //private MatrMake matrMake;
        //private int[,] originalMatrix; //ïåðåìåííàÿ äëÿ õðàíåíèÿ èñõîäíîé ìàòðèöû
        int str_n, col_n;
        int size;
        int n_str_res;
        int n_col_res;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxSize_Enter(object sender, EventArgs e)
        {
            if (textBoxSize.Text == "Ðàçìåð ìàòðèöû")
            {
                textBoxSize.Text = "";
                textBoxSize.ForeColor = Color.Black; // Óñòàíîâèòå öâåò òåêñòà íà ÷åðíûé
            }
        }

        private void textBoxSize_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSize.Text))
            {
                textBoxSize.Text = "Ðàçìåð ìàòðèöû";
                textBoxSize.ForeColor = Color.Gray; // Óñòàíîâèòå öâåò òåêñòà íà ñåðûé
            }
        }
        //ñîçäàíèå ìàòðèöû ñ êëàâèàòóðû
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //óñòàíîâêà ðàçìåðà ìàòðèöû è DataGridView 
            int i;
            size = Int32.Parse(textBoxSize.Text);
            if (size > 0)
            {
                str_n = size;
                col_n = size;
                DataTable matr = new DataTable("matr");
                DataColumn[] cols = new DataColumn[size];
                for (i = 0; i < size; i++)
                {
                    cols[i] = new DataColumn(i.ToString());
                    matr.Columns.Add(cols[i]);
                }
                for (i = 0; i < size; i++)
                {
                    DataRow newRow;
                    newRow = matr.NewRow();
                    matr.Rows.Add(newRow);
                }
                dataGridViewInput.DataSource = matr;
                for (i = 0; i < size; i++)
                    dataGridViewInput.Columns[i].Width = 50;
            }
            else
            {
                MessageBox.Show("Ïîæàëóéñòà, ââåäèòå êîððåêòíûé ðàçìåð ìàòðèöû.");
            }
        }

        private void btnSaveOriginal_Click(object sender, EventArgs e)
        {
            if (dataGridViewInput.RowCount > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|C# Files (*.cs)|*.cs|All Files (*.*)|*.*";
                saveFileDialog.Title = "Ñîõðàíèòü èñõîäíóþ ìàòðèöó";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.Write(str_n.ToString() + " " + col_n.ToString() + "\n");
                        for (int i = 0; i < str_n; i++)
                        {
                            for (int j = 0; j < col_n; j++)
                            {
                                writer.Write(dataGridViewInput.Rows[i].Cells[j].Value.ToString());
                                if (j < col_n - 1)
                                    writer.Write("\t"); // Äîáàâëÿåì òàáóëÿöèþ ìåæäó çíà÷åíèÿìè
                            }
                            writer.WriteLine(); // Ïåðåõîä íà íîâóþ ñòðîêó ïîñëå êàæäîé ñòðîêè ìàòðèöû
                        }
                    }
                    MessageBox.Show("Èñõîäíàÿ ìàòðèöà ñîõðàíåíà.");
                }
            }
            else
            {
                MessageBox.Show("Ñíà÷àëà ñîçäàéòå ìàòðèöó.");
            }
        }
        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            if (dataGridViewResult.RowCount > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|C# Files (*.cs)|*.cs|All Files (*.*)|*.*";
                saveFileDialog.Title = "Ñîõðàíèòü ïîëó÷èâøóþñÿ ìàòðèöó";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.Write(n_str_res.ToString() + " " + n_col_res.ToString() + "\n");
                        for (int i = 0; i < n_str_res; i++)
                        {
                            for (int j = 0; j < n_col_res; j++)
                            {
                                writer.Write(dataGridViewResult.Rows[i].Cells[j].Value.ToString());
                                if (j < n_col_res - 1)
                                    writer.Write("\t"); // Äîáàâëÿåì òàáóëÿöèþ ìåæäó çíà÷åíèÿìè
                            }
                            writer.WriteLine(); // Ïåðåõîä íà íîâóþ ñòðîêó ïîñëå êàæäîé ñòðîêè ìàòðèöû
                        }
                    }
                    MessageBox.Show("Ïîëó÷èâøàÿñÿ ìàòðèöà ñîõðàíåíà.");
                }
            }
            else
            {
                MessageBox.Show("Ñíà÷àëà âûïîëíèòå çàäà÷ó.");
            }
        }
        //çàãðóçêà ìàòðèöû ñ ôàéëà
        private void btnLoadMatrix_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|C# Files (*.cs)|*.cs|All Files (*.*)|*.*";
            openFileDialog.Title = "Çàãðóçèòü ìàòðèöó";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName);

                string[] dimensions = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                str_n = Convert.ToInt32(dimensions[0]);
                col_n = Convert.ToInt32(dimensions[1]);

                DataTable matr = new DataTable("matr");
                DataColumn[] cols = new DataColumn[col_n];
                for (int i = 0; i < col_n; i++)
                {
                    cols[i] = new DataColumn(i.ToString());
                    matr.Columns.Add(cols[i]);
                }

                for (int i = 1; i <= str_n; i++)
                {
                    string[] values = lines[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    DataRow newRow = matr.NewRow();
                    for (int j = 0; j < col_n; j++)
                        newRow[j] = int.Parse(values[j]);
                    matr.Rows.Add(newRow);
                }

                dataGridViewInput.DataSource = matr;
                for (int i = 0; i < col_n; i++)
                    dataGridViewInput.Columns[i].Width = 50;
            }
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            dataGridViewResult.Visible = false;
            MatrMake mt = new MatrMake(str_n, col_n);
            mt.GridToMatrix(dataGridViewInput);

            string inputValue = Microsoft.VisualBasic.Interaction.InputBox("Ââåäèòå çíà÷åíèå äëÿ óäàëåíèÿ ñòîëáöîâ:", "Óäàëåíèå ñòîëáöîâ", "0");
            int valueToRemove;

            if (int.TryParse(inputValue, out valueToRemove))
            {
                mt.DelCol(valueToRemove);
                dataGridViewResult.Visible = true;

                n_str_res = mt.GetStr();
                n_col_res = mt.GetCol();

                mt.MatrixToGrid(dataGridViewResult);
            }
            else
            {
                MessageBox.Show("Ââåäèòå êîððåêòíîå öåëîå ÷èñëî.");
            }
        }



    }
}