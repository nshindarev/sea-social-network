using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning.DecisionTrees;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Globalization;
using Accord.Statistics.Filters;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;

namespace vk_sea_wf.Model.Class.Study
{
    class DecisionTreeBuilder
    {

        private DecisionTree decisionTree;
        private DataTable training_dataset;
        private String pathToDataset;

        public DecisionTreeBuilder(String path)
        {
            this.pathToDataset = path;
        }
        
        /// <summary>
        /// конвертирует csv в объект и обучает дерево
        /// </summary>
        public void studyDT()
        {
            this.training_dataset = DecisionTreeBuilder.GetDataTableFromCsv(pathToDataset, false);

            // Create a new codification codebook to
            // convert strings into integer symbols
            Codification codebook = new Codification(training_dataset);



            DecisionVariable[] attributes =
                {
                new DecisionVariable("on_web",              2),                               // 2 possible values (0,1)  
                new DecisionVariable("has_firm_name",       2),                               // 2 possible values (0,1)    
                new DecisionVariable("likes_counter",       DecisionVariableKind.Continuous), // counter_parameter
                new DecisionVariable("followed_by",         2),                               // 2 possible values (Weak, strong)
                new DecisionVariable("following_matches",   DecisionVariableKind.Continuous)  // counter_parameter
            };

            int classCount = 2; // 2 possible output values: yes or no

            // Create a new instance of the ID3 algorithm
            ID3Learning id3learning = new ID3Learning(decisionTree);

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = codebook.Apply(training_dataset);
            int[][] inputs = symbols.ToIntArray("on_web", "has_firm_name", "likes_counter", "followed_by", "following_matches");
            int[] outputs  = symbols.ToIntArray("is_employee").GetColumn(0);

            // Learn the training instances!
            id3learning.Run(inputs, outputs);
            decisionTree = new DecisionTree(attributes, classCount);


            // Convert to an expression tree
            var expression = decisionTree.ToExpression();

            // Compiles the expression to IL
            var func = expression.Compile();
        }

        static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
