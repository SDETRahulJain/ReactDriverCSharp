using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactDriver.reactwebdriver
{
    public class ByReactFactory
    {

        private String rootSelector;

        public ByReactFactory(String rootSelector)
        {
            this.rootSelector = rootSelector;
        }

        public ByReactComponent component(String selector)
        {
            return new ByReactComponent(rootSelector, selector);
        }
    }
}
