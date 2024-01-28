using NewsApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Helper
{
    public static class GlobalVariables
    {
        // Token_Valid GET & SET
        public static string GetCategory()
        {
            return SecureStorage.GetAsync(SD.Category.ToString()).GetAwaiter().GetResult();
        }
        public static void SetCategory(string Category)
        {
            SecureStorage.SetAsync(SD.Category.ToString(), Category.ToString());
        }
    }
}
