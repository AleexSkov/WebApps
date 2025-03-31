using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ServerAPI.Controllers;

[Route("api/dogs")]
[ApiController]
public class DogController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public DogController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("{count}")]
    public async Task<IActionResult> GetDogImages(int count)
    {
        if (count <= 0)
            return BadRequest("Antallet skal være større end 0.");

        var response = await _httpClient.GetFromJsonAsync<DogResponse>(
         ///   $"https://dog.ceo/api/breed/mountain/bernese/images/random/{count}");
                    $"https://dog.ceo/api/breed/dachshund/images/random/{count}");


        if (response?.Message == null)
            return StatusCode(500, "Fejl ved hentning af billeder");

        return Ok(response.Message);
    }
}

public record DogResponse(List<string> Message);
