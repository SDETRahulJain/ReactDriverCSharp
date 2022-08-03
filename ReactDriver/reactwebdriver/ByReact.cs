using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactDriver.reactwebdriver
{
    public class ByReact
    {
        static readonly String DEFAULT_ROOT = "#root";

      public static string resqScript = readScriptFromResource("..\\..\\..\\js\\resq.js");        
       
       public static string locatorScript = readScriptFromResource("..\\..\\..\\js\\locator.js");
        public static ByReactFactory factory(String rootSelector)
        {
            return new ByReactFactory(rootSelector);
        }

        public static ByReactComponent component(String componentName)
        {
            return factory(DEFAULT_ROOT).component(componentName);
        }

        private static String readScriptFromResource(String fileName)
        {
            return File.ReadAllText(fileName, Encoding.UTF8);
    }

  public  static void LoadResqScript(IJavaScriptExecutor javascriptExecutor)
    {
        javascriptExecutor.ExecuteScript(ByReact.resqScript);
    }

   public static Object ExecuteQuery(IJavaScriptExecutor executor, String script, params object[] args)
    {
        ByReact.LoadResqScript(executor);
        return executor.ExecuteScript(script, args);
    }

}
}
