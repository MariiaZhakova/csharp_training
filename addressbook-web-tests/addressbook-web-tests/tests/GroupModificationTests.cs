using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("testing");
            newData.Header = "1";
            newData.Footer = "2";
            app.Groups.CheckIfGroupIsPresent();
            app.Groups.Modify(1, newData);
        }
    }
}
