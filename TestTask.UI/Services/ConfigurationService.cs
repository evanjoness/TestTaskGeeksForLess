using Microsoft.AspNetCore.Mvc;
using TestTask.UI.Data;
using TestTask.UI.Models;

namespace TestTask.UI.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfigurationParser _parser;
    private readonly ApplicationDbContext _dbContext;

    public ConfigurationService(IConfigurationParser parser, ApplicationDbContext dbContext)
    {
        _parser = parser;
        _dbContext = dbContext;
    }

    public List<ConfigurationNode> GetConfiguration(int cfgId)
    {
        var cfg = _dbContext.Configurations.Find(4);
        var parsedCfg = cfg is null ? throw new ArgumentException() : _parser.Parse(cfg.PlainConfiguration);

        return parsedCfg;
    }

    public List<ConfigurationNode> AddConfiguration(string cfg)
    {
        _dbContext.Configurations.Add(new() { PlainConfiguration = cfg });
        _dbContext.SaveChanges();
        
        var parsedCfg = _parser.Parse(cfg);
        
        return parsedCfg;
    }
}