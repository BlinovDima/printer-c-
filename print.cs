using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
 
namespace TestPrintProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 
        // текст для печати
        private string result = "";
 
        // обработчик события нажатия на кнопку Печать
        private void printButton_Click(object sender, EventArgs e)
        {
            // задаем текст для печати
            result = "Строка 1\n\n";
 
            result += "Строка 2\nСтрока 3";
 
            // объект для печати
            PrintDocument printDocument = new PrintDocument();
 
            // обработчик события печати
            printDocument.PrintPage += PrintPageHandler;
 
            // диалог настройки печати
            PrintDialog printDialog = new PrintDialog();
 
            // установка объекта печати для его настройки
            printDialog.Document = printDocument;
 
            // если в диалоге было нажато ОК
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print(); // печатаем
        }
 
        // обработчик события печати
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // печать строки result
            e.Graphics.DrawString(result, new Font("Arial", 14), Brushes.Black, 0, 0);
        }
    }
}