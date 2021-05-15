using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MartínezCarlos_Ioet_exercise.data_layer
{
    class Data
    {
        public static string[]  getData()
        {
            string input_file = @"inputs.txt";
            string[] data = File.ReadAllLines(input_file);

            return data;
        }
    }
}
