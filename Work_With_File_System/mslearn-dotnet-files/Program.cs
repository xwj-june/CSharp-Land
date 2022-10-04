using Newtonsoft.Json;
#region Basic methods from Directory and Path class
{
    //Exposes the full path to the current directory
    Console.WriteLine(Directory.GetCurrentDirectory());

    //Special path characters
    Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");

    //Join paths
    Console.WriteLine(Path.Combine("stores","201"));

    //Determine filename extensions
    Console.WriteLine(Path.GetExtension("sales.json"));

    //Get everything you need to know about a file or path
    string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

    FileInfo info = new FileInfo(fileName);

    Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more
}
#endregion

#region Get and filter file/directory with Directory and Path class
{
    var currentDirectory = Directory.GetCurrentDirectory();
    var storesDirectory = Path.Combine(currentDirectory, "stores");
    var salesFiles = FindFiles(storesDirectory);

    foreach (var file in salesFiles)
    {
        Console.WriteLine(file);
    }
}
#endregion

#region Create directory with Directory class and File class 1
{
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir");
    bool doesDirectoryExist = Directory.Exists(filePath);
    if (!doesDirectoryExist)
    {
        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));
    }

    //Create file greeting.txt not exist, create it. Otherwise, overwrite it
    File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
}
#endregion

#region Create directory with Directory class and File class 2
{
    var currentDirectory = Directory.GetCurrentDirectory();
    var storesDirectory = Path.Combine(currentDirectory, "stores");

    var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");

    //create directory
    Directory.CreateDirectory(salesTotalDir);

    var salesFiles = FindFiles(storesDirectory);

    File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);
}
#endregion

#region Write and append data to files
{
    var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
    var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

    Console.WriteLine(salesData.Total);

    var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
    //write data to files
    File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", data.Total.ToString());
    //append data to files
    File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data.Total}{Environment.NewLine}");
}
#endregion

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        // if (file.EndsWith("sales.json"))
        // {
        //     salesFiles.Add(file);
        // }

        // Get all json files in the folder
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

class SalesTotal
{
    public double Total { get; set; }
}