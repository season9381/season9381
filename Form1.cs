namespace WinFormsAppTest1
{
    public partial class Form1 : Form
    {
        private bool isFirstInput = true;
        private bool isFirstToData = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("전자 계산기 시작1");
        }

        private void AppendTextToTextBox(TextBox textBox, string text)
        {
            textBox.Text += text;
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TextBox targetTextBox = isFirstInput ? textBox1 : textBox3;
            AppendTextToTextBox(targetTextBox, button.Text);
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox2.Text = button.Text;
            isFirstInput = false;
            textBox3.Text = "";
            if (isFirstToData) textBox1.Text = textBox4.Text;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            double firstNumber = double.Parse(textBox1.Text);
            double secondNumber = double.Parse(textBox3.Text);
            string operation = textBox2.Text;
            double result = 0;

            //컴퓨터의 이진 부동 소수점 표현 방식임.
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                        MessageBox.Show("Cannot divide by zero!");
                    break;
            }

            textBox4.Text = result.ToString();
            isFirstToData = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            isFirstInput = true;
            isFirstToData = false;
        }

    }
}
