using Acme.BookStore.Domain.Shared.Localization.BookStore;
using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Acme.BookStore.Web
{
    public class SampleService: ITransientDependency
    {
        private readonly ISettingDefinitionManager _settingDefinitionManager;

        public SampleService(ISettingDefinitionManager settingDefinitionManager)
        {
            _settingDefinitionManager = settingDefinitionManager;
        }


        public async Task Test()
        {
            var settingDefinitions = await _settingDefinitionManager.GetAllAsync();
            foreach (var definition in settingDefinitions)
            {
                Console.WriteLine(definition.Name);
                Console.WriteLine(definition.DefaultValue);
            }
        }
    }
}
