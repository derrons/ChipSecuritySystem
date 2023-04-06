using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ChipSecuritySystem
{
    public  class Program
    {
        static Color [,] CorrectAccessArray = new Color [4, 2];
        public static ColorChip family;
 
        public static Array SequenceAccess(ColorChip colors)
        {
            //Logic Statement in this method
            if (colors.StartColor == Color.Blue)
            {
                CorrectAccessArray[0, 0] = colors.StartColor;
                CorrectAccessArray[0, 1] = colors.EndColor;
            }
            else if (colors.EndColor == Color.Green)
            {
                CorrectAccessArray[3, 0] = colors.StartColor;
                CorrectAccessArray[3, 1] = colors.EndColor;
            }
            else if (CorrectAccessArray[0, 0] != 0 && CorrectAccessArray[3, 1] != 0)
            {
                return CorrectAccessArray;
            }
            else if (CorrectAccessArray[1, 0] != 0)
            {
                CorrectAccessArray[1, 0] = colors.StartColor;
                CorrectAccessArray[1, 1] = colors.EndColor;
            }
            else 
            {
                CorrectAccessArray[2, 0] = colors.StartColor;
                CorrectAccessArray[2, 1] = colors.EndColor;
                return CorrectAccessArray; 
            }


            CorrectAccessArray[0, 0] = colors.StartColor;
            CorrectAccessArray[3, 1] = colors.EndColor;
            
                
            return CorrectAccessArray;
         }


        static void Main(string[] args)
        {

            for (int i = 0; i < 4; i++)
            {
                if (i != 4)
                {


                    Console.WriteLine("Please enter your chip colors");
                    string sequenceOne = Console.ReadLine().ToLower();
                    string sequenceTwo = Console.ReadLine().ToLower();

                    if (sequenceOne == "red")
                    {
                        family.StartColor = Color.Red;
                    }
                    else if (sequenceOne == "green")
                    {
                        family.StartColor = Color.Green;
                    }
                    else if (sequenceOne == "blue")
                    {
                        family.StartColor = Color.Blue;
                    }
                    else if (sequenceOne == "yellow")
                    {
                        family.StartColor = Color.Yellow;
                    }
                    else if (sequenceOne == "purple")
                    {
                        family.StartColor = Color.Purple;
                    }
                    else family.StartColor = Color.Orange;

                    if (sequenceTwo == "red")
                    {
                        family.EndColor = Color.Red;
                    }
                    else if (sequenceTwo == "green")
                    {
                        family.EndColor = Color.Green;
                    }
                    else if (sequenceTwo == "blue")
                    {
                        family.EndColor = Color.Blue;
                    }
                    else if (sequenceTwo == "yellow")
                    {
                        family.EndColor = Color.Yellow;
                    }
                    else if (sequenceTwo == "purple")
                    {
                        family.EndColor = Color.Purple;
                    }
                    else family.EndColor = Color.Orange;
                }

            }
            Console.WriteLine(SequenceAccess(family));

        }
    }
}
