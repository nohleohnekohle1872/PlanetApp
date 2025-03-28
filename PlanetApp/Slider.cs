using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetApp
{
    public class IntegerSlider
    {
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public int StepSize { get; set; }
        public string Name { get; set; }
        public string Line { get; set; }
        public string Arrow { get; set; }
        public int SliderValue { get; set; } = 0;
        public int[] ArrowPosition { get; set; }
        public int startPositionSlider { get; set; }

        public IntegerSlider(int startValue, int endValue, int stepSize, string name, string line, string arrow, int sliderValue)
        {
            StartValue = startValue;
            EndValue = endValue;
            StepSize = stepSize;
            Name = name;
            Line = line;
            Arrow = arrow;
            SliderValue = sliderValue;
        }

        public void DisplayIntegerSlider(int x_Position, int y_Position, ConsoleColor color)
        {
            Program.currentCursorPosition = [x_Position, y_Position];
            startPositionSlider = x_Position;
            HelpSystems.PrintString(Program.currentCursorPosition[0], Program.currentCursorPosition[1], Name, ConsoleColor.Cyan);

            for (int i = StartValue; i <= EndValue; i += StepSize)
            {
                HelpSystems.PrintString(Program.currentCursorPosition[0], Program.currentCursorPosition[1] + 2, i.ToString(), color);
                Program.currentCursorPosition[0] += EndValue.ToString().Length + 2;
            }

            int difference = Program.currentCursorPosition[0] - x_Position;
            Program.currentCursorPosition = [x_Position, y_Position + 3];
            

            for (int i = 0; i < difference; i++)
            {
                HelpSystems.PrintString(Program.currentCursorPosition[0], Program.currentCursorPosition[1], "-", color);
                Program.currentCursorPosition[0] += 1;
            }

            ArrowPosition = [x_Position + (EndValue.ToString().Length + 2) * ((SliderValue - StartValue) / StepSize), Program.currentCursorPosition[1]];
            HelpSystems.PrintString(ArrowPosition[0], ArrowPosition[1], Arrow, ConsoleColor.DarkYellow);
        }   

        public void PrintArrow(string s = "|", ConsoleColor color = ConsoleColor.DarkYellow)
        {
            ArrowPosition = [startPositionSlider + (EndValue.ToString().Length + 2) * ((SliderValue - StartValue) / StepSize), Program.currentCursorPosition[1]];
            HelpSystems.PrintString(ArrowPosition[0], ArrowPosition[1], s, color);
        }

        public void SlideLeft()
        {
            if (SliderValue > StartValue)
            {
                PrintArrow("-", ConsoleColor.DarkCyan);
                SliderValue -= StepSize;
                PrintArrow();
            }
        }

        public void SlideRight()
        {
            if (SliderValue < EndValue)
            {
                PrintArrow("-", ConsoleColor.DarkCyan);
                SliderValue += StepSize;
                PrintArrow();
            }
        }
    }
}
