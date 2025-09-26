# ManageLiveStream
(*ManageLiveStream*)

## Overview

### Available Operations

* [GetAllStreams](#getallstreams) - Get all live streams
* [GetLiveStreamViewerCountById](#getlivestreamviewercountbyid) - Get stream views by ID
* [GetLiveStreamById](#getlivestreambyid) - Get stream by ID
* [DeleteLiveStream](#deletelivestream) - Delete a stream
* [UpdateLiveStream](#updatelivestream) - Update a stream
* [DisableLiveStream](#disablelivestream) - Disable a stream
* [CompleteLiveStream](#completelivestream) - Complete a stream

## GetAllStreams

Retrieves a list of all live streams associated with the current workspace. It provides an overview of both current and past live streams, including details like `streamId`, `metadata`, `status`, `createdAt` and more.


#### How it works

Use the access token and secret key related to the workspace in the request header. When called, the API provides a paginated response containing all the live streams in that specific workspace. This is helpful for retrieving a large volume of streams and managing content in bulk.

### Example Usage

<!-- UsageSnippet language="unity" operationID="get-all-streams" method="get" path="/live/streams" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.ManageLiveStream.GetAllStreamsAsync(
    limit: 20,
    offset: 1,
    orderBy: OrderBy.Desc))
{
    // handle response
}


```

### Parameters

| Parameter                                                                                                                           | Type                                                                                                                                | Required                                                                                                                            | Description                                                                                                                         | Example                                                                                                                             |
| ----------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| `Limit`                                                                                                                             | *long*                                                                                                                              | :heavy_minus_sign:                                                                                                                  | Limit specifies the maximum number of items to display per page.                                                                    | 20                                                                                                                                  |
| `Offset`                                                                                                                            | *long*                                                                                                                              | :heavy_minus_sign:                                                                                                                  | Offset determines the starting point for data retrieval within a paginated list.                                                    | 1                                                                                                                                   |
| `OrderBy`                                                                                                                           | [OrderBy](../../Models/Requests/OrderBy.md)                                                                                         | :heavy_minus_sign:                                                                                                                  | The list of value can be order in two ways DESC (Descending) or ASC (Ascending). In case not specified, by default it will be DESC. | desc                                                                                                                                |

### Response

**[GetAllStreamsResponse](../../Models/Requests/GetAllStreamsResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## GetLiveStreamViewerCountById

This endpoint retrieves the current number of viewers watching a specific live stream, identified by its unique `streamId`.

The viewer count is an **approximate value**, optimized for performance. It provides a near-real-time estimate of how many clients are actively watching the stream. This approach ensures high efficiency, especially when the stream is being watched at large scale across multiple devices or platforms.

#### Example

Suppose a content creator is hosting a live concert and wants to display the number of live viewers on their dashboard. This endpoint can be queried to show up-to-date viewer statistics.

Related guide: <a href="https://docs.fastpix.io/docs/manage-streams">Manage streams</a>

### Example Usage

<!-- UsageSnippet language="unity" operationID="get-live-stream-viewer-count-by-id" method="get" path="/live/streams/{streamId}/viewer-count" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.ManageLiveStream.GetLiveStreamViewerCountByIdAsync(streamId: "61a264dcc447b63da6fb79ef925cd76d"))
{
    // handle response
}


```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `StreamId`                                                                          | *string*                                                                            | :heavy_check_mark:                                                                  | Upon creating a new live stream, FastPix assigns a unique identifier to the stream. | 61a264dcc447b63da6fb79ef925cd76d                                                    |

### Response

**[GetLiveStreamViewerCountByIdResponse](../../Models/Requests/GetLiveStreamViewerCountByIdResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.LiveNotFoundError          | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## GetLiveStreamById

This endpoint retrieves details about a specific live stream by its unique `streamId`. It includes data such as the stream’s `status` (idle, preparing, active, disabled), `metadata` (title, description), and more. 
#### Example

  Suppose a news agency is broadcasting a live event and wants to track the configurations set for the live stream while also checking the stream's status.


Related guide: <a href="https://docs.fastpix.io/docs/manage-streams">Manage streams</a>

### Example Usage

<!-- UsageSnippet language="unity" operationID="get-live-stream-by-id" method="get" path="/live/streams/{streamId}" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.ManageLiveStream.GetLiveStreamByIdAsync(streamId: "61a264dcc447b63da6fb79ef925cd76d"))
{
    // handle response
}


```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `StreamId`                                                                          | *string*                                                                            | :heavy_check_mark:                                                                  | Upon creating a new live stream, FastPix assigns a unique identifier to the stream. | 61a264dcc447b63da6fb79ef925cd76d                                                    |

### Response

**[GetLiveStreamByIdResponse](../../Models/Requests/GetLiveStreamByIdResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.NotFoundError              | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## DeleteLiveStream

Permanently removes a specified live stream from the workspace. If the stream is still active, the encoder will be disconnected, and the ingestion will stop. This action cannot be undone, and any future playback attempts will fail. 

  By providing the `streamId`, the API will terminate any active connections to the stream and remove it from the list of available live streams. You can further look for <a href="https://docs.fastpix.io/docs/live-events#videolive_streamdeleted">video.live_stream.deleted</a> webhook to notify your system about the status. 

  #### Example

  For an online concert platform, a trial stream was mistakenly made public. The event manager deletes the stream before the concert begins to avoid confusion among viewers. 


  Related guide: <a href="https://docs.fastpix.io/docs/manage-streams">Manage streams</a>

### Example Usage

<!-- UsageSnippet language="unity" operationID="delete-live-stream" method="delete" path="/live/streams/{streamId}" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.ManageLiveStream.DeleteLiveStreamAsync(streamId: "8717422d89288ad5958d4a86e9afe2a2"))
{
    // handle response
}


```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `StreamId`                                                                          | *string*                                                                            | :heavy_check_mark:                                                                  | Upon creating a new live stream, FastPix assigns a unique identifier to the stream. | 8717422d89288ad5958d4a86e9afe2a2                                                    |

### Response

**[DeleteLiveStreamResponse](../../Models/Requests/DeleteLiveStreamResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.LiveNotFoundError          | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## UpdateLiveStream

This endpoint allows you to modify the parameters of an existing live stream, such as its `metadata` (title, description) or the `reconnectWindow`. It’s useful for making changes to a stream that has already been created but not yet ended. Once the live stream is disabled, you cannot update a stream. 


  The updated stream parameters and the `streamId` needs to be shared in the request, and FastPix will return the updated stream details. Once updated, <a href="https://docs.fastpix.io/docs/live-events#videolive_streamupdated">video.live_stream.updated</a> webhook event notifies your system. 

 #### Example

 A host realizes they need to extend the reconnect window for their live stream in case they lose connection temporarily during the event. Or suppose during a multi-day online conference, the event organizers need to update the stream title to reflect the next day's session while keeping the same stream ID for continuity. 



  Related guide: <a href="https://docs.fastpix.io/docs/manage-streams">Manage streams</a>

### Example Usage

<!-- UsageSnippet language="unity" operationID="update-live-stream" method="patch" path="/live/streams/{streamId}" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;
using System.Collections.Generic;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.ManageLiveStream.UpdateLiveStreamAsync(
    streamId: "91a264dcc447b63da6fb79ef925cd76d",
    patchLiveStreamRequest: new PatchLiveStreamRequest() {
    Metadata = new Dictionary<string, string>() {
        { "livestream_name", "Gaming_stream" },
    },
    ReconnectWindow = 100,
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `StreamId`                                                                          | *string*                                                                            | :heavy_check_mark:                                                                  | Upon creating a new live stream, FastPix assigns a unique identifier to the stream. | 91a264dcc447b63da6fb79ef925cd76d                                                    |
| `PatchLiveStreamRequest`                                                            | [PatchLiveStreamRequest](../../Models/Components/PatchLiveStreamRequest.md)         | :heavy_check_mark:                                                                  | N/A                                                                                 | {<br/>"metadata": {<br/>"livestream_name": "Gaming_stream"<br/>},<br/>"reconnectWindow": 100<br/>} |

### Response

**[UpdateLiveStreamResponse](../../Models/Requests/UpdateLiveStreamResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.LiveNotFoundError          | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## DisableLiveStream

This endpoint disables a livestream by setting its status to `disabled`. Use this to stop a livestream when it's no longer needed or should be taken offline intentionally.

A disabled stream can later be re-enabled using the enable endpoint — however, if you're on a trial plan, re-enabling is not allowed once the stream is disabled.

#### Example

A speaker finishes their live session and wants to prevent the stream from being mistakenly started again. By calling this endpoint, the stream is transitioned to a `disabled` state, ensuring it's permanently stopped (unless re-enabled on a paid plan).

Related guide <a href="https://docs.fastpix.io/docs/manage-streams">Manage streams</a>

### Example Usage

<!-- UsageSnippet language="unity" operationID="disable-live-stream" method="put" path="/live/streams/{streamId}/live-disable" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.ManageLiveStream.DisableLiveStreamAsync(streamId: "91a264dcc447b63da6fb79ef925cd76d"))
{
    // handle response
}


```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `StreamId`                                                                          | *string*                                                                            | :heavy_check_mark:                                                                  | Upon creating a new live stream, FastPix assigns a unique identifier to the stream. | 91a264dcc447b63da6fb79ef925cd76d                                                    |

### Response

**[DisableLiveStreamResponse](../../Models/Requests/DisableLiveStreamResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.StreamAlreadyDisabledError | 400                                                 | application/json                                    |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.LiveNotFoundError          | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## CompleteLiveStream

This endpoint marks a livestream as completed by stopping the active stream and transitioning its status to `idle`. It is typically used after a livestream session has ended.

This operation only works when the stream is in the `active` state.

Completing a stream can help finalize the session and trigger post-processing events like VOD generation.

#### Example

A virtual event ends, and the system or host needs to close the livestream to prevent further streaming. This endpoint ensures the livestream status is changed from `active` to `idle`, indicating it's officially completed.

Related guide <a href="https://docs.fastpix.io/docs/manage-streams">Manage streams</a>

### Example Usage

<!-- UsageSnippet language="unity" operationID="complete-live-stream" method="put" path="/live/streams/{streamId}/finish" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.ManageLiveStream.CompleteLiveStreamAsync(streamId: "91a264dcc447b63da6fb79ef925cd76d"))
{
    // handle response
}


```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `StreamId`                                                                          | *string*                                                                            | :heavy_check_mark:                                                                  | Upon creating a new live stream, FastPix assigns a unique identifier to the stream. | 91a264dcc447b63da6fb79ef925cd76d                                                    |

### Response

**[CompleteLiveStreamResponse](../../Models/Requests/CompleteLiveStreamResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 400, 401                                            | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.NotFoundError              | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |