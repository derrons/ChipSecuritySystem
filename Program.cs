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
    public class Program
    {
        static List<ColorChip> colorChips = new List<ColorChip>() {
            new ColorChip(Color.Blue, Color.Yellow),
            new ColorChip(Color.Red, Color.Green),
            new ColorChip(Color.Yellow, Color.Red),
            new ColorChip(Color.Orange, Color.Purple),
        };

        static void GetCombinations(List<ColorChip> chipList, List<ColorChip> tempChipList, int startIndex,
            int endIndex, int currentIndex, int sequenceLength, ref List<List<ColorChip>> outPut)
        {


            if (currentIndex == sequenceLength)
            {
                outPut.Add(tempChipList);
                return;
            }

            for (int i = startIndex; i < endIndex && (endIndex - i + 1) >= currentIndex; i++)
            {
                tempChipList.Add(chipList[i]);
                GetCombinations(chipList, tempChipList, i + 1, endIndex, currentIndex + 1, sequenceLength, ref outPut);
            }

        }

        static void Main(string[] args)
        {
            int start, end;
            var chips = new List<ColorChip>();


            // find start and end chips
            for (int i = 0; i < colorChips.Count; i++)
            {
                if (colorChips[i].StartColor == Color.Blue)
                {
                    start = i;
                }

                else if (colorChips[i].EndColor == Color.Green)
                {
                    end = i;
                }

                else
                {
                    chips.Add(colorChips[i]);
                }
            }

            int powerSetCount = 1 << chips.Count;


            int itemLength = chips.Count;
            var chipCombinations = new List<List<ColorChip>>();
            while (chips.Count > 0)
            {

                GetCombinations(chips, new List<ColorChip>(), 0, chips.Count - 1, 0, itemLength, ref chipCombinations);

                itemLength--;
            }



            Console.WriteLine(chipCombinations.Count);



        }


    }
}