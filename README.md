# Jalium Slider 性能测试应用

这是一个用于测试 Jalium UI 框架性能的示例应用，包含 100 个联动的 Slider 控件。

## 功能特性

- **100个Slider**: 以 10x10 网格布局展示
- **实时联动**: 拖动任意一个 Slider，其余 99 个会同步更新
- **范围**: 0-100
- **性能测试**: 用于验证 Jalium 框架处理大量控件联动的性能表现

## 项目结构

```
jalium-app/
├── jalium-app/
│   ├── MainWindow.jalxaml      # 主窗口布局
│   ├── MainWindow.jalxaml.cs   # 主窗口逻辑
│   ├── Program.cs              # 程序入口
│   ├── app.manifest            # 应用程序清单
│   └── jalium-app.csproj       # 项目文件
└── jalium-app.slnx             # 解决方案文件
```

## 开发环境要求

- .NET 10.0 SDK 或更高版本
- Windows 操作系统
- Visual Studio 2022 或 VS Code（可选）

## 构建和运行

### 调试模式

```bash
dotnet build
dotnet run
```

### Release 模式

```bash
dotnet build -c Release
dotnet run -c Release
```

## 发布方式

项目已配置好 AOT 和单文件发布选项，只需简单命令即可发布。

### 方式一：NativeAOT 单文件发布（推荐）

```bash
dotnet publish -c Release -r win-x64
```

**输出位置**: `bin/Release/net10.0-windows/win-x64/publish/jalium-app.exe`

**特点**:
- ✅ 真正的 NativeAOT 编译
- ✅ 单文件可执行程序
- ✅ 自包含（无需安装 .NET 运行时）
- ✅ 启动速度最快
- ✅ 文件体积优化（约 40MB）

**配置说明** (`jalium-app.csproj`):
```xml
<!-- AOT Settings: Enable in Release mode -->
<PublishAot Condition="'$(Configuration)' == 'Release'">true</PublishAot>
<PublishSingleFile>true</PublishSingleFile>
<SelfContained>true</SelfContained>
```

**注意**: 编译时会有一些 trim 警告，这是正常的，不影响程序运行。

### 方式二：框架依赖发布

```bash
dotnet publish -c Release -r win-x64 --self-contained false
```

**特点**:
- 文件体积较小
- 需要目标机器安装 .NET 10 运行时

## 项目配置说明

### jalium-app.csproj 关键配置

```xml
<PropertyGroup>
    <!-- 目标框架 -->
    <TargetFramework>net10.0-windows</TargetFramework>
    
    <!-- AOT 配置：Release 模式下启用 NativeAOT -->
    <PublishAot Condition="'$(Configuration)' == 'Release'">true</PublishAot>
    <PublishSingleFile>true</PublishSingleFile>
    <SelfContained>true</SelfContained>
    <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
    <EnableCompressionInSingleFile>true</EnableCompressionInSingleFile>
    <DebugType>none</DebugType>
</PropertyGroup>
```

## 性能优化建议

1. **Release 模式**: 始终使用 Release 配置进行性能测试和发布
2. **NativeAOT**: 启用 AOT 编译获得最佳启动性能和文件体积
3. **单文件发布**: 减少文件碎片化，提高加载效率
4. **禁用调试符号**: 已配置 `<DebugType>none</DebugType>` 减小文件体积

## 许可证

本项目为示例代码，遵循 MIT 许可证。

## 相关链接

- [Jalium.UI 框架](https://github.com/jalium/jalium-ui)
- [Jalium.UI Gallery 示例](https://github.com/jalium/Jalium-UI-Gallery)
