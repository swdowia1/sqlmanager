namespace SQLM.Klasy
{
    internal class classMemory
    {
        private static string path = "_memory.txt";

        private static string kat = "Memory\\";

        public static string MemoryRead(ConfigSave s)
        {
            try
            {
                return File.ReadAllText(kat + s.ToString() + path);
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public static List<string> MemoryReadList(ConfigSave s)
        {
            try
            {
                return File.ReadAllLines(kat + s.ToString() + path).ToList();
            }
            catch (Exception e)
            {
                return new List<string>();
            }
        }

        public static void MemoryWrite(ConfigSave s, params string[] zaw)
        {
            File.WriteAllText(
                kat + s.ToString() + path,
                string.Join(Environment.NewLine, zaw)
            );
        }

        public static void MemoryWriteList(ConfigSave s, List<string> zaw)
        {
            File.WriteAllText(kat + s.ToString() + path, string.Join("\n", zaw));
        }
    }
}