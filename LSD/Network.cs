using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LSD
{
    class Network
    {
        private Random Randy = new Random();

        public Network(string fileName, int snitchCount, int mu, int sigma)
        {
            var file = ParseFile(fileName);
            var keys = file.Distinct(x => x.X).Union(file.Distinct(x => x.Y));
            Graph<int, double> arrayGraph = new ArrayGraph<double>(keys);
            Graph<int, double> hashGraph = new HashGraph<int, double>(keys);

            foreach (var line in file)
            {
                var arrayEdge = arrayGraph[line.X].Connect(line.Y);
                arrayEdge.Value = Randy.Gaussian(4, 1);

                var hashEdge = arrayGraph[line.X].Connect(line.Y);
                hashEdge.Value = arrayEdge.Value;
            }
        }

        private IEnumerable<VectorInt> ParseFile(string fileName)
        {
            return File.ReadAllLines(fileName)
                .Select(x => x.Split(' '))
                .Select(x => new VectorInt { X = int.Parse(x[0]), Y = int.Parse(x[1]) });
        }
    }
}
