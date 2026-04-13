using System;
using System.Collections;

namespace ai_chattt
{//start of name space
    internal class chat
    {//dtart of class
     //global arrays
        ArrayList answers = new ArrayList();
        ArrayList ignoring = new ArrayList();


        //method to chat

        public void ai_chat(string name)
        {

            //now store the answers 
            answers.Add("password must be 8 characters long");

            //store ignore
            ignoring.Add("what");
            ignoring.Add("is");
            ignoring.Add("about");

            //ignoring questions
            ignoring.Add("a");
            ignoring.Add("about");
            ignoring.Add("above");
            ignoring.Add("across");
            ignoring.Add("after");
            ignoring.Add("afterwards");
            ignoring.Add("again");
            ignoring.Add("against");
            ignoring.Add("all");
            ignoring.Add("almost");
            ignoring.Add("alone");
            ignoring.Add("along");
            ignoring.Add("already");
            ignoring.Add("also");
            ignoring.Add("although");
            ignoring.Add("always");
            ignoring.Add("am");
            ignoring.Add("among");
            ignoring.Add("amongst");
            ignoring.Add("amount");
            ignoring.Add("an");
            ignoring.Add("and");
            ignoring.Add("another");
            ignoring.Add("any");
            ignoring.Add("anyhow");
            ignoring.Add("anyone");
            ignoring.Add("anything");
            ignoring.Add("anyway");
            ignoring.Add("anywhere");
            ignoring.Add("are");
            ignoring.Add("around");
            ignoring.Add("as");
            ignoring.Add("at");
            ignoring.Add("back");
            ignoring.Add("be");
            ignoring.Add("became");
            ignoring.Add("because");
            ignoring.Add("become");
            ignoring.Add("becomes");
            ignoring.Add("becoming");
            ignoring.Add("been");
            ignoring.Add("before");
            ignoring.Add("beforehand");
            ignoring.Add("behind");
            ignoring.Add("being");
            ignoring.Add("below");
            ignoring.Add("beside");
            ignoring.Add("besides");
            ignoring.Add("between");
            ignoring.Add("beyond");
            ignoring.Add("both");
            ignoring.Add("but");
            ignoring.Add("by");
            ignoring.Add("can");
            ignoring.Add("cannot");
            ignoring.Add("could");
            ignoring.Add("did");
            ignoring.Add("do");
            ignoring.Add("does");
            ignoring.Add("doing");
            ignoring.Add("done");
            ignoring.Add("down");
            ignoring.Add("during");
            ignoring.Add("each");
            ignoring.Add("either");
            ignoring.Add("else");
            ignoring.Add("elsewhere");
            ignoring.Add("enough");
            ignoring.Add("etc");
            ignoring.Add("even");
            ignoring.Add("ever");
            ignoring.Add("every");
            ignoring.Add("everyone");
            ignoring.Add("everything");
            ignoring.Add("everywhere");
            ignoring.Add("except");
            ignoring.Add("few");
            ignoring.Add("first");
            ignoring.Add("for");
            ignoring.Add("former");
            ignoring.Add("formerly");
            ignoring.Add("from");
            ignoring.Add("further");
            ignoring.Add("had");
            ignoring.Add("has");
            ignoring.Add("have");
            ignoring.Add("having");
            ignoring.Add("he");
            ignoring.Add("hence");
            ignoring.Add("her");
            ignoring.Add("here");
            ignoring.Add("hereafter");
            ignoring.Add("hereby");
            ignoring.Add("herein");
            ignoring.Add("hereupon");
            ignoring.Add("hers");
            ignoring.Add("herself");
            ignoring.Add("him");
            ignoring.Add("himself");
            ignoring.Add("his");
            ignoring.Add("how");
            ignoring.Add("however");
            ignoring.Add("i");
            ignoring.Add("if");
            ignoring.Add("in");
            ignoring.Add("indeed");
            ignoring.Add("inside");
            ignoring.Add("instead");
            ignoring.Add("into");
            ignoring.Add("is");
            ignoring.Add("it");
            ignoring.Add("its");
            ignoring.Add("itself");
            ignoring.Add("last");
            ignoring.Add("later");
            ignoring.Add("latter");
            ignoring.Add("latterly");
            ignoring.Add("least");
            ignoring.Add("less");
            ignoring.Add("lot");
            ignoring.Add("many");
            ignoring.Add("may");
            ignoring.Add("me");
            ignoring.Add("meanwhile");
            ignoring.Add("might");
            ignoring.Add("more");
            ignoring.Add("moreover");
            ignoring.Add("most");
            ignoring.Add("mostly");
            ignoring.Add("much");
            ignoring.Add("must");
            ignoring.Add("my");
            ignoring.Add("myself");
            ignoring.Add("name");
            ignoring.Add("namely");
            ignoring.Add("neither");
            ignoring.Add("never");
            ignoring.Add("nevertheless");
            ignoring.Add("next");
            ignoring.Add("no");
            ignoring.Add("nobody");
            ignoring.Add("none");
            ignoring.Add("noone");
            ignoring.Add("nor");
            ignoring.Add("not");
            ignoring.Add("nothing");
            ignoring.Add("now");
            ignoring.Add("nowhere");
            ignoring.Add("of");
            ignoring.Add("off");
            ignoring.Add("often");
            ignoring.Add("on");
            ignoring.Add("once");
            ignoring.Add("one");
            ignoring.Add("only");
            ignoring.Add("or");
            ignoring.Add("other");
            ignoring.Add("others");
            ignoring.Add("otherwise");
            ignoring.Add("ought");
            ignoring.Add("our");
            ignoring.Add("ours");
            ignoring.Add("ourselves");
            ignoring.Add("out");
            ignoring.Add("outside");
            ignoring.Add("over");
            ignoring.Add("own");
            ignoring.Add("part");
            ignoring.Add("per");
            ignoring.Add("perhaps");
            ignoring.Add("please");
            ignoring.Add("put");
            ignoring.Add("rather");
            ignoring.Add("re");
            ignoring.Add("same");
            ignoring.Add("see");
            ignoring.Add("seem");
            ignoring.Add("seemed");
            ignoring.Add("seeming");
            ignoring.Add("seems");
            ignoring.Add("several");
            ignoring.Add("she");
            ignoring.Add("should");
            ignoring.Add("show");
            ignoring.Add("side");
            ignoring.Add("since");
            ignoring.Add("so");
            ignoring.Add("some");
            ignoring.Add("somehow");
            ignoring.Add("someone");
            ignoring.Add("something");
            ignoring.Add("sometime");
            ignoring.Add("sometimes");
            ignoring.Add("somewhere");
            ignoring.Add("still");
            ignoring.Add("such");
            ignoring.Add("take");
            ignoring.Add("than");
            ignoring.Add("that");
            ignoring.Add("the");
            ignoring.Add("their");
            ignoring.Add("theirs");
            ignoring.Add("them");
            ignoring.Add("themselves");
            ignoring.Add("then");
            ignoring.Add("thence");
            ignoring.Add("there");
            ignoring.Add("thereafter");
            ignoring.Add("thereby");
            ignoring.Add("therefore");
            ignoring.Add("therein");
            ignoring.Add("thereupon");
            ignoring.Add("these");
            ignoring.Add("they");
            ignoring.Add("this");
            ignoring.Add("those");
            ignoring.Add("though");
            ignoring.Add("through");
            ignoring.Add("throughout");
            ignoring.Add("thru");
            ignoring.Add("thus");
            ignoring.Add("to");
            ignoring.Add("together");
            ignoring.Add("too");
            ignoring.Add("toward");
            ignoring.Add("towards");
            ignoring.Add("under");
            ignoring.Add("unless");
            ignoring.Add("until");
            ignoring.Add("up");
            ignoring.Add("upon");
            ignoring.Add("us");
            ignoring.Add("used");
            ignoring.Add("very");
            ignoring.Add("via");
            ignoring.Add("was");
            ignoring.Add("we");
            ignoring.Add("well");
            ignoring.Add("were");
            ignoring.Add("what");
            ignoring.Add("whatever");
            ignoring.Add("when");
            ignoring.Add("whence");
            ignoring.Add("whenever");
            ignoring.Add("where");
            ignoring.Add("whereafter");
            ignoring.Add("whereas");
            ignoring.Add("whereby");
            ignoring.Add("wherein");
            ignoring.Add("whereupon");
            ignoring.Add("wherever");
            ignoring.Add("whether");
            ignoring.Add("which");
            ignoring.Add("while");
            ignoring.Add("whither");
            ignoring.Add("who");
            ignoring.Add("whoever");
            ignoring.Add("whole");
            ignoring.Add("whom");
            ignoring.Add("whose");
            ignoring.Add("why");
            ignoring.Add("will");
            ignoring.Add("with");
            ignoring.Add("within");
            ignoring.Add("without");
            ignoring.Add("would");
            ignoring.Add("yes");
            ignoring.Add("yet");
            ignoring.Add("you");
            ignoring.Add("your");
            ignoring.Add("yours");
            ignoring.Add("yourself");
            ignoring.Add("yourselves");
            //do while to chat
            string asking = string.Empty;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ChatBot: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("I can teach you about passwords, how to stay safe online, and phishing.");
            Console.ResetColor();
            do
            {
                //ask and prompt
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name + " : ");

                Console.ForegroundColor = ConsoleColor.Gray;
                asking = Console.ReadLine();

                Console.ResetColor();

            } while (end_chat(asking));



        }//end of method


        //method to check if exit or chatting
        private Boolean end_chat(string question)

        {
            if (question.ToLower() == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("ChatBot: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Bye..");
                Console.ResetColor();
                return false;
            }

            string input = question.ToLower();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ChatBot: ");
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (input.Contains("password"))
            {
       
                Console.WriteLine("Here are some tips for creating a strong password:");
                Console.WriteLine();
                Console.WriteLine("- Use at least 8–12 characters.");
                Console.WriteLine("- Include uppercase and lowercase letters.");
                Console.WriteLine("- Add numbers and special characters (e.g. @, #, !).");
                Console.WriteLine("- Avoid using personal information like your name or birthdate.");
                Console.WriteLine("- Do not reuse the same password on multiple accounts.");
            }
            else if (input.Contains("phishing") || input.Contains("scam") || input.Contains("fake email"))
            {
                Console.WriteLine("Phishing is a type of online scam where attackers try to trick you into giving personal information.");
                Console.WriteLine("They often pretend to be trusted companies through emails, messages, or fake websites.");
                Console.WriteLine();
                Console.WriteLine("Here are some tips to protect yourself from phishing:");
                Console.WriteLine("- Do not click on suspicious links or attachments.");
                Console.WriteLine("- Always check the sender's email address carefully.");
                Console.WriteLine("- Be cautious of messages that create urgency or fear.");
                Console.WriteLine("- Never share personal or financial information via email.");
                Console.WriteLine("- Look for spelling and grammar mistakes in messages.");
                
                Console.WriteLine("Be careful of phishing scams. Do not click suspicious links and always verify the sender.");
            }
            else if (input.Contains("safe browsing") || input.Contains("browser") || input.Contains("internet safety"))
            {
                Console.WriteLine("Safe browsing means using the internet in a way that protects your personal information and avoids threats.");
                Console.WriteLine("It helps you stay secure while visiting websites, downloading files, and using online services.");
                Console.WriteLine();

                Console.WriteLine("Here are some tips to stay safe while browsing:");
                Console.WriteLine("- Always use secure websites (look for https in the URL).");
                Console.WriteLine("- Avoid downloading files from unknown or untrusted sources.");
                Console.WriteLine("- Keep your browser and antivirus software up to date.");
                Console.WriteLine("- Do not click on pop-ups or suspicious ads.");
                Console.WriteLine("- Log out of accounts when using public or shared computers.");
            }
            else if (input.Contains("hello") || input.Contains("hi"))
            {
                Console.WriteLine("Hello there!");
            }
            else if (input.Contains("help"))
            {
                Console.WriteLine("I can help you with password safety, phishing, and safe browsing.");
            }
            else
            {
                Console.WriteLine("I didnt quite understand that , could you rephrase?");
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(Type 'exit' to quit)");
            Console.ResetColor();
            return true;
        }

    }//end of class  
}//end of namespace