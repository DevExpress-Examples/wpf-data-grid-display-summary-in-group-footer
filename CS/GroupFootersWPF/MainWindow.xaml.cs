using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupFootersWPF
{
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            List<TestData> list = new List<TestData>();
            for (int i = 0; i < 200; i++)
                list.Add(new TestData()
                {
                    Text = "Text0 Row" + i,
                    Number0 = i,
                    Number1 = 100 - i,
                    Number2 = i % 10,
                    Group = i % 10
                });
            DataContext = list;
        }
    }

    public class TestData
    {
        public string Text { get; set; }
        public int Number0 { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Group { get; set; }
    }
}