using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ai_chattt
{//start of name space

    public class prompt_userr
    {//start of class 

        //global variable declaration, string datatype
        //and variable name called name
        //must be private
        private string name = string.Empty;



        //welcome the user
        public void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================**********************************====================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("            [ Welcome To Marks Cyber Security ChatBot ]          ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================**********************************====================");
            Console.ResetColor();
        }


        //void method to prompt the user for name
        //start with access modifier public
        //then type of method void, then name of the
        //method called asking_name()
        public void asking_name()
        { //start of asking name method

            //ask for name

            //AI and colors

            //AI name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("chatBot : ");

            //AI message
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please enter your name...");

            //reset color
            Console.ResetColor();

            //do while to check and re-prompt the user
            do
            { //start of do while 

                //user entering name
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("user : ");



                //input color
                Console.ForegroundColor = ConsoleColor.Gray;

                name = Console.ReadLine();

                //reset color
                Console.ResetColor();


            } while (!check_name());//end of do while


        }//end of the asking name method

        //boolean method to check if the user entered name
        //start by the access modifier must be private
        //then the type of method boolean then name of it
        //check_name()
        private Boolean check_name()
        { //start of check_name


            //check if the name is entered using if statement
            if (name == "")
            { //start if statement

                //show error message
                //AI name
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("chatBot : ");

                //AI message
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Please try to enter your name...");

                //reset color
                Console.ResetColor();

                //return false
                return false;
            }//end of if statement
            else
            {//start of else
                string userName = name;
                //return the success message
                //AI name
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("chatBot : ");

                //AI message
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Hey ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" " + name);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(" how can i help you");

                //reset color
                Console.ResetColor();
                //return
                return true;

            }//end of else




        }//end of check_name method

        //metord to return  the user name 
        public string GetName()
        {//start of return name methord 
         //return the name of  the user 



            return name;
        }

        //returning the name  of the user





    }        //end of class
}//end of name space 

