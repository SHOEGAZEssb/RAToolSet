using System;
using System.IO;

namespace RAToolSetWPF
{
  public static class Logging
  {
    private const string LOGGINGPATH = "..\\..\\logfile.txt";

    /// <summary>
    /// Writes the given <see cref="text"/> to the logfile.
    /// </summary>
    /// <param name="text">Text to write to the logfile.</param>
    public static void LogText(string text)
    {
      text = "[" + DateTime.Now + "]: " + text + "\r\n";

      File.AppendAllText(LOGGINGPATH, text);
    }
  }
}
