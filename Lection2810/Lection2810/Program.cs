using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace Lection2810
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIA3Automation _automation = new UIA3Automation();
            Application _app;

            _app = Application.Launch("C:\\Users\\221\\Downloads\\EducationProjects-master\\EducationProjects-master\\TestApp\\bin\\Debug\\TestApp.exe");

            var window = _app.GetMainWindow(_automation);

            Console.WriteLine(window.Title);

            var children = window.FindAllChildren();
            foreach (var item in children)
            {
                Console.WriteLine(item.Name);
                //Console.WriteLine(item.ClassName);
                Console.WriteLine(item.AutomationId);
                Console.WriteLine("-------");
            }

            //var input = window.FindFirstDescendant(x=>x.ByName("Текстовый редактор")).AsTextBox();
            var inputs = window.FindAllDescendants(x => x.ByControlType(FlaUI.Core.Definitions.ControlType.Edit));
            inputs[0].AsTextBox().Enter("Сделать домашку");
            inputs[1].AsTextBox().Enter("Открыть тетради и закрыть тетрадь");

            window.FindFirstDescendant(x => x.ByText("Добавить")).AsButton().Click();

            window.FindFirstDescendant(x => x.ByText("Сделать домашку")).AsButton().Click();


            //Console.WriteLine(inputs.Count());
            //window.FindFirstDescendant(x => x.ByText("Тестирование знаний")).AsButton().Click();
            //input.Enter("Hello world!");

            Console.ReadLine();
            _app.Close();
        }
    }
}