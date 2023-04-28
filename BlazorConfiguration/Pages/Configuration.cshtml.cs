using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorConfiguration.Pages
{
    public class ConfigurationModel : PageModel
    {
	    private readonly IConfiguration Configuration;

	    public ConfigurationModel(IConfiguration configuration)
	    {
		    Configuration = configuration;
        }
		public ContentResult OnGet()
        {
            var styleSheetOptions1 = Configuration.GetSection("adeNet:styles:add").Get<Styles[]>();


            string strStyles = string.Empty;
            HashSet<string>  styleSet = new HashSet<string>();
            foreach(Styles styles in styleSheetOptions1)
            {
                strStyles += $"Path = {styles.Path}, Theme= {styles.Theme} \n\r";
                styleSet.Add(styles.Path);
            }

	        return Content(strStyles);
		}
    }
}
