using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ReactDriver.reactwebdriver
{
    public abstract class BaseBy: By
    {
        protected readonly string rootSelector;
        protected BaseBy(String rootSelector)
        {
            this.rootSelector = rootSelector;
        }

        private  IJavaScriptExecutor getJavascriptExecutor(ISearchContext context)
        {
            IJavaScriptExecutor jse;
            if (context is IWebElement) {

                IWrapsDriver wrapsDriver = context as IWrapsDriver;
               
                    jse = wrapsDriver.WrappedDriver as IJavaScriptExecutor;
                
               
            } else
            {
                jse = (IJavaScriptExecutor)context;
            }
            return jse;
        }

        protected  Object errorIfNull(Object o)
        {
            

            if (o == null  ) {
                throw new NoSuchElementException("Cannot locate an element using " + this);
            }
            return o;
        }

        public override WebElement FindElement(ISearchContext context)
        {
            IJavaScriptExecutor javascriptExecutor = getJavascriptExecutor(context);
            if (context is WebDriver) {
                context = null;
            }
            return ((List<WebElement>)errorIfNull(getObject(context, javascriptExecutor)))[0];
        }

        protected abstract Object getObject(ISearchContext context, IJavaScriptExecutor javascriptExecutor);


    public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            List<IWebElement> webElements = new List<IWebElement>();
            IJavaScriptExecutor javascriptExecutor = getJavascriptExecutor(context);
            if (context is WebDriver) {
                context = null;
            }
            var obj = getObject(context, javascriptExecutor);

            foreach (WebElement element in (IEnumerable<object>)obj)
            {
                if (element != null)
                {
                    webElements.Add(element);

                }
            }

          
            return new ReadOnlyCollection<IWebElement>(webElements);
        }
    }
}
