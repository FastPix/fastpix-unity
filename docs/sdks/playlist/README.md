# Playlist
(*Playlist*)

## Overview

### Available Operations

* [CreateAPlaylist](#createaplaylist) - Create a new playlist
* [GetAllPlaylists](#getallplaylists) - Get all playlists
* [GetPlaylistById](#getplaylistbyid) - Get a playlist by ID
* [UpdateAPlaylist](#updateaplaylist) - Update a playlist by ID
* [DeleteAPlaylist](#deleteaplaylist) - Delete a playlist by ID
* [AddMediaToPlaylist](#addmediatoplaylist) - Add media to a playlist by ID
* [ChangeMediaOrderInPlaylist](#changemediaorderinplaylist) - Change media order in a playlist by ID
* [DeleteMediaFromPlaylist](#deletemediafromplaylist) - Delete media in a playlist by ID

## CreateAPlaylist

This endpoint creates a new playlist within a specified workspace. A playlist acts as a container for organizing media items either manually or based on filters and metadata. <br> <br>
### Playlists can be created in two modes
- **Manual:** An empty playlist is created without any initial media items. It's intended for manual curation, where items can be added later in a user-defined sequence.
- **Smart:** The playlist is auto-populated at creation time based on filters (video creation date range) criteria provided in the request.

#### How it works 

 - When a user sends a POST request to this endpoint, FastPix creates a playlist and returns a playlist ID, using which items can be added later in a user-defined sequence.
 - For a smart playlist, the playlist will be auto-populated based on metadata in the request body.


#### Example
An e-learning platform creates a new playlist titled "Beginner Python Series" via the API. The response includes a unique playlist ID. The platform then uses this ID to add a series of video tutorials to the playlist in a defined order. The playlist is presented to learners on the frontend as a structured learning path.

### Example Usage

<!-- UsageSnippet language="unity" operationID="create-a-playlist" method="post" path="/on-demand/playlists" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });

CreatePlaylistRequest req = new CreatePlaylistRequest() {
    Name = "playlist name",
    ReferenceId = "a1",
    Type = CreatePlaylistRequestType.Smart,
    Description = "This is a playlist",
    PlayOrder = PlaylistOrder.CreatedDateASC,
    Limit = 20,
    Metadata = new CreatePlaylistRequestMetadata() {
        CreatedDate = new DateRange() {
            StartDate = "2024-11-11",
            EndDate = "2024-12-12",
        },
        UpdatedDate = new DateRange() {
            StartDate = "2024-11-11",
            EndDate = "2024-12-12",
        },
    },
};


using(var res = await sdk.Playlist.CreateAPlaylistAsync(req))
{
    // handle response
}


```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [CreatePlaylistRequest](../../Models/Components/CreatePlaylistRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[CreateAPlaylistResponse](../../Models/Requests/CreateAPlaylistResponse.md)**

### Errors

| Error Type                                                 | Status Code                                                | Content Type                                               |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException             | 401                                                        | application/json                                           |
| fastpix.io.Models.Errors.InvalidPermissionException        | 403                                                        | application/json                                           |
| fastpix.io.Models.Errors.DuplicateReferenceIdErrorResponse | 409                                                        | application/json                                           |
| fastpix.io.Models.Errors.ValidationErrorResponse           | 422                                                        | application/json                                           |
| fastpix.io.Models.Errors.APIException                      | 4XX, 5XX                                                   | \*/\*                                                      |

## GetAllPlaylists

This endpoint retrieves all playlists present within a specified workspace. It allows users to view the collection of playlists that have been created, whether manual or smart, along with their associated metadata.
#### How it works

 - When a user sends a GET request to this endpoint, FastPix returns a list of all playlists in the workspace, including details such as playlist IDs, titles, creation mode (manual or smart), and other relevant metadata.
 
#### Example

  An e-learning platform requests all playlists within a workspace to display an overview of available learning paths. The response includes multiple playlists like "Beginner Python Series" and "Advanced Java Tutorials," enabling the platform to show users a catalog of curated content collections.

### Example Usage

<!-- UsageSnippet language="unity" operationID="get-all-playlists" method="get" path="/on-demand/playlists" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playlist.GetAllPlaylistsAsync(
    limit: 1,
    offset: 1))
{
    // handle response
}


```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             | Example                                                                                 |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `Limit`                                                                                 | *long*                                                                                  | :heavy_minus_sign:                                                                      | The number of playlists to return (default is 10, max is 50).                           | 1                                                                                       |
| `Offset`                                                                                | *long*                                                                                  | :heavy_minus_sign:                                                                      | The page number to retrieve, starting from 1. Used for paginating the playlist results. | 1                                                                                       |

### Response

**[fastpix.io.Models.Requests.GetAllPlaylistsResponse](../../Models/Requests/GetAllPlaylistsResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException | 401                                            | application/json                               |
| fastpix.io.Models.Errors.APIException          | 4XX, 5XX                                       | \*/\*                                          |

## GetPlaylistById

This endpoint retrieves detailed information about a specific playlist using its unique `playlistId`. It provides comprehensive metadata about the playlist, including its title, creation mode (manual or smart), media items along with the metadata of each media in the playlist.

 
#### Example
An e-learning platform requests details for the playlist "Beginner Python Series" by providing its unique `playlistId`. The response includes the playlist's title, creation mode, and the ordered list of video tutorials contained within, enabling the platform to present the full learning path to users.

### Example Usage

<!-- UsageSnippet language="unity" operationID="get-playlist-by-id" method="get" path="/on-demand/playlists/{playlistId}" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playlist.GetPlaylistByIdAsync(playlistId: "<id>"))
{
    // handle response
}


```

### Parameters

| Parameter                                           | Type                                                | Required                                            | Description                                         |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| `PlaylistId`                                        | *string*                                            | :heavy_check_mark:                                  | The unique id of the playlist you want to retrieve. |

### Response

**[GetPlaylistByIdResponse](../../Models/Requests/GetPlaylistByIdResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException              | 401                                                         | application/json                                            |
| fastpix.io.Models.Errors.NotFoundError                      | 404                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPlaylistIdResponseException | 422                                                         | application/json                                            |
| fastpix.io.Models.Errors.APIException                       | 4XX, 5XX                                                    | \*/\*                                                       |

## UpdateAPlaylist

This endpoint allows you to update the name and description of an existing playlist. It enables modifications to the playlist's metadata without altering the media items or playlist structure.
#### How it works

 - When a user sends a PUT request to this endpoint with the `playlistId` and updated name and description in the request body, FastPix updates the playlist metadata accordingly and returns the updated playlist details.

#### Example
An e-learning platform updates the playlist titled "Beginner Python Series" to rename it as "Python Basics" and add a more detailed description. The updated metadata is reflected when retrieving the playlist, helping users better understand the playlist content.

### Example Usage

<!-- UsageSnippet language="unity" operationID="update-a-playlist" method="put" path="/on-demand/playlists/{playlistId}" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playlist.UpdateAPlaylistAsync(
    playlistId: "<id>",
    updatePlaylistRequest: new UpdatePlaylistRequest() {
    Name = "updated name",
    Description = "updated description",
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `PlaylistId`                                                              | *string*                                                                  | :heavy_check_mark:                                                        | The unique id of the playlist you want to retrieve.                       |                                                                           |
| `UpdatePlaylistRequest`                                                   | [UpdatePlaylistRequest](../../Models/Components/UpdatePlaylistRequest.md) | :heavy_check_mark:                                                        | N/A                                                                       | {<br/>"name": "updated name",<br/>"description": "updated description"<br/>} |

### Response

**[UpdateAPlaylistResponse](../../Models/Requests/UpdateAPlaylistResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException              | 401                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPermissionException         | 403                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPlaylistIdResponseException | 422                                                         | application/json                                            |
| fastpix.io.Models.Errors.APIException                       | 4XX, 5XX                                                    | \*/\*                                                       |

## DeleteAPlaylist

This endpoint allows you to delete an existing playlist from the workspace. Once deleted, the playlist and its metadata are permanently removed and cannot be recovered.
#### How it works
 - When a user sends a DELETE request to this endpoint with the `playlistId`, FastPix removes the specified playlist from the workspace and returns a confirmation of successful deletion.
 
#### Example
An e-learning platform deletes an outdated playlist titled "Old Python Tutorials" by providing its unique playlist ID. The platform receives confirmation that the playlist has been removed, ensuring learners no longer see the obsolete content.

### Example Usage

<!-- UsageSnippet language="unity" operationID="delete-a-playlist" method="delete" path="/on-demand/playlists/{playlistId}" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playlist.DeleteAPlaylistAsync(playlistId: "<id>"))
{
    // handle response
}


```

### Parameters

| Parameter                                         | Type                                              | Required                                          | Description                                       |
| ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- |
| `PlaylistId`                                      | *string*                                          | :heavy_check_mark:                                | The unique id of the playlist you want to delete. |

### Response

**[DeleteAPlaylistResponse](../../Models/Requests/DeleteAPlaylistResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException              | 401                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPermissionException         | 403                                                         | application/json                                            |
| fastpix.io.Models.Errors.NotFoundError                      | 404                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPlaylistIdResponseException | 422                                                         | application/json                                            |
| fastpix.io.Models.Errors.APIException                       | 4XX, 5XX                                                    | \*/\*                                                       |

## AddMediaToPlaylist

This endpoint allows you to add one or more media items to an existing playlist. By passing the media ID(s) in the request, the specified media items are appended to the playlist in the order provided.
#### How it works

 - When a user sends a PATCH request to this endpoint with the `playlistId` as path parameter and a list of media ID(s) in the request body, FastPix adds the specified media items to the playlist and returns the updated playlist details.
 
#### Example
An e-learning platform adds new video tutorials to the "Beginner Python Series" playlist by sending their media IDs in the request. The playlist is updated with the new content, ensuring learners have access to the latest tutorials in sequence.

### Example Usage

<!-- UsageSnippet language="unity" operationID="add-media-to-playlist" method="patch" path="/on-demand/playlists/{playlistId}/media" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;
using System.Collections.Generic;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playlist.AddMediaToPlaylistAsync(
    playlistId: "<id>",
    mediaIdsRequest: new MediaIdsRequest() {
    MediaIds = new List<string>() {
        "a1cd180e-f9b5-4e99-9d44-b9c9baabad89",
        "245800c3-7b73-47d9-a201-e961260dcb30",
        "41316aac-5396-4278-8f44-08d5f2495b12",
    },
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `PlaylistId`                                                        | *string*                                                            | :heavy_check_mark:                                                  | The unique id of the playlist you want to perform the operation on. |
| `MediaIdsRequest`                                                   | [MediaIdsRequest](../../Models/Components/MediaIdsRequest.md)       | :heavy_check_mark:                                                  | N/A                                                                 |

### Response

**[AddMediaToPlaylistResponse](../../Models/Requests/AddMediaToPlaylistResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException              | 401                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPermissionException         | 403                                                         | application/json                                            |
| fastpix.io.Models.Errors.NotFoundError                      | 404                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPlaylistIdResponseException | 422                                                         | application/json                                            |
| fastpix.io.Models.Errors.APIException                       | 4XX, 5XX                                                    | \*/\*                                                       |

## ChangeMediaOrderInPlaylist

This endpoint allows you to change the order of media items within a playlist. By passing the complete list of media IDs in the desired sequence, the playlist's play order is updated accordingly.
#### How it works

 - When a user sends a PUT request to this endpoint with the `playlistId` as path parameter and the reordered list of all media IDs in the request body, FastPix updates the playlist to reflect the new media sequence and returns the updated playlist details.
 
#### Example
An e-learning platform rearranges the "Beginner Python Series" playlist by submitting a reordered list of media IDs. The playlist now follows the new sequence, providing learners with a better structured learning path.

### Example Usage

<!-- UsageSnippet language="unity" operationID="change-media-order-in-playlist" method="put" path="/on-demand/playlists/{playlistId}/media" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;
using System.Collections.Generic;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playlist.ChangeMediaOrderInPlaylistAsync(
    playlistId: "<id>",
    mediaIdsRequest: new MediaIdsRequest() {
    MediaIds = new List<string>() {
        "a1cd180e-f9b5-4e99-9d44-b9c9baabad89",
        "245800c3-7b73-47d9-a201-e961260dcb30",
        "41316aac-5396-4278-8f44-08d5f2495b12",
    },
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `PlaylistId`                                                        | *string*                                                            | :heavy_check_mark:                                                  | The unique id of the playlist you want to perform the operation on. |
| `MediaIdsRequest`                                                   | [MediaIdsRequest](../../Models/Components/MediaIdsRequest.md)       | :heavy_check_mark:                                                  | N/A                                                                 |

### Response

**[ChangeMediaOrderInPlaylistResponse](../../Models/Requests/ChangeMediaOrderInPlaylistResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException              | 401                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPermissionException         | 403                                                         | application/json                                            |
| fastpix.io.Models.Errors.NotFoundError                      | 404                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPlaylistIdResponseException | 422                                                         | application/json                                            |
| fastpix.io.Models.Errors.APIException                       | 4XX, 5XX                                                    | \*/\*                                                       |

## DeleteMediaFromPlaylist

This endpoint allows you to delete one or more media items from an existing playlist. By passing the media ID(s) in the request, the specified media items are removed from the playlist.
#### How it works

 - When a user sends a DELETE request to this endpoint with the playlist ID as the path parameter and the media ID(s) to be removed in the request body, FastPix deletes the specified media items from the playlist and returns the updated playlist details.
 
#### Example
An e-learning platform removes outdated video tutorials from the "Beginner Python Series" playlist by specifying their media IDs in the request. The playlist is updated to exclude these items, ensuring learners only access relevant content.

### Example Usage

<!-- UsageSnippet language="unity" operationID="delete-media-from-playlist" method="delete" path="/on-demand/playlists/{playlistId}/media" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;
using System.Collections.Generic;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.Playlist.DeleteMediaFromPlaylistAsync(
    playlistId: "<id>",
    mediaIdsRequest: new MediaIdsRequest() {
    MediaIds = new List<string>() {
        "a1cd180e-f9b5-4e99-9d44-b9c9baabad89",
        "245800c3-7b73-47d9-a201-e961260dcb30",
        "41316aac-5396-4278-8f44-08d5f2495b12",
    },
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `PlaylistId`                                                        | *string*                                                            | :heavy_check_mark:                                                  | The unique id of the playlist you want to perform the operation on. |
| `MediaIdsRequest`                                                   | [MediaIdsRequest](../../Models/Components/MediaIdsRequest.md)       | :heavy_minus_sign:                                                  | N/A                                                                 |

### Response

**[DeleteMediaFromPlaylistResponse](../../Models/Requests/DeleteMediaFromPlaylistResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| fastpix.io.Models.Errors.UnauthorizedException              | 401                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPermissionException         | 403                                                         | application/json                                            |
| fastpix.io.Models.Errors.NotFoundError                      | 404                                                         | application/json                                            |
| fastpix.io.Models.Errors.InvalidPlaylistIdResponseException | 422                                                         | application/json                                            |
| fastpix.io.Models.Errors.APIException                       | 4XX, 5XX                                                    | \*/\*                                                       |