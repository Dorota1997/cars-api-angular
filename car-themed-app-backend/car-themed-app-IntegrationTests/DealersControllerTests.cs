using car_themed_app_Contracts;
using car_themed_app_IntegrationTests.DeserializedJsonModels;
using car_themed_app_Repository.Dtos.DealerDtos;
using car_themed_app_Repository.Models;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace car_themed_app_IntegrationTests
{
    public class DealersControllerTests : IntegrationTest
    {
        private readonly int _defaultPageNumber = 1;
        private readonly int _defaultMaxPageSize = 10;
        private readonly int _unexistingDealerId = 999;

        [Fact]
        public async Task GetAllDealers_WithoutAnyDealers_ReturnsEmptyResponse()
        {
            // Arrange
            
            // Act
            HttpResponseMessage response = await TestClient.GetAsync(ApiRoutes.Dealers.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string result = await response.Content.ReadAsStringAsync();
            var responseContent = DeserializeContentIntoObject<DeserializedGetAll<DealerDto>>(result);

            responseContent.Data.Count.Should().Be(0);
            responseContent.PageNumber.Should().Be(_defaultPageNumber);
            responseContent.PageSize.Should().Be(_defaultMaxPageSize);
            responseContent.NextPage.Should().BeNull();
            responseContent.PreviousPage.Should().BeNull();
        }

        [Fact]
        public async Task GetAllDealers_ReturnsMaximumPossibleDealerNumber_DueToPaginationDefaultLimit()
        {
            // Arrange
            for (int i = 0; i < 20; i++)
            {
                await CreateDealerAsync(new NewDealerDto { Name = "Kazlov", Address = "Inte-Tests", Country = "Poland", PostalCode = "040" });
            }

            // Act
            HttpResponseMessage response = await TestClient.GetAsync(ApiRoutes.Dealers.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string result = await response.Content.ReadAsStringAsync();
            var responseContent = DeserializeContentIntoObject<DeserializedGetAll<DealerDto>>(result);

            responseContent.Data.Count.Should().Be(_defaultMaxPageSize);
        }

        [Fact]
        public async Task Get_ReturnsDealer_WhenDealerExistsInDatabase()
        {
            // Arrange
            var createdDealer = await CreateDealerAsync(Instantiate_NewDealerDto_Object());

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Dealers.Get.Replace("{dealerId}", createdDealer.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseContent = await response.Content.ReadAsStringAsync();
            var returnedDealer = DeserializeContentIntoObject<DealerDto>(responseContent);

            returnedDealer.Id.Should().Be(createdDealer.Id);
            returnedDealer.Name.Should().Be(createdDealer.Name);
            returnedDealer.Address.Should().Be(createdDealer.Address);
            returnedDealer.PostalCode.Should().Be(createdDealer.PostalCode);
            returnedDealer.Country.Should().Be(createdDealer.Country);
        }

        [Fact]
        public async Task Get_ReturnsNotFound_WhenDealerNotExistsInDatabase()
        {
            // Arrange

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Dealers.Get.Replace("{dealerId}", _unexistingDealerId.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenDealerIsDeletedFromDatabase()
        {
            // Arrange
            var createdDealer = await CreateDealerAsync(Instantiate_NewDealerDto_Object());

            // Act
            var response = await TestClient.DeleteAsync(ApiRoutes.Dealers.Delete.Replace("{dealerId}", createdDealer.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenDealerToDeleteNotExists()
        {
            // Arrange

            // Act
            var response = await TestClient.DeleteAsync(ApiRoutes.Dealers.Delete.Replace("{dealerId}", _unexistingDealerId.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var responseContent = await response.Content.ReadAsStringAsync();

            responseContent.Should().Contain($"Dealer {_unexistingDealerId} does not exist.");
        }

        [Fact]
        public async Task Update_ReturnsOK_WhenDealerWasSuccessfullyUpdated()
        {
            // Arrange
            var createdDealer = await CreateDealerAsync(Instantiate_NewDealerDto_Object());
            var dealerToUpdate = Instantiate_UpdateDealerDto_Object(createdDealer.Id);

            // Act
            var response = await TestClient.PutAsJsonAsync(ApiRoutes.Dealers.Update, dealerToUpdate);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenDealerNotExistsInDatabase()
        {
            // Arrange
            var dealerToUpdate = Instantiate_UpdateDealerDto_Object(_unexistingDealerId);

            // Act
            var response = await TestClient.PutAsJsonAsync(ApiRoutes.Dealers.Update, dealerToUpdate);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var responseContent = await response.Content.ReadAsStringAsync();

            responseContent.Should().Contain($"Dealer {_unexistingDealerId} does not exist.");
        }

        private async Task<Dealer> CreateDealerAsync(NewDealerDto dealer)
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Dealers.Create, dealer);
            var responseContent = await response.Content.ReadAsStringAsync();
            return DeserializeContentIntoObject<Dealer>(responseContent);
        }
        
        private NewDealerDto Instantiate_NewDealerDto_Object()
        {
            return new NewDealerDto()
            {
                Name = "Kazlov - NewDealer",
                Address = "Inte-Tests",
                Country = "Poland",
                PostalCode = "040"
            };
        }

        private UpdateDealerDto Instantiate_UpdateDealerDto_Object(int id)
        {
            return new UpdateDealerDto()
            {
                Id = id,
                Name = "Zaklov - UpdateDealer",
                Address = "testing",
                Country = "testing",
                PostalCode = "testing"
            };
        }
    }
}
