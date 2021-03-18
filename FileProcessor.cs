using System;
using System.IO;
using System.Collections.Generic;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileProcessor fp = new FileProcessor(new HtmlHandler());
            fp.ProcessFile(@"C:\Users\777\Desktop\test.html");

            fp.fileHandler = new TextHandler();
            fp.ProcessFile(@"C:\Users\777\Desktop\test.txt");

            fp.fileHandler = new JsonHandler();
            fp.ProcessFile(@"C:\Users\777\Desktop\test.json");

            fp.fileHandler = new JsonHandler();
            fp.ProcessFile(@"C:\Users\777\Desktop\test.xml");
        }
    }


    public abstract class AbstractFileHandler
    {
        List<string> SupportedExtensions = new List<string>() {".html",".txt",".json"};
        public string TheFileExtension;

        public void FileHandler(string fileName)
        {
            if (File.Exists(fileName))
            {
                TheFileExtension = Path.GetExtension(fileName);
                if (SupportedExtensions.Contains(TheFileExtension))
                {
                    DoSomeStuff(fileName);
                }
                else
                {
                    Console.WriteLine("The extension you try to work with is not supported yet.");
                }  
            }   
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        protected abstract void DoSomeStuff(string fileName);
    }

    public class FileProcessor
    {
        public AbstractFileHandler fileHandler;
        public FileProcessor(AbstractFileHandler fileHandler) => this.fileHandler = fileHandler;
        public void ProcessFile(string fileName)
        {
            fileHandler.FileHandler(fileName);

        }
    }

    class HtmlHandler : AbstractFileHandler
    {
        protected override void DoSomeStuff(string fileName)
        {
            Console.WriteLine("Html file handled");
        }
    }

    class TextHandler : AbstractFileHandler
    {
        protected override void DoSomeStuff(string fileName)
        {
            Console.WriteLine("Text file handled");
        }
    }

    class JsonHandler : AbstractFileHandler
    {
        protected override void DoSomeStuff(string fileName)
        {
            Console.WriteLine("JSON file handled");
        }
    }
}