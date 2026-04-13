using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_chattt
{//start of namespace 
    public class Program
    {//start of class 
        static void Main(string[] args)
        {//start of main methord 

            //creating an instance for the class voice_logo 
            //without  an object name but a constructor 
            new voice_logoo() { };
            //creating an instance for the class prompt_user 
            //with an object name collect_name
            prompt_userr collect_name = new prompt_userr();

            //call th ewwelcome methord 
            collect_name.DisplayWelcomeMessage();
            collect_name.asking_name();

            //instance for the class ai_response
            //with an object name chatting chatting
            chat chatting = new chat();

            chatting.ai_chat(collect_name.GetName());

        }//end of main methord 
    }// end of class
}//end of namespace
