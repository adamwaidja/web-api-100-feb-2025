using Microsoft.AspNetCore.Mvc;

namespace SoftwareCatalog.Api.Status;

//have to be public classes and have to extend* ControllerBase
public class StatusController : ControllerBase
{
    [HttpGet("/Status")]
    public ActionResult GetTheStatus()
    {
        // 
        // this is fake...
        var response = new StatusResponse(DateTimeOffset.Now, "Looks Good!");
        return Ok(response);
    }

}

public record StatusResponse(DateTimeOffset LastChecked, String Message);
