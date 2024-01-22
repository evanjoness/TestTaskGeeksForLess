using TestTask.UI.Models;

namespace TestTask.UI.Services;

public interface IConfigurationService
{
    List<ConfigurationNode> GetConfiguration(int cfgId);
    
    List<ConfigurationNode> AddConfiguration(string cfg);
}