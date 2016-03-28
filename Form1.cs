using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;

namespace tba2csv
{
    public partial class Form1 : Form
    {
        protected List<string> columnList;
        public Form1()
        {
            InitializeComponent();
        }

        const string tbaheader = "frc5818:tba2csv:1.00";
        const string tbawebsite = "https://www.thebluealliance.com";

        Match match = new Match();

        protected string TBA_RequestJson(string request)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", tbaheader);
            string url = tbawebsite + request;
            string downloadedData = null;
            try
            {
                downloadedData = wc.DownloadString(url);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEPTION: " + url + ":" + ex.ToString());
            }
            return downloadedData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string eventtcode = "2016cave";
            string team = "frc5818";
            string reqevent = "/api/v2/event/" + eventtcode + "/matches";
            string reqteam = "/api/v2/team/" + team + "/event/" + eventtcode + "/matches";
            comboURL.Items.Add(reqevent);
            comboURL.Items.Add(reqteam);
            comboURL.Text = reqevent;
            int cols = match.headers.Length;

            dgvValues.Columns.Clear();
            for (int col = 0; col < cols; ++col)
            {
                string label = match.headers[col];
                dgvValues.Columns.Add(label, label);
            }
        }

        // Read the JSON data from the server.
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string jsonString = TBA_RequestJson(comboURL.Text);
            if (jsonString != null)
            {
                dgvValues.Rows.Clear();
                columnList = new List<string>();
                Match[] matches;
                int rows = match.ParseJson(jsonString, out matches);
                int cols = match.headers.Length;

                for (int row = 0; row < rows; ++row)
                {
                    string[] values;
                    dgvValues.Rows.Add();
                    values = matches[row].blue.ToStrings();
                    for (int col = 0; col < cols; ++col)
                    {
                        dgvValues.Rows[row*2].Cells[col].Value = values[col];
                    }
                    dgvValues.Rows.Add();
                    values = matches[row].red.ToStrings();
                    for (int col = 0; col < cols; ++col)
                    {
                        dgvValues.Rows[row*2 + 1].Cells[col].Value = values[col];
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string pathname = txtFile.Text;
            if (pathname.Length == 0)
            {
                FileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.DefaultExt = ".csv";
                dlg.Filter = "Comma Separated Values|*.csv|Text Files|*.txt|All Files|*.*";

                DialogResult result = dlg.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                pathname = dlg.FileName;
                txtFile.Text = pathname;
            }
			
            int rows = dgvValues.Rows.Count;
            int cols = dgvValues.Columns.Count;
            
            StreamWriter file = new StreamWriter(pathname);
            string header = "";
            for (int c = 0; c < cols; ++c)
            {
                if (c != 0)
                    header += ',';
                header += dgvValues.Columns[c].Name;
            }
            file.WriteLine(header);

            for (int r = 0; r < rows; ++r)
            {
                string line = "";
                for (int c = 0; c < cols; ++c)
                {
                    String str = dgvValues.Rows[r].Cells[c].Value.ToString();
                    // Escape dquotes in str
                    str = str.Replace("\"", "\"\"");
                    // Quote if str contains a comma
                    if (str.Contains(","))
                        str = '"' + str + '"';
                    if (c != 0)
                        line += ',' + str;
                    else
                        line = str;
                }
                file.WriteLine(line);
            }
            file.Close();
        }
    }
}
    