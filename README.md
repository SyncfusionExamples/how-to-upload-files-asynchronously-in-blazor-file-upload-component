# How to Upload Files Asynchronously in Blazor File Upload Component

## Overview

This sample demonstrates asynchronous file uploading in a Blazor Server application using the Syncfusion [Blazor File Upload](https://www.syncfusion.com/blazor-components/blazor-file-upload) component. The implementation showcases how files can be uploaded efficiently without blocking the user interface, improving responsiveness and user experience in web applications.

The sample focuses on advanced upload scenarios such as chunk uploading for large files, directory uploading for transferring complete folders, and drag-and-drop file uploading through a custom drop area. These capabilities help developers build reliable file management workflows that support large data transfers and bulk uploads.

## Key Features

- Uses the Syncfusion Blazor File Upload (`SfUploader`) component for asynchronous file uploads.
- Automatically uploads files immediately after selection using `AutoUpload="true"`.
- Uploads files sequentially with `SequentialUpload="true"` to ensure ordered processing.
- Supports folder selection and bulk file uploads through `DirectoryUpload="true"`.
- Enables drag-and-drop uploading using a custom drop area configured with `DropArea="#DropArea"`.
- Performs server-side file uploads using `UploaderAsyncSettings` with dedicated `SaveUrl` and `RemoveUrl` endpoints.
- Implements chunk uploading with `ChunkSize="500000"` to split large files into smaller segments during transfer.
- Provides automatic retry support for failed chunk uploads using `RetryCount="5"` and `RetryAfterDelay="3000"`.
- Demonstrates preloaded file entries through the `UploaderFiles` collection.
- Customizes file removal behavior using the `BeforeRemove` event.
- Uses `args.PostRawFile = false` in the `BeforeRemove` event handler to control the payload sent during file deletion requests.
- Stores uploaded files in the application's `wwwroot` directory through the `SampleDataController.Save()` action.
- Prevents duplicate file creation by validating file existence before saving uploaded content.
- Supports file deletion through the `SampleDataController.Remove()` action endpoint.
- Implements server-side file processing using ASP.NET Core `IFormFile` collections.
- Includes HTTP response handling for duplicate files, upload exceptions, and file removal operations.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone or download this repository.
2. Open the `UploadFiles.sln` solution file.
3. Restore the NuGet packages if prompted.
4. Ensure the `UploadFiles` project is selected as the startup project.
5. Build the solution.
6. Run the application using **Ctrl+F5**.

**Visual Studio Code**

1. Open the repository folder in Visual Studio Code.
2. Open a terminal in the project root directory.
3. Restore the NuGet packages:

```bash
dotnet restore
```

4. Run the application:

```bash
dotnet run
```

5. Open the application using the local URL displayed in the terminal output after startup.

## Project Structure

`Pages/Index.razor` - Hosts the Syncfusion `SfUploader` component and demonstrates asynchronous uploads, chunk uploads, directory uploads, custom drag-and-drop support, preloaded files, and file removal handling.

`Data/SampleDataController.cs` - ASP.NET Core API controller containing the `Save()` and `Remove()` endpoints used by the uploader's asynchronous upload and delete operations.

`Data/WeatherForecast.cs` - Default Blazor template data model retained as supporting sample code.

`Data/WeatherForecastService.cs` - Default Blazor template service for generating weather forecast data.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- For documentation related to asynchronous file uploading, see: https://blazor.syncfusion.com/documentation/file-upload/async

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.