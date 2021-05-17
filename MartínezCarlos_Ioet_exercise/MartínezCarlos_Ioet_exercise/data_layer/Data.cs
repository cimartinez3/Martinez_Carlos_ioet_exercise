using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MartínezCarlos_Ioet_exercise.data_layer
{
    public class Data
    {
        public static string[]  getData()
        {             
            try
            {
                string input_file = @"inputs.txt";
                string[]  data = File.ReadAllLines(input_file);
            
                return data;
            }
            catch (Exception e)
            {
                 return null;
            }
        }
    }
}
