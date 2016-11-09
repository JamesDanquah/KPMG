using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class BaseModel
    {
        private string pageTitle;
        public string PageTitle
        {
            get
            {
                if (pageTitle == null)
                    return "TestProject";
                return pageTitle;
            }
            set
            {
                pageTitle = value;
            }
        }

        public string PageDescription { get; set; }
        public string Canonical { get; set; }
        public List<Link> HeaderLinks { get; set; }

        public BaseModel()
        {
            HeaderLinks = new List<Link>();
            Navigation = new NavigationSelected();
        }
        public NavigationSelected Navigation { get; set; }
    }
    public class Link
    {
        public string ImageUrl { get; set; }
        public string Href { get; set; }
        public string Alt { get; set; }
        public string Html { get; set; }
        public string TransitionTime { get; set; }
    }
    public class NavigationSelected
    {
        public bool Home { get; set; }
    }
}
