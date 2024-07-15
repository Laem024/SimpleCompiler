namespace SimpleCompiler
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
            txtSourceCode = new TextBox();
            txtTokens = new TextBox();
            txtIntermediateCode = new TextBox();
            btnCompile = new Button();
            txtSymbolTable = new TextBox();
            SuspendLayout();
            // 
            // txtSourceCode
            // 
            txtSourceCode.Location = new Point(12, 12);
            txtSourceCode.Multiline = true;
            txtSourceCode.Name = "txtSourceCode";
            txtSourceCode.Size = new Size(312, 426);
            txtSourceCode.TabIndex = 0;
            // 
            // txtTokens
            // 
            txtTokens.Location = new Point(330, 12);
            txtTokens.Multiline = true;
            txtTokens.Name = "txtTokens";
            txtTokens.Size = new Size(312, 154);
            txtTokens.TabIndex = 1;
            // 
            // txtIntermediateCode
            // 
            txtIntermediateCode.Location = new Point(648, 12);
            txtIntermediateCode.Multiline = true;
            txtIntermediateCode.Name = "txtIntermediateCode";
            txtIntermediateCode.Size = new Size(312, 426);
            txtIntermediateCode.TabIndex = 2;
            // 
            // btnCompile
            // 
            btnCompile.Location = new Point(400, 219);
            btnCompile.Name = "btnCompile";
            btnCompile.Size = new Size(171, 23);
            btnCompile.TabIndex = 3;
            btnCompile.Text = "Compilar";
            btnCompile.UseVisualStyleBackColor = true;
            btnCompile.Click += btnCompile_Click;
            // 
            // txtSymbolTable
            // 
            txtSymbolTable.Location = new Point(330, 284);
            txtSymbolTable.Multiline = true;
            txtSymbolTable.Name = "txtSymbolTable";
            txtSymbolTable.Size = new Size(312, 154);
            txtSymbolTable.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 450);
            Controls.Add(txtSymbolTable);
            Controls.Add(btnCompile);
            Controls.Add(txtIntermediateCode);
            Controls.Add(txtTokens);
            Controls.Add(txtSourceCode);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSourceCode;
        private TextBox txtTokens;
        private TextBox txtIntermediateCode;
        private Button btnCompile;
        private TextBox txtSymbolTable;
    }
}
