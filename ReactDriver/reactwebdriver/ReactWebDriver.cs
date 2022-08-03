using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactDriver.reactwebdriver
{
    public class ReactWebDriver
    {
        private String rootSelector;

        private  IJavaScriptExecutor javascriptExecutor;

    public ReactWebDriver(IJavaScriptExecutor javascriptExecutor, String rootSelector)
        {
            this.javascriptExecutor = javascriptExecutor;
            withRootSelector(rootSelector);
        }

        /**
         * Set the root selector for finding react in the DOM
         *
         * @param rootSelector like "#root" (which is the default)
         */

        public ReactWebDriver withRootSelector(String rootSelector)
        {
            this.rootSelector = rootSelector;
            return this;
        }

        public ByReactFactory makeByReactFactory()
        {
            return new ByReactFactory(rootSelector);
        }
        public void waitForReactToLoad()
        {
            ByReact.LoadResqScript(javascriptExecutor);
            javascriptExecutor.ExecuteAsyncScript("window.resq.waitToLoadReact().then(arguments[arguments.length-1])");
        }

        public ReactComponent getComponent(IFilterableBy by)
        {
            return new ReactComponent(javascriptExecutor, by.getFilter());
        }

        public ReactComponent getComponent(IFilterableBy by, int index)
        {
            return new ReactComponent(javascriptExecutor, by.getFilter()).nthIndex(index);
        }

    }
}
