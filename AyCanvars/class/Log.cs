using System;
using System.Diagnostics;
using System.IO;

namespace Log
{
    public class LogFile : IDisposable
    {
        private static LogFile _instance;
        private static readonly object _lock = new object();
        private StreamWriter _sw;
        private bool _disposed;
        private static string _logName = "AyCanvars";
        private static string _logPath = null;
        private static bool _isInitialized = false;

        private string GetTimestamp() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

        public static void Initialize(string name = "AyCanvars", string logPath = null)
        {
            lock (_lock)
            {
                if (_instance != null)
                    throw new InvalidOperationException("LogFile already initialized. Call Initialize before accessing Instance.");
                _logName = name;
                _logPath = logPath;
                _isInitialized = true;
            }
        }

        private LogFile()
        {
            string defaultLogName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log";
            string path = new FileInfo(_logPath ?? defaultLogName).FullName;
            try
            {
                var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                _sw = new StreamWriter(fs) { AutoFlush = true };
               
                _sw.WriteLine($"[----- {_logName} {GetTimestamp()} Log Begin -----]");
                Info("-----LogClass: The logging system has finished loading-----");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LogFile initialization failed: {ex}");
                _sw = null;
            }
        }

        public static LogFile Instance
        {
            get
            {
                if (!_isInitialized) Initialize();
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null) _instance = new LogFile();
                    }
                }
                return _instance;
            }
        }

        public void Info(string message)
        {
            if (_sw == null) return;
            lock (_lock)
            {
                try { _sw.WriteLine($"[{GetTimestamp()}][INFO] {message}"); }
                catch (Exception ex) { Debug.WriteLine(ex); }
            }
        }

        public void DebugW(string message)
        {
            if (_sw == null) return;
            lock (_lock)
            {
                try { _sw.WriteLine($"[{GetTimestamp()}][DEBUG] {message}"); }
                catch (Exception ex) { Debug.WriteLine(ex); }
            }
        }

        public void Warn(string message)
        {
            if (_sw == null) return;
            lock (_lock)
            {
                try { _sw.WriteLine($"[{GetTimestamp()}][WARN] {message}"); }
                catch (Exception ex) { Debug.WriteLine(ex); }
            }
        }

        public void Error(string message)
        {
            if (_sw == null) return;
            lock (_lock)
            {
                try { _sw.WriteLine($"[{GetTimestamp()}][ERROR] [ERROR HERE] {message}"); }
                catch (Exception ex) { Debug.WriteLine(ex); }
            }
        }

        public void Error(Exception ex, string additionalMessage = null)
        {
            if (_sw == null) return;
            lock (_lock)
            {
                try
                {
                    var timestamp = GetTimestamp();
                    _sw.WriteLine($"[{timestamp}][ERROR] [ERROR HERE] {additionalMessage ?? ex.Message}");
                    _sw.WriteLine($"        Exception Type: {ex.GetType().FullName}");
                    _sw.WriteLine($"        Message: {ex.Message}");
                    _sw.WriteLine("        Stack Trace:");
                    _sw.WriteLine("       " + ex.StackTrace);
                    if (ex.InnerException != null)
                    {
                        _sw.WriteLine($"        Inner Exception: {ex.InnerException.Message}");
                        _sw.WriteLine("        Inner Stack Trace:");
                        _sw.WriteLine("        "+ex.InnerException.StackTrace);
                    }
                }
                catch (Exception ex2) { Debug.WriteLine(ex2); }
            }
        }

        public void Fatal(string message)
        {
            if (_sw == null) return;
            lock (_lock)
            {
                try { _sw.WriteLine($"[{GetTimestamp()}][FATAL] [FATAL HERE] {message}"); }
                catch (Exception ex) { Debug.WriteLine(ex); }
            }
        }

        public void Fatal(Exception ex, string additionalMessage = null)
        {
            if (_sw == null) return;
            lock (_lock)
            {
                try
                {
                    var timestamp = GetTimestamp();
                    _sw.WriteLine($"[{timestamp}][FATAL] [FATAL HERE] {additionalMessage ?? ex.Message}");
                    _sw.WriteLine($"        Exception Type: {ex.GetType().FullName}");
                    _sw.WriteLine($"        Message: {ex.Message}");
                    _sw.WriteLine("        Stack Trace:");
                    _sw.WriteLine("        "+ex.StackTrace);
                    if (ex.InnerException != null)
                    {
                        _sw.WriteLine($"        Inner Exception: {ex.InnerException.Message}");
                        _sw.WriteLine("        Inner Stack Trace:");
                        _sw.WriteLine("       "+ex.InnerException.StackTrace);
                    }
                }
                catch (Exception ex2) { Debug.WriteLine(ex2); }
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                lock (_lock)
                {
                    if (!_disposed && _sw != null)
                    {
                        try
                        {
                            _sw.WriteLine($"[----- {_logName} {GetTimestamp()} Log Stop -----]");
                            _sw.Flush();
                            _sw.Close();
                            _sw.Dispose();
                        }
                        catch (Exception ex) { Debug.WriteLine(ex); }
                        finally { _sw = null; }
                    }
                    _disposed = true;
                }
            }
        }
    }
}