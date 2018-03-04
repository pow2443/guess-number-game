using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
* T INFO200 A 
* Assignments(Guessing Number Game) 02/20/2018
* Professor : Dr. Chunming Gao
* Name : Hyeongwoo Park
* Comments : I took 3 hours per day for 7 days. 
* In this assignment, I had to understand mathematical algorithms to develop this program.
* There are so many algorithms to sort and find numbers.
* I tried to understand other algorithms to compare each argorithm in efficiency.
* the mathematical concept of the algorithms were not easy to understand, 
* but it was really good experience to practice understanding complex algorithms 
* 
*/
namespace guessing_number
{
    public partial class Form1 : Form
    {

        private int[] numbers = new int[1000];
        private Random random = new Random();
        public int count = 0;



        public Form1()
        {
            InitializeComponent();
            inputTextBox.Enabled = false;
            startButton.Enabled = true;
            submitButton.Enabled = false;
            

        }

        //initializing all conditions 
        private void startButton_Click(object sender, EventArgs e)
        {
            
            inputTextBox.Enabled = true;
            startButton.Enabled = false;
            submitButton.Enabled = true;
            count = 0;

            getArray();
            bubbleSort();
            MessageBox.Show("Guess a number between 1 ~ 5000 and then submit a number.");
            inputTextBox.Focus();


        }
        //getting numbers and save the numbers in the array
        private void getArray()
        {
            for (int i = 0; i < 1000; i = i + 1)
            {

                numbers[i] = random.Next(1, 5001);

                for (int j = 0; j < i; j = j + 1)
                {
                    if (numbers[i] == numbers[j])
                    {
                        i = i - 1;
                        break;
                    }

                }

            }
        }

        //Bubble Sort 
        private void bubbleSort()
        {

            int temp = 0;
            //decreasing length of array
            for (int i = (numbers.Length - 1); i > 0; i = i - 1)
            {
                //sorting from first element
                for (int j = 0; j < i; j = j + 1)
                {

                    if (numbers[j] > numbers[j + 1])
                    {

                        temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;


                    }


                }

            }

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            
            Boolean gameover=true;

            //catching exception condition 
            try
            {
                //calling a guessNum that has binary search
                gameover = guessNum(inputTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Enter valid number");
            }

            //gameover
            if (gameover == true)
            {
                MessageBox.Show("Wrong guess and try again, you have " + (count + 1) + " / 5 chances.");
                inputTextBox.Text = "";
                inputTextBox.Focus();
                //counting chance
                count = count + 1;
            }

            //if there is not a same num, showing message box.
            if (count == 5)
            {
                MessageBox.Show("Game Over, there is not your guesssing number\n" +
                        "Start again!");
                inputTextBox.Enabled = false;
                startButton.Enabled = true;
                submitButton.Enabled = false;
                inputTextBox.Text = "";
                count = 0;

            }



        }

        //Binary Search 
        private Boolean guessNum(string guessedNum)
        {

            int min = 0;
            int max = numbers.Length - 1;
            int middle = 0;
            int target = int.Parse(guessedNum);
            bool gameover = true;

            numbers[2] = 2;
                //binary search
                for (; max >= min;)
                {
                    //middle is calculated with maximum index and minmum index.
                    middle = (max + min) / 2;

                    if (target == numbers[middle])
                    {

                        gameover = false;
                        MessageBox.Show("Congratulations! You have selected a winning number!");
                        inputTextBox.Enabled = false;
                        startButton.Enabled = true;
                        inputTextBox.Text = "";
                        submitButton.Enabled = false;
                        //return finding number result
                        return gameover;
                        
                    }
                    else if (target < numbers[middle])
                    {

                        max = middle - 1;

                    }
                    else if (target > numbers[middle])
                    {

                        min = middle + 1;

                    }

                    

                }


            //return finding number result
            return gameover;
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
