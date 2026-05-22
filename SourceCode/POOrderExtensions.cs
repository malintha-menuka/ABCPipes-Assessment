using PX.Data;

namespace POCustomization
{
    // Acuminator disable once PX1016 ExtensionDoesNotDeclareIsActiveMethod extension should be constantly active
    public sealed class POOrderExt : PXCacheExtension<PX.Objects.PO.POOrder>
    {
        #region UsrWarehouseSyncStatus
        [PXDBString(2, IsFixed = true)]
        [PXStringList(
            new string[]
            {
                WarehouseSyncStatusConstants.Pending,
                WarehouseSyncStatusConstants.Synced,
                WarehouseSyncStatusConstants.Failed
            },
            new string[]
            {
                Messages.Pending,
                Messages.Synced,
                Messages.Failed
            })]
        [PXUIField(DisplayName = "Warehouse Sync Status")]
        [PXDefault(WarehouseSyncStatusConstants.Pending, PersistingCheck = PXPersistingCheck.Nothing)]
        public string UsrWarehouseSyncStatus { get; set; }
        public abstract class usrWarehouseSyncStatus : PX.Data.BQL.BqlString.Field<usrWarehouseSyncStatus> { }
        #endregion
    }
}