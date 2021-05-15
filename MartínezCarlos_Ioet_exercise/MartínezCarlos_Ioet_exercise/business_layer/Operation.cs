using MartínezCarlos_Ioet_exercise.data_layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartínezCarlos_Ioet_exercise.business_layer
{
    class Operation
    {
        public static float pay = 0;
        static Dictionary<string, int> rates = new Dictionary<string, int>()
        {
            { "00:01-09:00",25 },
            { "09:01-18:00",15 },
            { "18:01-23:59",20 }
        };
        static Dictionary<TimeSpan, string> init_times = new Dictionary<TimeSpan, string>()
        {
            {TimeSpan.Parse("18:00"), "18:01-23:59"},
            {TimeSpan.Parse("23:59"), "00:01-09:00"},
            {TimeSpan.Parse("09:00"), "09:01-18:00"},

        };

        public static void getSalary()
        {
            string[] schedule = { "00:01-09:00", "09:01-18:00", "18:01-23:59" };
            string[] file_data = Data.getData();

            foreach (var line in file_data)
            {
                string[] splited = line.Split('=');
                string name = splited[0];
                pay = 0;
                foreach (var sub_split in splited[1].Split(','))
                {
                    string day = sub_split.Substring(0, 2);
                    string horario = sub_split.Substring(2, sub_split.Length - 2);
                    string[] hours = horario.Split('-');

                    TimeSpan init_time = TimeSpan.Parse(hours[0]);
                    TimeSpan end_time = TimeSpan.Parse(hours[1]);

                    foreach (string interval in schedule)
                    {
                        pay += calculatePayment(init_time, end_time, interval, day);

                    }

                }
                Console.WriteLine($"The amount to pay {name} is: {pay} USD");
            }
        }

        private static float calculatePayment(TimeSpan initTime, TimeSpan endTime, string interval, string day)
        {
            int hours_worked = (endTime - initTime).Hours;
            string[] interval_splited = interval.Split('-');
            TimeSpan start_journey = TimeSpan.Parse(interval_splited[0]);
            TimeSpan end_journey = TimeSpan.Parse(interval_splited[1]);

            if (initTime.Hours >= start_journey.Hours && endTime.Hours <= end_journey.Hours)
            {
                if (day.Equals("SA") || day.Equals("SU"))
                {
                    return hours_worked * (rates[interval] + 5);
                }
                else
                {
                    return hours_worked * (rates[interval]);
                }

            }
            else
            {
                if (initTime >= start_journey && initTime < end_journey)
                {
                    int hours = (end_journey - initTime).Hours;

                    if (day.Equals("SA") || day.Equals("SU"))
                    {
                        return hours * (rates[interval] + 5) + calculatePayment(end_journey, endTime, init_times[end_journey], day);
                    }
                    else
                    {
                        return hours * (rates[interval]) + calculatePayment(end_journey, endTime, init_times[end_journey], day);
                    }

                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
