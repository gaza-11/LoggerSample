using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDependencySample
{
    /// <summary>
    /// ログファイル出力用トレースリスナークラス
    /// </summary>
    internal class SampleTraceListener : TraceListener
    {
        /// <summary>
        /// テキストライター
        /// </summary>
        private TextWriter Writer { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected SampleTraceListener() : base()
        {
            var encoding = Encoding.GetEncoding(ConfigurationManager.AppSettings["LogEncoding"]);
            var logDir = ConfigurationManager.AppSettings["LogDirectory"];
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            var tempLogName = string.Format(
                ConfigurationManager.AppSettings["LogNameTemplate"], DateTime.Now.ToString("yyyyMMdd"));
            var logName = GetLogFileName(logDir, tempLogName);

            var sw = new StreamWriter(logName, true, encoding);
            sw.AutoFlush = true;
            this.Writer = TextWriter.Synchronized(sw);
        }

        /// <summary>
        /// 引数からフルパスのログファイル名を組み立てて返却します。
        /// </summary>
        /// <param name="logDir">ログディレクトリ</param>
        /// <param name="tempLogName">ログファイル名</param>
        /// <returns></returns>
        private string GetLogFileName(string logDir, string tempLogName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writeメソッドのオーバーライド。
        /// メッセージレベルのみのデータの場合は書き出しをやめ、それ以外はWriteLineメソッドを呼び出します。
        /// </summary>
        /// <param name="message"></param>
        public override void Write(string message)
        {
            if (!message.StartsWith("SampleTraceSource"))
            {
                this.WriteLine(message);
            }
        }

        /// <summary>
        /// WriteLineメソッドのオーバーライド。
        /// ログファイルに書き込みを行います。
        /// </summary>
        /// <param name="message"></param>
        public override void WriteLine(string message)
        {
            var dateTimeStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            this.Writer.WriteLine(dateTimeStr + " " + message);
        }
    }
}
