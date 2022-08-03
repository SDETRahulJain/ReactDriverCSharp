using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ReactDriver.reactwebdriver
{
    public class ReactComponent
    {

        private IJavaScriptExecutor jse;
        private ReactComponentFilter filter;
        private int elementIndex;

        public ReactComponent(IJavaScriptExecutor jse, ReactComponentFilter filter)
        {
            this.jse = jse;
            this.filter = filter;
            elementIndex = 0;
        }

        public ReactComponent nthIndex(int elementIndex)
        {
            this.elementIndex = elementIndex;
            return this;
        }

        public Object getProps()
        {
            return getComponentDetails("props", "");
        }

        public Object getProp(String propName)
        {
            return getComponentDetails("props", propName);
        }


        private Object getComponentDetails(String objName, String key)
        {
            return ByReact.ExecuteQuery(jse,
                    ByReact.locatorScript +
                            "return getObjectDetails({" +
                            "    rootSelector: arguments[0]," +
                            "    selector: arguments[1]," +
                            "    props: arguments[2]," +
                            "    state: arguments[3]," +
                            "    context: arguments[4]," +
                            "    elementIndex: arguments[5]," +
                            "    objectName: arguments[6]," +
                            "    key: arguments[7]" +
                            "})",
                    filter.getRootSelector(),
                    filter.getComponentName(),
                    filter.getProps(),
                    filter.getState(),
                    null, elementIndex, objName, key);
        }
    }
}
