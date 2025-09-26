# InVideoAIFeatures
(*InVideoAIFeatures*)

## Overview

### Available Operations

* [UpdateMediaSummary](#updatemediasummary) - Generate video summary
* [UpdateMediaChapters](#updatemediachapters) - Generate video chapters
* [UpdateMediaNamedEntities](#updatemedianamedentities) - Generate named entities
* [UpdateMediaModeration](#updatemediamoderation) - Enable video moderation

## UpdateMediaSummary

This endpoint allows you to generate the summary for an existing media.

#### How it works
1. Send a PATCH request to this endpoint, replacing `<mediaId>` with the unique ID of the media for which you wish to generate a summary.
2. Include the `generate` parameter in the request body.
3. Include the `summaryLength` parameter, specify the desired length of the summary in words (e.g., 120 words), this determines how concise or detailed the summary will be. If no specific summary length is provided, the default length will be 100 words. 
4. The response will include the updated media data and confirmation of the changes applied.

You can use the <a href="https://docs.fastpix.io/docs/ai-events#videomediaaisummaryready">video.mediaAI.summary.ready</a> webhook event to track and notify about the summary generation.





**Use case**: This is particularly useful when a user uploads a video and later chooses to generate a summary without needing to re-upload the video.

Related guide: <a href="https://docs.fastpix.io/docs/generate-video-summary">Video summary</a>


### Example Usage

<!-- UsageSnippet language="unity" operationID="update-media-summary" method="patch" path="/on-demand/{mediaId}/summary" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.InVideoAIFeatures.UpdateMediaSummaryAsync(
    mediaId: "4fa85f64-5717-4562-b3fc-2c963f66afa6",
    requestBody: new UpdateMediaSummaryRequestBody() {
    Generate = true,
    SummaryLength = 100,
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                                                    | Type                                                                                         | Required                                                                                     | Description                                                                                  | Example                                                                                      |
| -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- |
| `MediaId`                                                                                    | *string*                                                                                     | :heavy_check_mark:                                                                           | The unique identifier assigned to the media when created. The value should be a valid UUID.<br/> | 4fa85f64-5717-4562-b3fc-2c963f66afa6                                                         |
| `RequestBody`                                                                                | [UpdateMediaSummaryRequestBody](../../Models/Requests/UpdateMediaSummaryRequestBody.md)      | :heavy_check_mark:                                                                           | N/A                                                                                          | {<br/>"generate": true,<br/>"summaryLength": 100<br/>}                                       |

### Response

**[UpdateMediaSummaryResponse](../../Models/Requests/UpdateMediaSummaryResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.InvalidPermissionException | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.ForbiddenException         | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.MediaNotFoundException     | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## UpdateMediaChapters

This endpoint enables you to generate chapters for an existing media file.

#### How it works
1. Make a `PATCH` request to this endpoint, replacing `<mediaId>` with the ID of the media for which you want to generate chapters.
2. Include the `chapters` parameter in the request body to enable.
3. The response will contain the updated media data, confirming the changes made.

You can use the <a href="https://docs.fastpix.io/docs/ai-events#videomediaaichaptersready">video.mediaAI.chapters.ready</a> webhook event to track and notify about the chapters generation.

**Use case:** This is particularly useful when a user uploads a video and later decides to enable chapters without re-uploading the entire video.

Related guide: <a href="https://docs.fastpix.io/reference/update-media-chapters">Video chapters</a>


### Example Usage

<!-- UsageSnippet language="unity" operationID="update-media-chapters" method="patch" path="/on-demand/{mediaId}/chapters" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.InVideoAIFeatures.UpdateMediaChaptersAsync(
    mediaId: "4fa85f64-5717-4562-b3fc-2c963f66afa6",
    requestBody: new UpdateMediaChaptersRequestBody() {
    Chapters = true,
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                                                    | Type                                                                                         | Required                                                                                     | Description                                                                                  | Example                                                                                      |
| -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- |
| `MediaId`                                                                                    | *string*                                                                                     | :heavy_check_mark:                                                                           | The unique identifier assigned to the media when created. The value should be a valid UUID.<br/> | 4fa85f64-5717-4562-b3fc-2c963f66afa6                                                         |
| `RequestBody`                                                                                | [UpdateMediaChaptersRequestBody](../../Models/Requests/UpdateMediaChaptersRequestBody.md)    | :heavy_check_mark:                                                                           | N/A                                                                                          | {<br/>"chapters": true<br/>}                                                                 |

### Response

**[UpdateMediaChaptersResponse](../../Models/Requests/UpdateMediaChaptersResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.InvalidPermissionException | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.ForbiddenException         | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.MediaNotFoundException     | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## UpdateMediaNamedEntities

This endpoint allows you to extract named entities from an existing media.
Named Entity Recognition (NER) is a fundamental natural language processing (NLP) technique that identifies and classifies key information (entities) in text into predefined categories. For instance:

  - Organizations (e.g., "Microsoft", "United Nations")
  - Locations (e.g., "Paris", "Mount Everest")
  - Product names (e.g., "iPhone", "Coca-Cola")

#### How it works
1. Make a PATCH request to this endpoint, replacing `<mediaId>` with the ID of the media you want to extract named-entities.
2. Include the `namedEntities` parameter in the request body to enable.
3. Receive a response containing the updated media data, confirming the changes made.

You can use the <a href="https://docs.fastpix.io/docs/ai-events#videomediaainamedentitiesready">video.mediaAI.named-entities.ready</a> webhook event to track and notify about the named entities extraction.

**Use case:** If a user uploads a video and later decides to enable named entity extraction without re-uploading the entire video.

Related guide: <a href="https://docs.fastpix.io/docs/generate-named-entities">Named entities</a>


### Example Usage

<!-- UsageSnippet language="unity" operationID="update-media-named-entities" method="patch" path="/on-demand/{mediaId}/named-entities" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.InVideoAIFeatures.UpdateMediaNamedEntitiesAsync(
    mediaId: "0cec3c88-c69d-4232-9b96-f0976327fa2d",
    requestBody: new UpdateMediaNamedEntitiesRequestBody() {
    NamedEntities = true,
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                                                           | Type                                                                                                | Required                                                                                            | Description                                                                                         | Example                                                                                             |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `MediaId`                                                                                           | *string*                                                                                            | :heavy_check_mark:                                                                                  | The unique identifier assigned to the media when created. The value should be a valid UUID.<br/>    | 0cec3c88-c69d-4232-9b96-f0976327fa2d                                                                |
| `RequestBody`                                                                                       | [UpdateMediaNamedEntitiesRequestBody](../../Models/Requests/UpdateMediaNamedEntitiesRequestBody.md) | :heavy_check_mark:                                                                                  | N/A                                                                                                 | {<br/>"namedEntities": true<br/>}                                                                   |

### Response

**[UpdateMediaNamedEntitiesResponse](../../Models/Requests/UpdateMediaNamedEntitiesResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.InvalidPermissionException | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.ForbiddenException         | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.MediaNotFoundException     | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## UpdateMediaModeration

This endpoint enables moderation features, such as NSFW and profanity filtering, to detect inappropriate content in existing media.

#### How it works
1. Make a PATCH request to this endpoint, replacing `<mediaId>` with the ID of the media you want to update.
2. Include the `moderation` object and provide the requried `type` parameter in the request body to specify the media type (e.g., video/audio/av).
4. The response will contain the updated media data, confirming the changes made.

You can use the <a href="https://docs.fastpix.io/docs/ai-events#videomediaaimoderationready">video.mediaAI.moderation.ready</a> webhook event to track and notify about the detected moderation results.

**Use case:** This is particularly useful when a user uploads a video and later decides to enable moderation detection without the need to re-upload it.

Related guide: <a href="https://docs.fastpix.io/docs/using-nsfw-and-profanity-filter-for-video-moderation">Moderate NSFW & Profanity</a>


### Example Usage

<!-- UsageSnippet language="unity" operationID="update-media-moderation" method="patch" path="/on-demand/{mediaId}/moderation" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.InVideoAIFeatures.UpdateMediaModerationAsync(
    mediaId: "0cec3c88-c69d-4232-9b96-f0976327fa2d",
    requestBody: new UpdateMediaModerationRequestBody() {
    Moderation = new UpdateMediaModerationModeration() {
        Type = MediaType.Video,
    },
}))
{
    // handle response
}


```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   | Example                                                                                       |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `MediaId`                                                                                     | *string*                                                                                      | :heavy_check_mark:                                                                            | The unique identifier assigned to the media when created. The value should be a valid UUID.<br/> | 0cec3c88-c69d-4232-9b96-f0976327fa2d                                                          |
| `RequestBody`                                                                                 | [UpdateMediaModerationRequestBody](../../Models/Requests/UpdateMediaModerationRequestBody.md) | :heavy_check_mark:                                                                            | N/A                                                                                           | {<br/>"moderation": {<br/>"type": "video"<br/>}<br/>}                                         |

### Response

**[UpdateMediaModerationResponse](../../Models/Requests/UpdateMediaModerationResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.InvalidPermissionException | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.ForbiddenException         | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.MediaNotFoundException     | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |