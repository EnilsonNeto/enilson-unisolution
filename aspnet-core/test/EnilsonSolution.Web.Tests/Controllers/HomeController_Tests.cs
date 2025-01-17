using System.Threading.Tasks;
using EnilsonSolution.Models.TokenAuth;
using EnilsonSolution.Web.Controllers;
using Shouldly;
using Xunit;

namespace EnilsonSolution.Web.Tests.Controllers
{
    public class HomeController_Tests: EnilsonSolutionWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}