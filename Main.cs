using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPICreateBar
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "My Revit API";
            application.CreateRibbonTab(tabName); //Создание вкладки
            string utilsPath = @"C:\Program Files\RevitAPITraining\RevitAPIPipesWallsDoors.dll";
            string utilsPath2 = @"C:\Program Files\RevitAPITraining\RevitAPIChangeWallType.dll";

            var panel = application.CreateRibbonPanel(tabName, "Моя панель"); //Создание панели на вкладке

            var button = new PushButtonData("Сведения", "Сбор сведений", utilsPath, "RevitAPIPipesWallsDoors.Main"); //Создание кнопки
            var button2 = new PushButtonData("Изменения", "Изменить тип стен", utilsPath2, "RevitAPIChangeWallType.Main");

            panel.AddItem(button); //Добавление кнопки на панель
            panel.AddItem(button2);

            return Result.Succeeded;
        }
    }
}
