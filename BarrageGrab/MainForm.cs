using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BarrageGrab
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }
        static WsBarrageService server = null;


        private void MainForm_Load(object sender, EventArgs e)
        {
            server = new WsBarrageService();

            server.onWsStartListen += onWsStartListen;
            server.onTextBoxPrintDanMuData += onTextBoxPrintDanMuData;

            server.StartListen();

        }

        List<string> textBoxDanMuDataList = new List<string>();
        private void onTextBoxPrintDanMuData(Color color, string content)
        {
            try
            {
                if (this.danmuTextBox.Lines.Length > 1000)
                {
                    this.danmuTextBox.Clear();
                }

                this.danmuTextBox.SelectionColor = color;
                this.danmuTextBox.AppendText($"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss ")}" + content);
                this.danmuTextBox.AppendText(Environment.NewLine);

                this.danmuTextBox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:" + ex.ToString());
                throw;
            }

            log4netHelper.Info(content);
        }

        private void onWsStartListen(string obj)
        {
            this.serverLocationLbl.Text = "[" + obj + "]";
        }

        private void onMainFormClosed(object sender, FormClosedEventArgs e)
        {
            server.Close();
        }


    }
}
