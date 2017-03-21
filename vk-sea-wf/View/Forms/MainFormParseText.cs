using KBCsv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using vk_sea_wf.View.Interfaces;

namespace vk_sea_wf.View.Forms
{
    public partial class MainFormParseText :Form, IView, IMainView {
        //events
        public event EventHandler<EventArgs> findFriendsItemClicked;

        // override show 
        public void show() {
            Program.Context.MainForm = this;
            this.Show();
        }
        public MainFormParseText() {
            InitializeComponent();
        }

        private void getTextToolStripMenuItem_Click(object sender, EventArgs e) {
            findFriendsItemClicked?.Invoke(this, e);
        }
        
        public void fillInHTTPAnswer(IList<string> user_friends, IList<List<string>> user_sub_friends)
        {
            MessageBox.Show("Done!");
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\data.csv";
            using (var streamReader = new StreamReader(fileName))
            using (var reader = new CsvReader(streamReader))
            {
                reader.ValueSeparator = ';';
                reader.ValueDelimiter = '\'';

                // the CSV file has a header record, so we read that first
                reader.ReadHeaderRecord();

                // Установить названия столбцов
                for (int i = 0; i < reader.HeaderRecord.Count; i++)
                {
                    tableDataParsed.Columns.Add(
                        reader.HeaderRecord.GetValueOrNull(i),
                        reader.HeaderRecord.GetValueOrNull(i));
                }

                tableDataParsed.Columns[0].Width = 800;
                tableDataParsed.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                tableDataParsed.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                while (reader.HasMoreRecords)
                {
                    var dataRecord = reader.ReadDataRecord();

                    tableDataParsed.Rows.Add(
                        dataRecord[0], dataRecord[1], dataRecord[2], dataRecord[3], dataRecord[4], dataRecord[5]);

                }
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\data.csv";
            using (var streamWriter = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
            using (var writer = new CsvWriter(streamWriter))
            {
                writer.ForceDelimit = true;
                writer.ValueSeparator = ';';
                writer.ValueDelimiter = '\'';
                writer.WriteRecord(
                    "text",
                    "v_info_imprudence",
                    "v_weak_password",
                    "v_tech_negligence",
                    "v_inexperience",
                    "v_illiteracy");

                for (int i = 0; i < tableDataParsed.RowCount - 1; i++)
                {
                    writer.WriteRecord(
                        tableDataParsed.Rows[i].Cells[0].Value.ToString(),
                        tableDataParsed.Rows[i].Cells[1].Value.ToString(),
                        tableDataParsed.Rows[i].Cells[2].Value.ToString(),
                        tableDataParsed.Rows[i].Cells[3].Value.ToString(),
                        tableDataParsed.Rows[i].Cells[4].Value.ToString(),
                        tableDataParsed.Rows[i].Cells[5].Value.ToString());
                }                
            }

            MessageBox.Show("Done!");
        }

    }
}
