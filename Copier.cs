using System;
using System.Collections.Generic;
using System.Text;
using static Kserokopiarka.IDocument;

namespace Kserokopiarka
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int ScanCounter { get; set; } = 0;
        public int Counter { get; set; } = 0;
        public int PrintCounter { get; set; } = 0;

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                PrintCounter++;

                Console.WriteLine($"{DateTime.Now.ToLocalTime()} Print: {document.GetFileName()}");
            }

        }


        public void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                this.Counter++;
                state = IDevice.State.on;
            }
        }

        public void ScanAndPrint()
        {
         
            if (state == IDevice.State.on)
            {
                Scan(out IDocument document);
                Print(document);
            }

        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = FormatType.PDF)
        {
            switch (formatType)
            {
                case FormatType.JPG: document = new ImageDocument($"ImageScan{ScanCounter}.jpg"); break;
                case FormatType.PDF: document = new PDFDocument($"PDFScan{ScanCounter}.pdf"); break;
                case FormatType.TXT: document = new TextDocument($"TextScan{ScanCounter}.txt"); break;
                default: throw new ArgumentException("Unknown type");
            }

            if (state == IDevice.State.on)
            {
                ScanCounter++;

                Console.WriteLine($"{DateTime.Now.ToLocalTime()} Scan: {document.GetFileName()}");
            }

        }
    }
}
