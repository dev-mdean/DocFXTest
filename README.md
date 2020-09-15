# DocFXTest

### Current Issues

##### docfx.json
- `"build": "xref"` doesn't work when using `.cs` files for `"metadata" : "src"`
- `"build": "xref"` doesn't work when multlple `.csproj` files are in the project
  - Some plugins, like [LeanTouch](https://assetstore.unity.com/packages/tools/input-management/lean-touch-30111), introduce these extra files
  ```
  <ItemGroup>
    <ProjectReference Include="LeanCommon.csproj">
      <Project>{23c5f3ec-cb67-763a-a939-7cd358cae720}</Project>
      <Name>LeanCommon</Name>
      <ReferenceOutputAssembly>false</ReferenceOutputAssembly>
    </ProjectReference>
    <ProjectReference Include="LeanTouch.csproj">
      <Project>{f25bb72c-13a0-a372-ce14-f77b0ea3b0c3}</Project>
      <Name>LeanTouch</Name>
      <ReferenceOutputAssembly>false</ReferenceOutputAssembly>
    </ProjectReference>
  </ItemGroup>
  ```
