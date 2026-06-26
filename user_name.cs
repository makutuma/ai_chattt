using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.IO;
using System.Windows.Media;

namespace ai_chatttt
{
    
    public class user_name
    {

        public string submit_name(TextBox user_name, ListView chats, TextBlock username_error)
        {
            // check if textbox is empty
            if (string.IsNullOrWhiteSpace(user_name.Text))
            {
                username_error.Visibility = Visibility.Visible;
                return "";
            }

            // hide error if user entered a name
            username_error.Visibility = Visibility.Hidden;

            // temp variables
            string filename = "user_names.txt";

            // create file if it doesn't exist
            if (!File.Exists(filename))
            {
                File.AppendAllText(filename, "auto_create\n");
            }

            // get username
            string name = user_name.Text.ToString();

            bool found = check_name(name);

            // new user
            if (!found)
            {
                File.AppendAllText(filename, name + "\n");

                error_method(
                    "ChatBot",
                    "Hey " + name + " welcome to AI cybersecurity",
                    chats
                );
            }
            else
            {
                // existing user
                error_method(
                    "ChatBot",
                    "Hey " + name + " welcome back, how can i help you today",
                    chats
                );
            }

            return name;
        }
        //method to check name of the user







        private Boolean check_name(string name)
        {//start

            //temp variable
            string filename = "user_names.txt";

            bool found_name = false;


            //store or get all the names in the text file and store in an 1D array
            string[] names = File.ReadAllLines(filename);

            //foreach to search the name of the user
            foreach (string name_found in names)
            { //start of loop

                //if statement to check for the username
                if (name_found.ToLower() == name.ToLower())
                {//start if

                    //found_name set to true
                    found_name = true;

                }//end of if

            }//end of the loop


            //return the status of found or not [ true or false ]
            return found_name;

        }//end check method



        //error method
        private void error_method(string name, string message, ListView chats)
        {//star of error mehtod

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

        }//end of error method




    }


}