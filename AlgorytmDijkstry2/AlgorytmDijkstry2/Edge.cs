﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmDijkstry2
{
    public class Edge
    {
        public NodeG start;
        public NodeG end;
        public int weight;

        public Edge(NodeG start, NodeG end, int weigth)
        {
            this.start = start;
            this.end = end;
            this.weight = weigth;
        }
    }
}
