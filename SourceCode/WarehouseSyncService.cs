using Newtonsoft.Json;
using PX.Data;
using PX.Objects.PO;

namespace POCustomization
{
    // Service class for preparing and sending PO data to warehouse system
    public class WarehouseSyncService
    {
        public void SyncPO(POOrder order)
        {
            // Exit if Purchase Order is not available
            if (order == null) return;

            // Build payload object for warehouse integration
            var payload = new
            {
                OrderNbr = order.OrderNbr,
                Status = order.Status,
                OrderDate = order.OrderDate,
                VendorID = order.VendorID,

            };

            // Convert payload into JSON format
            string jsonPayload = JsonConvert.SerializeObject(payload);

            // Log payload to the trace
            PXTrace.WriteInformation("PO JSON Payload: " + jsonPayload);

        }

    }
}
