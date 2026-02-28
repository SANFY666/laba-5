using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            textBoxInput.Clear();
            numericUpDownN.Value = 1;
            labelResultA.Text = "а)";
            labelResultB.Text = "б)";

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string[] stringsArray = textBoxInput.Lines;

            if (stringsArray.Length == 0)
            {
                MessageBox.Show("напиши щось");
                return;
            }

            // кількість однакових рядків 
            int duplicateCount = 0;
            var groupedStrings = stringsArray.GroupBy(s => s);

            foreach (var group in groupedStrings)
            {
                if (group.Count() > 1)
                {
                    duplicateCount += group.Count();
                }
            }
            labelResultA.Text = $"Кількість однакових рядків (разом): {duplicateCount}";

            // кількість рядків що починаються з n однакових символів
            int n = (int)numericUpDownN.Value;
            int startsWithNIdenticalCount = 0;

            foreach (string str in stringsArray)
            {
                if (str.Length >= n)
                {
                    bool isIdentical = true;
                    char firstChar = str[0];

                    // перевірка чи перші n символів збігаються з першим
                    for (int i = 1; i < n; i++)
                    {
                        if (str[i] != firstChar)
                        {
                            isIdentical = false;
                            break;
                        }
                    }

                    if (isIdentical)
                    {
                        startsWithNIdenticalCount++;
                    }
                }
            }
            labelResultB.Text = $"Рядків, що починаються з {n} однакових символів: {startsWithNIdenticalCount}";
        }
    }
}
