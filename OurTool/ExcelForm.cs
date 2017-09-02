using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurCRMTool
{
    public partial class ExcelForm : Form
    {
        List<DataTable> dtList = new List<DataTable>();
        string header;
        BackgroundWorker worker = new BackgroundWorker();
        LoadingForm1 l;
        ExcelHelper excel;
        string fileName;
        string sugestedFileName;
        Dictionary<string, object> keyCharDic;
        bool open = false;
        bool save = false;
        LogUtils log;

        public ExcelForm(List<DataTable> _dtList, string _sugestedFileName, string _header = null, Dictionary<string, object> _keyCharDic = null)
        {
            InitializeComponent();
            dtList = _dtList;
            header = _header;
            keyCharDic = _keyCharDic;
            sugestedFileName = _sugestedFileName;
            log = new LogUtils();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerSupportsCancellation = true;
            l = new LoadingForm1("Generating Excel, Please wait");
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            excel.createExcel(dtList, fileName, open && !save, header, keyCharDic);  //if open and save, will open after generated.
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                l.Close();
                if (e.Error == null)
                {
                    if (save)
                    {
                        excel.saveExcel(fileName);
                    }
                    if (open && save && fileName != string.Empty)
                    {
                        System.Diagnostics.Process.Start(fileName);
                    }
                    if (!open)
                    {
                        MessageBox.Show("Excel ready");
                    }
                    this.Close();
                }
                else
                {
                    log.HandleException(e.Error, 0, "Error creating Excel");
                }
            }
            catch (Exception ex)
            {
                log.HandleException(ex, 0, " in RunWorkerCompleted in ExcelForm");
            }
            finally
            {
                excel.ReleseExcel();
            }
        }

        private void DoExcel()
        {
            fileName = string.Empty;
            excel = new ExcelHelper();
            bool createExcel = false;
            if (save == true)
            {
                saveFileDialog1.Filter = "Excel |*.xlsx";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.FileName = sugestedFileName;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.OverwritePrompt = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    createExcel = true;
                }
            }
            else
            {
                createExcel = true;
            }

            if (createExcel)
            {
                worker.RunWorkerAsync();
                DialogResult res = l.ShowDialog();
                if (res == DialogResult.Abort)
                {
                    if (worker.IsBusy == true)
                    {
                        worker.CancelAsync();
                    }
                }
            }
        }

        private void butSaveAs_Click(object sender, EventArgs e)
        {
            open = false;
            save = true;
            DoExcel();
        }

        private void butSaveOpen_Click(object sender, EventArgs e)
        {

            open = true;
            save = true;
            DoExcel(); ;
        }

        private void butOpen_Click(object sender, EventArgs e)
        {

            open = true;
            save = false;
            DoExcel();
        }


    }
}
