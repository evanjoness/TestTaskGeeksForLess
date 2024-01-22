using Newtonsoft.Json;
using TestTask.UI.Models;

namespace TestTask.UI.Services;

public class ConfigurationParser : IConfigurationParser
{
    public List<ConfigurationNode> Parse(string configuration)
    {
        List<ConfigurationNode> nodes = new();
        var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(configuration);
        foreach (var key in dict.Keys)
        {
            if (dict[key].ToString().Contains("{"))
            {
                var nodeWithChildren = new ConfigurationNode
                {
                    NodeName = key,
                    Children = Parse(dict[key].ToString())
                };
                nodes.Add(nodeWithChildren);
            }
            else
            {
                var nodeWithoutChildren = new ConfigurationNode();
                nodeWithoutChildren.NodeName = key;
                nodeWithoutChildren.Value = dict[key].ToString();
                nodes.Add(nodeWithoutChildren);
            }
        }
 
        return nodes;
    }
}