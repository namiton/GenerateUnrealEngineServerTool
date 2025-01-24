namespace GenerateUnrealEngineServerTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button2 = new Button();
            label2 = new Label();
            projectPathBox = new TextBox();
            onlyRun = new Button();
            ueEditorPathBox = new TextBox();
            label3 = new Label();
            CustomEditorParhbutton = new Button();
            OpenBatFileCheckBox = new CheckBox();
            batbutton = new Button();
            cmbueversion = new ComboBox();
            checkboxcustompath = new CheckBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(697, 194);
            button2.Name = "button2";
            button2.Size = new Size(58, 29);
            button2.TabIndex = 1;
            button2.Text = "Select";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button_ProjectPath_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 173);
            label2.Name = "label2";
            label2.Size = new Size(165, 20);
            label2.TabIndex = 3;
            label2.Text = "Select Project .uproject ";
            // 
            // projectPathBox
            // 
            projectPathBox.AllowDrop = true;
            projectPathBox.Location = new Point(34, 196);
            projectPathBox.Name = "projectPathBox";
            projectPathBox.ScrollBars = ScrollBars.Horizontal;
            projectPathBox.Size = new Size(657, 27);
            projectPathBox.TabIndex = 5;
            projectPathBox.TextChanged += textBox_SelectCopyFile_TextChanged;
            projectPathBox.DragDrop += projectPathBox_DragDrop;
            projectPathBox.DragEnter += projectPathBox_DragEnter;
            // 
            // onlyRun
            // 
            onlyRun.Location = new Point(552, 269);
            onlyRun.Name = "onlyRun";
            onlyRun.Size = new Size(203, 33);
            onlyRun.TabIndex = 6;
            onlyRun.Text = "Run Only";
            onlyRun.UseVisualStyleBackColor = true;
            onlyRun.Click += button_Execution_Click;
            // 
            // uepathbox
            // 
            ueEditorPathBox.AllowDrop = true;
            ueEditorPathBox.Location = new Point(34, 117);
            ueEditorPathBox.Name = "uepathbox";
            ueEditorPathBox.ScrollBars = ScrollBars.Horizontal;
            ueEditorPathBox.Size = new Size(657, 27);
            ueEditorPathBox.TabIndex = 9;
            ueEditorPathBox.TextChanged += textBox_SelectRootFile_TextChanged;
            ueEditorPathBox.DragDrop += uePathBox_DragDrop;
            ueEditorPathBox.DragEnter += button4_DragEnter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 9F);
            label3.Location = new Point(34, 27);
            label3.Name = "label3";
            label3.Size = new Size(174, 20);
            label3.TabIndex = 8;
            label3.Text = "UnrealEngine Editor Path";
            // 
            // CustomEditorParhbutton
            // 
            CustomEditorParhbutton.Font = new Font("Yu Gothic UI", 9F);
            CustomEditorParhbutton.Location = new Point(697, 115);
            CustomEditorParhbutton.Name = "CustomEditorParhbutton";
            CustomEditorParhbutton.Size = new Size(58, 29);
            CustomEditorParhbutton.TabIndex = 7;
            CustomEditorParhbutton.Text = "Select";
            CustomEditorParhbutton.UseVisualStyleBackColor = true;
            CustomEditorParhbutton.Click += button_CustomUEEditor_Click;
            // 
            // OpenBatFileCheckBox
            // 
            OpenBatFileCheckBox.AutoSize = true;
            OpenBatFileCheckBox.Location = new Point(294, 313);
            OpenBatFileCheckBox.Name = "OpenBatFileCheckBox";
            OpenBatFileCheckBox.Size = new Size(252, 24);
            OpenBatFileCheckBox.TabIndex = 10;
            OpenBatFileCheckBox.Text = "Open the bat folder upon success";
            OpenBatFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // batbutton
            // 
            batbutton.Location = new Point(552, 308);
            batbutton.Name = "batbutton";
            batbutton.Size = new Size(203, 33);
            batbutton.TabIndex = 11;
            batbutton.Text = "Generate .bat and Run";
            batbutton.UseVisualStyleBackColor = true;
            batbutton.Click += batbutton_Click;
            // 
            // cmbueversion
            // 
            cmbueversion.FormattingEnabled = true;
            cmbueversion.Location = new Point(34, 50);
            cmbueversion.Name = "cmbueversion";
            cmbueversion.Size = new Size(151, 28);
            cmbueversion.TabIndex = 12;
            // 
            // checkboxcustompath
            // 
            checkboxcustompath.AutoSize = true;
            checkboxcustompath.Location = new Point(34, 87);
            checkboxcustompath.Name = "checkboxcustompath";
            checkboxcustompath.Size = new Size(186, 24);
            checkboxcustompath.TabIndex = 13;
            checkboxcustompath.Text = "Use Custom Editor Path";
            checkboxcustompath.UseVisualStyleBackColor = true;
            checkboxcustompath.CheckedChanged += checkboxCustomPath_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 353);
            Controls.Add(checkboxcustompath);
            Controls.Add(cmbueversion);
            Controls.Add(batbutton);
            Controls.Add(OpenBatFileCheckBox);
            Controls.Add(ueEditorPathBox);
            Controls.Add(label3);
            Controls.Add(CustomEditorParhbutton);
            Controls.Add(onlyRun);
            Controls.Add(projectPathBox);
            Controls.Add(label2);
            Controls.Add(button2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(800, 400);
            MinimumSize = new Size(800, 400);
            Name = "Form1";
            Text = "Generate Dedicated Server Run Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Label label2;
        private TextBox projectPathBox;
        private Button onlyRun;
        private TextBox ueEditorPathBox;
        private Label label3;
        private Button CustomEditorParhbutton;
        private CheckBox OpenBatFileCheckBox;
        private Button batbutton;
        private ComboBox cmbueversion;
        private CheckBox checkboxcustompath;
    }
}
