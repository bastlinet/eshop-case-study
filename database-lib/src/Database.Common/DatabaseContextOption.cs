namespace EshopDb.Common
{
    /// <summary>
    /// Standard database context options for database layer
    /// </summary>
    public class DatabaseContextOption
    {
        /// <summary>
        /// Connection string 
        /// </summary>
        public virtual string ConnectionString { get; set; }
    }
}