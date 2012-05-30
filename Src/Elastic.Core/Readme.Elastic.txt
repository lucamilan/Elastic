Elastic
-------

public class DescribeBootstrapper
{
    /// <summary>
    /// 
    /// </summary>
    public void Describe()
    {
        Bootstrap.AfterInstall += Print;
        var typeCatalog = new TypeCatalog(Assembly.GetExecutingAssembly().GetExportedTypes());
        var compositionContainer = new CompositionContainer(typeCatalog);
        Bootstrap.DiscoveryInstallerWith(() => compositionContainer);
        Root root = Bootstrap.This(() => new Root());
        Console.WriteLine("{0}", root.Messagges.Single());
    }

    /// <summary>
    /// Print installer message to console.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Print(object sender, InstallerEventArg e)
    {
        Console.WriteLine("{0} : {1} secs", e.Installer.FullName, e.InstallDuration);
    }

    #region Nested type: InstallMessageInRoot

    /// <summary>
    /// 
    /// </summary>
    [ExportInstaller(1, typeof (IInstaller<Root>))]
    public class InstallMessageInRoot : InstallerBase<Root>
    {
        protected override void Configure(Root @object)
        {
            @object.Messagges = new List<string> {" configure and install "};
        }
    }

    #endregion

    #region Nested type: Root

    /// <summary>
    /// Class to bootstrapping
    /// </summary>
    public class Root
    {
        public List<string> Messagges { get; set; }
    }

    #endregion
}