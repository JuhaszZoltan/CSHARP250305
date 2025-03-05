namespace CSHARP250305;

class Student
{
    public string Name { get; set; }
    public bool Sex { get; set; }
    public int Balance { get; set; }
    public Dictionary<string, int> Results { get; set; }

    public override string ToString() =>
        $"\t{Name} ({(Sex ? "male" : "female")}) ${Balance}\n" +
        $"\t[net:{Results["network"]}%|" +
            $"mob:{Results["mobile"]}%|" +
            $"front:{Results["frontend"]}%|" +
            $"back:{Results["backend"]}%]";

    public double SubjectAvg => Results.Values.Average();

    public int WebScore => Results["frontend"] + Results["backend"];

    public Student(string row)
    {
        var tmp = row.Split(';');
        Name = tmp[0];
        Sex = tmp[1] == "m";
        Balance = int.Parse(tmp[2]);
        Results = new()
        {
            { "network", int.Parse(tmp[3]) },
            { "mobile", int.Parse(tmp[4]) },
            { "frontend", int.Parse(tmp[5]) },
            { "backend", int.Parse(tmp[6]) },
        };
    }
}
