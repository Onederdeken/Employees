using Employees;
using System.Text.Json;
String pathJsonFile = "..\\..\\..\\data.json";
String pathTextFile = "..\\..\\..\\top_employeers";
/*
Директория из которой происходит запуск приложения находится в ./Employee/bin/Debug/net8.0/ 
по этому я возвращаюсь на несколько директорий назад, что бы хранить статические файлы в той же директории где я работаю, для удобства"
 */
String JsonString = File.ReadAllText(pathJsonFile);
List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(JsonString)!;
employees.ForEach(e =>e.ToFormate());
employees = employees.OrderByDescending(c=>c.numberSalary).Take(20).ToList();
string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
Console.WriteLine(projectDirectory);
Directory.SetCurrentDirectory(projectDirectory);
using (StreamWriter writer = new StreamWriter(pathTextFile))
{
    foreach(Employee employee in employees)
    {
        writer.WriteLine(employee.ToString());
    }
}
