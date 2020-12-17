using ComputerDatabase_CommonLibs.Utilities;
using System;

namespace ComputerDatabase_PageObjects
{
    public class BasePage
    {
        protected CommonActions _action;

        public BasePage()
        {
            _action = new CommonActions();

        }

    }
}
