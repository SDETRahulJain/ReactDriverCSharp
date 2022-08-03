using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactDriver.reactwebdriver
{
   
    public class ReactComponentFilter
    {
        private readonly string rootSelector, componentName, props, state;

        public ReactComponentFilter(String rootSelector,
                               String componentName,
                               String props,
                               String state)
        {
            this.rootSelector = rootSelector;
            this.componentName = componentName;
            this.props = props;
            this.state = state;
        }
        public String getRootSelector()
        {
            return rootSelector;
        }

        public String getComponentName()
        {
            return componentName;
        }

        public String getProps()
        {
            return props;
        }

        public String getState()
        {
            return state;
        }
    }
}
