namespace TestProject1.utility;

using System.Diagnostics;

public class VideoRecorder
{
    private Process ffmpegProcess;

    public void StartRecording(string outputPath)
    {
        ffmpegProcess = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-video_size 1920x1080 -framerate 30 -f x11grab -i :0.0+0,0 {outputPath}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true, // Allow input redirection
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        ffmpegProcess.Start();
    }

    public void StopRecording()
    {
        if (ffmpegProcess != null && !ffmpegProcess.HasExited)
        {
            ffmpegProcess.StandardInput.WriteLine("q"); 
            ffmpegProcess.WaitForExit();
        }
    }
    public string GetErrorLog()
    {
        return ffmpegProcess?.StandardError.ReadToEnd();
    }
}