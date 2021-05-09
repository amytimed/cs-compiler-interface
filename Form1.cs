using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CS_Compiler_Interface
{
    public partial class Form1 : Form
    {
        static string output = "";
        static string prev = "";
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 2)
            {
                prev = args[1];
                textBox1.Text = "Processing...";
                output = "";
                var startInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    WorkingDirectory = Path.GetDirectoryName(args[1]),
                    FileName = "powershell.exe",
                    Arguments = "\"C:\\Windows\\Microsoft.NET\\Framework64\\v3.5\\csc.exe\" \"\\\"" + args[1] + "\\\"\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                System.Diagnostics.Process a = System.Diagnostics.Process.Start(startInfo);
                a.OutputDataReceived += new DataReceivedEventHandler((object thesender, DataReceivedEventArgs ee) =>
                {
                    // Prepend line numbers to each line of the output.
                    if (!String.IsNullOrEmpty(ee.Data))
                    {
                        output += ee.Data + Environment.NewLine;
                        // output.Append("\n[" + lineCount + "]: " + e.Data);
                    }
                });
                a.BeginOutputReadLine();
                a.WaitForExit();
                textBox1.Text = output;
                MessageBox.Show("Finished building 1 file.", "Finished building", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!checkBox1.Checked)
                {
                    Process.Start(Path.GetDirectoryName(args[1]));
                }
                else
                {
                    Process.Start(Path.Combine(Path.GetDirectoryName(args[1]), Path.GetFileNameWithoutExtension(args[1]) + ".exe"));
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void textBox1_Enter(object sender, EventArgs e)
        {
            ActiveControl = label1;
        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                prev = file;
                textBox1.Text = "Processing...";
                output = "";
                var startInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    WorkingDirectory = Path.GetDirectoryName(file),
                    FileName = "powershell.exe",
                    Arguments = "\"C:\\Windows\\Microsoft.NET\\Framework64\\v3.5\\csc.exe\" \"\\\"" + file + "\\\"\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
            };
                System.Diagnostics.Process a = System.Diagnostics.Process.Start(startInfo);
                a.OutputDataReceived += new DataReceivedEventHandler((object thesender, DataReceivedEventArgs ee) =>
                {
                    // Prepend line numbers to each line of the output.
                    if (!String.IsNullOrEmpty(ee.Data))
                    {
                        output += ee.Data + Environment.NewLine;
                       // output.Append("\n[" + lineCount + "]: " + e.Data);
                    }
                });
                a.BeginOutputReadLine();
                a.WaitForExit();
                textBox1.Text = output;
                MessageBox.Show("Finished building 1 file.", "Finished building", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!checkBox1.Checked)
                {
                    Process.Start(Path.GetDirectoryName(file));
                }
                else
                {
                    Process.Start(Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + ".exe"));
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(prev != "")
            {
                textBox1.Text = "Processing...";
                output = "";
                var startInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    WorkingDirectory = Path.GetDirectoryName(prev),
                    FileName = "powershell.exe",
                    Arguments = "\"C:\\Windows\\Microsoft.NET\\Framework64\\v3.5\\csc.exe\" \"\\\"" + prev + "\\\"\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                System.Diagnostics.Process a = System.Diagnostics.Process.Start(startInfo);
                a.OutputDataReceived += new DataReceivedEventHandler((object thesender, DataReceivedEventArgs ee) =>
                {
                    // Prepend line numbers to each line of the output.
                    if (!String.IsNullOrEmpty(ee.Data))
                    {
                        output += ee.Data + Environment.NewLine;
                        // output.Append("\n[" + lineCount + "]: " + e.Data);
                    }
                });
                a.BeginOutputReadLine();
                a.WaitForExit();
                textBox1.Text = output;
                MessageBox.Show("Finished building 1 file.", "Finished building", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(!checkBox1.Checked)
                {
                    Process.Start(Path.GetDirectoryName(prev));
                }
                else
                {
                    Process.Start(Path.Combine(Path.GetDirectoryName(prev), Path.GetFileNameWithoutExtension(prev) + ".exe"));
                }
            }
            
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
