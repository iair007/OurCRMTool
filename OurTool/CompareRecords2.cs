using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Query;
using System.ComponentModel;

namespace OurCRMTool
{
    public partial class CompareRecords2 : Form
    {
        #region CONS/VAR
        private BL2Enviroments bl;
        log4net.ILog log;
        bool commingFromOtherSelect = false;  //used when changeSelection in grids
        DataTable dtFields = new System.Data.DataTable();
        DataTable dtEnviroment1 = new DataTable();
        DataTable dtEnviroment2 = new DataTable();
        DataTable dtOnlyInEnviroment1 = new DataTable();
        DataTable dtOnlyInEnviroment2 = new DataTable();
        DataTable dtDifference1 = new DataTable();
        DataTable dtDifference2 = new DataTable();
        EntityCollection recordsEnviroment1 = new EntityCollection();
        EntityCollection recordsEnviroment2 = new EntityCollection();
        Dictionary<string, string> compareFields;
        Dictionary<string, string> selectFields;
        Dictionary<string, string> recordKeyList;
        string entityName;
        string orderby;
        OrderType direcction;
        string top = "";
        BackgroundWorker worker1 = new BackgroundWorker();
        BackgroundWorker worker2 = new BackgroundWorker();
        bool isActivty;

        List<Guid> recordsToCreate = new List<Guid>();
        Dictionary<Guid, Entity> recordsToUpdate = new Dictionary<Guid, Entity>();

        bool finish1 = false;  //to make 2 async calls and wait until bouth will be done before continue
        bool finish2 = false;

        #endregion

        #region Contructor

        public CompareRecords2(BL2Enviroments _bl, log4net.ILog _log, string _entityName, bool _isActivity, DataTable _dtFields, Dictionary<string, string> _compareFieldsList,
            Dictionary<string, string> _selectFields, Dictionary<string, string> _recordKeyList, string _orderby, OrderType _direcction, string _top = "")
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            groupBox.Enabled = false;
            bl = _bl;
            log = _log;
            dtFields = _dtFields;
            isActivty = _isActivity;
            lbEnviroment1.Text = bl.url1;
            lbEnviroment2.Text = bl.url2;
            lbEnviroment1b.Text = bl.url1;
            lbEnviroment2b.Text = bl.url2;
            lbEnviroment1c.Text = bl.url1;
            lbEnviroment2c.Text = bl.url2;

            selectFields = _selectFields;
            compareFields = _compareFieldsList;
            recordKeyList = _recordKeyList;
            entityName = _entityName;
            orderby = _orderby;
            direcction = _direcction;
            top = _top;

            SetComboFilterBy();
            CreatedtdtGlobalColumns(dtEnviroment1);
            CreatedtdtGlobalColumns(dtEnviroment2);
            CreatedtdtGlobalColumns(dtOnlyInEnviroment1);
            CreatedtdtGlobalColumns(dtOnlyInEnviroment2);
            CreatedtdtGlobalColumns(dtDifference1);
            CreatedtdtGlobalColumns(dtDifference2);

            worker1 = new BackgroundWorker();
            worker1.WorkerReportsProgress = true;
            worker1.DoWork += worker_DoWork1;
            worker1.RunWorkerCompleted += worker_RunWorkerCompleted1;

            worker2 = new BackgroundWorker();
            worker2.WorkerReportsProgress = true;
            worker2.DoWork += worker_DoWork2;
            worker2.RunWorkerCompleted += worker_RunWorkerCompleted2;

            worker1.RunWorkerAsync();
            worker2.RunWorkerAsync();
        }

        #endregion

        #region Tables
        private void CreatedtdtGlobalColumns(DataTable table)
        {
            table.Columns.Add("myIndex", typeof(int));   //used to sincronize the records between the 2 enviroments
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("check", typeof(bool));

            List<string> AllColumns = selectFields.Keys.Union(compareFields.Keys).ToList();
            AllColumns = AllColumns.Union(recordKeyList.Keys).ToList();

            foreach (string s in AllColumns)
            {
                table.Columns.Add(s, typeof(string));
            }
        }
        private void SetGridsProperties(DataGridView grid)
        {
            if (grid.Columns.Count > 0)
            {
                //set Columns properties
                grid.Columns["myIndex"].Visible = false;
                grid.Columns["myIndex"].ReadOnly = true;
                grid.Columns["myIndex"].SortMode = DataGridViewColumnSortMode.Automatic;

                grid.Columns["id"].Visible = false;
                grid.Columns["id"].ReadOnly = true;
                grid.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;

                grid.Columns["check"].Visible = true;
                grid.Columns["check"].ReadOnly = false;
                grid.Columns["check"].Width = 60;
                grid.Columns["check"].SortMode = DataGridViewColumnSortMode.NotSortable;

                foreach (string s in recordKeyList.Keys)
                {
                    grid.Columns[s].Visible = false;
                    grid.Columns[s].ReadOnly = true;
                    grid.Columns[s].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                foreach (string s in compareFields.Keys)
                {
                    grid.Columns[s].Visible = false;
                    grid.Columns[s].ReadOnly = true;
                    grid.Columns[s].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                foreach (string s in selectFields.Keys)
                {
                    //grid.Columns[s].Width = 100;
                    grid.Columns[s].Visible = true;
                    grid.Columns[s].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grid.Columns[s].HeaderText = s;
                    grid.Columns[s].ReadOnly = true;
                    grid.Columns[s].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        #endregion  Tables

        #region Workers

        void worker_DoWork1(object sender, DoWorkEventArgs e)
        {
            try
            {
                EntityCollection recordsEnviroment1 = bl.GetRecords(entityName, compareFields, selectFields, recordKeyList, orderby, direcction, true, top);
                e.Result = recordsEnviroment1;
            }
            catch (Exception ex)
            {
                e.Result = "Error getting entity from enviroment 1: " + ex.Message;
            }
        }
        void worker_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.GetType() == typeof(string))
            {
                MessageBox.Show(e.Result.ToString());
                recordsEnviroment1 = new EntityCollection();
            }
            else
            {
                recordsEnviroment1 = (EntityCollection)e.Result;
            }
            foreach (Entity en in recordsEnviroment1.Entities)
            {
                string id = en.Id.ToString();
                List<string> columns = new List<string>();
                columns.Add("-1");
                columns.Add(id);
                columns.Add("false");
                for (int i = 3; i < dtEnviroment1.Columns.Count; i++)
                {  //start in 3 because the first 3 columns are mine, and not from the selected values
                    if (en.Contains(dtEnviroment1.Columns[i].ColumnName))
                    {
                        columns.Add(ConvertToString(en[dtEnviroment1.Columns[i].ColumnName], selectFields[dtEnviroment1.Columns[i].ColumnName]));
                    }
                    else
                    {
                        columns.Add(null);
                    }
                }

                dtEnviroment1.Rows.Add(columns.ToArray());
            }

            lbRecords1.Text = "Nr of Records: " + recordsEnviroment1.Entities.Count().ToString();
            finish1 = true;
            SetGrids();

        }
        void worker_DoWork2(object sender, DoWorkEventArgs e)
        {
            try
            {
                EntityCollection recordsEnviroment2 = bl.GetRecords(entityName, compareFields, selectFields, recordKeyList, orderby, direcction, false, top);
                e.Result = recordsEnviroment2;
            }
            catch (Exception ex)
            {
                e.Result = "Error getting entity from enviroment 2: " + ex.Message;
            }
        }
        void worker_RunWorkerCompleted2(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.GetType() == typeof(string))
            {
                MessageBox.Show(e.Result.ToString());
                recordsEnviroment2 = new EntityCollection();
            }
            else
            {
                recordsEnviroment2 = (EntityCollection)e.Result;
            }
            foreach (Entity en in recordsEnviroment2.Entities)
            {
                string id = en.Id.ToString();
                List<string> columns = new List<string>();
                columns.Add("-1");
                columns.Add(id);
                columns.Add("false");
                for (int i = 3; i < dtEnviroment2.Columns.Count; i++)
                {  //start in 3 because the first 3 columns are mine, and not from the selected values
                    if (en.Contains(dtEnviroment2.Columns[i].ColumnName))
                    {
                        columns.Add(ConvertToString(en[dtEnviroment2.Columns[i].ColumnName], selectFields[dtEnviroment2.Columns[i].ColumnName]));
                    }
                    else
                    {
                        columns.Add(null);
                    }
                }

                dtEnviroment2.Rows.Add(columns.ToArray());
            }

            lbRecords2.Text = "Nr of Records: " + recordsEnviroment2.Entities.Count().ToString();
            finish2 = true;
            SetGrids();

        }

        #endregion workers

        private void butRefresh_Click(object sender, EventArgs e)
        {
            gridEnviroment1.DataSource = "";
            gridEnviroment2.DataSource = "";
            gridDiff1.DataSource = "";
            gridDiff2.DataSource = "";
            gridOnlyIn1.DataSource = "";
            gridOnlyIn2.DataSource = "";

            dtEnviroment1.Clear();
            dtEnviroment2.Clear();
            dtOnlyInEnviroment1.Clear();
            dtOnlyInEnviroment2.Clear();
            dtDifference1.Clear();
            dtDifference2.Clear();
            recordsEnviroment1 = new EntityCollection();
            recordsEnviroment2 = new EntityCollection();




            finish1 = false;
            finish2 = false;

            groupBox.Enabled = false;

            worker1.RunWorkerAsync();
            worker2.RunWorkerAsync();
        }

        private void SetGrids()
        {
            //wait to get all the needed data before making the dataTables
            if (finish1 && finish2)
            {
                ReorganizeTables();

                gridEnviroment1.DataSource = dtEnviroment1;
                gridEnviroment2.DataSource = dtEnviroment2;

                gridDiff1.DataSource = dtDifference1;
                gridDiff2.DataSource = dtDifference2;

                gridOnlyIn1.DataSource = dtOnlyInEnviroment1;
                gridOnlyIn2.DataSource = dtOnlyInEnviroment2;

                SetGridsProperties(gridEnviroment1);
                SetGridsProperties(gridEnviroment2);
                SetGridsProperties(gridDiff1);
                SetGridsProperties(gridDiff2);
                SetGridsProperties(gridOnlyIn1);
                SetGridsProperties(gridOnlyIn2);

                DisableEmptyCells(gridEnviroment1);
                DisableEmptyCells(gridEnviroment2);
                DisableEmptyCells(gridDiff1);
                DisableEmptyCells(gridDiff2);

                groupBox.Enabled = true;
                this.Cursor = Cursors.Default;
            }

            gridEnviroment1.Focus();
        }

        /// <summary>
        /// Will reorganize the tables putting empy spaces where is missing a record in the other enviroment
        /// </summary>
        private void ReorganizeTables()
        {
            if (finish1 && finish2)
            {
                // recordsEnviroment1.Entities.
                int myIndex = 0;
                int nrColumnsToCompate = compareFields.Count();
                bool findEqual = false;
                bool isSameKey = false;
                foreach (DataRow r1 in dtEnviroment1.Rows)
                {
                    findEqual = false;
                    isSameKey = false;
                    nrColumnsToCompate = compareFields.Count();
                    foreach (DataRow r2 in dtEnviroment2.Rows)
                    {
                        int nrOfKeys = recordKeyList.Count();
                        foreach (string key in recordKeyList.Keys)
                        {
                            if (r1[key].ToString() == r2[key].ToString())
                            {
                                nrOfKeys--;
                            }
                            if (nrOfKeys == 0)
                            {
                                isSameKey = true;
                            }
                        }
                        if (isSameKey)
                        {
                            r1[0] = myIndex.ToString();
                            r2[0] = myIndex.ToString();

                            foreach (string s in compareFields.Keys)
                            {
                                if (r1[s].ToString() == r2[s].ToString())
                                {
                                    nrColumnsToCompate--;
                                }
                                else
                                {
                                    //if one column doesnt match so go to check next row.
                                    break;
                                }
                            }

                            if (nrColumnsToCompate == 0)
                            {
                                findEqual = true;
                                break;
                            }
                            else
                            {
                                //find a same Key, but the compare fields are differents
                                DataRow newR = dtDifference1.NewRow();
                                newR.ItemArray = r1.ItemArray;
                                dtDifference1.Rows.Add(newR);

                                DataRow newR2 = dtDifference2.NewRow();
                                newR2.ItemArray = r2.ItemArray;

                                dtDifference2.Rows.Add(newR2);
                                break;
                            }
                        }
                    }

                    if (findEqual == false)
                    {
                        if (isSameKey == false)
                        {
                            // this row is only in Enviroment1
                            r1[0] = myIndex;
                            dtEnviroment2.Rows.Add(myIndex, "");

                            DataRow newROnly = dtOnlyInEnviroment1.NewRow();
                            newROnly.ItemArray = r1.ItemArray;
                            dtOnlyInEnviroment1.Rows.Add(newROnly);
                        }
                    }
                    myIndex++;
                }

                //check all the rows from enviroment2 that did not match any row in enviroment1
                DataRow[] row2 = dtEnviroment2.Select("myIndex = '-1'");
                foreach (DataRow r in row2)
                {
                    r[0] = myIndex;
                    dtEnviroment1.Rows.Add(myIndex, "");
                    DataRow copyOnlyR = r;
                    DataRow copyR = r;

                    DataRow newR = dtDifference2.NewRow();
                    newR.ItemArray = r.ItemArray;
                    dtDifference2.Rows.Add(newR);

                    DataRow newROnly = dtOnlyInEnviroment2.NewRow();
                    newROnly.ItemArray = r.ItemArray;
                    dtOnlyInEnviroment2.Rows.Add(newROnly);

                    dtDifference1.Rows.Add(myIndex, "");
                    myIndex++;
                }
            }
        }

        private string ConvertToString(object value, string attributeType)
        {
            string valueAsString;

            switch (attributeType.ToLower())
            {
                case "string":
                    valueAsString = value.ToString();
                    break;
                case "integer":
                    valueAsString = value.ToString();
                    break;
                case "optionset":
                    valueAsString = (value as OptionSetValue).Value.ToString();
                    break;
                case "entityreference":
                    valueAsString = (value as EntityReference).Name;
                    break;
                case "lookup":
                    valueAsString = (value as EntityReference).Name;
                    break;
                case "Status":
                    valueAsString = (value as OptionSetValue).Value.ToString();
                    break;
                case "state":
                    valueAsString = (value as OptionSetValue).Value.ToString();
                    break;
                case "Money":
                    valueAsString = (value as Money).Value.ToString();
                    break;
                case "decimal":
                    valueAsString = value.ToString();
                    break;
                case "double":
                    valueAsString = value.ToString();
                    break;
                case "picklist":
                    valueAsString = (value as OptionSetValue).Value.ToString();
                    break;
                case "owner":
                    valueAsString = (value as EntityReference).Name;
                    break;
                case "boolean":
                    valueAsString = value.ToString();
                    break;
                case "datetime":
                    valueAsString = value.ToString();
                    break;
                default:
                    valueAsString = value.ToString();
                    break;
            }

            return valueAsString;
        }

        #region Grids Events

        private int FindIndexByMyIndex(int myIndex1, DataGridView secondGrid)
        {
            int index = -1;

            foreach (DataGridViewRow r in secondGrid.Rows)
            {
                if ((int)r.Cells["myIndex"].Value == myIndex1)
                {
                    index = r.Index;
                    break;
                }
            }
            return index;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridEnviroment1.Rows)
            {
                if (row.Cells[comboFilterBy.SelectedItem.ToString()].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    gridEnviroment2.FirstDisplayedScrollingRowIndex = row.Index;
                    gridEnviroment1.FirstDisplayedScrollingRowIndex = row.Index;
                    gridEnviroment1.Rows[row.Index].Selected = true;
                    break;
                }
            }
            txtSearch.Focus();
        }

        #endregion

        #region ToolTip

        private void AddToolTip(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if ((e.ColumnIndex == 1) && e.Value != null)
            {
                SetToolTips(grid, e.RowIndex);
            }
        }

        private void SetToolTips(DataGridView grid, int rowIndex)
        {
            DataGridViewCell cell = grid.Rows[rowIndex].Cells[1];
            cell.ToolTipText = grid.Rows[rowIndex].Cells[0].Value.ToString();
        }

        #endregion

        #region Panel1 - All Records

        private void gridEnviroment1_Scroll(object sender, ScrollEventArgs e)
        {
            int myIndex1 = (int)gridEnviroment1.Rows[gridEnviroment1.FirstDisplayedScrollingRowIndex].Cells[0].Value;
            int enviroment2Index = FindIndexByMyIndex(myIndex1, gridEnviroment2);
            if (enviroment2Index > 0)
            {
                gridEnviroment2.FirstDisplayedScrollingRowIndex = enviroment2Index;
            }
        }

        private void gridEnviroment2_Scroll(object sender, ScrollEventArgs e)
        {
            int myIndex2 = (int)gridEnviroment2.Rows[gridEnviroment2.FirstDisplayedScrollingRowIndex].Cells[0].Value;

            int enviroment1Index = FindIndexByMyIndex(myIndex2, gridEnviroment1);
            if (enviroment1Index > 0)
            {
                gridEnviroment1.FirstDisplayedScrollingRowIndex = enviroment1Index;
            }
        }

        private void gridEnviroment1_SelectionChanged(object sender, EventArgs e)
        {
            if (!commingFromOtherSelect)
            {
                DataGridView grid = (sender as DataGridView);
                if (grid.Rows.Count > 0 && grid.SelectedRows.Count > 0)
                {
                    if (grid.FirstDisplayedScrollingRowIndex != -1)
                    {
                        int myIndex1 = (int)grid.SelectedRows[0].Cells[0].Value;
                        if (gridEnviroment2.Rows.Count > 0)
                        {
                            int enviroment2Index = FindIndexByMyIndex(myIndex1, gridEnviroment2);

                            commingFromOtherSelect = true;
                            if (enviroment2Index >= 0)
                            {
                                gridEnviroment2.Rows[enviroment2Index].Selected = true;
                            }
                        }
                    }
                    commingFromOtherSelect = false;
                }
            }
        }

        private void gridEnviroment2_SelectionChanged(object sender, EventArgs e)
        {
            if (!commingFromOtherSelect)
            {
                DataGridView grid = (sender as DataGridView);
                if (grid.Rows.Count > 0 && grid.SelectedRows.Count > 0)
                {
                    if (grid.FirstDisplayedScrollingRowIndex != -1)
                    {
                        int myIndex2 = (int)grid.SelectedRows[0].Cells[0].Value;
                        if (gridEnviroment1.Rows.Count > 0)
                        {
                            int enviroment1Index = FindIndexByMyIndex(myIndex2, gridEnviroment1);

                            commingFromOtherSelect = true;
                            if (enviroment1Index >= 0)
                            {
                                gridEnviroment1.Rows[enviroment1Index].Selected = true;
                            }
                        }
                    }
                    commingFromOtherSelect = false;
                }
            }
        }

        private void gridEnviroment1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            CellClicked(grid);

            if (grid.Rows[e.RowIndex].Cells["id"].Value.ToString() == string.Empty)
            {
                grid.Rows[e.RowIndex].Cells["check"].Value = false;
            }
            else
            {
                bool isChecked = (bool)grid.Rows[e.RowIndex].Cells["check"].Value;
                int myIndex = (int)grid.Rows[e.RowIndex].Cells["myIndex"].Value;
                EqualSelectionInAllTheGrids(myIndex, grid, isChecked, true);
            }
        }

        private void gridEnviroment2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            CellClicked(grid);

            if (grid.Rows[e.RowIndex].Cells["id"].Value.ToString() == string.Empty)
            {
                grid.Rows[e.RowIndex].Cells["check"].Value = false;
            }
            else
            {
                bool isChecked = (bool)grid.Rows[e.RowIndex].Cells["check"].Value;  //! because it ocurrse befor the change
                int myIndex = (int)grid.Rows[e.RowIndex].Cells["myIndex"].Value;
                EqualSelectionInAllTheGrids(myIndex, grid, isChecked, false);
            }
        }

        #endregion

        #region Panel2  - Difference

        private void gridDiff1_Scroll(object sender, ScrollEventArgs e)
        {
            int myIndex1 = (int)gridDiff1.Rows[gridDiff1.FirstDisplayedScrollingRowIndex].Cells[0].Value;
            int enviroment2Index = FindIndexByMyIndex(myIndex1, gridDiff2);
            if (enviroment2Index > 0)
            {
                gridDiff2.FirstDisplayedScrollingRowIndex = enviroment2Index;
            }
        }

        private void gridDiff2_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int myIndex2 = (int)gridDiff2.Rows[gridDiff2.FirstDisplayedScrollingRowIndex].Cells[0].Value;

                int enviroment1Index = FindIndexByMyIndex(myIndex2, gridEnviroment1);
                if (enviroment1Index > 0)
                {
                    gridDiff1.FirstDisplayedScrollingRowIndex = enviroment1Index;
                }
            }
            catch { }
        }

        private void gridDiff1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView grid = (DataGridView)sender;
                CellClicked(grid);

                if (grid.Rows[e.RowIndex].Cells["id"].Value.ToString() == string.Empty)
                {
                    grid.Rows[e.RowIndex].Cells["check"].Value = false;
                }
                else
                {

                    bool isChecked = (bool)grid.Rows[e.RowIndex].Cells["check"].Value;
                    int myIndex = (int)grid.Rows[e.RowIndex].Cells["myIndex"].Value;
                    EqualSelectionInAllTheGrids(myIndex, grid, isChecked, true);
                }

            }
            catch { }
        }

        private void gridDiff2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView grid = (DataGridView)sender;
                CellClicked(grid);

                if (grid.Rows[e.RowIndex].Cells["id"].Value.ToString() == string.Empty)
                {
                    grid.Rows[e.RowIndex].Cells["check"].Value = false;
                }
                else
                {
                    bool isChecked = (bool)grid.Rows[e.RowIndex].Cells["check"].Value;  //! because it ocurrse befor the change
                    int myIndex = (int)grid.Rows[e.RowIndex].Cells["myIndex"].Value;
                    EqualSelectionInAllTheGrids(myIndex, grid, isChecked, false);
                }

            }
            catch { }
        }

        private void gridDiff1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!commingFromOtherSelect)
                {
                    DataGridView grid = (sender as DataGridView);
                    if (grid.Rows.Count > 0 && grid.SelectedRows.Count > 0)
                    {
                        if (grid.FirstDisplayedScrollingRowIndex != -1)
                        {
                            int myIndex1 = (int)grid.SelectedRows[0].Cells[0].Value;
                            if (gridDiff2.Rows.Count > 0)
                            {
                                int gridDiff2Index = FindIndexByMyIndex(myIndex1, gridDiff2);

                                commingFromOtherSelect = true;
                                if (gridDiff2Index >= 0)
                                {
                                    gridDiff2.Rows[gridDiff2Index].Selected = true;
                                }
                            }
                        }
                        commingFromOtherSelect = false;
                    }
                }
            }
            catch { }
        }

        private void gridDiff2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!commingFromOtherSelect)
                {
                    DataGridView grid = (sender as DataGridView);
                    if (grid.Rows.Count > 0 && grid.SelectedRows.Count > 0)
                    {
                        if (grid.FirstDisplayedScrollingRowIndex != -1)
                        {
                            int myIndex2 = (int)grid.SelectedRows[0].Cells[0].Value;
                            if (gridDiff1.Rows.Count > 0)
                            {
                                int gridDiff1Index = FindIndexByMyIndex(myIndex2, gridDiff1);

                                commingFromOtherSelect = true;
                                if (gridDiff1Index >= 0)
                                {
                                    gridDiff1.Rows[gridDiff1Index].Selected = true;
                                }
                            }
                        }
                        commingFromOtherSelect = false;
                    }
                }
            }
            catch { }
        }
        #endregion

        #region Panel3 - Only in one enviroment
        private void gridOnlyIn1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            CellClicked(grid);

            if (grid.Rows[e.RowIndex].Cells["id"].Value.ToString() == string.Empty)
            {
                grid.Rows[e.RowIndex].Cells["check"].Value = false;
            }
            else
            {
                bool isChecked = (bool)grid.Rows[e.RowIndex].Cells["check"].Value;
                int myIndex = (int)grid.Rows[e.RowIndex].Cells["myIndex"].Value;
                EqualSelectionInAllTheGrids(myIndex, grid, isChecked, true);
            }
        }

        private void gridOnlyIn2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            CellClicked(grid);


            if (grid.Rows[e.RowIndex].Cells["id"].Value.ToString() == string.Empty)
            {
                grid.Rows[e.RowIndex].Cells["check"].Value = false;
            }
            else
            {
                bool isChecked = (bool)grid.Rows[e.RowIndex].Cells["check"].Value;
                int myIndex = (int)grid.Rows[e.RowIndex].Cells["myIndex"].Value;
                EqualSelectionInAllTheGrids(myIndex, grid, isChecked, false);
            }

        }

        private void butSelAllOnlyIn1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridOnlyIn1.Rows)
            {
                r.Cells["check"].Value = true;
                int myIndex = (int)r.Cells["myIndex"].Value;
                EqualSelectionInAllTheGrids(myIndex, gridOnlyIn1, true, true);
            }
        }
        private void butSelAllOnlyIn2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridOnlyIn2.Rows)
            {
                r.Cells["check"].Value = true;
                int myIndex = (int)r.Cells["myIndex"].Value;
                EqualSelectionInAllTheGrids(myIndex, gridOnlyIn2, true, false);
            }
        }
        private void butClearAllOnlyIn1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridOnlyIn1.Rows)
            {
                r.Cells["check"].Value = false;
                int myIndex = (int)r.Cells["myIndex"].Value;
                EqualSelectionInAllTheGrids(myIndex, gridOnlyIn1, false, true);
            }
        }
        private void butClearAllOnlyIn2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridOnlyIn2.Rows)
            {
                r.Cells["check"].Value = false;
                int myIndex = (int)r.Cells["myIndex"].Value;
                EqualSelectionInAllTheGrids(myIndex, gridOnlyIn2, false, false);
            }
        }
        #endregion

        /// <summary>
        /// this helps to show the checked box when user click inside the checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            senderGridView.RefreshEdit();
        }

        private void CellClicked(DataGridView grid)
        {
            DataGridViewRow rowClicked = grid.CurrentRow;
            rowClicked.Cells["check"].Value = !(bool)rowClicked.Cells["check"].Value;
            grid.RefreshEdit();
        }

        private void SetComboFilterBy()
        {
            comboFilterBy.Items.Clear();
            foreach (string s in selectFields.Keys)
            {
                comboFilterBy.Items.Add(s);
            }
            comboFilterBy.Sorted = true;
        }

        private void grid_CellDoubleClick1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (sender as DataGridView);
            bl.OpenWithArguments(dataGridView.CurrentRow.Cells["id"].Value.ToString(), entityName, true);
        }

        private void grid_CellDoubleClick2(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (sender as DataGridView);
            bl.OpenWithArguments(dataGridView.CurrentRow.Cells["id"].Value.ToString(), entityName, false);
        }
        private void comboFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ldFilterBy.Text = comboFilterBy.SelectedItem.ToString();
        }

        #region Private functions

        private void EqualSelectionInAllTheGrids(int myIndex, DataGridView grid, bool isCheck, bool isFromEnviroment1)
        {
            if (grid.Name != "gridEnviroment1")
            {
                if (gridEnviroment1.Rows.Count > 0)
                {
                    int indexInOtherGrid = FindIndexByMyIndex(myIndex, gridEnviroment1);

                    commingFromOtherSelect = true;
                    if (indexInOtherGrid >= 0)
                    {
                        gridEnviroment1.Rows[indexInOtherGrid].Cells["check"].Value = isFromEnviroment1 && isCheck;
                    }
                }
            }
            if (grid.Name != "gridDiff1")
            {
                if (gridDiff1.Rows.Count > 0)
                {
                    int indexInOtherGrid = FindIndexByMyIndex(myIndex, gridDiff1);

                    commingFromOtherSelect = true;
                    if (indexInOtherGrid >= 0)
                    {
                        gridDiff1.Rows[indexInOtherGrid].Cells["check"].Value = isFromEnviroment1 && isCheck;
                    }
                }
            }

            if (grid.Name != "gridOnlyIn1")
            {
                if (gridOnlyIn1.Rows.Count > 0)
                {
                    int indexInOtherGrid = FindIndexByMyIndex(myIndex, gridOnlyIn1);

                    commingFromOtherSelect = true;
                    if (indexInOtherGrid >= 0)
                    {
                        gridOnlyIn1.Rows[indexInOtherGrid].Cells["check"].Value = isFromEnviroment1 && isCheck;
                    }
                }
            }

            if (grid.Name != "gridEnviroment2")
            {
                if (gridEnviroment2.Rows.Count > 0)
                {
                    int indexInOtherGrid = FindIndexByMyIndex(myIndex, gridEnviroment2);

                    commingFromOtherSelect = true;
                    if (indexInOtherGrid >= 0)
                    {
                        gridEnviroment2.Rows[indexInOtherGrid].Cells["check"].Value = !isFromEnviroment1 && isCheck;
                    }
                }
            }
            if (grid.Name != "gridDiff2")
            {
                if (gridDiff2.Rows.Count > 0)
                {
                    int indexInOtherGrid = FindIndexByMyIndex(myIndex, gridDiff2);

                    commingFromOtherSelect = true;
                    if (indexInOtherGrid >= 0)
                    {
                        gridDiff2.Rows[indexInOtherGrid].Cells["check"].Value = !isFromEnviroment1 && isCheck;
                    }
                }
            }

            if (grid.Name != "gridOnlyIn2")
            {
                if (gridOnlyIn2.Rows.Count > 0)
                {
                    int indexInOtherGrid = FindIndexByMyIndex(myIndex, gridOnlyIn2);

                    commingFromOtherSelect = true;
                    if (indexInOtherGrid >= 0)
                    {
                        gridOnlyIn2.Rows[indexInOtherGrid].Cells["check"].Value = !isFromEnviroment1 && isCheck;
                    }
                }
            }
        }
        private List<DataGridViewRow> GetSelectedRecords(DataGridView grid)
        {
            List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow r in grid.Rows)
            {
                if (r.Cells["check"].Value.ToString() != string.Empty && (bool)r.Cells["check"].Value == true)
                {
                    selectedRows.Add(r);
                }
            }
            return selectedRows;
        }
        private void DisableEmptyCells(DataGridView grid)
        {
            foreach (DataGridViewRow r in grid.Rows)
            {
                if (r.Cells["id"].Value.ToString() == string.Empty)
                {
                    r.ReadOnly = true;
                    r.Cells["check"].ReadOnly = true;
                }
            }
        }

        #endregion

        private void butFrom1To2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string message = string.Empty;
                List<DataGridViewRow> selectedRecords = GetSelectedRecords(gridEnviroment1);
                CreateListToUpdateAndCreate(selectedRecords, true);

                if (recordsToCreate.Count() > 0 || recordsToUpdate.Count() > 0)
                {
                    CompareRecords_SelectFieldsToCopy form = new CompareRecords_SelectFieldsToCopy(bl, true, entityName,isActivty ,dtFields, recordsToCreate, recordsToUpdate, log);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No record Selected");
                }
            }
            catch (Exception ex)
            {
                log.Error("CompareRecords2.butFrom1To2_Click_1: " + ex.Message);
            }
        }

        private void butFrom2To1_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            List<DataGridViewRow> selectedRecords = GetSelectedRecords(gridEnviroment2);
            CreateListToUpdateAndCreate(selectedRecords, false);

            if (recordsToCreate.Count() > 0 || recordsToUpdate.Count() > 0)
            {
                CompareRecords_SelectFieldsToCopy form = new CompareRecords_SelectFieldsToCopy(bl, false, entityName,isActivty, dtFields, recordsToCreate, recordsToUpdate, log);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No record Selected");
            }
        }

        /// <summary>
        /// Will create a list of records to create in the other enviroment
        /// and Create a Dictionary with the records to update in the other enviroment
        /// </summary>
        /// <param name="selectedRecords"></param>
        /// <param name="isFromEnviroment1"></param>
        private void CreateListToUpdateAndCreate(List<DataGridViewRow> selectedRecords, bool isFromEnviroment1)
        {
            recordsToUpdate.Clear();
            recordsToCreate.Clear();

            //Check if exist in the enviroment2 or no
            //If does, have to update
            //If doesnt, have to create a new record in enviroment2
            bool goNext = false;
            DataGridView otherEnviroment = isFromEnviroment1 ? gridEnviroment2 : gridEnviroment1;

            foreach (DataGridViewRow r1 in selectedRecords)
            {
                goNext = false;
                foreach (DataGridViewRow r2 in otherEnviroment.Rows)
                {
                    if (goNext == true) break;
                    if (r1.Cells["myIndex"].Value.ToString() == r2.Cells["myIndex"].Value.ToString())
                    {
                        if (r2.Cells["id"].Value.ToString() != string.Empty)
                        {
                            Entity e = new Entity();
                            e.Id = new Guid(r1.Cells["id"].Value.ToString());
                            recordsToUpdate.Add(new Guid(r2.Cells["id"].Value.ToString()), e);  //the Entity will be retrieved later with all the fields needed to
                            goNext = true;
                            break;
                        }
                        else
                        {
                            recordsToCreate.Add(new Guid(r1.Cells["id"].Value.ToString()));
                            goNext = true;
                            break;
                        }
                    }
                }
            }
        }


    }
}
