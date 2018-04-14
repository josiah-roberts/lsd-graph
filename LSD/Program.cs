using System.IO;
using System.Linq;
using System;
using System.Numerics;
using System.Collections.Generic;

namespace LSD
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "./data/testData.edge";
            var network = new Network(fileName, 1, 1, 1);
        }        
    }
}