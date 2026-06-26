using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO; 
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ai_chatttt
{ //start of namespace

    public partial class MainWindow : Window
    {//start of class


        //creating an instance for the class Array
        ArrayList reply = new ArrayList();
        List<TaskItem> tasks = new List<TaskItem>();
        ArrayList ignore = new ArrayList();
        user_name check_name = new user_name();
        QuizManager quiz = new QuizManager();
        ActivityLogger logger = new ActivityLogger();


        // variables
        string username = string.Empty;
        string pre_question = string.Empty;
        int counting = 0;



        public MainWindow()
        {

            InitializeComponent();
            LoadTasks();
            new respond(reply, ignore) { };


            //creating an instance for the class voice_greeting 
            //with an object name greet
            voice_greeting greet = new voice_greeting();

            //call the voice method
            greet.greet();
        }
        private DatabaseHelper database = new DatabaseHelper();

        //submit name  event handler



        private void submit_name(object sender, RoutedEventArgs e)
        {
            // check the user name
            username = check_name.submit_name(
                usernames_input,
                chats,
                username_error
            );

            // only continue if username is not empty
            if (username != "")
            {
                // Hide username page grid and show chat grid
                username_grid.Visibility = Visibility.Hidden;
                chat_grid.Visibility = Visibility.Visible;
            }
        }


        private void proceed(object sender, RoutedEventArgs e)
        {
            home_grid.Visibility = Visibility.Hidden;

            username_grid.Visibility = Visibility.Visible;
        }






        //send event handler
        private void send(object sender, RoutedEventArgs e)
        {
            // Get the question from the design and sanitize it
            string rawQuestion = question.Text.ToString().Trim();
            string input = question.Text.ToLower();
            // TASK KEYWORDS
            if (input.Contains("task") ||
                input.Contains("remind") ||
                input.Contains("reminder") ||
                input.Contains("2fa") ||
                input.Contains("two-factor") ||
                input.Contains("password"))
            {
                btnTasks_Click(null, null);

                error_method(
                    "ChatBot",
                    "It looks like you want help managing a cybersecurity task. I've opened the Task Assistant.");

                logger.AddLog("NLP: Task Assistant opened.");

                question.Clear();

                return;
            }
            // QUIZ KEYWORDS
            if (input.Contains("quiz") ||
                input.Contains("test") ||
                input.Contains("questions"))
            {
                btnQuiz_Click(null, null);

                error_method(
                    "ChatBot",
                    "I've opened the Cybersecurity Quiz.");

                logger.AddLog("NLP: Quiz opened.");

                question.Clear();

                return;
            }
            // ACTIVITY LOG KEYWORDS
            if (input.Contains("activity") ||
                input.Contains("log") ||
                input.Contains("what have you done"))
            {
                btnActivityLog_Click(null, null);

                logger.AddLog("NLP: Activity Log viewed.");

                question.Clear();

                return;
            }
            // HELP KEYWORDS
            if (input.Contains("help") ||
                input.Contains("commands"))
            {
                error_method(
                    "ChatBot",
                    "You can ask me to:\n\n" +
                    "- Add a task\n" +
                    "- Set a reminder\n" +
                    "- Start the quiz\n" +
                    "- Show my tasks\n" +
                    "- Show activity log");

                question.Clear();

                return;
            }


            if (string.IsNullOrWhiteSpace(rawQuestion))
            {
                error_method("ChatBot", "Please enter a question.");
                return;
            }

            // Remove special characters and clean the question
            string questions = RemoveSpecialCharacters(rawQuestion);

            // Show what the user typed 
            error_method(username, rawQuestion);


            //ai chats and auto_show_interest
            auto_show_interest();
            ai_check(questions);
        }

        //end for the username submit


        //start of ai_chat method
        private void ai_check(string questions)
        {


            // Check if user entered anything meaningful
            if (string.IsNullOrWhiteSpace(questions))
            {
                error_method("ChatBot", "Please enter a valid question.");
                question.Clear();
                return;
            }



            // Check if the question contains only special characters or empty after cleaning
            if (questions.Length == 0 || string.IsNullOrWhiteSpace(questions))
            {
                error_method("ChatBot", "I couldn't understand that.");
                question.Clear();
                return;
            }

            // Variables for processing
            string[] words = questions.ToLower().Split(new char[] { ' ', ',', '.', '?', '!', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            bool found = false;
            string message = string.Empty;
            Random indexer = new Random();
            List<string> per_word = new List<string>();
            List<string> answers_found = new List<string>();






            // Process each word
            foreach (string word in words)
            {
                // Skip very short words or ignored words
                if (word.Length < 3 || ignore.Contains(word.ToLower()))
                    continue;

                per_word.Clear();





                //start of interests




                if (word.Contains("interested"))
                {
                    string store_interests = string.Empty;
                    bool found_interest = false;

                    HashSet<string> currentInterests = new HashSet<string>();

                    foreach (string interest in words)
                    {
                        // CLEAN INPUT
                        string clean = interest.ToLower().Trim();
                        clean = Regex.Replace(clean, @"[^a-zA-Z0-9\s]", "");

                        // FILTER NOISE WORDS
                        if (!ignore.Contains(clean) && clean != "interested" && clean != "and" && clean != "in" && clean.Length >= 3)
                        {
                            found_interest = true;
                            currentInterests.Add(clean);
                        }
                    }


                    // prepare interests
                    store_interests = string.Join(", ", currentInterests);

                    if (found_interest && !string.IsNullOrWhiteSpace(store_interests))
                    {
                        string filename = "interested_topic.txt";
                        bool userFound = false;

                        if (File.Exists(filename))
                        {
                            string[] lines = File.ReadAllLines(filename);

                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (lines[i].StartsWith(username))
                                {
                                    userFound = true;

                                    //get all the interests
                                    string existing = lines[i].Replace(username + " interested in:", "").ToLower();

                                    HashSet<string> existingSet = new HashSet<string>(existing.Split(',').Select(x => x.Trim()).Where(x => x != ""));

                                    // remove dumplicates
                                    foreach (string item in currentInterests)
                                    {
                                        existingSet.Add(item);
                                    }

                                    string finalList = string.Join(", ", existingSet);

                                    lines[i] = username + " interested in: " + finalList;
                                    File.WriteAllLines(filename, lines);

                                    message += "great, i added " + store_interests + " to your interests and ";
                                    break;
                                }
                            }
                        }

                        if (!userFound)
                        {
                            File.AppendAllText(
                                filename,
                                username + " interested in: " + store_interests + "\n"
                            );

                            message += "great, i will remember that you are interested in " + store_interests + " and ";
                        }
                    }
                    else
                    {
                        message += "Please specify what you're interested in (e.g., 'I am interested in cybersecurity')";
                    }
                }



                //end of interests




                // Search for matching answers
                bool wordFound = false;
                foreach (string answer in reply)
                {
                    if (answer.ToLower().Contains(word))
                    {
                        wordFound = true;
                        per_word.Add(answer);
                    }
                }

                if (wordFound && per_word.Count > 0)
                {
                    found = true;
                    int indexing = indexer.Next(0, per_word.Count);
                    answers_found.Add(per_word[indexing]);
                }
            }

            // Show responses or error message
            if (found && answers_found.Count > 0)
            {
                // Remove duplicate answers
                answers_found = answers_found.Distinct().ToList();

                foreach (string per_answer in answers_found)
                {
                    message += per_answer + "\n";
                }

                error_method("ChatBot", message.TrimEnd('\n'));


                chats.ScrollIntoView(chats.Items[chats.Items.Count - 1]);
            }
            else
            {
                // when nothing is found
                string[] fallbackMessages = {
            "I'm sorry, I don't understand that. Could you rephrase your question?",
            "I didn't quite get that. Try asking about cyber security topics.",
            "Hmm, I'm not sure how to respond to that. Can you ask something else?",
            "I couldn't find an answer for that. Please ask about programming, security, or technology.",
            "My apologies, I don't have information on that topic yet."
        };

                Random random = new Random();
                string fallbackMessage = fallbackMessages[random.Next(fallbackMessages.Length)];
                error_method("ChatBot", fallbackMessage);
            }

            // Clear the input box
            question.Clear();


        }

        //end of ai_chat method




        //method to remove special characters
        private string RemoveSpecialCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            StringBuilder sanitized = new StringBuilder();

            foreach (char c in input)
            {
                // Keep letters, numbers, spaces, and basic punctuation
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '\'' || c == '-')
                {
                    sanitized.Append(c);
                }
                else
                {
                    // Replace other special characters with space
                    sanitized.Append(' ');
                }
            }

            // Clean up extra spaces and trim
            string result = sanitized.ToString();
            result = System.Text.RegularExpressions.Regex.Replace(result, @"\s+", " ").Trim();

            return result;
        }


        //end of method to remove special characters





        //method count to show interests randomly
        private void auto_show_interest()
        {
            //check if three times
            if (counting == 3)
            {
                //read the user's interests from file
                string filename = "interested_topic.txt";

                if (File.Exists(filename))
                {
                    string[] lines = File.ReadAllLines(filename);

                    //find the user's line
                    foreach (string line in lines)
                    {
                        if (line.StartsWith(username))
                        {
                            //get the interests part
                            int colonIndex = line.IndexOf("interested in:");
                            if (colonIndex >= 0)
                            {
                                string interests = line.Substring(colonIndex + 14).Trim();

                                //show reminder of interests
                                error_method("ChatBot", "Just a reminder, you are interested in " + interests + " and ");
                                ai_check(interests);
                                break;
                            }
                        }
                    }
                }

                //reset counting
                counting = 0;
            }
            else
            {
                //incrementing
                counting += 1;
            }
        }
        //end of count interest method






        // Updated error method with better formatting
        private void error_method(string name, string message)
        {
            // Create a border for chats
            Border messageBorder = new Border
            {
                Margin = new Thickness(0, 2, 0, 2),
                Padding = new Thickness(5, 3, 5, 3),
                CornerRadius = new CornerRadius(5)
            };

            // Set different background for user vs bot
            if (name.ToLower().Contains("chatbot") || name.ToLower().Contains("chat"))
            {// Light blue
                messageBorder.Background = new SolidColorBrush(Color.FromRgb(240, 248, 255));
                messageBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(173, 216, 230));
            }
            else
            {    // Light gray
                messageBorder.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
                messageBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            }
            messageBorder.BorderThickness = new Thickness(1);

            TextBlock messageText = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(2)
            };

            // Set color based on sender
            Brush nameColor = (name.ToLower().Contains("chatbot") || name.ToLower().Contains("chat")) ?
                              Brushes.DarkBlue : Brushes.DarkGreen;

            Brush messageColor = Brushes.Black;

            messageText.Inlines.Add(new Run
            {
                Text = name + ": ",
                Foreground = nameColor,
                FontWeight = FontWeights.Bold
            });

            messageText.Inlines.Add(new Run
            {
                Text = message,
                Foreground = messageColor
            });

            messageBorder.Child = messageText;
            chats.Items.Add(messageBorder);

            chats.ScrollIntoView(chats.Items[chats.Items.Count - 1]);
        }//end of error method

        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            ChatPanel.Visibility = Visibility.Visible;
            TaskPanel.Visibility = Visibility.Collapsed;
            QuizPanel.Visibility = Visibility.Collapsed;
            ActivityLogPanel.Visibility = Visibility.Collapsed;
        }
        private void btnTasks_Click(object sender, RoutedEventArgs e)
        {
            ChatPanel.Visibility = Visibility.Collapsed;
            TaskPanel.Visibility = Visibility.Visible;
            QuizPanel.Visibility = Visibility.Collapsed;
            ActivityLogPanel.Visibility = Visibility.Collapsed;
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            using (MySqlConnection connection = database.GetConnection())
            {
                connection.Open();

                string sql =
                    @"INSERT INTO Tasks
            (Title, Description, ReminderDate, Completed)
            VALUES
            (@title,@description,@reminder,@completed)";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@title", txtTaskTitle.Text);
                cmd.Parameters.AddWithValue("@description", txtTaskDescription.Text);

                if (dpReminder.SelectedDate.HasValue)
                    cmd.Parameters.AddWithValue("@reminder", dpReminder.SelectedDate.Value);
                else
                    cmd.Parameters.AddWithValue("@reminder", DBNull.Value);

                cmd.Parameters.AddWithValue("@completed", false);

                cmd.ExecuteNonQuery();
            }

            error_method(
                "ChatBot",
                $"Task '{txtTaskTitle.Text}' added successfully."
            );

            logger.AddLog($"Task Added: {txtTaskTitle.Text}");

            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
            dpReminder.SelectedDate = null;

            LoadTasks();
        }
        private void btnCompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem == null)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            TaskItem selectedTask = (TaskItem)TaskList.SelectedItem;

            selectedTask.Completed = true;

            TaskList.Items.Refresh();

            error_method("ChatBot",
                $"Task '{selectedTask.Title}' marked as completed.");
            logger.AddLog($"Task Completed: {selectedTask.Title}");
        }

        private void btnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem == null)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            TaskItem selectedTask = (TaskItem)TaskList.SelectedItem;

            tasks.Remove(selectedTask);

            TaskList.Items.Remove(selectedTask);

            error_method("ChatBot",
                $"Task '{selectedTask.Title}' deleted.");
            logger.AddLog($"Task Deleted: {selectedTask.Title}");
        }
        private void btnQuiz_Click(object sender, RoutedEventArgs e)
        {
            ChatPanel.Visibility = Visibility.Collapsed;
            TaskPanel.Visibility = Visibility.Collapsed;
            QuizPanel.Visibility = Visibility.Visible;
            ActivityLogPanel.Visibility = Visibility.Collapsed;

            quiz = new QuizManager();

            quiz.ShuffleQuestions();

            LoadQuestion();
            logger.AddLog("Cybersecurity Quiz Started");
        }

        private void LoadQuestion()
        {
            QuizQuestion q = quiz.Questions[quiz.CurrentQuestion];

            QuizQuestion.Text = $"Question {quiz.CurrentQuestion + 1}/{quiz.Questions.Count}\n\n{q.Question}";

            OptionA.Content = "A. " + q.OptionA;
            OptionB.Content = "B. " + q.OptionB;

            OptionA.IsChecked = false;
            OptionB.IsChecked = false;
            OptionC.IsChecked = false;
            OptionD.IsChecked = false;

            // If it's a True/False question
            if (string.IsNullOrWhiteSpace(q.OptionC) &&
                string.IsNullOrWhiteSpace(q.OptionD))
            {
                OptionC.Visibility = Visibility.Collapsed;
                OptionD.Visibility = Visibility.Collapsed;
            }
            else
            {
                OptionC.Visibility = Visibility.Visible;
                OptionD.Visibility = Visibility.Visible;

                OptionC.Content = "C. " + q.OptionC;
                OptionD.Content = "D. " + q.OptionD;
            }
            QuizFeedback.Text = "";

            QuizFeedback.Visibility = Visibility.Collapsed;

            btnNextQuestion.Visibility = Visibility.Collapsed;

            btnSubmitQuiz.IsEnabled = true;
        }

        private void btnSubmitQuiz_Click(object sender, RoutedEventArgs e)
        {
            char selectedAnswer = ' ';

            if (OptionA.IsChecked == true)
                selectedAnswer = 'A';
            else if (OptionB.IsChecked == true)
                selectedAnswer = 'B';
            else if (OptionC.IsChecked == true)
                selectedAnswer = 'C';
            else if (OptionD.IsChecked == true)
                selectedAnswer = 'D';
            else
            {
                MessageBox.Show("Please select an answer.");
                return;
            }

            QuizQuestion current = quiz.Questions[quiz.CurrentQuestion];

            if (selectedAnswer == current.CorrectAnswer)
            {
                quiz.Score++;

                QuizFeedback.Text =
                    "Correct!\n\n" +
                    current.Explanation;

                QuizFeedback.Foreground = Brushes.DarkGreen;
            }
            else
            {
                string correctOption = "";

                switch (current.CorrectAnswer)
                {
                    case 'A':
                        correctOption = current.OptionA;
                        break;

                    case 'B':
                        correctOption = current.OptionB;
                        break;

                    case 'C':
                        correctOption = current.OptionC;
                        break;

                    case 'D':
                        correctOption = current.OptionD;
                        break;
                }

                QuizFeedback.Text =
                    "Incorrect.\n\n" +
                    "Correct Answer:\n" +
                    current.CorrectAnswer + ". " + correctOption +
                    "\n\nExplanation:\n" +
                    current.Explanation;

                QuizFeedback.Foreground = Brushes.DarkRed;
            }

            QuizFeedback.Visibility = Visibility.Visible;

            btnSubmitQuiz.IsEnabled = false;

            btnNextQuestion.Visibility = Visibility.Visible;
        }

        private void ShowFinalScore()
        {
            int correct = quiz.Score;
            int incorrect = quiz.Questions.Count - quiz.Score;

            string performance;

            if (correct >= 9)
            {
                performance = "Excellent! You have a strong understanding of cybersecurity.";
            }
            else if (correct >= 7)
            {
                performance = "Very Good! Your cybersecurity knowledge is solid.";
            }
            else if (correct >= 5)
            {
                performance = "Good effort. Continue practising to improve your cybersecurity awareness.";
            }
            else
            {
                performance = "You should review cybersecurity basics before trying again.";
            }
            logger.AddLog($"Quiz Completed - Score {correct}/{quiz.Questions.Count}");
            MessageBox.Show(
                $"Quiz Completed\n\n" +
                $"Final Score: {correct}/{quiz.Questions.Count}\n\n" +
                $"Correct Answers: {correct}\n" +
                $"Incorrect Answers: {incorrect}\n\n" +
                $"Performance:\n{performance}",
                "Quiz Results",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            ChatPanel.Visibility = Visibility.Visible;
            QuizPanel.Visibility = Visibility.Collapsed;
        }
        private void btnActivityLog_Click(object sender, RoutedEventArgs e)
        {
            ChatPanel.Visibility = Visibility.Collapsed;
            TaskPanel.Visibility = Visibility.Collapsed;
            QuizPanel.Visibility = Visibility.Collapsed;
            ActivityLogPanel.Visibility = Visibility.Visible;

            ActivityLogList.Items.Clear();

            foreach (string log in logger.GetRecentLogs())
            {
                ActivityLogList.Items.Add(log);
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnNextQuestion_Click(object sender, RoutedEventArgs e)
        {
            quiz.CurrentQuestion++;

            if (quiz.CurrentQuestion < quiz.Questions.Count)
            {
                LoadQuestion();

                QuizFeedback.Visibility = Visibility.Collapsed;

                btnNextQuestion.Visibility = Visibility.Collapsed;

                btnSubmitQuiz.IsEnabled = true;
            }
            else
            {
                ShowFinalScore();
            }
        }
        private void LoadTasks()
        {
            TaskList.Items.Clear();

            using (MySqlConnection connection = database.GetConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM Tasks";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TaskItem task = new TaskItem();

                    task.Title = reader["Title"].ToString();
                    task.Description = reader["Description"].ToString();

                    if (reader["ReminderDate"] != DBNull.Value)
                        task.Reminder = Convert.ToDateTime(reader["ReminderDate"]);

                    task.Completed = Convert.ToBoolean(reader["Completed"]);

                    TaskList.Items.Add(task);
                }
            }
        }
    }//end of class

    }//end of namespace
