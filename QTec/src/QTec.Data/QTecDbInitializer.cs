namespace QTec.Data
{
    using System.Data.Entity;

    using QTec.Data.Migrations;

    /// <summary>
    /// The QTec database initializer.
    /// </summary>
    public class QTecDbInitializer : MigrateDatabaseToLatestVersion<QTecDataContext, Configuration>
    {
    }
}