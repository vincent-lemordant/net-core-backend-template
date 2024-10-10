using System.Net.Http.Json;
using API;
using Domain.Entities;

namespace Template.IntegrationTests;

public class InitativeControllerTest(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task PostInitative_ShouldReturnOk()
    {
        // Arrange
        var newAddressDto = new Initiative { Name = "Test" };

        // Act
        var response = await _client.PostAsJsonAsync($"/api/initative", newAddressDto);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}