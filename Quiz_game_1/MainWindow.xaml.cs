using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace Quiz_game_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<int> lvl1_QuestionNumebers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> lvl2_QuestionNumebers = new List<int> { 1, 2 , 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        List<int> lvl3_QuestionNumebers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19,20 };
        int qNum = 0;
        int qNumlvl2 = 0;
        int qNumlvl3 = 0;
        int score;
        int lvl1;
        int lvl2;
        int lvl3;
        int lvl1_timer = 70;
        int lvl2_timer = 50;
        int lvl3_timer = 45;
        int scoreS1 = 0;
        int scoreS2 = 0;
        int scoreS3 = 0;

        DispatcherTimer dtr = new DispatcherTimer();
        DispatcherTimer dtr2 = new DispatcherTimer();
        DispatcherTimer dtr3 = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
          
            StartGame();
            NextQuestion();
            Imagebg.Source = new BitmapImage(new Uri("quiz_game_logo-01.png", UriKind.Relative));

        }

        private void checkanswer(object sender, RoutedEventArgs e)
        {
           
            Button senderButton = sender as Button;
          
           
            if (lvlTxt.Text.Equals("LEVEL 1"))
            {
                if (senderButton.Tag.ToString() == "1")
                {
                    correcteffect();
                    score++;
                  
                }
                else
                {
                    wrongeffect();  
                }
                if (qNum < 0)
                {
                    qNum = 0;
                }
                else
                {
                    qNum++;
                }
                scoreLabel.Content = "Score: " + score;
                NextQuestion();
                [System.Runtime.InteropServices.DllImport("winmm.dll")]
                static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

            }
            else if(lvlTxt.Text.Equals("LEVEL 2"))
            {
                if (senderButton.Tag.ToString() == "1")
                {
                    correcteffect();
                    score+=2;
                }
                else
                {
                    wrongeffect();
                    if(score == 0)
                    {
                        score = 0;
                    }
                    else
                    {
                        score -= 1;
                    }
                  
                }
                if (qNumlvl2 < 0)
                {
                    qNumlvl2 = 0;
                }
                else
                {
                    qNumlvl2++;
                }
                scoreLabel.Content = "Score: " + score;
                lvl2Question();
            }
            else if (lvlTxt.Text.Equals("LEVEL 3"))
            {
                if (senderButton.Tag.ToString() == "1")
                {
                      correcteffect();
                    score += 2;

                }
                else
                {
                    wrongeffect();
                    if (score == 0)
                    {
                        score = 0;
                    }
                    else
                    {
                        score -= 1;
                    }

                }
                if (qNumlvl3 < 0)
                {
                    qNumlvl3 = 0;
                }
                else
                {
                    qNumlvl3++;
                }
                scoreLabel.Content = "Score: " + score;
                lvl3question();
            }

        }
       private void RGame()
        {
            ans1.IsEnabled = true;
            ans2.IsEnabled = true;
            ans3.IsEnabled = true;
            ans4.IsEnabled = true;
            score = 0;
            qNum = 0;
            qNumlvl2 = 0;
            qNumlvl3 = 0;
            lvl2_timer = 50;
            lvl1_timer = 70;
            lvl3_timer = 45;
            lvl1 = 0;
            lvl2 = 0;
            lvl3 = 0;
            dtr.Tick -= tickerlvl1;
            dtr2.Tick -= tickerlvl2;
            dtr3.Tick -= tickerlvl3;
            if (lvlTxt.Text.Equals("LEVEL 1"))
            {
                Dtimerlvl1();
                NextQuestion();
            }
            else if (lvlTxt.Text.Equals("LEVEL 2"))
            {
                lvl2Start();
            }
            else if (lvlTxt.Text.Equals("LEVEL 3"))
            {
               lvl3Start();
            }
        }
        private void NextQuestion() 
        {
            level1();
            
            foreach(var x in myGrid.Children.OfType<Button>())
            {
                x.Tag = 0;
               
            }
            switch (lvl1)
            {
                case 1:
                    
                    QuestionText.Text = "What is the color of an emerald";

                    ans1.Content = "Green";
                    ans2.Content = "Indigo";
                    ans3.Content = "yellow";
                    ans4.Content = "orange";

                    ans1.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                        break;

                case 2:
                    
                    QuestionText.Text = "What do caterpillars turn into?";

                    ans1.Content = "Flies";
                    ans2.Content = "Butterfly";
                    ans3.Content = "Bugs";
                    ans4.Content = "Fireflies";

                    ans2.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                    break;

                case 3:

                    QuestionText.Text = "How many days are in a year?";

                    ans1.Content = "365";
                    ans2.Content = "356";
                    ans3.Content = "366";
                    ans4.Content = "357";

                    ans1.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                    break;
                case 4:

                    QuestionText.Text = "What is the largest mammal in the world?";

                    ans1.Content = "Shark";
                    ans2.Content = "Gorilla";
                    ans3.Content = "Whale";
                    ans4.Content = "Giraffe";

                    ans3.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                    break;
                case 5:

                    QuestionText.Text = "Who was the first Philippine President?";

                    ans1.Content = "Andres Bonifacio";
                    ans2.Content = "Emilio Aguinaldo";
                    ans3.Content = "Elpidio Quirino";
                    ans4.Content = "Manual Quezon";

                    ans2.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                    break;
                case 6:

                    QuestionText.Text = "What is the name of molten rock after a volcanic eruption?";

                    ans1.Content = "Ash";
                    ans2.Content = "Lava";
                    ans3.Content = "Red water";
                    ans4.Content = "Magma";

                    ans2.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                    break;
                case 7:

                    QuestionText.Text = "Who invented the telephone?";

                    ans1.Content = "Alexander Grehem Bell";
                    ans2.Content = "Alexander The Great";
                    ans3.Content = "Alexander Graham Bell";
                    ans4.Content = "Alexander Greham Ball";

                    ans3.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                    break;
                case 8:

                    QuestionText.Text = "Who painted the Mona Lisa?";

                    ans1.Content = "Leonardo DeCaprio";
                    ans2.Content = "Leonardo DeVinci";
                    ans3.Content = "Leonardo DaVinci";
                    ans4.Content = "Leonardo DeVisible";

                    ans3.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                    break;
                case 9:

                    QuestionText.Text = "What is the largest continent?";

                    ans1.Content = "Russia";
                    ans2.Content = "Antartica ";
                    ans3.Content = "Africa";
                    ans4.Content = "Asia ";

                    ans4.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                    break;
                case 10:

                    QuestionText.Text = "Who was the first man to step on the moon?";

                    ans1.Content = "Neil Armstrong";
                    ans2.Content = "Nail Armstrong";
                    ans3.Content = "Nill Armstrong";
                    ans4.Content = "Nell Armstrong";

                    ans1.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 2"))
                    {
                        lvl2Question();
                    }
                    break;

            }
           
           
        }
        private void lvl2Question()
        {
            level2();
            

            foreach (var x in myGrid.Children.OfType<Button>())
            {
                x.Tag = 0;

            }
            switch (lvl2)
            {
                case 1:
                    QuestionText.Text = "How many elements are there in Periodic Table?";
                    ans1.Content = "116";
                    ans2.Content = "114";
                    ans3.Content = "118";
                    ans4.Content = "112";

                    ans3.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 2:
                    QuestionText.Text = "What is the most abundant gas in the earths atmosphere?";
                    ans1.Content = "Oxygen";
                    ans2.Content = "Hillum";
                    ans3.Content = "Hydrogen ";
                    ans4.Content = "Nitrogen";

                    ans4.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 3:
                    QuestionText.Text = "On the periodic table what symbol stands for silver?";
                    ans1.Content = "AG";
                    ans2.Content = "SL";
                    ans3.Content = "SR";
                    ans4.Content = "AU";

                    ans1.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 4:
                    QuestionText.Text = "What is the biggest planet in our solar system?";
                    ans1.Content = "uranus";
                    ans2.Content = "jupiter";
                    ans3.Content = "saturn";
                    ans4.Content = "neptune";

                    ans2.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 5:
                    QuestionText.Text = "What type of lens is magnifying glass?";
                    ans1.Content = "Tempered ";
                    ans2.Content = "Confess";
                    ans3.Content = "Convex ";
                    ans4.Content = "Concave ";

                    ans3.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 6:
                    QuestionText.Text = "At what temperature are celcius and fahrenheit are equal?";
                    ans1.Content = "0";
                    ans2.Content = "36";
                    ans3.Content = "37.5";
                    ans4.Content = "-40";

                    ans4.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 7:
                    QuestionText.Text = "What is the largest type of bigcat in the world?";
                    ans1.Content = "Panther";
                    ans2.Content = "Tiger ";
                    ans3.Content = "Cheetah ";
                    ans4.Content = "Lion ";

                    ans2.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 8:
                    QuestionText.Text = "Pure water has pH level of around ?";
                    ans1.Content = "7";
                    ans2.Content = "10";
                    ans3.Content = "17";
                    ans4.Content = "0";

                    ans1.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 9:
                    QuestionText.Text = "What is 1/2 of half of 40??";
                    ans1.Content = "0 ";
                    ans2.Content = "5";
                    ans3.Content = "10 ";
                    ans4.Content = "20 ";

                    ans3.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 10:
                    QuestionText.Text = "How many minutes are in 6 hours?";
                    ans1.Content = "360";
                    ans2.Content = "36 ";
                    ans3.Content = "600 ";
                    ans4.Content = "60 ";

                    ans1.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 11:
                    QuestionText.Text = "What is the name of the biggest technology company in south korea?";
                    ans1.Content = "Samsung ";
                    ans2.Content = "Nokia";
                    ans3.Content = "Apple ";
                    ans4.Content = "Samsan ";

                    ans1.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 12:
                    QuestionText.Text = "Which country invented ice cream?";
                    ans1.Content = "Japan";
                    ans2.Content = "China ";
                    ans3.Content = "Alaska ";
                    ans4.Content = "Switzerland ";

                    ans2.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 13:
                    QuestionText.Text = "What country has the most natural lake?";
                    ans1.Content = "Thailand ";
                    ans2.Content = "Myanmar ";
                    ans3.Content = "Canada ";
                    ans4.Content = "Philippines";

                    ans3.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 14:
                    QuestionText.Text = "What is the largest part of the brain?";
                    ans1.Content = "cerebellum ";
                    ans2.Content = "foramen magnum";
                    ans3.Content = "cerebrum ";
                    ans4.Content = "brain stem";

                    ans3.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
                case 15:
                    QuestionText.Text = "He developed the theory of relativity?";
                    ans1.Content = "Isaac Newton";
                    ans2.Content = "Albert Einstein";
                    ans3.Content = "Charles Darwin";
                    ans4.Content = "Blaise Pascal";

                    ans2.Tag = "1";
                    if (lvlTxt.Text.Equals("LEVEL 3"))
                    {
                        lvl3question();
                    }
                    break;
            }
        }

        private void lvl3question()
        {
            level3();


            foreach (var x in myGrid.Children.OfType<Button>())
            {
                x.Tag = 0;

            }
            switch (lvl3)
            {
                case 1:
                    QuestionText.Text = "Who is the maker of bitcoin?";
                    ans1.Content = "Satoshi Nakamoto";
                    ans2.Content = "Vitalik Buterin";
                    ans3.Content = "Arthur Britto";
                    ans4.Content = "Ripple Labs";

                    ans1.Tag = "1";
                    break;
                case 2:
                    QuestionText.Text = "A year ago Jack was 5 times younger than his father, and in 4 years he will be only 3 times younger than his father. How old is Jack now?";
                    ans1.Content = "5";
                    ans2.Content = "6";
                    ans3.Content = "7";
                    ans4.Content = "8";

                    ans2.Tag = "1";
                    break;
                case 3:
                    QuestionText.Text = "The day before yesterday, Jack had a birthday. The day after tomorrow will be Tuesday, What day of the week was Jack's birthday?";
                    ans1.Content = "Tuesday";
                    ans2.Content = "Saturday";
                    ans3.Content = "Friday";
                    ans4.Content = "Monday";

                    ans3.Tag = "1";
                    break;
                case 4:
                    QuestionText.Text = "Which word below means the same or about the same as “caprice”?";
                    ans1.Content = "5.30";
                    ans2.Content = "25.00";
                    ans3.Content = "12.25";
                    ans4.Content = "25.5";

                    ans4.Tag = "1";
                    break;
                case 5:
                    QuestionText.Text = "What is the next number in the sequence? 3,54,204,461,833,1328,1954,?";
                    ans1.Content = "2808";
                    ans2.Content = "2706";
                    ans3.Content = "2758";
                    ans4.Content = "2719";

                    ans1.Tag = "1";
                    break;
                case 6:
                    QuestionText.Text = "Who first discovered America?";
                    ans1.Content = "Leif Erikson";
                    ans2.Content = "Mark Meneses";
                    ans3.Content = "Zabel Lusineh";
                    ans4.Content = "Karine Arevik";

                    ans1.Tag = "1";
                    break;
                case 7:
                    QuestionText.Text = " Who was the ancient Greek god of medicine?";
                    ans1.Content = "Apollo";
                    ans2.Content = "Hippocrates";
                    ans3.Content = "Hygieia";
                    ans4.Content = "Asclepius";

                    ans4.Tag = "1";
                    break;
                case 8:
                    QuestionText.Text = "Where does the primary photo chemical reaction occur in chloroplast?";
                    ans1.Content = "Photosystem";
                    ans2.Content = "Quantasome";
                    ans3.Content = "Chloroplasts";
                    ans4.Content = "Photosynthetic";

                    ans2.Tag = "1";
                    break;
                case 9:
                    QuestionText.Text = "In which year did Hitler commit suicide?";
                    ans1.Content = "1923";
                    ans2.Content = "1941";
                    ans3.Content = "1954";
                    ans4.Content = "1945";

                    ans4.Tag = "1";
                    break;
                case 10:
                    QuestionText.Text = "When did the first Space Shuttle go into space?";
                    ans1.Content = "4/14/1981";
                    ans2.Content = "4/13/1981";
                    ans3.Content = "4/12/1981";
                    ans4.Content = "4/11/1981";

                    ans3.Tag = "1";
                    break;
                case 11:
                    QuestionText.Text = "The ___________ forms the relatively cool, brittle plates of plate tectonics.";
                    ans1.Content = "Lithosphere";
                    ans2.Content = "Astrosphere";
                    ans3.Content = "Asthenosphere";
                    ans4.Content = "Eosphere";

                    ans1.Tag = "1";
                    break;
                case 12:
                    QuestionText.Text = "The simplest form of 1.5 : 2.5 is..?";
                    ans1.Content = "6 : 10";
                    ans2.Content = "15 : 25";
                    ans3.Content = "0.75 : 1.25";
                    ans4.Content = "3 : 5";

                    ans4.Tag = "1";
                    break;
                case 13:
                    QuestionText.Text = "What is Basketball court dimensions in feet??";
                    ans1.Content = "91.75ft";
                    ans2.Content = "91.76ft";
                    ans3.Content = "91.86ft ";
                    ans4.Content = "91.85ft";

                    ans3.Tag = "1";
                    break;
                case 14:
                    QuestionText.Text = "_______ is the process of finding errors and fixing them within a program.";
                    ans1.Content = "Debugging";
                    ans2.Content = "Executing";
                    ans3.Content = "Scanning";
                    ans4.Content = "Compiling";

                    ans1.Tag = "1";
                    break;
                case 15:
                    QuestionText.Text = "Name the extravagant period of art and architecture prevalent in Europe during most of the 17th century";
                    ans1.Content = "Renaissance";
                    ans2.Content = "Baroque";
                    ans3.Content = "Classical";
                    ans4.Content = "Medieval";

                    ans2.Tag = "1";
                    break;
                case 16:
                    QuestionText.Text = "Which of the languages below are used to code a robot?";
                    ans1.Content = "Machine Learning";
                    ans2.Content = "Java";
                    ans3.Content = "Computer Vision";
                    ans4.Content = "Python";

                    ans4.Tag = "1";
                    break;
                case 17:
                    QuestionText.Text = "When was the first psychology laboratory founded?";
                    ans1.Content = "1874";
                    ans2.Content = "1876";
                    ans3.Content = "1875";
                    ans4.Content = "1877";

                    ans3.Tag = "1";
                    break;
                case 18:
                    QuestionText.Text = "What is the name of the longest river in Africa?";
                    ans1.Content = "Nile";
                    ans2.Content = "Amazon";
                    ans3.Content = "Yangtze";
                    ans4.Content = "Mississippi";

                    ans1.Tag = "1";
                    break;
                case 19:
                    QuestionText.Text = "What is the fifth planet from the sun?";
                    ans1.Content = "Mars";
                    ans2.Content = "Jupiter";
                    ans3.Content = "Uranus";
                    ans4.Content = "Venus";

                    ans3.Tag = "1";
                    break;
                case 20:
                    QuestionText.Text = "What is responsible for the current to flow?";
                    ans1.Content = "Protons";
                    ans2.Content = "Nucleus";
                    ans3.Content = "Protons and Electrons";
                    ans4.Content = "Electrons";

                    ans4.Tag = "1";
                    break;

            }
        }
        private void StartGame()
        {
          pausebtn.Visibility = Visibility.Collapsed;
            restartbtn.Visibility = Visibility.Collapsed;
            QuitBtn.Visibility = Visibility.Collapsed;
            Playbtn.Visibility = Visibility.Collapsed;
            var randonmlist = lvl1_QuestionNumebers.OrderBy(a => Guid.NewGuid()).ToList();
            sound.Source = new Uri(@"C:\Users\Gab\source\repos\Quiz_game_1\Quiz_game_1\Bensound_ _Funky Element_ - Royalty Free Music.wav");
            sound.Position = new TimeSpan(0, 0, 1);
            sound.Play();
            lvl1_QuestionNumebers = randonmlist;
           
           
        }
        private void lvl2Start()
        {
            lvlTxt.Text = "LEVEL 2";
            score = 0;
           
            scoreLabel.Content = "Score: " + score.ToString();
            Dtimerlvl2();
            var randomlist = lvl2_QuestionNumebers.OrderBy(a => Guid.NewGuid()).ToList();
            lvl2_QuestionNumebers=randomlist;
            lvl2Question();
            ans1.IsEnabled = true;
            ans2.IsEnabled = true;
            ans3.IsEnabled = true;
            ans4.IsEnabled = true;
        }
        private void lvl3Start()
        {
            lvlTxt.Text = "LEVEL 3";
            score = 0;

            scoreLabel.Content = "Score: " + score.ToString();
            Dtimerlvl3();
            var randomlist = lvl3_QuestionNumebers.OrderBy(a => Guid.NewGuid()).ToList();
            lvl3_QuestionNumebers = randomlist;
            lvl3question();
            ans1.IsEnabled = true;
            ans2.IsEnabled = true;
            ans3.IsEnabled = true;
            ans4.IsEnabled = true;
        }
        private void Dtimerlvl1() 
        {
                dtr.Interval = new TimeSpan(0,0,1);
                dtr.Tick += tickerlvl1;
                dtr.Start();
          
        }
        private void tickerlvl1(object sender, EventArgs e)
        {
                LblTime.Content = lvl1_timer--.ToString();
                if (lvl1_timer < 0)
                {
                    dtr.Stop();
                    ans1.IsEnabled = false;
                    ans2.IsEnabled = false;
                    ans3.IsEnabled = false;
                    ans4.IsEnabled = false;
                if (MessageBox.Show("You dont have enough time, you want to try it again?", "Confirmation", MessageBoxButton.YesNo)
                   == MessageBoxResult.Yes)
                {

                    RGame();

                }
                else
                {
                    Environment.Exit(0);
                }
                
            }
          
        }
        private void Dtimerlvl2()
        {
            dtr2.Interval = new TimeSpan(0, 0, 1);
            dtr2.Tick += tickerlvl2;
            dtr2.Start();

        }
        private void tickerlvl2(object sender, EventArgs e)
        {
            LblTime.Content = lvl2_timer--.ToString();
            if (lvl2_timer < 0)
            {
                dtr2.Stop();
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
                if (MessageBox.Show("You dont have enough time, you want to try it again?", "Confirmation", MessageBoxButton.YesNo)
                     == MessageBoxResult.Yes)
                {

                    RGame();

                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
        private void Dtimerlvl3()
        {

            dtr3.Interval = new TimeSpan(0, 0, 1);
            dtr3.Tick += tickerlvl3;
            dtr3.Start();
        }
        private void tickerlvl3(object sender, EventArgs e)
        {

            LblTime.Content = lvl3_timer--.ToString();
            if (lvl3_timer < 0)
            {
                dtr3.Stop();
              ans1.IsEnabled = false;
               ans2.IsEnabled = false;
              ans3.IsEnabled = false;
               ans4.IsEnabled = false;
                if (MessageBox.Show("You dont have enough time, you want to try it again?", "Confirmation", MessageBoxButton.YesNo)
                   == MessageBoxResult.Yes)
                {

                    RGame();

                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
        private void level1() 
        {
           
            if (qNum < lvl1_QuestionNumebers.Count)
            {
                lvl1 = lvl1_QuestionNumebers[qNum];
            }
            else if (score > 8)
            {
                scoreS1 = score;
                dtr.Stop();
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
                MessageBox.Show("Congratulation, you passed the first level, your score is " + score.ToString() + ", Get ready on the second level", "Confirmation", MessageBoxButton.OK);
              
               lvl2Start();
                   
                
            }
            else if(score <= 7) 
            {
                dtr.Stop();
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
                if (MessageBox.Show("You failed the first level your score is " + score.ToString() + ", you want to try it again?", "Confirmation", MessageBoxButton.YesNo)
                   == MessageBoxResult.Yes)
                {
                  
                    RGame();

                }
                else
                {
                    Environment.Exit(0);
                }
                score = 0;
                scoreLabel.Content = "Score: "+score.ToString();
            }
            
        }
        private void level2()
        {
            if (qNumlvl2 < lvl2_QuestionNumebers.Count)
            {
                lvl2 = lvl2_QuestionNumebers[qNumlvl2];
            }
            else if (score >= 25)
            {
                scoreS2 = score;
                dtr2.Stop();
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
                MessageBox.Show("Congratulation, you passed the Second level, your score is " + score.ToString() + ", Get ready on the third level", "Confirmation", MessageBoxButton.OK);

                lvl3Start();

            }
            else if (score <= 24)
            {
                dtr2.Stop();
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
                if (MessageBox.Show("You Failed the Second level your score is " + score.ToString() + ", You want it to try again?", "Confirmation", MessageBoxButton.YesNo)
                  == MessageBoxResult.Yes)
                {
                    RGame();
                }
                else
                {
                    Environment.Exit(0);
                }
                score = 0;
                scoreLabel.Content = "Score: " + score.ToString();

            }
            else
            {
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
            }
        }
        private void level3()
        {
            if (qNumlvl3 < lvl3_QuestionNumebers.Count)
            {
                lvl3 = lvl3_QuestionNumebers[qNumlvl3];
            }
            else if (score >= 27)
            {
                scoreS3 = score;
                dtr3.Stop();
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
                MessageBox.Show("Your score summary are:  \n LEVEL 1: " + scoreS1.ToString() + "\n LEVEL 2: " + scoreS2.ToString() + "\n LEVEL 3: " + scoreS3.ToString() , "Game Summary");
                Environment.Exit(0);


            }
            else if (score <= 26)
            {
                scoreS3 = score;
                dtr3.Stop();
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
                MessageBox.Show("Your score summary are:  \n LEVEL 1: " + scoreS1.ToString() + "\n LEVEL 2: " + scoreS2.ToString() + "\n LEVEL 3: " + scoreS3.ToString() , "Game Summary");
                Environment.Exit(0);
            }
            else
            {
              ;
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
            }
        }

        private void key(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Playbtn.Visibility = Visibility.Visible;
                Imagebg.Source = new BitmapImage(new Uri("instructions-05.png", UriKind.Relative));
           
                
            }
        }
       

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                dtr.Stop();
                pausebtn.Visibility = Visibility.Visible;
                restartbtn.Visibility = Visibility.Visible;
                QuitBtn.Visibility = Visibility.Visible;
                Imagebg.Source = new BitmapImage(new Uri("pausebg-03.png", UriKind.Relative));
            }
        }

        private void pause(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
               dtr.Stop();
                QuitBtn.Visibility = Visibility.Visible;
                pausebtn.Visibility = Visibility.Visible;
                restartbtn.Visibility = Visibility.Visible;
               Imagebg.Source = new BitmapImage(new Uri("pausebg-03.png", UriKind.Relative));
               
            }
        }

        private void Resume(object sender, RoutedEventArgs e)
        {
            ButtonSoundEffect();
            dtr.Start();
            Imagebg.Source = null;
            pausebtn.Visibility = Visibility.Collapsed;
            restartbtn.Visibility = Visibility.Collapsed;
            QuitBtn.Visibility= Visibility.Collapsed;
        }

        private void wrongeffect()
        {
            var wrong = new System.Windows.Media.MediaPlayer();
            wrong.Open(new System.Uri(@"C:\Users\Gab\source\repos\Quiz_game_1\Quiz_game_1\wrongSFX.wav"));
            wrong.Play();
        }
        private void correcteffect()
        {
            var correct = new System.Windows.Media.MediaPlayer();
            correct.Open(new System.Uri(@"C:\Users\Gab\source\repos\Quiz_game_1\Quiz_game_1\correctSFX.wav"));
            correct.Play();
        }
        private void ButtonSoundEffect()
        {
            var button = new System.Windows.Media.MediaPlayer();
            button.Open(new System.Uri(@"C:\Users\Gab\source\repos\Quiz_game_1\Quiz_game_1\Menu Game Button Click Sound Effect.wav"));
            button.Play();
        }

        private void RestartGame(object sender, RoutedEventArgs e)
        {
            ButtonSoundEffect();
            dtr.Start();
            Imagebg.Source = null;
            pausebtn.Visibility = Visibility.Collapsed;
            restartbtn.Visibility = Visibility.Collapsed;
            QuitBtn.Visibility = Visibility.Collapsed;
            RGame();

          
        }
        private void QuitGame(object sender, RoutedEventArgs e)
        {
            ButtonSoundEffect();
            if (MessageBox.Show("Are you sure you want to quit the game?", "Confirmation", MessageBoxButton.YesNo)
                  == MessageBoxResult.Yes)
            {
           
                Environment.Exit(0);

            }

        }
        private void PlayGame(object sender, RoutedEventArgs e)
        {
            ButtonSoundEffect();
            Dtimerlvl1();
           Playbtn.Visibility = Visibility.Collapsed;
            Imagebg.Source = null;

        }
    }
    }
