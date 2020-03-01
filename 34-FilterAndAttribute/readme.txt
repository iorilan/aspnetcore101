for filter :
1. register at startup.cs 
 public void ConfigureServices(IServiceCollection services) {
            ...
            services.AddMvc().AddMvcOptions(options => {
                ...
                options.Filters.Add(typeof(DiagnosticsFilter));
            });
        }
2. usage 
  [ServiceFilter(typeof(DiagnosticsFilter))]  


attribute :
global level 
        public void ConfigureServices(IServiceCollection services) {
            ...
            services.AddMvc().AddMvcOptions(options => {
                options.Filters.Add(new MessageAttribute("This is the Globally-Scoped Filter"));
                ...
            });
        }

action level
 [Message("This is the First Action-Scoped Filter")]

define order :
 [Message("This is the Controller-Scoped Filter", Order = 10)]