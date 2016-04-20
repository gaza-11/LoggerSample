using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerSample
{
    class LoggingUtility
    {
        /// <summary>
        /// トレースソース
        /// </summary>
        private static TraceSource Source { get; set; }

        /// <summary>
        /// 初期化処理
        /// </summary>
        internal static void Initialize()
        {
            Source = new TraceSource("");
        }

        /// <summary>
        /// ログ書き込み処理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        public static void WriteLog(string id, params string[] parameters)
        {

        }
    }
}
