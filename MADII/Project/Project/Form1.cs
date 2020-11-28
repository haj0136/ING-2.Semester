using Project.Network;
using Project.SamplingAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        private Graph _graph;
        private Graph _sampledGraph;
        private List<ISampling> samplingMethods;

        public Form1()
        {
            InitializeComponent();

            samplingMethods = new List<ISampling>();
            InitializeAlgorithms();
            AlgorithmsComboBox.SelectedIndex = 0;
        }

        private void InitializeAlgorithms()
        {
            AlgorithmsComboBox.Items.Add("Random Node Sampling");
            samplingMethods.Add(new RandomNodeSampling());
            AlgorithmsComboBox.Items.Add("Degree Based Sampling");
            samplingMethods.Add(new DegreeBasedSampling());
            AlgorithmsComboBox.Items.Add("Random Walk Sampling");
            samplingMethods.Add(new RandomWalkSampling());
            AlgorithmsComboBox.Items.Add("Forest Fire Sampling");
            samplingMethods.Add(new ForestFireSampling());
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DatasetListView.Items.Clear();
                _graph = new Graph();
                var waitDialog = new WaitDialog("Loading dataset, please wait.");
                waitDialog.Show();
                waitDialog.Refresh();
                DataLoader.LoadData(_graph, openFileDialog1.FileName);
                waitDialog.Hide();
                waitDialog.Dispose();
                StartSamplingButton.Enabled = true;
                PrintStats(_graph, DatasetListView);

            }
        }

        private void StartSamplingButton_Click(object sender, EventArgs e)
        {
            SampleListView.Items.Clear();
            var waitDialog = new WaitDialog("Making sample, please wait.");
            var thread = new Thread(() => waitDialog.ShowDialog());
            thread.Start();
            //waitDialog.Refresh();
            _sampledGraph = samplingMethods[AlgorithmsComboBox.SelectedIndex]
                .GetSample((double)SizeUpDown.Value, _graph.NodeList, (double)RestartUpDown.Value);
            Action action = () =>
            {
                waitDialog.Hide();
                waitDialog.Dispose();
            };
            try
            {
                Thread.Sleep(1000);
                waitDialog.Invoke(action);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                Thread.Sleep(5000);
                waitDialog.Invoke(action);
            }

            //waitDialog.Hide();
            //waitDialog.Dispose();
            PrintStats(_sampledGraph, SampleListView, true);
            PrintReportButton.Enabled = true;
            SaveCsvButton.Enabled = true;


        }

        private void PrintStats(Graph g, ListView listView, bool isSample = false)
        {

            var nodes = new ListViewItem(new[] { "Nodes", g.NodeList.Count.ToString() });
            listView.Items.Add(nodes);
            var edges = new ListViewItem(new[] { "Edges", g.CountEdges().ToString() });
            listView.Items.Add(edges);
            g.CountNeighbors();
            var averageDegree = new ListViewItem(new[] { "Average degree", g.GetAverageDegree().ToString("F", CultureInfo.InvariantCulture) });
            listView.Items.Add(averageDegree);
            var maxDegree = new ListViewItem(new[] { "Max degree", g.NodeList.Max(x => x.Degree).ToString() });
            listView.Items.Add(maxDegree);
            var componentCount = new ListViewItem(new[] { "Components", g.CountComponents().ToString() });
            listView.Items.Add(componentCount);

            if (isSample)
            {
                this.Refresh();
                Debug.WriteLine("Computing Average clustering coefficient");
                g.CalculateClusteringCoefficient();
                var averageCc = new ListViewItem(new[] { "Average clustering c.", g.AverageCC.ToString("F", CultureInfo.InvariantCulture) });
                listView.Items.Add(averageCc);
                this.Refresh();
                Debug.WriteLine("Computing Diameter");
                var thread = Task.Run(() =>
                {
                    var distanceMatrix = FloydWarshallAlgorithm.GetResult(g.ToMatrix());
                    Debug.WriteLine("Distance Matrix complete");
                    g.DiameterInfo = GraphUtils.GetDiameter(distanceMatrix);
                    var diameter = new ListViewItem(new[] { "Graph diameter", g.DiameterInfo[2].ToString() });
                    Debug.WriteLine("Diameter complete");
                    Action action = () =>
                    {
                        listView.Items.Add(diameter);
                    };
                    this.BeginInvoke(action);
                });
            }
        }

        private void AlgorithmsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlgorithmsComboBox.SelectedIndex == 2)
            {
                RestartUpDown.Visible = true;
                RestartLabel.Visible = true;
                RestartLabel.Text = "Restart:";
                RestartUpDown.Value = new decimal(0.15);
            } else if (AlgorithmsComboBox.SelectedIndex == 3)
            {
                RestartUpDown.Visible = true;
                RestartLabel.Visible = true;
                RestartLabel.Text = "Fire prob.:";
                RestartUpDown.Value = new decimal(0.7);
            }
            else
            {
                RestartUpDown.Visible = false;
                RestartLabel.Visible = false;
            }

        }

        private void SaveCsvButton_Click(object sender, EventArgs e)
        {
            _sampledGraph.PrintToCSV($"{AlgorithmsComboBox.SelectedItem.ToString().Replace(" ","")}.csv");
        }

        private void PrintReportButton_Click(object sender, EventArgs e)
        {
            _sampledGraph.CalculateDegreeDistribution();
            _sampledGraph.PrintGraphInfoToFile("graphInfo.txt");
        }
    }
}
