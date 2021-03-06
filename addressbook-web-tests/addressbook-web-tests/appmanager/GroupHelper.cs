﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }    

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int index, GroupData newData)
        {          
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index); 
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Modify(GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            SelectGroup(index);
            SubmitGroupRemoval();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Remove(GroupData group)
        {
            SelectGroup(group.Id);
            SubmitGroupRemoval();
            ReturnToGroupsPage();
            return this;

        }
        public GroupHelper CreateNewTempGroup()
        {
            GroupData group = new GroupData("Temp");
            group.Header = "Group";
            group.Footer = "For Modify";
            Create(group);
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+ (index+1) +"]")).Click();
            return this;
        }
        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '"+id+"'])")).Click();
            return this;
        }

        public int GetCountGroup()
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.ClassName("group")).Count;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }  

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupRemoval()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper CheckIfGroupIsPresent()
        {
            manager.Navigator.GoToGroupsPage();

            if (GetCountGroup() == 0)
            {
                CreateNewTempGroup();
            }
            return this;
        }

        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            
            if (groupCache == null)
            {

                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text){
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
      
                }
            }
            return new List<GroupData>(groupCache);

        }
    }
}
