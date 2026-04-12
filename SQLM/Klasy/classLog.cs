using NLog;

namespace SQLM.Klasy
{
    internal class classLog
    {
        internal static void LogInfo(string info, string opis = "")
        {
            if (opis != "")
                LogManager.GetCurrentClassLogger().Info("\n=========== " + opis + "  ========\n" + info);
            else
            {
                LogManager.GetCurrentClassLogger().Info(info);
            }
        }

        internal static void LogError(Exception ee, string gdzie = "")
        {
            LogManager.GetCurrentClassLogger().Error(ee.Message + ee.Source + " funkcja :" + gdzie);
        }
    }
}