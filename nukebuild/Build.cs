using System;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using Serilog;
using System.Collections.Generic;
using Nuke.Common.Utilities;

partial class Build : NukeBuild
{
    // Note: These extensions are currently unavailable, as there's some rework going on I  guess
    //
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode <summary>
        
        
    // TODO: Add mobile platforms
    enum Runtime
    {
        osx_x64,
        osx_arm64,
        win_x64,
        win_arm64,
        linux_x64,
        linux_arm64
    }

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("Runtime to build, or all if none specified")]
    readonly Runtime? runtime;

    AbsolutePath OutputDirectory => RootDirectory / "output";
    AbsolutePath SourceDirectory => RootDirectory / "sources";
    AbsolutePath DepsDirectory => RootDirectory / "deps";
    AbsolutePath EngineDirectory => SourceDirectory / "engine";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/{obj,bin,debug,release}").DeleteDirectories();
            OutputDirectory.CreateOrCleanDirectory();
        });

    Target Native => _ => _
        .Executes(() =>
        {
            // Coming in future commit
            //BuildNativeProjects();
        });

    Target Restore => _ => _
        .Executes(() =>
        {
        });

    Target Compile => _ => _
        .DependsOn(Native)
        .DependsOn(Restore)
        .Executes(() =>
        {
        });

}
