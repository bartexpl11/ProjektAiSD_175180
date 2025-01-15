using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgorytmDijkstry2
{
    public class Graf
    {
        public List<NodeG> nodes = new List<NodeG>();
        public List<Edge> edges = new List<Edge>();

        public Graf(Edge k)
        {
            edges.Add(k);
            nodes.Add(edges[0].start);
            nodes.Add(edges[0].end);
        }

        public Graf()
        {
            nodes.Clear();
            edges.Clear();
        }

        public List<Element> AlgorytmDijkstry(NodeG start)
        {
            List<Element> tabelka = this.StworzTabelke(start);
            int i = 1;
            Element currentElement = tabelka.Where(e => e.wezel == start).First();
            currentElement.poprzednik = new NodeG(-1);
            List<NodeG> odwiedzoneNodes = new List<NodeG>();
            while (i < nodes.Count)
            {
                var doOdwiedzenia = edges.Where(k => k.start == currentElement.wezel &&
                !odwiedzoneNodes.Contains(k.end)).ToList();
                foreach (Edge k in doOdwiedzenia)
                {
                    Element element = tabelka.Where(e => e.wezel == k.end).First();
                    if (element.dystans > currentElement.dystans + k.weight)
                    {
                        element.dystans = currentElement.dystans + k.weight;
                        element.poprzednik = currentElement.wezel;
                    }
                }
                odwiedzoneNodes.Add(currentElement.wezel);
                var elementy = tabelka.Where(e => !odwiedzoneNodes.Contains(e.wezel)).ToList();
                currentElement = elementy.OrderBy(e => e.dystans).First();
                i++;
            }
            return tabelka;
        }

        

        public List<Element> StworzTabelke(NodeG start)
        {
            List<Element> list = new List<Element>();
            foreach (NodeG node in nodes)
            {
                if (node != start)
                    list.Add(new Element(node, Int32.MaxValue, null));
                else
                    list.Add(new Element(node, 0, null));
            }
            return list;
        }

        public void Add(Edge k)
        {
            if (!edges.Contains(k))
            {
                edges.Add(k);
                if (!nodes.Contains(k.start))
                {
                    nodes.Add(k.start);
                }
                if (!nodes.Contains(k.end))
                {
                    nodes.Add(k.end);
                }
            }
        }
    }
}
