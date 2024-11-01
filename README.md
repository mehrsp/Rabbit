
Instructions for Database Configuration
To ensure proper database connection, update your appsettings.json with the following:

Note: Replace your_server with the name of your server to direct the application to the correct database .


"ConnectionStrings": {
 "MedicationConnection": "Server=[your_server];Database=MedicationDB;Trusted_Connection=True;TrustServerCertificate=True;    
}

then update database 
dotnet ef database update --project [yourpath]\BCC\BCC.Endpoints
-----------------------------------------------------------------
Code Documentation
-----------------------------------------------------------------
1. GetMedicationsQueryHandler.cs
Purpose: Handles the query for retrieving all medications.

Dependencies: IMedicationRepository.
Key Method:
Handle: Fetches all medications asynchronously and maps them to MedicationViewModel. Returns a ServiceResult with the list or a "not found" message.
2. CreateMedicationCommandHandler.cs
Purpose: Handles commands for creating new medication records.

Dependencies: IMedicationRepository, IMedicationService.
Key Method:
Handle: Validates the request, creates a Medication instance, and adds it to the repository. Returns a CreateMedicationResponse with the new record's ID.
3. DeleteMedicationCommandHandler.cs
Purpose: Manages the deletion of medication records.

Dependencies: IMedicationRepository.
Key Method:
Handle: Retrieves a medication by ID, marks it as deleted, and performs deletion. Returns a success ServiceResult.
4. MedicationController.cs
Purpose: Provides API endpoints for medication management.

Endpoints:
GET /Medications: Retrieves medication records using GetMedicationsQuery.
POST /: Creates a new medication with CreateMedicationCommand.
PUT /: Deletes a medication using DeleteMedicationCommand.
5. Medication.cs
Purpose: Represents the domain model for medications.

Key Properties: Id, Name, Quantity, CreationDate, IsDeleted.
Methods:
ChangeName, ChangeQuantity, ChangeCreationDate: Modify properties.
DeleteMedican: Marks a medication as deleted, with validation.
6. MedicationService.cs
Purpose: Provides validation logic for medications.

Method:
ValidateQuantity: Ensures the quantity is greater than zero. Throws BusinessValidationException if not.
7. IMedicationRepository.cs
Purpose: Interface for medication repository operations.

Methods:
GetAllMedicationAsync(), GetMedicationAsync(int id), AddMedicationAsync(Medication medication), DeleteMedicationAsync(Medication medication).
8. IMedicationService.cs
Purpose: Interface for defining validation logic.

Method:
ValidateQuantity: Specifies the contract for quantity validation.


