using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

public class Day7Circus
{
        
    public static void Part1(){
        var lines = File.ReadAllLines("Files/D7.txt");

        //On rempli le dictionnaire des nodes avec leur poids.
        Dictionary<string, D7Node> nodes = new Dictionary<string, D7Node>();
        foreach (var l in lines)
        {
            var values = l.Split(" ");
            var weightStr = values[1].Replace('(',' ').Replace(')',' ').Trim();
            nodes.Add( values[0],
                new D7Node(){
                    Name = values[0],
                    Weight = Int32.Parse(weightStr),  
                }
            );
        }

        //On repasse pour mettre les enfants/parents
        foreach (var l in lines)
        {
            var key = l.Split(" ")[0];
            var values = l.Split("->");
            var parent = nodes[key];
            if(values.Length > 1){
                var childs = values[1].Split(",");
                foreach (var cStr in childs)
                {
                    var c = nodes[cStr.Trim()];
                    parent.Childs.Add(c);
                    c.Parent = parent;
                }
            }
        }

        //Find the root
        var root = nodes.First().Value;
        while(root.Parent != null){
            root = root.Parent;
        }
        Console.WriteLine("Root : " + root.Name);
        Console.WriteLine("\n----------");

        Console.WriteLine("Le poids devrait etre + " + FindTheWRONG(root));
        //1183  - 1079

    }

	private static int FindTheWRONG(D7Node element)
	{
        var groups = element.Childs.GroupBy(c=>c.TotalWeight);
        if(groups.Count() == 2){
            var a = groups.First().First().TotalWeight;
            var b = groups.Last().First().TotalWeight;
            var returned = FindTheWRONG(groups.Last().First());
            if(returned != -1){
                return returned;
            }else{
                foreach (var c in element.Childs)
                {
                    Console.WriteLine(c.Name + " : " + c.TotalWeight);                
                }
                if(groups.First().Count() > groups.Last().Count())
                    return groups.Last().First().Weight;
                else
                    return groups.Last().Last().Weight;

                //return (int)( MathF.Max(a,b) - MathF.Min(a,b));
                //return a;
            }
        }else{
            return -1;
        }
	}
}

public class D7Node
{
    public string Name;
    public D7Node Parent;
    public List<D7Node> Childs = new List<D7Node>();
    public int Weight; 
    public int TotalWeight{
        get{
            var childWeight = 0;
            if(Childs.Count() > 0)
           
                childWeight = Childs.Select(c=>c.TotalWeight).Aggregate( (sum,a) => sum + a);
            return Weight + childWeight;
        }
    }
}
