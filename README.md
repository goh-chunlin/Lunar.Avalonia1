# Lunar.Avalonia1
Avalonia demo programme to be used to demonstrate Avalonia UI development, including integration with Syncfusion services.

## Related Topics

### 1. Avalonia UI
[Avalonia](https://avaloniaui.net/) is an open source UI framework for building stunning, desktop, mobile, web and embedded applications using a .NET single codebase.

Avalonia UI enables .NET developers to create pixel-perfect apps for desktop, mobile and web from a single codebase. Avalonia UI supports several .NET runtimes, including .NET Framework, Mono and .NET Core.

It's essential to understand that Avalonia works very differently from frameworks like MAUI (or Xamarin.Forms), which uses a platform's native UI toolkit, providing a common API across all the supported platforms.

Avalonia UI is a cross-platform framework that uses its own rendering engine to draw controls. It's not a wrapper around native controls, and it doesn't use native controls. Instead, it uses a cross-platform rendering engine that draws controls using SkiaSharp.

#### MVVM on Avalonia

#### RowDefinition and ColumnDefinition with Riza's Proposal

#### Avalonia on Linux

#### Sharing in 2018 Community Meetup

#### Development Experience with Xamarin.Forms with DC Suite

#### .NET 5 UWP with WinUI 3

#### Semi.Avalonia
Avalonia theme inspired by Semi Design. 

#### XAML Previewr for Avalonia
The Avalonia XAML Previewer in Visual Studio Code is a powerful tool that allows you to visualise XAML code in real-time. It enables you to efficiently design and fine-tune user interfaces, helping to identify potential issues and visualise the impact of changes instantly.

Since build 2022.3 EAP 7, Rider supports Avalonia previewer using an open-source plugin AvaloniaRider.

#### C# DevKit in VS Code
The C# DevKit is out and gives you a complete .NET experience inside VS Code!

C# Dev Kit helps you manage your code with a solution explorer and test your code with integrated unit test discovery and execution, elevating your C# development experience wherever you like to develop (Windows, macOS, Linux, and even in a Codespace).

This extension builds on top of the great C# language capabilities provided by the C# extension and enhances your C# environment by adding a set of powerful tools and utilities that integrate natively with VS Code to help C# developers write, debug, and maintain their code faster and with fewer errors.

#### Dev Home
Dev Home is a new control center for Windows providing the ability to monitor projects in your dashboard using customizable widgets, set up your dev environment by downloading apps, packages, or repositories, connect to your developer accounts and tools (such as GitHub), and create a Dev Drive for storage all in one place.

### 2. Syncfusion

#### Applying Syncfusion for Individual Open Source Project

### 3. GitHub Copilot

Q: "Is Avalonia in beta?"
A: "Avalonia is currently in version 0.10.0, which is considered a stable release. However, it is still under active development and new features are being added. You can check the latest version and release notes on the Avalonia website: https://avaloniaui.net/docs/roadmap/"
Note: The link to the website does not even exist.

#### Working Together with IntelliSense
IntelliSense is known for its code-completion functionality, while also providing a variety of code editing features such as parameter info, quick info and member lists, while Copilot is an advanced AI system that goes much further, for example, generating whole code constructs or even entire programs in response to developer prompts.

Developers continue to claim that the "AI pair programmer" GitHub Copilot tool doesn't work well with IntelliSense, which is built in to Visual Studio and Visual Studio Code.

#### Other Project Experience with GitHub Copilot
- Azure Face Recognition verification tool;
- HTTP Request (outdated code is generated);
- XAML Password box is suggested but no library supported;
- Good to explain MVVM concept for new comers;
- Creative of Humanity vs Source of AI.

### 4. Observability with Prometheus and Grafana

#### What is Observability and Why is it Important?

#### OpenTelemetry

#### About Prometheus

Prometheus is an open-source systems monitoring and alerting toolkit originally built at SoundCloud. Since its inception in 2012, many companies and organizations have adopted Prometheus, and the project has a very active developer and user community. It is now a standalone open source project and maintained independently of any company. To emphasize this, and to clarify the project's governance structure, Prometheus joined the Cloud Native Computing Foundation in 2016 as the second hosted project, after Kubernetes.

#### About Graphite
Alternative to Prometheus.

#### Prometheus Syntax

#### About Grafana

Grafana is the open source analytics & monitoring solution for every database. The open observability platform Grafana is the open source analytics & monitoring solution for every database Get Grafana Learn more Used by thousands of companies to monitor everything from infrastructure, applications, power plants to beehives.

#### Sending Metrics with HTTP
Ship metrics directly from your application code over HTTP for storage in your Grafana Cloud account using Graphite and Prometheus. Featuring the ability to generate an api key and a wide selection of predefined code snippets to plug in and push up.

#### Dashboard and Design

### References

- [Avalonia platform support - why it's simple](https://dev.to/avalonia/avalonia-platform-support-why-its-simple-cjd);
- [Avalonia UI Community Q&A. We talked about themes, v11, MAUI Hybrid and much more.](https://www.reddit.com/r/dotnet/comments/138zcao/avalonia_ui_community_qa_we_talked_about_themes/);
- [Avalonia for Visual Studio Code (Early Access)](https://avaloniaui.net/Blog/avalonia-for-visual-studio-code-early-access,e2464208-4482-4dd1-bd60-fd11c98983dc);
- [AvaloniaRider](https://plugins.jetbrains.com/plugin/14839-avaloniarider/);
- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit);
- [Devs Cite Problems with GitHub Copilot and IntelliSense Working Together](https://visualstudiomagazine.com/articles/2023/02/17/copilot-intellisense.aspx);
- [Dev Home](https://learn.microsoft.com/en-us/windows/dev-home/);
- [Why GitHub Copilot is not a Threat to your Job](https://blog.devgenius.io/why-github-copilot-is-not-a-treat-for-your-job-cd7f5fae9ff9);
- [I Built an App with GitHub Copilot, Here's the Result](https://www.linkedin.com/pulse/i-built-app-github-copilot-heres-result-simona-winnekes/);
- [Goldman Sachs CIO is ‘anxious to see results’ from GenAI, but moving carefully | The AI Beat](https://venturebeat.com/ai/goldman-sachs-cio-is-anxious-to-see-results-from-genai-but-moving-carefully-the-ai-beat/);
- [Proposal: Naming Grid Rows/Columns on Simplified Inline Syntax and Grid.RowColumn](https://github.com/microsoft/microsoft-ui-xaml/issues/2094).