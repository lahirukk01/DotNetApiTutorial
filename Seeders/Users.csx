#r "nuget:Bogus,35.5.1"
#r "nuget:Microsoft.Data.SqlClient,5.2.1"
#r "nuget:Dapper,2.1.35"

using Bogus;
using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;User Id=sa;Password=Sqlconnect1;";
string[] Gender = {"Male", "Female", "Other"};

int NUsersToGenerate = 10;

using (var connection = new SqlConnection(connectionString))
{
    var faker = new Faker();
    var users = new List<dynamic>();
    
    for (int i = 1; i <= NUsersToGenerate; i++ ) {
        var email = faker.Internet.Email();
        var firstName = faker.Name.FirstName();
        var lastName = faker.Name.LastName();
        var gender = faker.PickRandom(Gender);
        var active = faker.Random.Bool();
        
        users.Add(new {FirstName = firstName, LastName = lastName, Email = email, Gender = gender, Active = active});
    }
    
    string sql = "INSERT INTO TutorialAppSchema.t_user (first_name, last_name, email, gender, active) VALUES (@FirstName, @LastName, @Email, @Gender, @Active)";
    
    var affectedRows = connection.Execute(sql, users);

    Console.WriteLine($"{affectedRows} rows affected.");
}


