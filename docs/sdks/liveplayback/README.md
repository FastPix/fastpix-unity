# LivePlayback
(*LivePlayback*)

## Overview

### Available Operations

* [CreatePlaybackIdOfStream](#createplaybackidofstream) - Create a playbackId
* [DeletePlaybackIdOfStream](#deleteplaybackidofstream) - Delete a playbackId
* [GetLiveStreamPlaybackId](#getlivestreamplaybackid) - Get playbackId details

## CreatePlaybackIdOfStream

Generates a new playback ID for the live stream, allowing viewers to access the stream through this ID. The playback ID can be shared with viewers for direct access to the live broadcast. 

  By calling this endpoint with the `streamId`, FastPix returns a unique `playbackId`, which can be used to stream the live content. 

  #### Example

  A media platform needs to distribute a unique playback ID to users for an exclusive live concert. The platform can also embed the stream on various partner websites.

### Example Usage

<!-- UsageSnippet language="unity" operationID="create-playbackId-of-stream" method="post" path="/live/streams/{streamId}/playback-ids" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.LivePlayback.CreatePlaybackIdOfStreamAsync(
    streamId: "8717422d89288ad5958d4a86e9afe2a2",
    playbackIdRequest: new PlaybackIdRequest() {
    AccessPolicy = BasicAccessPolicy.Public,
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `StreamId`                                                                          | *string*                                                                            | :heavy_check_mark:                                                                  | Upon creating a new live stream, FastPix assigns a unique identifier to the stream. | 8717422d89288ad5958d4a86e9afe2a2                                                    |
| `PlaybackIdRequest`                                                                 | [PlaybackIdRequest](../../Models/Components/PlaybackIdRequest.md)                   | :heavy_check_mark:                                                                  | N/A                                                                                 | {<br/>"accessPolicy": "public"<br/>}                                                |

### Response

**[CreatePlaybackIdOfStreamResponse](../../Models/Requests/CreatePlaybackIdOfStreamResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.LiveNotFoundError          | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## DeletePlaybackIdOfStream

Deletes a previously created playback ID for a live stream. This will prevent any new viewers from accessing the stream through the playback ID, though current viewers will be able to continue watching for a limited time before being disconnected. By providing the `playbackId`, FastPix deletes the ID and ensures new playback requests will fail. 

#### Example
A streaming service wants to prevent new users from joining a live stream that is nearing its end. The host can delete the playback ID to ensure no one can join the stream or replay it once it ends.

### Example Usage

<!-- UsageSnippet language="unity" operationID="delete-playbackId-of-stream" method="delete" path="/live/streams/{streamId}/playback-ids" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.LivePlayback.DeletePlaybackIdOfStreamAsync(
    streamId: "8717422d89288ad5958d4a86e9afe2a2",
    playbackId: "88b7ac0f-2504-4dd5-b7b4-d84ab4fee1bd"))
{
    // handle response
}


```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `StreamId`                                                                          | *string*                                                                            | :heavy_check_mark:                                                                  | Upon creating a new live stream, FastPix assigns a unique identifier to the stream. | 8717422d89288ad5958d4a86e9afe2a2                                                    |
| `PlaybackId`                                                                        | *string*                                                                            | :heavy_check_mark:                                                                  | Unique identifier for the playbackId                                                | 88b7ac0f-2504-4dd5-b7b4-d84ab4fee1bd                                                |

### Response

**[DeletePlaybackIdOfStreamResponse](../../Models/Requests/DeletePlaybackIdOfStreamResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.NotFoundErrorPlaybackId    | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## GetLiveStreamPlaybackId

Retrieves details about a previously created playback ID. If you provide the distinct `playbackId` that was given back to you in the previous stream or <a href="https://docs.fastpix.io/reference/create-playbackid-of-stream">create playbackId</a> request, FastPix will provide the relevant playback details such as the access policy. 

#### Example
A developer needs to confirm the access policy of the playback ID to ensure whether the stream is public or private for viewers.

### Example Usage

<!-- UsageSnippet language="unity" operationID="get-live-stream-playback-id" method="get" path="/live/streams/{streamId}/playback-ids/{playbackId}" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.LivePlayback.GetLiveStreamPlaybackIdAsync(
    streamId: "61a264dcc447b63da6fb79ef925cd76d",
    playbackId: "61a264dcc447b63da6fb79ef925cd76d"))
{
    // handle response
}


```

### Parameters

| Parameter                                                                            | Type                                                                                 | Required                                                                             | Description                                                                          | Example                                                                              |
| ------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------ |
| `StreamId`                                                                           | *string*                                                                             | :heavy_check_mark:                                                                   | Upon creating a new live stream, FastPix assigns a unique identifier to the stream.  | 61a264dcc447b63da6fb79ef925cd76d                                                     |
| `PlaybackId`                                                                         | *string*                                                                             | :heavy_check_mark:                                                                   | Upon creating a new playbackId, FastPix assigns a unique identifier to the playback. | 61a264dcc447b63da6fb79ef925cd76d                                                     |

### Response

**[GetLiveStreamPlaybackIdResponse](../../Models/Requests/GetLiveStreamPlaybackIdResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException      | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.NotFoundErrorPlaybackId    | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |