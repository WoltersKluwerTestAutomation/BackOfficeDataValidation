using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkBackOfficeTests.PageObjects;

namespace WkBackOfficeTests.Support
{
    public abstract class Pages : Base
    {

        // this is to test
        public static HomePageClass HomePage { get { var homePage = new HomePageClass(); return homePage; } }
        public static PackagesPageClass PackagesPage { get { var packagesPage = new PackagesPageClass(); return packagesPage; } }
        public static SitesPageClass SitesPage { get { var sitesPage = new SitesPageClass(); return sitesPage; } }
        public static SubscriptionsPageClass SubscriptionsPage { get { var subscriptionsPage = new SubscriptionsPageClass(); return subscriptionsPage; } }
        public static UsersPageClass UsersPage { get { var userspage = new UsersPageClass(); return userspage; } }
        public static WkLoginPageClass WkLoginPage { get { var wkLoginPage = new WkLoginPageClass(); return wkLoginPage; } }



    }
}