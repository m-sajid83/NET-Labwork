using Microsoft.Data.Sqlite;
using DOT_NET_lab_9.Models;
namespace DOT_NET_lab_9.Data;
public static class PlacementDb
{
    private static readonly string DbPath = Path.Combine(AppContext.BaseDirectory, "placement.db");
    private static string Cs => $"Data Source={DbPath}";
    public static void Initialize()
    {
        using var c = new SqliteConnection(Cs); c.Open();
        using var cmd = c.CreateCommand();
        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Students(
          StudentId INTEGER PRIMARY KEY AUTOINCREMENT, EnrollmentNo TEXT NOT NULL,
          StudentName TEXT NOT NULL, Department TEXT NOT NULL, IsPlaced INTEGER NOT NULL);
          CREATE TABLE IF NOT EXISTS Placements(
          PlacementId INTEGER PRIMARY KEY AUTOINCREMENT, StudentId INTEGER NOT NULL,
          CompanyName TEXT NOT NULL, JobRole TEXT NOT NULL, PackageLPA REAL NOT NULL);";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "SELECT COUNT(*) FROM Students;";
        if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
        {
            cmd.CommandText = @"INSERT INTO Students(EnrollmentNo,StudentName,Department,IsPlaced) VALUES
            ('92400103336','Yatharthsinh Zala','Computer Engineering',1),
            ('92400103216','Mahmad Sajid','Computer Engineering',1),
            ('92400103322','Omdeepsinh Jadeja','Computer Engineering',1),
            ('92400103113','Ashish Agrawal','Computer Engineering',0),
            ('92400103405','Srisant Kumar','Computer Engineering',1),
            ('92400103501','Aarav Patel','Computer Engineering',0),
            ('92400103502','Diya Shah','Computer Engineering',1),
            ('92400103503','Rohan Mehta','Computer Engineering',1),
            ('92400103504','Nisha Joshi','Computer Engineering',0),
            ('92400103505','Karan Desai','Computer Engineering',1),
            ('92400103506','Mira Trivedi','Computer Engineering',1),
            ('92400103507','Dev Parmar','Computer Engineering',0);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"INSERT INTO Placements(StudentId,CompanyName,JobRole,PackageLPA)
            SELECT StudentId,
            CASE StudentId%4 WHEN 0 THEN 'Infosys' WHEN 1 THEN 'TCS' WHEN 2 THEN 'Wipro' ELSE 'Tech Mahindra' END,
            CASE StudentId%3 WHEN 0 THEN 'Software Developer' WHEN 1 THEN 'Graduate Engineer Trainee' ELSE 'Web Developer' END,
            CASE StudentId%5 WHEN 0 THEN 4.5 WHEN 1 THEN 5.0 WHEN 2 THEN 6.0 WHEN 3 THEN 7.2 ELSE 8.0 END
            FROM Students WHERE IsPlaced=1;";
            cmd.ExecuteNonQuery();
        }
    }
    public static (int total, decimal high, decimal avg) Overview()
    {
        using var c = new SqliteConnection(Cs); c.Open();
        using var cmd = c.CreateCommand();
        cmd.CommandText = "SELECT (SELECT COUNT(*) FROM Students WHERE IsPlaced=1), COALESCE((SELECT MAX(PackageLPA) FROM Placements),0), COALESCE((SELECT AVG(PackageLPA) FROM Placements),0);";
        using var r = cmd.ExecuteReader(); r.Read();
        return (r.GetInt32(0), r.GetDecimal(1), r.GetDecimal(2));
    }
    public static int StudentCount()
    {
        using var c = new SqliteConnection(Cs); c.Open();
        using var cmd = c.CreateCommand(); cmd.CommandText = "SELECT COUNT(*) FROM Students;";
        return Convert.ToInt32(cmd.ExecuteScalar());
    }
    public static List<StudentPlacement> Students(int page, int size)
    {
        var list = new List<StudentPlacement>();
        using var c = new SqliteConnection(Cs); c.Open();
        using var cmd = c.CreateCommand();
        cmd.CommandText = @"SELECT s.StudentId,s.EnrollmentNo,s.StudentName,s.Department,s.IsPlaced,
          COALESCE(p.CompanyName,'-'),COALESCE(p.JobRole,'-'),p.PackageLPA
          FROM Students s LEFT JOIN Placements p ON s.StudentId=p.StudentId
          ORDER BY s.StudentId LIMIT $n OFFSET $o;";
        cmd.Parameters.AddWithValue("$n",size); cmd.Parameters.AddWithValue("$o",(page-1)*size);
        using var r = cmd.ExecuteReader();
        while(r.Read()) list.Add(new StudentPlacement {
          StudentId=r.GetInt32(0), EnrollmentNo=r.GetString(1), StudentName=r.GetString(2),
          Department=r.GetString(3), IsPlaced=r.GetInt32(4)==1, CompanyName=r.GetString(5),
          JobRole=r.GetString(6), PackageLPA=r.IsDBNull(7)?null:r.GetDecimal(7)});
        return list;
    }
    public static List<CompanySummary> Companies()
    {
        var list = new List<CompanySummary>();
        using var c = new SqliteConnection(Cs); c.Open();
        using var cmd = c.CreateCommand();
        cmd.CommandText = "SELECT CompanyName,COUNT(*),MAX(PackageLPA),AVG(PackageLPA) FROM Placements GROUP BY CompanyName ORDER BY CompanyName;";
        using var r=cmd.ExecuteReader();
        while(r.Read()) list.Add(new CompanySummary { CompanyName=r.GetString(0),TotalHired=r.GetInt32(1),MaxPackage=r.GetDecimal(2),AveragePackage=r.GetDecimal(3)});
        return list;
    }
    public static List<StudentPlacement> PlacedStudents()
    {
        var list=new List<StudentPlacement>();
        using var c=new SqliteConnection(Cs); c.Open();
        using var cmd=c.CreateCommand();
        cmd.CommandText=@"SELECT s.StudentId,s.EnrollmentNo,s.StudentName,s.Department,p.CompanyName,p.JobRole,p.PackageLPA
          FROM Placements p INNER JOIN Students s ON p.StudentId=s.StudentId ORDER BY p.CompanyName,s.StudentName;";
        using var r=cmd.ExecuteReader();
        while(r.Read()) list.Add(new StudentPlacement { StudentId=r.GetInt32(0),EnrollmentNo=r.GetString(1),StudentName=r.GetString(2),Department=r.GetString(3),IsPlaced=true,CompanyName=r.GetString(4),JobRole=r.GetString(5),PackageLPA=r.GetDecimal(6)});
        return list;
    }
}
