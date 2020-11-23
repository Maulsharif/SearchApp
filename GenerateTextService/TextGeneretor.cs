using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

namespace GenerateTextService
{
    public class TextGenerator
    {
        public List<string> Texts{ get; set; }

        public TextGenerator()
        {
            Texts=new List<string>(){"mouse", "koala", "dog", "elephant", "shark", "tiger"};
        }
    }
}