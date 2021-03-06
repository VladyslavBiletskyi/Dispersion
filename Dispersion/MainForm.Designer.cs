﻿namespace Dispersion
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.experimentDataGridView = new System.Windows.Forms.DataGridView();
            this.groupValuesGridView = new System.Windows.Forms.DataGridView();
            this.experimentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.calculateButton = new System.Windows.Forms.Button();
            this.dispersionResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.experimentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupValuesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.experimentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // experimentDataGridView
            // 
            this.experimentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.experimentDataGridView.Location = new System.Drawing.Point(13, 13);
            this.experimentDataGridView.Name = "experimentDataGridView";
            this.experimentDataGridView.Size = new System.Drawing.Size(710, 345);
            this.experimentDataGridView.TabIndex = 0;
            this.experimentDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.experimentDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridView1_RowsAdded);
            // 
            // groupValuesGridView
            // 
            this.groupValuesGridView.AllowUserToAddRows = false;
            this.groupValuesGridView.AllowUserToDeleteRows = false;
            this.groupValuesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupValuesGridView.Location = new System.Drawing.Point(13, 379);
            this.groupValuesGridView.Name = "groupValuesGridView";
            this.groupValuesGridView.ReadOnly = true;
            this.groupValuesGridView.Size = new System.Drawing.Size(710, 60);
            this.groupValuesGridView.TabIndex = 1;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(13, 457);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 2;
            this.calculateButton.Text = "Calculate dispersion";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // dispersionResult
            // 
            this.dispersionResult.AutoSize = true;
            this.dispersionResult.Location = new System.Drawing.Point(106, 457);
            this.dispersionResult.Name = "dispersionResult";
            this.dispersionResult.Size = new System.Drawing.Size(0, 13);
            this.dispersionResult.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 501);
            this.Controls.Add(this.dispersionResult);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.groupValuesGridView);
            this.Controls.Add(this.experimentDataGridView);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.experimentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupValuesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.experimentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView experimentDataGridView;
        private System.Windows.Forms.BindingSource experimentBindingSource;
        private System.Windows.Forms.DataGridView groupValuesGridView;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label dispersionResult;
    }
}

