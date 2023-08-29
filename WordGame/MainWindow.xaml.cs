using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
        public partial class MainWindow : Window
        {
            private List<string> wordlist;
            private string DisplayedWord;
            private Random random;

            public MainWindow()
            {
                InitializeComponent();

                wordlist = new List<string>
            {
               "messi", "ronaldo", "kane", "gerrard", "lebron",
                "jordan", "son", "mourinho"
            };

                random = new Random();
            }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (wordlist.Count < 5)
            {
                MessageBox.Show("Not enough words to play. Please add more words.");
                return;
            }

            DisplayedWord = GetRandomWord();
            scrambledWordText.Text = ScrambleWord(DisplayedWord);
            userInputTextBox.Text = "";
        }


        private void CheckButton_Click(object sender, RoutedEventArgs e)
            {
                if (userInputTextBox.Text.ToLower() == DisplayedWord)
                {
                    MessageBox.Show("CORRECT");
                }
                else
                {
                    MessageBox.Show("INCORRECT");
                }
            }

            private string GetRandomWord()
            {
                int index = random.Next(wordlist.Count);
            string word = wordlist [index];
                wordlist.RemoveAt(index);
                return word;
            }

        private string ScrambleWord(string word)
        {
            char[] chars = word.ToCharArray();
            int n = chars.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }

            return new string(chars);
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            scrambledWordText.Text = "";
            userInputTextBox.Text = "";
        }
    }
    }


