## ABC Pipes – Acumatica Purchase Order Customization Assessment

## Approach

1. Created a new Acumatica 2025 R2 instance using the T100 dataset.

2. Created a customization project targeting the Purchase Orders screen (PO301000).

3. Added a custom field named 'Warehouse Sync Status' to support:
   - Pending
   - Synced
   - Failed

4. Implemented DAC extensions and helper classes for constants and reusable messages.

5. Added a custom action named 'Mark as Synced' with validation to prevent execution while the Purchase Order is on Hold.

6. Implemented a sample integration/service class (`WarehouseSyncService`) to prepare Purchase Order data as a JSON payload and display it through Acumatica Trace for demonstration purposes.

7. Added a 'Test Sync' action to execute the sample integration logic.

8. Built, published, and tested the customization successfully in Classic UI.


## Assumptions

- The customization was implemented and fully tested in Classic UI.
- Modern UI support was partially explored during implementation.
- Modern UI compilation could not be fully completed due to repeated frontend/NPM build issues during screen compilation.
- The integration implementation is provided as a demonstration/sample service approach rather than a production-ready external integration.


## Setup Instructions

1. Import or publish the provided customization package into an Acumatica 2025 R2 instance.

2. Source code files are included in the repository for review and further customization if required.

3. Publish the customization project from the Customization Projects screen.

4. Navigate to Purchase Orders (PO301000).

5. Create or open a Purchase Order to test:
   - Warehouse Sync Status field
   - Mark as Synced action
   - Test Sync action

6. Open Acumatica Trace to view the generated JSON payload from the sample integration service.


## Production Environment Improvements

In a production implementation, the solution could be extended with:

- Real external REST API integration using HttpClient.
- OAuth2 or token-based authentication.
- Logging and monitoring improvements.
- Background processing using PXLongOperation.
- Integration status history management.
