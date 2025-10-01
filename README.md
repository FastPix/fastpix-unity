# FastPix Unity SDK

A Unity-Native, Developer-Friendly SDK for Seamless Integration with the FastPix Platform API

## Introduction

The **FastPix Unity SDK** simplifies integration with the FastPix platform directly within your Unity projects. It provides a interface for secure and efficient communication with the FastPix API, enabling easy management of media uploads, live streaming, on-demand content, playlists, video analytics, and signing keys for secure access and token management.

# Key Features

## Media API
- **Upload Media**: Seamlessly upload media files from URLs or local devices.  
- **Manage Media**: List, fetch, update, and delete media assets with ease.  
- **Playback IDs**: Generate and manage playback IDs for secure and flexible media access.  
- **Advanced Media Tools**: Generate video summaries, chapters, named entities, subtitles, and perform content moderation.  
- **Playlist Management**: Create and manage playlists, add or remove media, and adjust playback order.  
- **DRM Support**: Configure and manage DRM settings for protected content.  

## Live API
- **Create & Manage Live Streams**: Effortlessly create, list, update, and delete live streams.  
- **Control Stream Access**: Generate playback IDs to manage viewer access securely.  
- **Stream Management**: Enable, disable, or complete streams with fine-grained control.  
- **Simulcast to Multiple Platforms**: Broadcast live content to multiple platforms simultaneously.  

## Signing Keys
- **Create Signing Keys**: Generate signing keys for secure token-based access.  
- **List & Retrieve Keys**: Fetch all keys or get details for a specific key.  
- **Manage Keys**: Delete or revoke signing keys to maintain secure access control.  

## Video Data API
- **View Analytics**: List video views, get detailed view information, and track top-performing content.  
- **Concurrent Viewer Insights**: Access timeseries data for live and on-demand streams.  
- **Custom Reporting**: Filter viewers by dimensions, list breakdowns, and compare metrics across datasets.  
- **Error Tracking & Diagnostics**: Retrieve logs and analyze errors for proactive monitoring.  

For detailed usage, refer to the [FastPix API Reference](https://docs.fastpix.io/reference/signingkeys-overview).

# Prerequisites:

## Getting started with FastPix:

To get started with the **FastPix Unity SDK**, ensure you have the following:

- The FastPix APIs are authenticated using an **Access Token** and a **Secret Key**. You must generate these credentials to use the SDK.

- Follow the steps in the [Authentication with Access Tokens](https://docs.fastpix.io/docs/basic-authentication) guide to obtain your credentials.

---

## Table of Contents
* [FastPixSDK](#fastpixio)
  * [SDK Installation](#sdk-installation)
  * [SDK Example Usage](#sdk-example-usage)
  * [Available Resources and Operations](#available-resources-and-operations)
  * [Error Handling](#error-handling)
  * [Server Selection](#server-selection)
  * [Development](#development)
  * [Maturity](#maturity)
  * [Detailed Usage]( #detailed-usage)

## SDK Installation

The SDK can either be compiled using `dotnet build` and the resultant `.dll` file can be copied into your Unity project's `Assets` folder, or you can copy the source code directly into your project.

The SDK relies on Newtonsoft's JSON.NET Package which can be installed via the Unity Package Manager.

To do so open the Package Manager via `Window > Package Manager` and click the `+` button then `Add package from git URL...` and enter `com.unity.nuget.newtonsoft-json` and click `Add`.

## SDK Example Usage

### Example

```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using System.Collections.Generic;

var sdk = new Fastpix(security: new Security() {
        Username="your-access-token"
        Password = "secret-key",
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
## Available Resources and Operations

<details open>
<summary>Available methods</summary>

### [Dimensions](docs/sdks/dimensions/README.md)

* [ListDimensions](docs/sdks/dimensions/README.md#listdimensions) - List the dimensions
* [ListFilterValuesForDimension](docs/sdks/dimensions/README.md#listfiltervaluesfordimension) - List the filter values for a dimension

### [DRMConfigurations](docs/sdks/drmconfigurations/README.md)

* [GetDrmConfiguration](docs/sdks/drmconfigurations/README.md#getdrmconfiguration) - Get list of DRM configuration IDs
* [GetDrmConfigurationById](docs/sdks/drmconfigurations/README.md#getdrmconfigurationbyid) - Get DRM configuration by ID

### [Errors](docs/sdks/errors/README.md)

* [ListErrors](docs/sdks/errors/README.md#listerrors) - List errors


### [InputVideo](docs/sdks/inputvideo/README.md)

* [CreateMedia](docs/sdks/inputvideo/README.md#createmedia) - Create media from URL
* [DirectUploadVideoMedia](docs/sdks/inputvideo/README.md#directuploadvideomedia) - Upload media from device

### [InVideoAIFeatures](docs/sdks/invideoaifeatures/README.md)

* [UpdateMediaSummary](docs/sdks/invideoaifeatures/README.md#updatemediasummary) - Generate video summary
* [UpdateMediaChapters](docs/sdks/invideoaifeatures/README.md#updatemediachapters) - Generate video chapters
* [UpdateMediaNamedEntities](docs/sdks/invideoaifeatures/README.md#updatemedianamedentities) - Generate named entities
* [UpdateMediaModeration](docs/sdks/invideoaifeatures/README.md#updatemediamoderation) - Enable video moderation

### [LivePlayback](docs/sdks/liveplayback/README.md)

* [CreatePlaybackIdOfStream](docs/sdks/liveplayback/README.md#createplaybackidofstream) - Create a playbackId
* [DeletePlaybackIdOfStream](docs/sdks/liveplayback/README.md#deleteplaybackidofstream) - Delete a playbackId
* [GetLiveStreamPlaybackId](docs/sdks/liveplayback/README.md#getlivestreamplaybackid) - Get playbackId details

### [ManageLiveStream](docs/sdks/managelivestream/README.md)

* [GetAllStreams](docs/sdks/managelivestream/README.md#getallstreams) - Get all live streams
* [GetLiveStreamViewerCountById](docs/sdks/managelivestream/README.md#getlivestreamviewercountbyid) - Get stream views by ID
* [GetLiveStreamById](docs/sdks/managelivestream/README.md#getlivestreambyid) - Get stream by ID
* [DeleteLiveStream](docs/sdks/managelivestream/README.md#deletelivestream) - Delete a stream
* [UpdateLiveStream](docs/sdks/managelivestream/README.md#updatelivestream) - Update a stream
* [DisableLiveStream](docs/sdks/managelivestream/README.md#disablelivestream) - Disable a stream
* [CompleteLiveStream](docs/sdks/managelivestream/README.md#completelivestream) - Complete a stream

### [ManageVideos](docs/sdks/managevideos/README.md)

* [ListMedia](docs/sdks/managevideos/README.md#listmedia) - Get list of all media
* [ListLiveClips](docs/sdks/managevideos/README.md#listliveclips) - Get all clips of a live stream
* [GetMedia](docs/sdks/managevideos/README.md#getmedia) - Get a media by ID
* [UpdatedMedia](docs/sdks/managevideos/README.md#updatedmedia) - Update a media by ID
* [DeleteMedia](docs/sdks/managevideos/README.md#deletemedia) - Delete a media by ID
* [AddMediaTrack](docs/sdks/managevideos/README.md#addmediatrack) - Add audio / subtitle track
* [CancelUpload](docs/sdks/managevideos/README.md#cancelupload) - Cancel ongoing upload
* [UpdateMediaTrack](docs/sdks/managevideos/README.md#updatemediatrack) - Update audio / subtitle track
* [DeleteMediaTrack](docs/sdks/managevideos/README.md#deletemediatrack) - Delete audio / subtitle track
* [GenerateSubtitleTrack](docs/sdks/managevideos/README.md#generatesubtitletrack) - Generate track subtitle
* [UpdatedSourceAccess](docs/sdks/managevideos/README.md#updatedsourceaccess) - Update the source access of a media by ID
* [UpdatedMp4Support](docs/sdks/managevideos/README.md#updatedmp4support) - Update the mp4Support of a media by ID
* [RetrieveMediaInputInfo](docs/sdks/managevideos/README.md#retrievemediainputinfo) - Get info of media inputs
* [ListUploads](docs/sdks/managevideos/README.md#listuploads) - Get all unused upload URLs
* [GetMediaClips](docs/sdks/managevideos/README.md#getmediaclips) - Get all clips of a media

### [Metrics](docs/sdks/metrics/README.md)

* [ListBreakdownValues](docs/sdks/metrics/README.md#listbreakdownvalues) - List breakdown values
* [ListOverallValues](docs/sdks/metrics/README.md#listoverallvalues) - List overall values
* [GetTimeseriesData](docs/sdks/metrics/README.md#gettimeseriesdata) - Get timeseries data
* [ListComparisonValues](docs/sdks/metrics/README.md#listcomparisonvalues) - List comparison values

### [Playback](docs/sdks/playback/README.md)

* [CreateMediaPlaybackId](docs/sdks/playback/README.md#createmediaplaybackid) - Create a playback ID
* [DeleteMediaPlaybackId](docs/sdks/playback/README.md#deletemediaplaybackid) - Delete a playback ID
* [GetPlaybackId](docs/sdks/playback/README.md#getplaybackid) - Get a playback ID

### [Playlist](docs/sdks/playlist/README.md)

* [CreateAPlaylist](docs/sdks/playlist/README.md#createaplaylist) - Create a new playlist
* [GetAllPlaylists](docs/sdks/playlist/README.md#getallplaylists) - Get all playlists
* [GetPlaylistById](docs/sdks/playlist/README.md#getplaylistbyid) - Get a playlist by ID
* [UpdateAPlaylist](docs/sdks/playlist/README.md#updateaplaylist) - Update a playlist by ID
* [DeleteAPlaylist](docs/sdks/playlist/README.md#deleteaplaylist) - Delete a playlist by ID
* [AddMediaToPlaylist](docs/sdks/playlist/README.md#addmediatoplaylist) - Add media to a playlist by ID
* [ChangeMediaOrderInPlaylist](docs/sdks/playlist/README.md#changemediaorderinplaylist) - Change media order in a playlist by ID
* [DeleteMediaFromPlaylist](docs/sdks/playlist/README.md#deletemediafromplaylist) - Delete media in a playlist by ID

### [SigningKeys](docs/sdks/signingkeys/README.md)

* [CreateSigningKey](docs/sdks/signingkeys/README.md#createsigningkey) - Create a signing key
* [ListSigningKeys](docs/sdks/signingkeys/README.md#listsigningkeys) - Get list of signing key
* [DeleteSigningKey](docs/sdks/signingkeys/README.md#deletesigningkey) - Delete a signing key
* [GetSigningKeyById](docs/sdks/signingkeys/README.md#getsigningkeybyid) - Get signing key by ID

### [SimulcastStream](docs/sdks/simulcaststream/README.md)

* [CreateSimulcastOfStream](docs/sdks/simulcaststream/README.md#createsimulcastofstream) - Create a simulcast
* [DeleteSimulcastOfStream](docs/sdks/simulcaststream/README.md#deletesimulcastofstream) - Delete a simulcast
* [GetSpecificSimulcastOfStream](docs/sdks/simulcaststream/README.md#getspecificsimulcastofstream) - Get a specific simulcast
* [UpdateSpecificSimulcastOfStream](docs/sdks/simulcaststream/README.md#updatespecificsimulcastofstream) - Update a simulcast

### [StartLiveStream](docs/sdks/startlivestream/README.md)

* [CreateNewStream](docs/sdks/startlivestream/README.md#createnewstream) - Create a new stream

### [Views](docs/sdks/views/README.md)

* [ListVideoViews](docs/sdks/views/README.md#listvideoviews) - List video views
* [GetVideoViewDetails](docs/sdks/views/README.md#getvideoviewdetails) - Get details of video view
* [ListByTopContent](docs/sdks/views/README.md#listbytopcontent) - List by top content
* [GetDataViewlistCurrentViewsGetTimeseriesViews](docs/sdks/views/README.md#getdataviewlistcurrentviewsgettimeseriesviews) - Get concurrent viewers timeseries
* [GetDataViewlistCurrentViewsFilter](docs/sdks/views/README.md#getdataviewlistcurrentviewsfilter) - Get concurrent viewers breakdown by dimension

</details>
<!-- End Available Resources and Operations [operations] -->

<!-- Start Error Handling [errors] -->


## Error Handling

Handling errors in this SDK should largely match your expectations. All operations return a response object or throw an exception.

By default, an API error will raise a `fastpix.io.Models.Errors.APIException` exception, which has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | The error message     |
| `StatusCode`  | *int*                 | The raw HTTP response |
| `RawResponse` | *HttpResponseMessage* | The raw HTTP response |
| `Body`        | *string*              | The response content  |

When custom error responses are specified for an operation, the SDK may also throw their associated exception. You can refer to respective *Errors* tables in SDK docs for more details on possible exception types for each operation. For example, the `CreateMediaAsync` method throws the following exceptions:

| Error Type                                          | Status Code | Content Type     |
| --------------------------------------------------- | ----------- | ---------------- |
| fastpix.io.Models.Errors.BadRequestException        | 400         | application/json |
| fastpix.io.Models.Errors.InvalidPermissionException | 401         | application/json |
| fastpix.io.Models.Errors.ForbiddenException         | 403         | application/json |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422         | application/json |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX    | \*/\*            |

### Example

```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using System;
using fastpix.io.Models.Errors;
using System.Collections.Generic;
using FastPixInput = fastpix.io.Models.Components.Input;
using FastPixSecurity = fastpix.io.Models.Components.Security;

var sdk = new Fastpix(security: new FastPixSecurity() {
        username="your-access-token"
        Password = "secret-key",
    });

CreateMediaRequest req = new CreateMediaRequest() {
    Inputs = new List<FastPixInput>() {
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

try
{
    using(var res = await sdk.InputVideo.CreateMediaAsync(req))
    {
            // handle response
    }
}
catch (Exception ex)
{
    if (ex is BadRequestException)
    {
        // handle exception
    }
    else if (ex is InvalidPermissionException)
    {
        // handle exception
    }
    else if (ex is ForbiddenException)
    {
        // handle exception
    }
    else if (ex is ValidationErrorResponse)
    {
        // handle exception
    }
    else if (ex is fastpix.io.Models.Errors.APIException)
    {
        // handle exception
    }
}

```


## Server Selection

### Override Server URL Per-Client

The default server can be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using System.Collections.Generic;
using FastPixInput = fastpix.io.Models.Components.Input;
using FastPixSecurity = fastpix.io.Models.Components.Security;

var sdk = new Fastpix(
    serverUrl: "https://api.fastpix.io/v1/",
    security: new FastPixSecurity() {
        username="your-access-token"
        Password = "secret-key",
    });

CreateMediaRequest req = new CreateMediaRequest() {
    Inputs = new List<FastPixInput>() {
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

# Development

## Maturity

This SDK is currently in beta, and breaking changes may occur between versions even without a major version update. To avoid unexpected issues, we recommend pinning your dependency to a specific version. This ensures consistent behavior unless you intentionally update to a newer release.

## Detailed Usage

For a complete understanding of each API's functionality, including request and response details, parameter descriptions, and additional examples, please refer to the [FastPix API Reference](https://docs.fastpix.io/reference/signingkeys-overview).

The API reference provides comprehensive documentation for all available endpoints and features, ensuring developers can integrate and utilize FastPix APIs efficiently.
