# DocFXTest

A project used for testing if DocFX can be used to generate documentation from code written for Unity

## Details

- <b>Operating System:</b> macOS Catalina 10.15.6
- <b>Unity Version:</b> 2019.4.8f1
- <b>DocFX Version:</b> 2.51.0 (Later versions don't work on my OS)


## Inheritance is not generated from `"build": "xref"` in specific cases

- Doesn't work when using `.cs` files for `"metadata" : "src"`

- Doesn't work when multlple `.csproj` files are in the project
  - Some plugins, like [LeanTouch](https://assetstore.unity.com/packages/tools/input-management/lean-touch-30111), introduce these
  - Additional `.csproj` are referenced in `Assembly-CSharp.csproj` similar to below:
  
    ```
    ...
    <ItemGroup>
      <ProjectReference Include="AdditionalProject.csproj">
        <Project>{project-identifier}</Project>
        <Name>Project Name</Name>
        <ReferenceOutputAssembly>false</ReferenceOutputAssembly>
      </ProjectReference>
    </ItemGroup>
    ...
    ```
  - When running `docfx` in this case, the following warnings are generated:

    ```
    [20-09-15 04:00:57.025]Warning:[MetadataCommand.ExtractMetadata](/Users/matt.dean/Development/Unity Projects/R and D/DocFXTest/LeanTouch.csproj)Workspace failed with: [Failure] Msbuild failed when processing the file '/Users/matt.dean/Development/Unity Projects/R and D/DocFXTest/LeanTouch.csproj' with message: /Library/Frameworks/Mono.framework/Versions/6.10.0/lib/mono/msbuild/15.0/bin/Microsoft.Common.CurrentVersion.targets: (1675, 5): The "GetReferenceNearestTargetFrameworkTask" task failed unexpectedly.
      System.BadImageFormatException: Could not resolve field token 0x0400009a, due to: Could not load type of field 'NuGet.Build.Tasks.BuildTasksUtility+<>c:<>9__20_0' (10) due to: Could not resolve type with token 01000048 from typeref (expected class 'NuGet.Packaging.Signing.PackageVerificationResult' in assembly 'NuGet.Packaging, Version=5.6.0.5, Culture=neutral, PublicKeyToken=31bf3856ad364e35') assembly:NuGet.Packaging, Version=5.6.0.5, Culture=neutral, PublicKeyToken=31bf3856ad364e35 type:NuGet.Packaging.Signing.PackageVerificationResult member:(null) assembly:/Library/Frameworks/Mono.framework/Versions/6.10.0/lib/mono/msbuild/Current/bin/NuGet.Build.Tasks.dll type:<>c member:(null)
    File name: 'NuGet.Build.Tasks'
      at NuGet.Build.Tasks.BuildTasksUtility.LogInputParam (NuGet.Common.ILogger log, System.String name, System.String[] values) [0x00000] in <009987ec01cb40349878c8cf80e08eb8>:0 
      at NuGet.Build.Tasks.GetReferenceNearestTargetFrameworkTask.Execute () [0x00020] in <009987ec01cb40349878c8cf80e08eb8>:0 
      at Microsoft.Build.BackEnd.TaskExecutionHost.Microsoft.Build.BackEnd.ITaskExecutionHost.Execute () [0x00029] in <88c37ed7acf047d1b22c53e4ffb9f126>:0 
      at Microsoft.Build.BackEnd.TaskBuilder.ExecuteInstantiatedTask (Microsoft.Build.BackEnd.ITaskExecutionHost taskExecutionHost, Microsoft.Build.BackEnd.Logging.TaskLoggingContext taskLoggingContext, Microsoft.Build.BackEnd.TaskHost taskHost, Microsoft.Build.BackEnd.ItemBucket bucket, Microsoft.Build.BackEnd.TaskExecutionMode howToExecuteTask) [0x002a9] in <88c37ed7acf047d1b22c53e4ffb9f126>:0 
    [20-09-15 04:00:57.025]Warning:[MetadataCommand.ExtractMetadata](/Users/matt.dean/Development/Unity Projects/R and D/DocFXTest/Assembly-CSharp.csproj)Workspace failed with: [Failure] Msbuild failed when processing the file '/Users/matt.dean/Development/Unity Projects/R and D/DocFXTest/Assembly-CSharp.csproj' with message: /Library/Frameworks/Mono.framework/Versions/6.10.0/lib/mono/msbuild/15.0/bin/Microsoft.Common.CurrentVersion.targets: (1675, 5): The "GetReferenceNearestTargetFrameworkTask" task failed unexpectedly.
    System.BadImageFormatException: Could not resolve field token 0x0400009a, due to: Could not load type of field 'NuGet.Build.Tasks.BuildTasksUtility+<>c:<>9__20_0' (10) due to: Could not resolve type with token 01000048 from typeref (expected class 'NuGet.Packaging.Signing.PackageVerificationResult' in assembly 'NuGet.Packaging, Version=5.6.0.5, Culture=neutral, PublicKeyToken=31bf3856ad364e35') assembly:NuGet.Packaging, Version=5.6.0.5, Culture=neutral, PublicKeyToken=31bf3856ad364e35 type:NuGet.Packaging.Signing.PackageVerificationResult member:(null) assembly:/Library/Frameworks/Mono.framework/Versions/6.10.0/lib/mono/msbuild/Current/bin/NuGet.Build.Tasks.dll type:<>c member:(null)
    File name: 'NuGet.Build.Tasks'
      at NuGet.Build.Tasks.BuildTasksUtility.LogInputParam (NuGet.Common.ILogger log, System.String name, System.String[] values) [0x00000] in <009987ec01cb40349878c8cf80e08eb8>:0 
      at NuGet.Build.Tasks.GetReferenceNearestTargetFrameworkTask.Execute () [0x00020] in <009987ec01cb40349878c8cf80e08eb8>:0 
      at Microsoft.Build.BackEnd.TaskExecutionHost.Microsoft.Build.BackEnd.ITaskExecutionHost.Execute () [0x00029] in <88c37ed7acf047d1b22c53e4ffb9f126>:0 
      at Microsoft.Build.BackEnd.TaskBuilder.ExecuteInstantiatedTask (Microsoft.Build.BackEnd.ITaskExecutionHost taskExecutionHost, Microsoft.Build.BackEnd.Logging.TaskLoggingContext taskLoggingContext, Microsoft.Build.BackEnd.TaskHost taskHost, Microsoft.Build.BackEnd.ItemBucket bucket, Microsoft.Build.BackEnd.TaskExecutionMode howToExecuteTask) [0x002a9] in <88c37ed7acf047d1b22c53e4ffb9f126>:0 
    [20-09-15 04:00:57.026]Warning:[MetadataCommand.ExtractMetadata]Invalid cref value "!:System.ArgumentOutOfRangeException" found in triple-slash-comments for Accelerate defined in ../Assets/Scripts/VehicleBase.cs Line 22, ignored.
    [20-09-15 04:00:57.026]Warning:[MetadataCommand.ExtractMetadata]Invalid cref value "!:System.OverflowException" found in triple-slash-comments for Accelerate defined in ../Assets/Scripts/VehicleBase.cs Line 22, ignored.
    [20-09-15 04:00:57.026]Warning:[MetadataCommand.ExtractMetadata]Invalid cref value "!:System.ArgumentOutOfRangeException" found in triple-slash-comments for Decelerate defined in ../Assets/Scripts/VehicleBase.cs Line 42, ignored.
    [20-09-15 04:00:57.026]Warning:[MetadataCommand.ExtractMetadata]Invalid cref value "!:System.OverflowException" found in triple-slash-comments for Decelerate defined in ../Assets/Scripts/VehicleBase.cs Line 42, ignored.
    ```