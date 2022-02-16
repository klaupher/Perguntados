using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perguntados.Helpers
{
    public static class Helper
    {
        public static string GetJSON(string filename)
        {
            var fileJson = filename;
            var jsonString = File.ReadAllText(fileJson);

            return jsonString;
        }

        public static string SetJSON(string filename, string dados)
        {
            var fileJson = filename;
            try
            {
                File.WriteAllText(filename, dados);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }
    }
}
