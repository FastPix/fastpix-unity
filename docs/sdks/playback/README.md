# Playback
(*Playback*)

## Overview

### Available Operations

* [CreateMediaPlaybackId](#createmediaplaybackid) - Create a playback ID
* [DeleteMediaPlaybackId](#deletemediaplaybackid) - Delete a playback ID
* [GetPlaybackId](#getplaybackid) - Get a playback ID

## CreateMediaPlaybackId

You can create a new playback ID for a specific media asset. If you have already retrieved an existing `playbackId` using the <a href="https://docs.fastpix.io/reference/get-media">Get Media by ID</a> endpoint for a media asset, you can use this endpoint to generate a new playback ID with a specified access policy. 



If you want to create a private playback ID for a media asset that already has a public playback ID, this endpoint also allows you to do so by specifying the desired access policy. 

#### How it works

1. Make a `POST` request to this endpoint, replacing `<mediaId>` with the `uploadId` or `id` of the media asset. 

2. Include the `accessPolicy` in the request body with `private` or `public` as the value. 

3. Receive a response containing the newly created playback ID with the requested access level. 


#### Example
A video streaming service generates playback IDs for each media file when users request to view specific content. The playback ID is then used by the video player to stream the video.


### Example Usage

<!-- UsageSnippet language="unity" operationID="create-media-playback-id" method="post" path="/on-demand/{mediaId}/playback-ids" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;
using System.Collections.Generic;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playback.CreateMediaPlaybackIdAsync(
    mediaId: "dbb8a39a-e4a5-4120-9f22-22f603f1446e",
    requestBody: new CreateMediaPlaybackIdRequestBody() {
    AccessPolicy = AccessPolicy.Public,
    DrmConfigurationId = "123e4567-e89b-12d3-a456-426614174000",
    Resolution = Resolution.OneThousandAndEightyp,
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       | Example                                                                                                           |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `MediaId`                                                                                                         | *string*                                                                                                          | :heavy_check_mark:                                                                                                | When creating the media, FastPix assigns a universally unique identifier with a maximum length of 255 characters. | dbb8a39a-e4a5-4120-9f22-22f603f1446e                                                                              |
| `RequestBody`                                                                                                     | [CreateMediaPlaybackIdRequestBody](../../Models/Requests/CreateMediaPlaybackIdRequestBody.md)                     | :heavy_minus_sign:                                                                                                | Request body for creating playback id for an media                                                                |                                                                                                                   |

### Response

**[CreateMediaPlaybackIdResponse](../../Models/Requests/CreateMediaPlaybackIdResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.InvalidPermissionException | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.ForbiddenException         | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.MediaNotFoundException     | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## DeleteMediaPlaybackId

This endpoint allows you to remove a specific playback ID associated with a media asset. Deleting a `playbackId` will revoke access to the media content linked to that ID. 


#### How it works

1. Make a `DELETE` request to this endpoint, replacing `<mediaId>` with the unique ID of the media asset from which you want to delete the playback ID. 

2. Specify the `playbackId` you wish to delete in the request body. 

#### Example

Your platform offers limited-time access to premium content. When the subscription expires, you can revoke access to the content by deleting the associated playback ID, preventing users from streaming the video further.


### Example Usage

<!-- UsageSnippet language="unity" operationID="delete-media-playback-id" method="delete" path="/on-demand/{mediaId}/playback-ids" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playback.DeleteMediaPlaybackIdAsync(
    mediaId: "dbb8a39a-e4a5-4120-9f22-22f603f1446e",
    playbackId: "dbb8a39a-e4a5-4120-9f22-22f603f1446e"))
{
    // handle response
}


```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           | Example                                                                                               |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `MediaId`                                                                                             | *string*                                                                                              | :heavy_check_mark:                                                                                    | Return the universal unique identifier for media which can contain a maximum of 255 characters.       | dbb8a39a-e4a5-4120-9f22-22f603f1446e                                                                  |
| `PlaybackId`                                                                                          | *string*                                                                                              | :heavy_check_mark:                                                                                    | Return the universal unique identifier for playbacks  which can contain a maximum of 255 characters.  | dbb8a39a-e4a5-4120-9f22-22f603f1446e                                                                  |

### Response

**[DeleteMediaPlaybackIdResponse](../../Models/Requests/DeleteMediaPlaybackIdResponse.md)**

### Errors

| Error Type                                                | Status Code                                               | Content Type                                              |
| --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- |
| fastpix.io.Models.Errors.InvalidPermissionException       | 401                                                       | application/json                                          |
| fastpix.io.Models.Errors.ForbiddenException               | 403                                                       | application/json                                          |
| fastpix.io.Models.Errors.MediaOrPlaybackNotFoundException | 404                                                       | application/json                                          |
| fastpix.io.Models.Errors.ValidationErrorResponse          | 422                                                       | application/json                                          |
| fastpix.io.Models.Errors.APIException                     | 4XX, 5XX                                                  | \*/\*                                                     |

## GetPlaybackId

This endpoint retrieves details about a specific playback ID associated with a media asset. This endpoint is commonly used to check the access policy (e.g., public or private) with the specific playback ID.

**How it works:**
1. Make a GET request to the endpoint, replacing `{mediaId}` with the `id` of the media, and `{playbackId}` with the specific playback ID.
2. Useful for auditing or validation before granting playback access in your application.

**Example:**
A media platform might use this endpoint to verify if a playback ID is public or private before embedding the video in a frontend player or allowing access to a restricted group.


### Example Usage

<!-- UsageSnippet language="unity" operationID="get-playback-id" method="get" path="/on-demand/{mediaId}/playback-ids/{playbackId}" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playback.GetPlaybackIdAsync(
    mediaId: "4fa85f64-5717-4562-b3fc-2c963f66afa6",
    playbackId: "4fa85f64-5717-4562-b3fc-2c963f66afa6"))
{
    // handle response
}


```

### Parameters

| Parameter                            | Type                                 | Required                             | Description                          | Example                              |
| ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ |
| `MediaId`                            | *string*                             | :heavy_check_mark:                   | N/A                                  | 4fa85f64-5717-4562-b3fc-2c963f66afa6 |
| `PlaybackId`                         | *string*                             | :heavy_check_mark:                   | N/A                                  | 4fa85f64-5717-4562-b3fc-2c963f66afa6 |

### Response

**[GetPlaybackIdResponse](../../Models/Requests/GetPlaybackIdResponse.md)**

### Errors

| Error Type                                                | Status Code                                               | Content Type                                              |
| --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- |
| fastpix.io.Models.Errors.InvalidPermissionException       | 401                                                       | application/json                                          |
| fastpix.io.Models.Errors.ForbiddenException               | 403                                                       | application/json                                          |
| fastpix.io.Models.Errors.MediaOrPlaybackNotFoundException | 404                                                       | application/json                                          |
| fastpix.io.Models.Errors.ValidationErrorResponse          | 422                                                       | application/json                                          |
| fastpix.io.Models.Errors.APIException                     | 4XX, 5XX                                                  | \*/\*                                                     |