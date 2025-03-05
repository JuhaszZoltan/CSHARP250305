using CSHARP250305;

const string DIRPATH = "..\\..\\..\\src";
const int TOTAL_PRICE = 2600;
List<Student> students = [];

using StreamReader sr = new($"{DIRPATH}\\course.txt");
while (!sr.EndOfStream) students.Add(new(sr.ReadLine()));
//foreach (var s in students) Console.WriteLine($"{s}\n");

Console.WriteLine($"#1.: number of students: {students.Count}");

var f2 = students.Average(s => s.Results["backend"]);
Console.WriteLine($"#2.: backend subject avg: {f2:0.00}%");

var f3 = students.MaxBy(s => s.SubjectAvg);
Console.WriteLine($"#3.: best student:\n{f3}");

var f4m = students.Count(s => s.Sex is true);
Console.WriteLine($"#4.: proportion of men: {f4m / (float)students.Count * 100}%");

var f5 = students.Where(s => s.Sex is false).MaxBy(f => f.WebScore);
Console.WriteLine($"#5.: best felame web dev (total webdev score: {f5.WebScore}):\n{f5}");

var f6names = students.Where(s => s.Balance >= TOTAL_PRICE).Select(s => s.Name);
Console.WriteLine("#6.: who have already paid:");
foreach (var name in f6names) Console.WriteLine($"\t- {name}");

Console.Write("#7.: enter a name here: ");
string f7name = Console.ReadLine();
var f7student = students.SingleOrDefault(s => s.Name == f7name);
if (f7student is null) Console.WriteLine("\tthere is no student with that name");
else if (!f7student.Results.Values.Any(v => v <= 50))
    Console.WriteLine($"\t{f7name} doesn't have to take any new exam");
else
{
    Console.WriteLine($"\t{f7name} needs to improve in the following subject exam:");
    var f7exams = f7student.Results.Where(kvp => kvp.Value <= 50);
    foreach (var kvp in f7exams) Console.WriteLine($"\t\t- {kvp.Key} (currently: {kvp.Value}%)");
}

var f8 = students
    .Where(s => s.Results.Values.Any(v => v == 100) && !s.Results.Values.Any(v => v <= 50))
    .Count();

Console.WriteLine($"#8.: the number of students who have a 100% result but have not failed any exam: {f8}");

Dictionary<string, int> f9dict = new();
foreach (var student in students)
{
    foreach (var kvp in student.Results)
    {
        if (kvp.Value <= 50)
        {
            if (!f9dict.ContainsKey(kvp.Key)) f9dict.Add(kvp.Key, 0);
            f9dict[kvp.Key]++;
        }
    }
}
Console.WriteLine("#9.: number of retake exams per subject:");
foreach (var kvp in f9dict) Console.WriteLine($"\t- {kvp.Key}: {kvp.Value}");

using StreamWriter sw = new($"{DIRPATH}\\alphabetical.txt", append: false);
var f10orderd = students.OrderBy(s => s.Name.Split(' ')[1]);
foreach (var student in f10orderd)
{
    var sepName = student.Name.Split(' ');
    sw.WriteLine($"{sepName[1]}, {sepName[0]} - {student.SubjectAvg:0.00}%");
}

//TODO: LINQ-t átvenni
//TODO: keressem meg a C#os dictionary jegyzetemet...
//TODO: mutassak nekik rendező algoritmust