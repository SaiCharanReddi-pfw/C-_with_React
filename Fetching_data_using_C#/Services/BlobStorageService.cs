using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class BlobStorageService
{
    private readonly string _blobUrl;
    private readonly string _sasToken;

    public BlobStorageService(string blobUrl, string sasToken)
    {
        _blobUrl = blobUrl;
        _sasToken = sasToken;
    }

    public async Task<List<Property>> FetchPropertiesAsync()
    {
        try
        {
            // Create BlobClient
            BlobClient blobClient = new BlobClient(new Uri(_blobUrl + _sasToken));

            // Download JSON content to a memory stream
            using var memoryStream = new MemoryStream();
            await blobClient.DownloadToAsync(memoryStream);

            // Convert the memory stream to a JSON string
            string jsonContent = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());

            // Deserialize the JSON into a list of Property objects
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // To handle JSON case insensitivity
            };
            return JsonSerializer.Deserialize<List<Property>>(jsonContent, options);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to fetch or parse blob content.", ex);
        }
    }
}
