using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly BlobStorageService _blobStorageService;

    public PropertiesController()
    {
        // Replace with your actual blob URL and SAS token
        string blobUrl = "https://nmrkpidev.blob.core.windows.net/dev-test/dev-test.json";
        string sasToken = "?sp=r&st=2024-10-28T10:35:48Z&se=2025-10-28T18:35:48Z&spr=https&sv=2022-11-02&sr=b&sig=bdeoPWtefikVgUGFCUs4ihsl22ZhQGu4%2B4cAfoMwd4k%3D";

        _blobStorageService = new BlobStorageService(blobUrl, sasToken);
    }

    [HttpGet]
    public async Task<IActionResult> GetProperties()
    {
        try
        {
            // Fetch properties from Blob Storage
            List<Property> properties = await _blobStorageService.FetchPropertiesAsync();
            return Ok(properties);
        }
        catch (Exception ex)
        {
            // Handle errors gracefully
            return StatusCode(500, new { message = "Failed to retrieve properties.", error = ex.Message });
        }
    }
}
