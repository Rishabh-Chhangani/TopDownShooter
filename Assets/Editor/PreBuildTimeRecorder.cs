//using System.IO;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class PreBuildTimeRecorder : UnityEditor.Build.ICustomBuildPreprocessor
//{
//    private static string buildInfoFilePath = "Assets/BuildInfo.txt";

//    // Automatic call before a build starts
//    public void OnPreprocessBuild(UnityEditor.Build.BuildReport report)
//    {
//        RecordBuildTime();
//    }

//    private static void RecordBuildTime()
//    {
//        // Get current date and time
//        string buildTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//        string content = $"Pre-Build Time: {buildTime}";

//        // Optionally append OS/target info for tracking
//        content += $"Target Platform: {EditorUserBuildSettings.activeBuildTarget}";

//        // Write or overwrite the build info file
//        File.WriteAllText(buildInfoFilePath, content);

//        // Refresh AssetDatabase so the file shows in Unity immediately
//        AssetDatabase.Refresh();
//        Debug.Log("Pre-build time recorded to " + buildInfoFilePath);
//    }

//    // Optional: Add a manual menu item to record build time anytime
//    [MenuItem("Build/Record Pre-Build Time")]
//    public static void RecordTimeManually()
//    {
//        RecordBuildTime();
//    }
//}
