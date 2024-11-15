namespace ProjectManagement.Common.CommonDTO
{
    /// <summary>
    /// Add and edit audit base data.
    /// </summary>
    public class AddEditAuditData
    {
        /// <summary>
        /// Created date time
        /// </summary>
        public DateTimeOffset CreatedDateTime { get; set; }

        /// <summary>
        /// Modified date time
        /// </summary>
        public DateTimeOffset ModifiedDateTime { get; set; }
    }
}
