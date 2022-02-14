using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsLab_1_0
{
    public partial class Laborotory_work_7 : Form
    {
        public Laborotory_work_7()
        {
            InitializeComponent();
        }

        private void L2_Click(object sender, EventArgs e)
        {
            L2_P.Visible = true;
            L3_P.Visible = false;
            L4_P.Visible = false;
            L5_P.Visible = false;
            Width = 610;
            Height = 770;
            L2.Location = new Point(90, 15);
            L3.Location = new Point(200, 15);
            L4.Location = new Point(310, 15);
            L5.Location = new Point(420, 15);
        }

        private void L3_Click(object sender, EventArgs e)
        {
            L2_P.Visible = false;
            L3_P.Visible = true;
            L4_P.Visible = false;
            L5_P.Visible = false;
            Width = 610;
            Height = 360;
            L2.Location = new Point(90, 15);
            L3.Location = new Point(200, 15);
            L4.Location = new Point(310, 15);
            L5.Location = new Point(420, 15);
        }

        private void L4_Click(object sender, EventArgs e)
        {
            L2_P.Visible = false;
            L3_P.Visible = false;
            L4_P.Visible = true;
            L5_P.Visible = false;
            Width = 610;
            Height = 475;
            L2.Location = new Point(90, 15);
            L3.Location = new Point(200, 15);
            L4.Location = new Point(310, 15);
            L5.Location = new Point(420, 15);
        }

        private void L5_Click(object sender, EventArgs e)
        {
            L2_P.Visible = false;
            L3_P.Visible = false;
            L4_P.Visible = false;
            L5_P.Visible = true;
            Width = 1045;
            Height = 820;
            L2.Location = new Point(307, 15);
            L3.Location = new Point(417, 15);
            L4.Location = new Point(527, 15);
            L5.Location = new Point(637, 15);
        }

        private void L2T1_Cal_Click(object sender, EventArgs e)
        {
            try
            {
                L2T1_l.Text = "";
                L2T1_Er.Text = "";
                L2T1.Height = 213;
                var resultInt = Functions.L2T1(new[] {L2T1_tb1.Text, L2T1_tb2.Text, L2T1_tb3.Text});
                foreach (var result in resultInt)
                {
                    L2T1_l.Text += result + " ";
                }
            }
            catch (Exception exception)
            {
                L2T1.Height = 300;
                L2T1_Er.Text = $@"An error occurred during the execution of the program: {exception.Message}";
                L2T1_l.Text = "0";
            }

            L2T1_tb1.Text = "";
            L2T1_tb2.Text = "";
            L2T1_tb3.Text = "";
        }

        private void L2T2_Check_Click(object sender, EventArgs e)
        {
            var answers = new int[L2T2.Controls.Count];
            for (var i = L2T2.Controls.Count - 1; i >= 0; i--)
            {
                if (!(L2T2.Controls[i] is GroupBox)) continue;
                for (var j = L2T2.Controls[i].Controls.Count - 1; j >= 0; j--)
                {
                    if (!(L2T2.Controls[i].Controls[j] is RadioButton)) continue;
                    var n = (RadioButton) L2T2.Controls[i].Controls[j];
                    if (!n.Checked) continue;
                    answers[L2T2.Controls.Count - 1 - i] = L2T2.Controls[i].Controls.Count - j;
                    break;
                }
            }

            L2T2_Ans.Text = $@"Right answers: {Functions.L2T2(answers.Take(L2T2.Controls.Count - 3).ToArray())}/{L2T2.Controls.Count - 3}";
        }

        private void L3T1_Cal_Click(object sender, EventArgs e)
        {
            try
            {
                L3T1_Ans.Text = "";
                L3T1_Err.Text = "";
                L3T1.Height = 149;
                L3T1_Ans.Text = $@"{Functions.L3T1(L3T1_tb1.Text):f5}";
            }
            catch (Exception exception)
            {
                L3T1.Height = 227;
                L3T1_Err.Text = $@"An error occurred during the execution of the program: {exception.Message}";
                L3T1_Ans.Text = "0";
            }

            L3T1_tb1.Text = "";
        }

        private void L3T2_Cal_Click(object sender, EventArgs e)
        {
            try
            {
                L3T2_Ans.Text = "";
                L3T2_Err.Text = "";
                L3T2.Height = 149;
                L3T2_Ans.Text = Functions.L3T2(L3T2_tb1.Text);
            }
            catch (Exception exception)
            {
                L3T2.Height = 227;
                L3T2_Err.Text = $@"An error occurred during the execution of the program: {exception.Message}";
                L3T2_Ans.Text = "0";
            }

            L3T2_tb1.Text = "";
        }

        private void L4T1_Build_Click(object sender, EventArgs e)
        {
            L4T1_OrM.Text = "";
            L4T1_ResM.Text = "";
            var rand = new Random();
            const int n = 11;
            const int m = 11;
            int[,] array = new int[n, m],
                result = new int[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    array[i, j] = rand.Next(0, 100);
                    L4T1_OrM.Text += (array[i, j] < 10 ? "  " : "") + array[i, j] + ", ";
                }

                L4T1_OrM.Text += "\n";
            }
            
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    result[i, j] = array[i, j] >= array[i, i] ? 1 : 0;
                    L4T1_ResM.Text += result[i, j] + ", ";
                }

                L4T1_ResM.Text += "\n";
            }
        }

        private void L5T1_Cal_Click(object sender, EventArgs e)
        {
            try
            {
                L5T1_Ans.Text = "";
                L5T1_Er.Text = "";
                L5T1.Height = 190;
                var answer = Functions.L5T1(new[] {L5T1_tb1.Text, L5T1_tb2.Text});
                L5T1_Ans.Text = $@"{answer[0]}, {answer[1]}";
            }
            catch (Exception exception)
            {
                L5T1.Height = 260;
                L5T1_Er.Text = $@"An error occurred during the execution of the program: {exception.Message}";
                L5T1_Ans.Text = "0";
            }

            L5T1_tb1.Text = "";
            L5T1_tb2.Text = "";
        }

        private void L5T2_Cal_Click(object sender, EventArgs e)
        {
            try
            {
                L5T2_Ans.Text = "";
                L5T2_Er.Text = "";
                L5T2.Height = 315;
                L5T2_Ans.Text = Functions.L5T2(L5T2_tb1.Text).ToString();
            }
            catch (Exception exception)
            {
                L5T2.Height = 430;
                L5T2_Er.Text = $@"An error occurred during the execution of the program: {exception.Message}";
                L5T2_Ans.Text = "0";
            }

            L5T2_tb1.Text = "";
        }

        private void L5T3_Cal_Click(object sender, EventArgs e)
        {
            try
            {
                L5T3_InM.Text = "";
                L5T3_OtM.Text = "";
                L5T3_Er.Text = "";
                L5T3.Height = 600;
                var result = Functions.L5T3(new[] {L5T3_tb1.Text, L5T3_tb2.Text});
                for (var i = 0; i < int.Parse(L5T3_tb1.Text); i++)
                {
                    for (var j = 0; j < int.Parse(L5T3_tb2.Text); j++)
                    {
                        L5T3_InM.Text += $@"{result[0][i, j]:f1}, ";
                    }

                    L5T3_InM.Text += "\r\n";
                }
                

                for (var i = 0; i < int.Parse(L5T3_tb1.Text); i++)
                {
                    for (var j = 0; j < int.Parse(L5T3_tb2.Text); j++)
                    {
                        L5T3_OtM.Text += $@"{result[1][i, j]:f1}, ";
                    }

                    L5T3_OtM.Text += "\r\n";
                }
                L5T3.Height += 16 * int.Parse(L5T3_tb2.Text);
            }
            catch (Exception exception)
            {
                L5T3.Height = 700;
                L5T3_Er.Text = $@"An error occurred during the execution of the program: {exception.Message}";
                L5T3_InM.Text = "0";
                L5T3_OtM.Text = "0";
            }

            L5T3_tb1.Text = "";
            L5T3_tb2.Text = "";
        }
    }


    public class Functions
    {
        public static int[] L2T1 (string[] inputStrings)
        {
            var inputInt = new int[inputStrings.Length];
            if (inputStrings.Where((t, i) => !int.TryParse(t, out inputInt[i])).Any())
            {
                throw new Exception("Invalid input");
            }
            if (inputInt[0] >= inputInt[1] && inputInt[1] >= inputInt[2])
                return new[] { inputInt[0] * 2, inputInt[1] * 2, inputInt[2] * 2};
            return new[] {Math.Abs(inputInt[0]),Math.Abs(inputInt[1]),Math.Abs(inputInt[2])};
        }

        public static int L2T2(int[] input)
        {
            var rightAnswers = new[] {1, 2, 3, 3, 2};
            return input.Select((t, i) => t == rightAnswers[i] ? 1 : 0).Sum();
        }

        public static double L3T1(string xString)
        {
            if (!int.TryParse(xString, out var x) || x <= 128)
                throw new Exception("Invalid input");
            double result = 1;
            for (var i = 1; i <= 128; i++)
            {
                if (i % 2 == 0)
                {
                    result *= x - i;
                }
                else
                {
                    result *= 1.0 / (x - i);
                }
            }

            return result;
        }


        public static string L3T2(string xString)
        {
            if (!int.TryParse(xString, out var number))
                throw new Exception("Invalid input");
            var divided = new ArrayList();
            var result = "";
            var isBellowZero = false;
            if (number < 0)
            {
                isBellowZero = true;
                number *= -1;
            }
            do
            {
                divided.Add(number % 16);
                number /= 16;
            } while (number >= 16);
            divided.Add(number % 16);
            divided.Reverse();
            foreach (int i in divided)
            {
                if (i < 10)
                {
                    result += Convert.ToString(i);
                }
                else
                {
                    switch (i)
                    {
                        case 10:
                            result += "A";
                            break;
                        case 11:
                            result += "B";
                            break;
                        case 12:
                            result += "C";
                            break;
                        case 13:
                            result += "D";
                            break;
                        case 14:
                            result += "E";
                            break;
                        case 15:
                            result += "F";
                            break;
                    }
                }
            }
            if (isBellowZero)
            {
                result = "1" + result;
            }
            else
            {
                result = "0" + result;
            }
            while (result.Length < 16)
            {
                result = result.Insert(1, "0");
            }
            return result;
        }

        public static double[] L5T1(string[] inputStrings)
        {
            var inputInt = new int[inputStrings.Length];
            if (inputStrings.Where((t, i) => !int.TryParse(t, out inputInt[i])).Any())
            {
                throw new Exception("Invalid input");
            }

            return new[] {Math.Pow(inputInt[0], 2) - Math.Pow(inputInt[1], 2), Math.Pow(inputInt[0], 3) - Math.Pow(inputInt[1], 3)};
        }

        public static double L5T2(string inputString)
        {
            var inputArrStr = inputString.Split('\r', '\n');
            var inputInt = new List<List<int>>();
            var counter = -1;
            foreach (var t1 in inputArrStr)
            {
                if (string.IsNullOrEmpty(t1)) continue;
                counter++;
                var inputArrSingleStr =  t1.Split(' ');
                inputInt.Add(new List<int>());
                foreach (var t in inputArrSingleStr)
                {
                    if (!int.TryParse(t, out var result))
                    {
                        throw new Exception("Invalid input");
                    }

                    inputInt[counter].Add(result);
                }
            }
            var count = inputInt.Count * inputInt[0].Count;
            var averageValue = inputInt.SelectMany(intLists => intLists).Sum(ints => (double) ints / count);
            var maxValue = inputInt.SelectMany(intLists => intLists).Prepend(int.MinValue).Max();
            return maxValue - averageValue;
        }

        public static double[][,] L5T3(string[] inputStrings)
        {
            var inputInt = new int[inputStrings.Length];
            var rand = new Random();
            if (inputStrings.Where((t, i) => !int.TryParse(t, out inputInt[i])).Any())
            {
                throw new Exception("Invalid input");
            }

            const int topEdge = 10;
            const int bottomEdge = -10;
            double[,] array = new double[inputInt[0], inputInt[1]],
                result = new double[inputInt[0], inputInt[1]];
            for (var i = 0; i < inputInt[0]; i++)
            {
                for (var j = 0; j < inputInt[1]; j++)
                {
                    array[i, j] = rand.NextDouble() * (topEdge - bottomEdge) + bottomEdge;
                }
            }
            for (var i = 0; i < inputInt[0]; i++)
            {
                for (var j = 0; j < inputInt[1]; j++)
                {
                    result[i, inputInt[1] - 1 - j] = array[i, j];
                }
            }

            return new[] {array, result};
        }
    }
}
