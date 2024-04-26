using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class LogParser
{
    public void ParseLog(string filePath)
    {
        Queue<string> logLines = ReadLastNLines(filePath, 50);

        string currentLine = null;
        string nextLine;

        while (logLines.Count > 0)
        {
            if (currentLine == null)
                currentLine = logLines.Dequeue();

            nextLine = logLines.Count > 0 ? logLines.Peek() : null;

            // Kiểm tra xem dòng tiếp theo có phải là phần tiếp theo của log hiện tại không
            if (nextLine != null && !Regex.IsMatch(nextLine, @"^\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2},\d{3}"))
            {
                currentLine += Environment.NewLine + nextLine;
                logLines.Dequeue();
            }

            // Phân tích dòng log
            ParseLine(currentLine);
            currentLine = null;
        }
    }

    private void ParseLine(string line)
    {
        string[] parts = line.Split('|');

        if (parts.Length >= 4)
        {
            string timestamp = parts[0].Trim();
            string logLevel = parts[2].Trim();
            string method = parts[3].Split(':')[1].Trim();
            string message = parts[4].Trim();

            string json = ExtractJsonFromMessage(message);

            Console.WriteLine($"Timestamp: {timestamp}");
            Console.WriteLine($"Log Level: {logLevel}");
            Console.WriteLine($"Method: {method}");
            Console.WriteLine($"Message: {message}");

            Console.WriteLine($"JSON : {json}");

            Console.WriteLine();
        }
    }

    private string ExtractJsonFromMessage(string message)
    {
        string jsonPattern = @"(?:\{[^{}]*\})";
        string json = string.Empty;

        Regex regex = new Regex(jsonPattern, RegexOptions.Singleline);
        MatchCollection matches = regex.Matches(message);

        foreach (Match match in matches)
        {
            json = match.Value;
            Console.WriteLine("JSON found:");
            Console.WriteLine(match.Value);
        }

        return json;    
    }

    private Queue<string> ReadLastNLines(string filePath, int n)
    {
        Queue<string> lines = new Queue<string>(n);

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (StreamReader sr = new StreamReader(fs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Enqueue(line);
                    if (lines.Count > n)
                    {
                        lines.Dequeue();
                    }
                }
            }
        }

        return lines;
    }
}
