namespace csharp_design_patterns.SOLID.ISP
{
    public class Document
    {
        //
    }
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class NewPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    // say the old printer cannot fax and scan, it has to forcefully implement, or rather throw exceptions
    // or do something of that sort. 
    public class OldPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    // Make smaller interfaces
    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scanner(Document d);
    }

    public interface IPrinterAndScanner : IPrinter, IScanner
    {
        //
    }

    // Now, say a printer can scan and print, we can inherit those specific interfaces only.
    // or even make a new interface for PrinterAndScanner that inherits the smaller ones
    // You can do something like below
    public class PrinterAndScanner : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            //
        }

        public void Scanner(Document d)
        {
            //
        }
    }

    public class PrinterAndScannerNew : IPrinterAndScanner
    {
        void IPrinter.Print(Document d)
        {
            //
        }

        void IScanner.Scanner(Document d)
        {
            //
        }
    }
}


/*
Notes:
    - If you have an interface that includes too much stuff in one, then break it down into multiple smaller interfaces
*/