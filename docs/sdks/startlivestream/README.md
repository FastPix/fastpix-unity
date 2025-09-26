# StartLiveStream
(*StartLiveStream*)

## Overview

### Available Operations

* [CreateNewStream](#createnewstream) - Create a new stream

## CreateNewStream

Allows you to initiate a new <a href="https://docs.fastpix.io/docs/get-started-with-live-streaming">RTMPS</a> or <a href="https://docs.fastpix.io/docs/using-srt-to-live-stream">SRT</a> live stream on FastPix. Upon creating a stream, FastPix generates a unique `streamKey` and `srtSecret`, which can be used with any broadcasting software (like OBS) to connect to FastPix's RTMPS or SRT servers.
Leverage SRT for live streaming in environments with unstable networks, taking advantage of its error correction and encryption features for a resilient and secure broadcast. 

<h4>How it works</h4> 

1. Send a a `POST` request to this endpoint. You can configure the stream settings, including `metadata` (such as stream name and description), `reconnectWindow` (in case of disconnection), and privacy options (`public` or `private`). 

2. FastPix returns the stream details for both RTMPS and SRT configurations. These keys and IDs from the stream details are essential for connecting the broadcasting software to FastPix’s servers and transmitting the live stream to viewers.

3. Once the live stream is created, we’ll shoot a `POST` message to the address you give us with the webhook event <a href="https://docs.fastpix.io/docs/live-events#videolive_streamcreated">video.live_stream.created</a>.


**Example:**


  Imagine a gaming platform that allows users to live stream gameplay directly from their dashboard. The API creates a new stream, provides the necessary stream key, and sets it to "private" so that only specific viewers can access it. 


Related guide: <a href="https://docs.fastpix.io/docs/how-to-livestream">How to live stream</a>

### Example Usage

<!-- UsageSnippet language="unity" operationID="create-new-stream" method="post" path="/live/streams" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using System.Collections.Generic;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });

CreateLiveStreamRequest req = new CreateLiveStreamRequest() {
    PlaybackSettings = new PlaybackSettings() {
        AccessPolicy = BasicAccessPolicy.Public,
    },
    InputMediaSettings = new InputMediaSettings() {
        MaxResolution = CreateLiveStreamRequestMaxResolution.OneThousandAndEightyp,
        ReconnectWindow = 60,
        MediaPolicy = BasicAccessPolicy.Public,
        Metadata = new Dictionary<string, string>() {
            { "livestream_name", "fastpix_livestream" },
        },
        EnableDvrMode = true,
    },
};


using(var res = await sdk.StartLiveStream.CreateNewStreamAsync(req))
{
    // handle response
}


```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [CreateLiveStreamRequest](../../Models/Components/CreateLiveStreamRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[CreateNewStreamResponse](../../Models/Requests/CreateNewStreamResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |