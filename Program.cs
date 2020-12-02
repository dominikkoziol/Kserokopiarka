using System;

namespace Kserokopiarka
{
    class Program
    {
        static void Main(string[] args)
        {
            var copier = new Copier();
            copier.PowerOn();
            copier.Scan(out IDocument document, IDocument.FormatType.PDF);

        }
    }
}
