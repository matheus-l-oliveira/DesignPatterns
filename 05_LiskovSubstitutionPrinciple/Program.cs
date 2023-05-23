using System.Linq;

Document doc1 = new("doc1Data", "doc1.txt");
WritableDocument doc2 = new("doc2Data", "doc2.txt");

Project project = new(new List<Document> { doc1, doc2 }, new List<WritableDocument> { doc2 });
project.SaveAll();
project.OpenAll();

class Document
{
    public string Data { get; set; }
    public string FileName { get; set; }

    public Document(string data, string fileName)
    {
        Data = data;
        FileName = fileName;
    }

    public void Open()
    {
        Console.WriteLine($"Opening file: {FileName}...");
        Console.WriteLine(Data);
        Console.WriteLine(new string('=', 50));
    }
}

class WritableDocument : Document
{
    public WritableDocument(string data, string fileName) : base(data, fileName)
    {
        Data = data;
        FileName = fileName;
    }

    public void Save()
    {
        Console.WriteLine($"Saving file... {FileName}");
        Console.WriteLine(new string('=', 50));
    }
}

class Project
{
    public List<Document> AllDocs;
    public List<WritableDocument> WritableDocs;

    public Project(List<Document> allDocs, List<WritableDocument> writableDocs)
    {
        AllDocs = allDocs;
        WritableDocs = writableDocs;
    }

    public void OpenAll()
    {
        foreach (var doc in AllDocs)
        {
            doc.Open();
        }
    }

    public void SaveAll()
    {
        foreach (var writableDoc in WritableDocs)
        {
            writableDoc.Save();
        }
    }
}