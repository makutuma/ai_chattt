using System;
using System.Drawing;
using System.IO;
using System.Media;

namespace ai_chattt
{//start of namespace
    public class voice_logoo
    {//start of class

        //auto get path directory 
        private string full_path = AppDomain.CurrentDomain.BaseDirectory;


        public voice_logoo()
        {//start of constructor 

            //calling sound methord 
            greetings();

            //call the logo method
            asci();


        }//end of constructor 

        //methord to play the sound 
        private void greetings()
        {//start of methord

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("ChatBot: Playing voice greeting...");
            Console.ResetColor();
            //check id the pathh is auto collected 
            Console.WriteLine(full_path);

            //then replace the \ bin \Debug 
            string correct_path = full_path.Replace(@"\bin\Debug\", @"\greett.wav");

            //check if audio is found     
            Console.WriteLine(correct_path);

            //use the sound player class to play the audio
            //creating an instance  for the soundPlay  class 
            //WITH AN OBJECT NAME GREET 
            SoundPlayer greett = new SoundPlayer(correct_path);
            //then play the sound using the play methord 
            greett.Play();

            Console.ReadLine();

        }//End of greetings methord

        //methord to turn logo to ascii
        private void asci()
        {
            //path of the logo [ where the logo is ]
            string path = full_path.Replace(@"\bin\Debug\", @"\logoo.jpg");
            Bitmap image = new Bitmap(path);

            // Resize for better console fit
            int width = 75;
            int height = 35; //(image.Height * width) / image.Width;
            Bitmap resized = new Bitmap(image, new Size(width, height));

            // Default color , you can set yours before this line
            string asciiChars = ".,#$%*&";

            //start by the height
            for (int y = 0; y < resized.Height; y++)
            {
                //then width
                for (int x = 0; x < resized.Width; x++)
                {
                    //color the pixel on x and y
                    Color pixel = resized.GetPixel(x, y);

                    // Convert to grayscale
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;

                    // Map grayscale to ASCII
                    int index = (gray * (asciiChars.Length - 1)) / 255;

                    Console.Write(asciiChars[index]);
                }
                Console.WriteLine();
            }
        }

    }//end of clas
}//end of namespace