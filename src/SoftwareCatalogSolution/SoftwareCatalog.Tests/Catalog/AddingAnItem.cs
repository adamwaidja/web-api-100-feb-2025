﻿
using Alba;
using SoftwareCatalog.Api.Catalog;

namespace SoftwareCatalog.Tests.Catalog;
public class AddingAnItem
{
    [Fact]
    public async Task CanAddAnItem()
    {
        var host = await AlbaHost.For<Program>();


        var itemToPost = new CatalogItemRequestModel
        {
            Name = "Visual Studio Code"
        };

        var response = await host.Scenario(api =>
        {
            api.Post.Json(itemToPost).ToUrl("/vendors/microsoft/opensource");
            api.StatusCodeShouldBe(201);
        });

        var responseFromThePost = response.ReadAsJson<CatalogItemResponseDetailsModel>();
        Assert.NotNull(responseFromThePost);

        //   Assert.Equal(expectedResponse, body);

        var getResponse = await host.Scenario(api =>
        {
            api.Get.Url($"/catalog/{responseFromThePost.Id}");
        });

        var responseFromGet = getResponse.ReadAsJson<CatalogItemResponseDetailsModel>();
        Assert.NotNull(responseFromGet);

        Assert.Equal(responseFromThePost, responseFromGet);

    }
}
