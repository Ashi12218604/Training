using System;
class Downloader
{
    public delegate void DownloadDelegate();
    public event DownloadDelegate DownloadCompleted;
    public void CompleteDownload()
    {
        DownloadCompleted?.Invoke();
    }
}