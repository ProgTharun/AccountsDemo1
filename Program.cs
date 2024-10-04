
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filepath = ConfigurationManager.AppSettings["Myfilepath"];
            Console.WriteLine(filepath);
            Console.WriteLine();
            AccountPresentation accountPresentation = new AccountPresentation();
            accountPresentation.ShowMenu();

        }
    }
}
