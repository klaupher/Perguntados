namespace Perguntados.Helpers
{
    public static class Helper
    {
        private static string _fileName = Directory.GetCurrentDirectory() + @"\\Data\\banco.json";

        public static string GetJSON()
        {
            var jsonString = File.ReadAllText(_fileName);

            return jsonString;
        }

        public static void SetJSON(string dados)
        {
            File.WriteAllText(_fileName, dados);
        }
    }
}
