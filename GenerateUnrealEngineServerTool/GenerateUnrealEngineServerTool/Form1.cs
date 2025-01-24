using Microsoft.VisualBasic.Logging;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace GenerateUnrealEngineServerTool
{
    public partial class Form1 : Form
    {
        private static string? uePath;
        private static string? projectPath;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            ResetPaths();
            SetInitialControlStates();
        }

        private void InitializeComboBox()
        {
            // ComboBox にバージョンを設定
            string[] versions = { "UE 4.26", "UE 4.27", "UE 5.0", "UE 5.1", "UE 5.2", "UE 5.3", "UE 5.4", "UE 5.5" };
            cmbueversion.Items.AddRange(versions);
            cmbueversion.SelectedIndex = 7;
        }

        private void ResetPaths()
        {
            // 値の初期化
            uePath = string.Empty;
            projectPath = string.Empty;
        }
        private void SetInitialControlStates()
        {
            // 初期状態ではカスタムパスは無効、プルダウンは有効
            cmbueversion.Enabled = true;
            ueEditorPathBox.Enabled = false;
            CustomEditorParhbutton.Enabled = false;
        }

        private void textBox_SelectCopyFile_TextChanged(object sender, EventArgs e)
        {
            projectPath = projectPathBox.Text;
        }

        private void textBox_SelectRootFile_TextChanged(object sender, EventArgs e)
        {
            uePath = ueEditorPathBox.Text;
        }

        private void button_ProjectPath_Click(object sender, EventArgs e)
        {
            projectPathBox.Text = SelectFile("Unreal Project|*.uproject");
        }

        private void button_CustomUEEditor_Click(object sender, EventArgs e)
        {
            ueEditorPathBox.Text = SelectFile("UEEditor|UE4Editor.exe;UnrealEditor.exe");
        }
        private string SelectFile(string filter)
        {
            using OpenFileDialog dialog = new OpenFileDialog 
            { 
                Filter = filter 
            };
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : string.Empty;
        }

        private void button_Execution_Click(object sender, EventArgs e)
        {
            // カスタムパスのチェックボックスによって、UEのパスを決定
            uePath = checkboxcustompath.Checked ? ueEditorPathBox.Text : GetUEPath(cmbueversion.Text);

            // パスの確認
            if (!ValidatePaths()) return;

            // プロセスの開始
            try
            {
                StartProcess(uePath, projectPath, "Game -server -game -log");
                ShowMessage("Server is Running.", "Success", MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}", "Error", MessageBoxIcon.Error);
            }

        }

        private void batbutton_Click(object sender, EventArgs e)
        {
            // カスタムパスのチェックボックスによって、UEのパスを決定
            uePath = checkboxcustompath.Checked ? ueEditorPathBox.Text : GetUEPath(cmbueversion.Text);

            // パスの確認
            if (!ValidatePaths()) return;

            // バッチファイルの設定
            string batFilePath = Path.Combine(Path.GetDirectoryName(projectPath), $"{Path.GetFileNameWithoutExtension(projectPath)}_RunServer.bat");
            string batContent = GenerateBatContent(uePath, projectPath);

            // バッチファイルがすでに存在する場合の処理
            if (File.Exists(batFilePath) && !ConfirmOverwrite()) return;

            try
            {
                File.WriteAllText(batFilePath, batContent);
                ShowMessage("Batch file has been generated.", "Success", MessageBoxIcon.Information);

                if (OpenBatFileCheckBox.Checked)
                {
                    OpenContainingFolder(batFilePath);
                }

                Process.Start(batFilePath);
            }
            catch (Exception ex)
            {
                ShowMessage($"Failed to generate the batch file: {ex.Message}", "Error", MessageBoxIcon.Error);
            }

        }
        private bool ValidatePaths()
        {
            if (string.IsNullOrWhiteSpace(uePath) || string.IsNullOrWhiteSpace(projectPath))
            {
                ShowMessage("The UE editor path or project path is empty.", "Error", MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists(uePath))
            {
                ShowMessage("The UE editor path is invalid.", "Error", MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists(projectPath))
            {
                ShowMessage("The project path is invalid.", "Error", MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void ShowMessage(string text, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, icon);
        }
        private void StartProcess(string filePath, string projectPath, string arguments)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = filePath,
                Arguments = $"\"{projectPath}\" {arguments}",
                UseShellExecute = true
            };
            Process.Start(processInfo);
        }
        private bool ConfirmOverwrite()
        {
            return MessageBox.Show("The batch file already exists. Do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }
        private void OpenContainingFolder(string filePath)
        {
            Process.Start("explorer.exe", Path.GetDirectoryName(filePath));
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            // ファイルが渡されていなければ、何もしない
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            // 渡されたファイルに対して処理を行う
            foreach (var LoadfilePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                ueEditorPathBox.Text = LoadfilePath;
            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void uePathBox_DragDrop(object sender, DragEventArgs e)
        {
            // ファイルが渡されていなければ、何もしない
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            // 渡されたファイルに対して処理を行う
            foreach (var LoadfilePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                ueEditorPathBox.Text = LoadfilePath;
            }
        }

        private void button4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            // ファイルが渡されていなければ、何もしない
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            // 渡されたファイルに対して処理を行う
            foreach (var LoadfilePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                uePath = LoadfilePath;
                ueEditorPathBox.Text = uePath;
            }
        }

        private void uePathBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void projectPathBox_DragDrop(object sender, DragEventArgs e)
        {
            // ファイルが渡されていなければ、何もしない
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            // 渡されたファイルに対して処理を行う
            foreach (var LoadfilePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                projectPath = LoadfilePath;
                projectPathBox.Text = projectPath;
            }
        }

        private void projectPathBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private string? GetUEPath(string ueVersion)
        {
            // バージョンごとのUEのパスを返す
            switch (ueVersion)
            {
                case "UE 4.26":
                    return "C:\\Program Files\\Epic Games\\UE_4.26\\Engine\\Binaries\\Win64\\UE4Editor.exe";
                case "UE 4.27":
                    return "C:\\Program Files\\Epic Games\\UE_4.27\\Engine\\Binaries\\Win64\\UE4Editor.exe";
                case "UE 5.0":
                    return "C:\\Program Files\\Epic Games\\UE_5.0\\Engine\\Binaries\\Win64\\UnrealEditor.exe";
                case "UE 5.1":
                    return "C:\\Program Files\\Epic Games\\UE_5.1\\Engine\\Binaries\\Win64\\UnrealEditor.exe";
                case "UE 5.2":
                    return "C:\\Program Files\\Epic Games\\UE_5.2\\Engine\\Binaries\\Win64\\UnrealEditor.exe";
                case "UE 5.3":
                    return "C:\\Program Files\\Epic Games\\UE_5.3\\Engine\\Binaries\\Win64\\UnrealEditor.exe";
                case "UE 5.4":
                    return "C:\\Program Files\\Epic Games\\UE_5.4\\Engine\\Binaries\\Win64\\UnrealEditor.exe";
                case "UE 5.5":
                    return "C:\\Program Files\\Epic Games\\UE_5.5\\Engine\\Binaries\\Win64\\UnrealEditor.exe";
                default:
                    return null;
            }
        }
        private void checkboxCustomPath_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxcustompath.Checked == true)
            {
                cmbueversion.Enabled = false;
                ueEditorPathBox.Enabled = true;
                CustomEditorParhbutton.Enabled = true;
            }
            else
            {
                cmbueversion.Enabled = true;
                ueEditorPathBox.Enabled = false;
                CustomEditorParhbutton.Enabled = false;
            }
        }

        private string GenerateBatContent(string editorPath, string projectPath)
        {
            string projectName = Path.GetFileNameWithoutExtension(projectPath);
            return $@"cd /d %~dp0
""{editorPath}"" ""{projectPath}"" Game -server -game -log";

        }
    }
}
