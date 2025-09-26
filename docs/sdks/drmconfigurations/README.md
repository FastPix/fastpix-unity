# DRMConfigurations
(*DRMConfigurations*)

## Overview

### Available Operations

* [GetDrmConfiguration](#getdrmconfiguration) - Get list of DRM configuration IDs
* [GetDrmConfigurationById](#getdrmconfigurationbyid) - Get DRM configuration by ID

## GetDrmConfiguration


This endpoint retrieves the DRM configuration (DRM ID) associated with a workspace. It returns a list of DRM configurations, identified by a unique DRM ID, which is used for creating DRM encrypted asset.

**How it works:**
1. Make a GET request to this endpoint.  
2. Optionally use the `offset` and `limit` query parameters to paginate through the list of DRM configurations.  
3. The response includes a list of DRM IDs and pagination metadata.

**Example:**  
A media service provider may retrieve DRM configuration for a workspace to create DRM content.

Related guide: <a href="https://docs.fastpix.io/docs/secure-playback-with-drm">Manage DRM configuration</a>


### Example Usage

<!-- UsageSnippet language="unity" operationID="getDrmConfiguration" method="get" path="/on-demand/drm-configurations" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.DRMConfigurations.GetDrmConfigurationAsync(
    offset: 1,
    limit: 10))
{
    // handle response
}


```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `Offset`                                                                         | *long*                                                                           | :heavy_minus_sign:                                                               | Offset determines the starting point for data retrieval within a paginated list. | 1                                                                                |
| `Limit`                                                                          | *long*                                                                           | :heavy_minus_sign:                                                               | Limit specifies the maximum number of items to display per page.                 | 10                                                                               |

### Response

**[GetDrmConfigurationResponse](../../Models/Requests/GetDrmConfigurationResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.BadRequestException        | 400                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.ForbiddenException         | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |

## GetDrmConfigurationById


This endpoint retrieves a DRM configuration ID. It is used to fetch the DRM-related ID for a workspace, typically required when validating or applying DRM policies to video assets.

**How it works:**
1. Make a GET request to this endpoint, replacing `{drmConfigurationId}` with the UUID of the DRM configuration.  
2. The response will contain the associated DRM configuration ID.

Related guide: <a href="https://docs.fastpix.io/docs/secure-playback-with-drm">Manage DRM configuration</a>


### Example Usage

<!-- UsageSnippet language="unity" operationID="getDrmConfigurationById" method="get" path="/on-demand/drm-configurations/{drmConfigurationId}" -->
```csharp
using fastpix.io;
using fastpix.io.Models.Components;
using fastpix.io.Models.Requests;

var sdk = new Fastpix(security: new Security() {
        Username = "",
        Password = "",
    });


using(var res = await sdk.DRMConfigurations.GetDrmConfigurationByIdAsync(drmConfigurationId: "4fa85f64-5717-4562-b3fc-2c963f66afa6"))
{
    // handle response
}


```

### Parameters

| Parameter                                       | Type                                            | Required                                        | Description                                     | Example                                         |
| ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- |
| `DrmConfigurationId`                            | *string*                                        | :heavy_check_mark:                              | The unique identifier of the DRM configuration. | 4fa85f64-5717-4562-b3fc-2c963f66afa6            |

### Response

**[GetDrmConfigurationByIdResponse](../../Models/Requests/GetDrmConfigurationByIdResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| fastpix.io.Models.Errors.BadRequestException        | 400                                                 | application/json                                    |
| fastpix.io.Models.Errors.InvalidPermissionException | 401                                                 | application/json                                    |
| fastpix.io.Models.Errors.ForbiddenException         | 403                                                 | application/json                                    |
| fastpix.io.Models.Errors.MediaNotFoundException     | 404                                                 | application/json                                    |
| fastpix.io.Models.Errors.ValidationErrorResponse    | 422                                                 | application/json                                    |
| fastpix.io.Models.Errors.APIException               | 4XX, 5XX                                            | \*/\*                                               |