using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ai_chatttt
{
    public class QuizManager
    {
        public List<QuizQuestion> Questions = new List<QuizQuestion>();

        public int CurrentQuestion = 0;

        public int Score = 0;

        public QuizManager()
        {
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            Questions.Add(new QuizQuestion
            {
                Question = "What should you do if an email asks for your password?",
                OptionA = "Reply with your password",
                OptionB = "Ignore it",
                OptionC = "Report it as phishing",
                OptionD = "Forward it to friends",
                CorrectAnswer = 'C',
                Explanation = "Legitimate companies never ask for your password by email."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "A strong password should contain:",
                OptionA = "Only numbers",
                OptionB = "Your birthday",
                OptionC = "Letters, numbers and symbols",
                OptionD = "Your first name",
                CorrectAnswer = 'C',
                Explanation = "Strong passwords combine uppercase letters, lowercase letters, numbers and symbols."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "True or False: You should share your password with close friends.",
                OptionA = "True",
                OptionB = "False",
                OptionC = "",
                OptionD = "",
                CorrectAnswer = 'B',
                Explanation = "Passwords should never be shared with anyone."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Which of these is an example of Multi-Factor Authentication?",
                OptionA = "Password only",
                OptionB = "Password and fingerprint",
                OptionC = "Username only",
                OptionD = "PIN only",
                CorrectAnswer = 'B',
                Explanation = "Using two different authentication methods makes accounts much more secure."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "True or False: Software updates help protect your computer.",
                OptionA = "True",
                OptionB = "False",
                OptionC = "",
                OptionD = "",
                CorrectAnswer = 'A',
                Explanation = "Updates fix security vulnerabilities and improve protection."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "What is phishing?",
                OptionA = "A type of antivirus",
                OptionB = "A cyberattack using fake messages",
                OptionC = "A firewall",
                OptionD = "A password manager",
                CorrectAnswer = 'B',
                Explanation = "Phishing tricks users into revealing personal information."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Which network is safest for online banking?",
                OptionA = "Public Wi-Fi",
                OptionB = "Open hotspot",
                OptionC = "Your secure home Wi-Fi",
                OptionD = "Any free Wi-Fi",
                CorrectAnswer = 'C',
                Explanation = "Avoid public networks when accessing sensitive information."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "True or False: Clicking unknown links is safe if they look professional.",
                OptionA = "True",
                OptionB = "False",
                OptionC = "",
                OptionD = "",
                CorrectAnswer = 'B',
                Explanation = "Appearance alone does not make a website trustworthy."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "What does a firewall do?",
                OptionA = "Stores passwords",
                OptionB = "Blocks unauthorized network traffic",
                OptionC = "Deletes viruses automatically",
                OptionD = "Creates backups",
                CorrectAnswer = 'B',
                Explanation = "A firewall monitors and filters incoming and outgoing network traffic."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Which of these is considered malware?",
                OptionA = "Virus",
                OptionB = "Microsoft Word",
                OptionC = "Calculator",
                OptionD = "Printer Driver",
                CorrectAnswer = 'A',
                Explanation = "Viruses are one type of malicious software."
            });



        }
        public void ShuffleQuestions()
        {
            Random random = new Random();

            Questions = Questions
                        .OrderBy(q => random.Next())
                        .Take(10)
                        .ToList();

            CurrentQuestion = 0;
            Score = 0;
        }
    }
}