Amazon amazon = new();
amazon.CreateServer("CreateServer");
amazon.ListServers("ListServers");
amazon.GetCDNAddress();
amazon.StoreFile("Name");
amazon.GetFile("Name");

Dropbox dropbox = new();
dropbox.StoreFile("Name");
dropbox.GetFile("Name");

interface ICloudHostingProvider
{
    void CreateServer(string region);
    void ListServers(string region);
}

interface ICDNProvider
{
    void GetCDNAddress();
}

interface ICloudStorageProvider
{
    void StoreFile(string name);
    void GetFile(string name);
}

class Amazon : ICloudHostingProvider, ICDNProvider, ICloudStorageProvider
{
    public void CreateServer(string region)
    {
        //
    }

    public void ListServers(string region)
    {
        //
    }

    public void GetCDNAddress()
    {
        //
    }

    public void StoreFile(string name)
    {
        //
    }

    public void GetFile(string name)
    {
        //
    }
}

class Dropbox : ICloudStorageProvider{
    public void StoreFile(string name)
    {
        //
    }

    public void GetFile(string name)
    {
        //
    }
}