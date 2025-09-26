<!-- Start SDK Example Usage [usage] -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using System.Collections.Generic;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });

CreateMediaRequest req = new CreateMediaRequest() {
    Inputs = new List<fastpix.io.Models.Components.Input>() {
        Input.CreateVideoInput(
            new VideoInput() {
                Type = "video",
                Url = "https://static.fastpix.io/sample.mp4",
            },
        ),
    },
    Metadata = new Dictionary<string, string>() {
        { "key1", "value1" },
    },
    AccessPolicy = CreateMediaRequestAccessPolicy.Public,
    MaxResolution = CreateMediaRequestMaxResolution.OneThousandAndEightyp,
};


using(var res = await sdk.InputVideo.CreateMediaAsync(req))
{
    // handle response
}


```
<!-- End SDK Example Usage [usage] -->