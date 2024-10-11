using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Employees
{
    public class Employee
    {
        [JsonPropertyName("name")]
        public String name { get; set; }
        [JsonPropertyName("phoneNumber")]
        public String phoneNumber { get; set; }
        [JsonPropertyName("salary")]
        public String salary { get; set; }
        [JsonIgnore]
        public int numberSalary { get; set; }
        public void ToFormate()
        {
            FormateTelephone();
            FormateSalary();
        }
        private void FormateTelephone()
        {
            try
            {
                phoneNumber = '+' + phoneNumber.Substring(0, 1)
                + '(' + phoneNumber.Substring(1, 3) + ')' + phoneNumber.Substring(4, 3)
                + '-' + phoneNumber.Substring(7, 2) + '-' + phoneNumber.Substring(9, 2);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"неудалось отформатировать номер телефона {phoneNumber} этого сотрудника {name}");
            }
        }
        private void FormateSalary()
        {
            String temp = salary;
            numberSalary = int.Parse(salary);
            salary = String.Empty;
            temp = string.Join("", temp.Reverse());
            int i = 0;
            while (i < temp.Length)
            {

                if (temp.Length - i > 3)
                {
                    salary += temp.Substring(i, 3) + " ";
                    i += 3;
                }
                else
                {
                    salary += temp[i..(temp.Length)];
                    break;
                }

            }
            salary = String.Join("", salary.Reverse()) + " р";
        }
           
        public override String ToString()
        {
            return $"{name} {phoneNumber}, {salary}";

        }



    }
    
}
