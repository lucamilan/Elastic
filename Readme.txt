Elastic is a framework that helps to simplify the "wiring" phase of our applications. Elastic promote Composition Root pattern by MEF.

Usage:

//in our app entry point, global.asax for example
=========================================================================================
//setup Composition Service (MEF powered)
var compositionService = new CompositionContainer(new DirectoryCatalog(@"."));
Extensibility.Composer = () => compositionService;

//bootstrapp the IOC Container, the Root
var container = new Container();
Bootstrap.This(() => container);
=========================================================================================


//after write an installer plugin for configure our container dependencies
=========================================================================================
/// <summary>
/// Boostrapp Automapper and Register in Container
/// </summary>
[ExportInstaller(1, typeof (IInstaller<IContainer>))]
public class BootstrapAutoMapper : InstallerBase<IContainer>
{
	#region Overrides of InstallerBase<IContainer>

	/// <summary>
	/// </summary>
	/// <param name = "object"></param>
	protected override void Configure(IContainer @object)
	{
		//create automapper configuration object
		var cfg = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.AllMappers());
		cfg.ConstructServicesUsing(@object.GetInstance);

		//bootstrap automapper, setup profile and so on
		Bootstrap.This(() => cfg);

		//configure automapper in container
		@object.Configure(_ => _.For<ConfigurationStore>().Singleton().Use(cfg));
		@object.Configure(_ => _.For<IMappingEngine>().Singleton().Use(new MappingEngine(cfg)));
	}
	#endregion
}

/// <summary>
/// Setup AutoMapper
/// </summary>
[ExportInstaller(typeof (IInstaller<ConfigurationStore>))]
public class SetupAutoMapperProfile : InstallerBase<ConfigurationStore>
{
	#region Overrides of InstallerBase<IConfiguration>

	/// <summary>
	/// </summary>
	/// <param name = "object"></param>
	protected override void Configure(ConfigurationStore @object)
	{
		@object.CreateMap<SimpleEntity, SimpleViewModel>()
			.ForMember(_ => _.FullName, _ => _.MapFrom(__ => string.Format("{0} {1}", __.FirstName, __.LastName)));
	}

	#endregion
}
=========================================================================================
