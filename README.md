# DocFXTest

## Current Issues

### Inheritance is not always generated from `"build": "xref"`
- Doesn't work when using `.cs` files for `"metadata" : "src"`

- Doesn't work when multlple `.csproj` files are in the project
  - Some plugins, like [LeanTouch](https://assetstore.unity.com/packages/tools/input-management/lean-touch-30111), introduce these extra files
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
  
