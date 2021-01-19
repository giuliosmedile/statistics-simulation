namespace _Final_Simulation
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.compute = new System.Windows.Forms.Button();
            this.sigmaInput = new System.Windows.Forms.TextBox();
            this.mInput = new System.Windows.Forms.TextBox();
            this.nInput = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioBrownian = new System.Windows.Forms.RadioButton();
            this.radioPoisson = new System.Windows.Forms.RadioButton();
            this.radioGeometricBrownian = new System.Windows.Forms.RadioButton();
            this.radioVasicek = new System.Windows.Forms.RadioButton();
            this.lambdaInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.muInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.aInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.kInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.debugLabel = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1797, 1187);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Points (n)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(123, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Paths (m)";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.userLabel.Location = new System.Drawing.Point(235, 17);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(98, 20);
            this.userLabel.TabIndex = 10;
            this.userLabel.Text = "Deviation (σ)";
            // 
            // compute
            // 
            this.compute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compute.Location = new System.Drawing.Point(1681, 17);
            this.compute.Name = "compute";
            this.compute.Size = new System.Drawing.Size(128, 52);
            this.compute.TabIndex = 11;
            this.compute.Text = "Compute";
            this.compute.UseVisualStyleBackColor = true;
            this.compute.Click += new System.EventHandler(this.compute_Click);
            // 
            // sigmaInput
            // 
            this.sigmaInput.Location = new System.Drawing.Point(239, 39);
            this.sigmaInput.Name = "sigmaInput";
            this.sigmaInput.Size = new System.Drawing.Size(100, 26);
            this.sigmaInput.TabIndex = 12;
            // 
            // mInput
            // 
            this.mInput.Location = new System.Drawing.Point(127, 39);
            this.mInput.Name = "mInput";
            this.mInput.Size = new System.Drawing.Size(100, 26);
            this.mInput.TabIndex = 13;
            // 
            // nInput
            // 
            this.nInput.Location = new System.Drawing.Point(16, 39);
            this.nInput.Name = "nInput";
            this.nInput.Size = new System.Drawing.Size(100, 26);
            this.nInput.TabIndex = 14;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(943, 77);
            this.progressBar1.Maximum = 6;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(866, 30);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 17;
            // 
            // radioBrownian
            // 
            this.radioBrownian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBrownian.AutoSize = true;
            this.radioBrownian.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioBrownian.Location = new System.Drawing.Point(943, 43);
            this.radioBrownian.Name = "radioBrownian";
            this.radioBrownian.Size = new System.Drawing.Size(152, 24);
            this.radioBrownian.TabIndex = 18;
            this.radioBrownian.Text = "Brownian Motion";
            this.radioBrownian.UseVisualStyleBackColor = true;
            this.radioBrownian.CheckedChanged += new System.EventHandler(this.radioBrownian_CheckedChanged);
            // 
            // radioPoisson
            // 
            this.radioPoisson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPoisson.AutoSize = true;
            this.radioPoisson.Checked = true;
            this.radioPoisson.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioPoisson.Location = new System.Drawing.Point(943, 17);
            this.radioPoisson.Name = "radioPoisson";
            this.radioPoisson.Size = new System.Drawing.Size(141, 24);
            this.radioPoisson.TabIndex = 19;
            this.radioPoisson.TabStop = true;
            this.radioPoisson.Text = "Poisson Jumps";
            this.radioPoisson.UseVisualStyleBackColor = true;
            this.radioPoisson.CheckedChanged += new System.EventHandler(this.radioPoisson_CheckedChanged);
            // 
            // radioGeometricBrownian
            // 
            this.radioGeometricBrownian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGeometricBrownian.AutoSize = true;
            this.radioGeometricBrownian.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioGeometricBrownian.Location = new System.Drawing.Point(1101, 19);
            this.radioGeometricBrownian.Name = "radioGeometricBrownian";
            this.radioGeometricBrownian.Size = new System.Drawing.Size(230, 24);
            this.radioGeometricBrownian.TabIndex = 21;
            this.radioGeometricBrownian.Text = "Geometric Brownian Motion";
            this.radioGeometricBrownian.UseVisualStyleBackColor = true;
            this.radioGeometricBrownian.CheckedChanged += new System.EventHandler(this.radioGeometricBrownian_CheckedChanged);
            // 
            // radioVasicek
            // 
            this.radioVasicek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioVasicek.AutoSize = true;
            this.radioVasicek.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioVasicek.Location = new System.Drawing.Point(1101, 43);
            this.radioVasicek.Name = "radioVasicek";
            this.radioVasicek.Size = new System.Drawing.Size(162, 24);
            this.radioVasicek.TabIndex = 22;
            this.radioVasicek.Text = "Vasicek\'s Process";
            this.radioVasicek.UseVisualStyleBackColor = true;
            this.radioVasicek.CheckedChanged += new System.EventHandler(this.radioVasicek_CheckedChanged);
            // 
            // lambdaInput
            // 
            this.lambdaInput.Location = new System.Drawing.Point(380, 39);
            this.lambdaInput.Name = "lambdaInput";
            this.lambdaInput.Size = new System.Drawing.Size(100, 26);
            this.lambdaInput.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(376, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Probability (λ) [%]";
            // 
            // muInput
            // 
            this.muInput.Location = new System.Drawing.Point(514, 39);
            this.muInput.Name = "muInput";
            this.muInput.Size = new System.Drawing.Size(100, 26);
            this.muInput.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(510, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Mean (µ)";
            // 
            // startInput
            // 
            this.startInput.Location = new System.Drawing.Point(514, 99);
            this.startInput.Name = "startInput";
            this.startInput.Size = new System.Drawing.Size(100, 26);
            this.startInput.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(510, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Starting Point";
            // 
            // bInput
            // 
            this.bInput.Location = new System.Drawing.Point(380, 99);
            this.bInput.Name = "bInput";
            this.bInput.Size = new System.Drawing.Size(100, 26);
            this.bInput.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(376, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Target (b)";
            // 
            // aInput
            // 
            this.aInput.Location = new System.Drawing.Point(239, 99);
            this.aInput.Name = "aInput";
            this.aInput.Size = new System.Drawing.Size(100, 26);
            this.aInput.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(235, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Speed (a)";
            // 
            // kInput
            // 
            this.kInput.Location = new System.Drawing.Point(16, 99);
            this.kInput.Name = "kInput";
            this.kInput.Size = new System.Drawing.Size(100, 26);
            this.kInput.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(12, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "Number of Histograms";
            // 
            // debugLabel
            // 
            this.debugLabel.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugLabel.Location = new System.Drawing.Point(1337, 17);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(338, 54);
            this.debugLabel.TabIndex = 36;
            this.debugLabel.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1821, 1345);
            this.Controls.Add(this.debugLabel);
            this.Controls.Add(this.kInput);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.startInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.aInput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.muInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lambdaInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioVasicek);
            this.Controls.Add(this.radioGeometricBrownian);
            this.Controls.Add(this.radioPoisson);
            this.Controls.Add(this.radioBrownian);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.nInput);
            this.Controls.Add(this.mInput);
            this.Controls.Add(this.sigmaInput);
            this.Controls.Add(this.compute);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Brownian Motion";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button compute;
        private System.Windows.Forms.TextBox sigmaInput;
        private System.Windows.Forms.TextBox mInput;
        private System.Windows.Forms.TextBox nInput;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radioBrownian;
        private System.Windows.Forms.RadioButton radioPoisson;
        private System.Windows.Forms.RadioButton radioGeometricBrownian;
        private System.Windows.Forms.RadioButton radioVasicek;
        private System.Windows.Forms.TextBox lambdaInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox muInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox startInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox bInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox aInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox kInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox debugLabel;
    }
}

