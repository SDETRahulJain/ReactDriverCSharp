using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactDriver.reactwebdriver
{
    public class ByReactComponent :BaseBy, IFilterableBy
    {
        private String clselector;
        private String clprops;
        private String clstate;


        public  class FindBy
        {
            [DefaultValue("")]
            public String rootSelector { get; set; }

            public String name { get; set; }

            [DefaultValue("{}")]
            public String prop { get; set; }

            [DefaultValue("{}")]
            public String states { get; set; }
            //    string rootSelector()
            //    { return ""; }

            //String name();

            //    String prop() { return "{}"; }

            //    String states() { return "{}"; }
        }
    public static class ReactFindByBuilder 
        {
        
        public static By buildIt( Object annotation, object field)
        {
             FindBy findBy = (FindBy)annotation;
            return new ByReactComponent(findBy.rootSelector, findBy.name, findBy.prop, findBy.states);
        }
    }

    public ByReactComponent(String rootSelector,
                           String selector,
                           String props,
                           String state):base(rootSelector)
        {
           // base(rootSelector);
            this.clselector = selector;
            this.clprops = props;
            this.clstate = state;
        }
        public ByReactComponent(String rootSelector, String selector):base(rootSelector)
        {
            this.clselector = selector;
           
        }

        public ByReactComponent props(String props)
        {
            this.clprops = props;
            return this;
        }

        public ByReactComponent state(String state)
        {
            this.clstate = state;
            return this;
        }

       
    protected override Object getObject(ISearchContext context, IJavaScriptExecutor javascriptExecutor)
        {
            return ByReact.ExecuteQuery(
                    javascriptExecutor,
                    ByReact.locatorScript +
                    "return getWebElements({\n" +
                            "    rootSelector: arguments[0],\n" +
                            "    selector: arguments[1],\n" +
                            "    props: arguments[2],\n" +
                            "    state: arguments[3],\n" +
                            "    context: arguments[4]\n" +
                            "})",
                    rootSelector, clselector, clprops, clstate, context);

        }

    public ReactComponentFilter getFilter()
        {
            return new ReactComponentFilter(rootSelector, clselector, clprops, clstate);
        }

       
    public  String toString()
        {
            return "ByReactComponent [component=" + clselector + "] [props=" + props + "] [state=" + state + "]";
        }

    }
}
