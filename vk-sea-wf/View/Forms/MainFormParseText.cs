using KBCsv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using vk_sea_wf.View.Interfaces;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;

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
        
        private void getExtendedTextDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string inputFileName = @"C:\psych.csv";
            string outFileName = @"C:\vk-extended.csv";

            using (var sr = new StreamReader(inputFileName))
            using (var reader = new CsvReader(sr))
            using (var sw = new StreamWriter(outFileName, false, System.Text.Encoding.UTF8))
            using (var writer = new CsvWriter(sw))
            {
                reader.ValueSeparator = ',';

                writer.ForceDelimit = false;
                writer.ValueSeparator = ',';
                writer.ValueDelimiter = '\'';

                reader.ReadHeaderRecord();
                writer.WriteRecord("id", "text", "origin_text", "date", "attachment");

                while (reader.HasMoreRecords)
                {
                    var dataRecord = reader.ReadDataRecord();

                    List<Post> posts = VkApiHolder.Api.Wall.Get(new WallGetParams()
                    {
                        OwnerId = long.Parse(dataRecord["id"]),
                        Filter = WallFilter.Owner,
                    }).WallPosts.ToList();

                    foreach (Post post in posts)
                    {
                        if (post.Date.Value < new DateTime(2016, 5, 1)) continue;

                        string text = post.Text + " ";
                        text = text.Replace(Environment.NewLine, " ")
                            .Replace("\n", " ")
                            .Replace("\r", " ")
                            .Replace("\"", "")
                            .Replace(";", " ")
                            .Replace(",", " ")
                            .Replace("'", "")
                            .Trim();

                        string originText = "";
                        if (post.CopyHistory.Count != 0)
                        {
                            originText = post.CopyHistory.First().Text.Replace(Environment.NewLine, " ")
                            .Replace("\n", " ")
                            .Replace("\r", " ")
                            .Replace("\"", "")
                            .Replace(";", " ")
                            .Replace(",", " ")
                            .Replace("'", "")
                            .Trim();
                        }
                        
                        var outputRecord = new string[5];
                        outputRecord[0] = dataRecord["id"];
                        outputRecord[1] = text;
                        outputRecord[2] = originText;
                        outputRecord[3] = post.Date.Value.ToString();
                        outputRecord[4] = post.Attachments.Count == 0 ? "false" : "true";
                        
                        writer.WriteRecord(outputRecord);
                    }

                    System.Threading.Thread.Sleep(50);
                }
            }

            MessageBox.Show("Done!");

        }

    }
}
