using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_chatttt
{



    public class respond
    {
        public respond(ArrayList reply, ArrayList ignore)
        {//start of constructor

            answers(reply);
            words(ignore);


        }//end of constructor

        //method to store the list of words
        private void words(ArrayList ignoring)
        {//
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
            ignoring.Add("hey");
            ignoring.Add("you");
            ignoring.Add("your");
            ignoring.Add("yours");
            ignoring.Add("yourself");
            ignoring.Add("yourselves");

        }//




        public void answers(ArrayList add_answers)
        {//start of method


            add_answers.Add("greeting i'm doing well, thanks for asking! how are you today?");
            add_answers.Add("greeting i'm great, thanks! how can i assist you today?");
            add_answers.Add("greeting i'm good! hope you're doing well today too.");
            add_answers.Add("greeting i'm doing fine, thank you! what can i help you with today?");
            add_answers.Add("greeting i'm well! nice to see you, how can i help?");


            add_answers.Add("purpose my purpose is to help you learn about online safety and cybersecurity.");
            add_answers.Add("purpose i guide users in understanding cybersecurity and staying safe online.");
            add_answers.Add("purpose i help explain digital safety and protect against online threats.");
            add_answers.Add("purpose my goal is to support your cybersecurity awareness and knowledge.");
            add_answers.Add("purpose i assist with learning how to stay safe in the digital world.");


            add_answers.Add("cybersecurity cybersecurity is the practice of protecting systems and networks from digital threats.");
            add_answers.Add("cybersecurity it involves securing devices, networks, and data from attacks.");
            add_answers.Add("cybersecurity it is about defending digital systems from unauthorized access or harm.");
            add_answers.Add("cybersecurity it focuses on protecting computers, networks, and information from threats.");
            add_answers.Add("cybersecurity it is the process of keeping digital systems safe from cyber attacks.");


            add_answers.Add("phishing phishing is a scam where attackers pretend to be trusted sources to steal information.");
            add_answers.Add("phishing it uses fake emails or websites to trick people into giving sensitive data.");
            add_answers.Add("phishing attackers impersonate legitimate services to steal personal information.");
            add_answers.Add("phishing it is a technique used to deceive users into revealing private details.");
            add_answers.Add("phishing it involves fraudulent messages designed to steal login or financial data.");


            add_answers.Add("firewall a firewall controls network traffic based on security rules.");
            add_answers.Add("firewall it monitors and filters incoming and outgoing network traffic.");
            add_answers.Add("firewall it helps block unauthorized access to your system or network.");
            add_answers.Add("firewall it acts as a barrier between trusted and untrusted networks.");
            add_answers.Add("firewall it enforces security rules to protect your device or network.");


            add_answers.Add("password a password is used to secure access to your accounts or devices.");
            add_answers.Add("password it is a secret code used to protect your login information.");
            add_answers.Add("password it should be strong and difficult for others to guess.");
            add_answers.Add("password it helps keep your accounts secure from unauthorized access.");
            add_answers.Add("password avoid using simple or personal information when creating one.");

            add_answers.Add("hacked account secure your account right away by changing your password.");
            add_answers.Add("hacked account sign out of all active sessions to prevent further access.");
            add_answers.Add("hacked account contact the platform's support team if you suspect unauthorized access.");
            add_answers.Add("hacked account enable two-factor authentication for added account security.");
            add_answers.Add("hacked account review your recent activity and remove anything suspicious.");

            add_answers.Add("fraud contact your bank as soon as possible if you notice suspicious transactions.");
            add_answers.Add("fraud keep a close eye on your accounts for unusual financial activity.");
            add_answers.Add("fraud report possible fraud to the appropriate authorities or service providers.");
            add_answers.Add("fraud act quickly to secure your accounts and protect your personal information.");
            add_answers.Add("fraud changing passwords and monitoring alerts can help reduce further risks.");

            add_answers.Add("malicious chatbot be careful of chatbots that pressure you into acting quickly.");
            add_answers.Add("malicious chatbot fake bots may try to collect personal or financial information.");
            add_answers.Add("malicious chatbot avoid sharing sensitive details with unverified chatbots.");
            add_answers.Add("malicious chatbot suspicious bots often use fear or urgency to manipulate users.");
            add_answers.Add("malicious chatbot always verify the source before trusting a chatbot with private data.");

            add_answers.Add("vpn a vpn keeps your online activity more private and secure.");
            add_answers.Add("vpn it creates an encrypted connection to help protect your data.");
            add_answers.Add("vpn using a vpn can reduce risks when browsing on public wi-fi.");
            add_answers.Add("vpn it helps secure your internet traffic from unwanted access.");
            add_answers.Add("vpn a vpn adds an extra layer of protection while you're online.");




            //sentiment detection

            add_answers.Add("frustrated i can see this situation is frustrating, but we'll sort it out together.");
            add_answers.Add("frustrated don't worry, we'll go through the problem one step at a time.");
            add_answers.Add("frustrated it's understandable to feel frustrated when things go wrong.");
            add_answers.Add("frustrated stay patient, i'll help you find a solution.");
            add_answers.Add("frustrated i know this can be annoying, but we'll work through it together.");

            add_answers.Add("confused that's completely okay, i'll make things easier to understand.");
            add_answers.Add("confused let me explain it in a simpler way step by step.");
            add_answers.Add("confused no problem, i'll help clear things up for you.");
            add_answers.Add("confused it can be tricky at first, but we'll work through it together.");
            add_answers.Add("confused i'll try to break it down clearly so it makes more sense.");


            add_answers.Add("worried it's completely understandable to feel concerned. i'll help you through it.");
            add_answers.Add("worried try not to stress, we'll work together to secure everything.");
            add_answers.Add("worried i know this can feel overwhelming, but there are steps we can take to fix it.");
            add_answers.Add("worried your safety online is important, and i'm here to guide you.");
            add_answers.Add("worried stay calm, most security problems can be resolved with the right steps.");


            add_answers.Add("happy that's wonderful to hear! i'm glad you're doing well.");
            add_answers.Add("happy awesome! it's always nice to hear good news.");
            add_answers.Add("happy i'm really happy for you! keep enjoying the positive vibes.");
            add_answers.Add("happy that sounds amazing! i hope the good moments continue.");
            add_answers.Add("happy it's great seeing your positivity, and i'm here if you need anything.");


            add_answers.Add("sad i'm sorry you're going through this. i'm here to support you.");
            add_answers.Add("sad that really sounds difficult, but you don't have to face it alone.");
            add_answers.Add("sad i hope tomorrow feels a little brighter for you.");
            add_answers.Add("sad take things at your own pace, and remember i'm here to listen anytime.");
            add_answers.Add("sad i'm sorry things feel heavy right now, but i'll stay here with you.");

            add_answers.Add("angry i can see you're upset. let's work through the problem together.");
            add_answers.Add("angry i know this situation is frustrating, but i'll do my best to help.");
            add_answers.Add("angry take a moment if you need to, and we'll figure this out together.");
            add_answers.Add("angry i understand your frustration, and i'm here to help resolve the issue.");
            add_answers.Add("angry i'm sorry things are difficult right now, let's find a solution together.");




        }//end of method








    }
}