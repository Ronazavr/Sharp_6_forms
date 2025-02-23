using System.Drawing;
using System.Windows.Forms;

namespace lab6._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnLoadMatrix = new System.Windows.Forms.Button();
            this.btnTask = new System.Windows.Forms.Button();
            this.btnSaveOriginal = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxSize
            // 
            this.textBoxSize.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSize.Location = new System.Drawing.Point(15, 11);
            this.textBoxSize.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSize.Multiline = true;
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(109, 34);
            this.textBoxSize.TabIndex = 0;
            this.textBoxSize.Text = "Размер матрицы";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(150, 11);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(69, 34);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnLoadMatrix
            // 
            this.btnLoadMatrix.Location = new System.Drawing.Point(245, 11);
            this.btnLoadMatrix.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadMatrix.Name = "btnLoadMatrix";
            this.btnLoadMatrix.Size = new System.Drawing.Size(132, 34);
            this.btnLoadMatrix.TabIndex = 2;
            this.btnLoadMatrix.Text = "Загрузить матрицу";
            this.btnLoadMatrix.UseVisualStyleBackColor = true;
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(398, 11);
            this.btnTask.Margin = new System.Windows.Forms.Padding(2);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(167, 34);
            this.btnTask.TabIndex = 3;
            this.btnTask.Text = "Удалить столбцы, с заданным значением";
            this.btnTask.UseVisualStyleBackColor = true;
            // 
            // btnSaveOriginal
            // 
            this.btnSaveOriginal.Location = new System.Drawing.Point(62, 68);
            this.btnSaveOriginal.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveOriginal.Name = "btnSaveOriginal";
            this.btnSaveOriginal.Size = new System.Drawing.Size(121, 22);
            this.btnSaveOriginal.TabIndex = 4;
            this.btnSaveOriginal.Text = "Сохранить исходную";
            this.btnSaveOriginal.UseVisualStyleBackColor = true;
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Location = new System.Drawing.Point(435, 68);
            this.btnSaveResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(115, 22);
            this.btnSaveResult.TabIndex = 5;
            this.btnSaveResult.Text = "Сохранить";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Location = new System.Drawing.Point(15, 94);
            this.dataGridViewInput.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.RowHeadersWidth = 62;
            this.dataGridViewInput.Size = new System.Drawing.Size(323, 168);
            this.dataGridViewInput.TabIndex = 6;
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(398, 94);
            this.dataGridViewResult.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.RowHeadersWidth = 62;
            this.dataGridViewResult.Size = new System.Drawing.Size(327, 168);
            this.dataGridViewResult.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 283);
            this.Controls.Add(this.dataGridViewResult);
            this.Controls.Add(this.dataGridViewInput);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.btnSaveOriginal);
            this.Controls.Add(this.btnTask);
            this.Controls.Add(this.btnLoadMatrix);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.textBoxSize);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Matrix Manipulation";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBoxSize;
        private Button btnCreate;
        private Button btnLoadMatrix;
        private Button btnTask;
        private Button btnSaveOriginal;
        private Button btnSaveResult;
        private DataGridView dataGridViewInput;
        private DataGridView dataGridViewResult;
    }
}