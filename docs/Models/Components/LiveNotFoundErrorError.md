# LiveNotFoundErrorError

Displays details about the reasons behind the request's failure.


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `Code`                                                              | *double*                                                            | :heavy_minus_sign:                                                  | Displays the error code indicating the type of the error.           | 404                                                                 |
| `Message`                                                           | *string*                                                            | :heavy_minus_sign:                                                  | A descriptive message providing more details for the error.         | stream not found                                                    |
| `Description`                                                       | *string*                                                            | :heavy_minus_sign:                                                  | A detailed explanation of the possible causes for the error.<br/>   | The requested resource (eg:streamId) doesn't exist in the workspace |