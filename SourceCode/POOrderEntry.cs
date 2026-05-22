using PX.Data;
using PX.Objects.PO;
using System.Collections;

namespace POCustomization
{
    // Acuminator disable once PX1016 ExtensionDoesNotDeclareIsActiveMethod extension should be constantly active
    public class POOrderEntry_Extension : PXGraphExtension<POOrderEntry>
    {
        #region Actions

        // Mark as Synched Action
        public PXAction<POOrder> MarkAsSynced = null;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Mark as Synced", Enabled = true)]
        protected virtual void markAsSynced()
        {
            // Get the current PO from the cache
            POOrder row = Base.Document.Current;
            if (row == null) return;

            // Get the extension to access custom field
            POOrderExt rowExt = row.GetExtension<POOrderExt>();

            // Update the sync status to Synced
            rowExt.UsrWarehouseSyncStatus = WarehouseSyncStatusConstants.Synced;

            // Update the data record in the cache
            Base.Document.Update(row);

            // Save changes to the database
            Base.Actions.PressSave();
        }


        //Test Sync Action
        public PXAction<POOrder> TestSync;

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Test Sync")]
        protected virtual IEnumerable testSync(PXAdapter adapter)
        {
            // Get currently selected Purchase Order
            POOrder order = Base.Document.Current;

            if (order == null)
                return adapter.Get();

            // Call external warehouse synchronization service
            WarehouseSyncService service = new WarehouseSyncService();

            service.SyncPO(order);

            return adapter.Get();
        }


        #endregion

        #region Event Handlers

        // Manage availability of the action
        protected virtual void _(Events.RowSelected<POOrder> e)
        {
            if (e.Row == null) return;
            var row = (POOrder)e.Row;

            // Disable when on Hold
            MarkAsSynced.SetEnabled(row.Hold != true);
            TestSync.SetEnabled(row.Hold != true);
        }

        #endregion
    }
}