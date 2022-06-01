using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VmsInform.DAL.Domain;

namespace VmsInform.DAL.MyBoxRepositories
{
    public sealed class GlobalSettings : IGlobalSettings
    {

        private const string _settingTransport = "Transport";
        private const string _settingCash = "Cash";

        private readonly DbContext _dbContext;
        public GlobalSettings(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private int GetValueInt(string settingName)
        {
            return Convert.ToInt32(GetValue(settingName));
        }

        private decimal GetValueDecimal(string settingName)
        {
            return Convert.ToDecimal(GetValue(settingName));
        }

        private string GetValue(string settingName)
        {
            return Data.FirstOrDefault(a => a.Name == settingName)?.Value;
        }

        private async Task SetValue(string settingName, string value, string type = "string")
        {
            var setting = await Data.FirstOrDefaultAsync(a => a.Name == settingName);

            if (setting != null) 
            {
                setting.Value = value;
                Data.Update(setting);
            }
            else
            {
                setting = new GlobalSetting
                {
                    Name = settingName,
                    Value = value,
                    Type = type,
                    Order = string.Empty,
                    Domain = string.Empty
                };
                await Data.AddAsync(setting);
            }

            await _dbContext.SaveChangesAsync();
        }

        private async Task SetValue(string settngName, decimal value)
        {
            await SetValue(settngName, Convert.ToString(value), "decimal");
        }

        private DbSet<GlobalSetting> Data
        {
            get => _dbContext.Set<GlobalSetting>();
        }

        public decimal Transport
        {
            get
            {
                return GetValueDecimal(_settingTransport);
            }
            set
            {
                SetValue(_settingTransport, value).Wait();
            }
        }

        public decimal Cash
        {
            get
            {
                return GetValueDecimal(_settingCash);
            }
            set
            {
                SetValue(_settingCash, value).Wait();
            }
        }
    }
}
