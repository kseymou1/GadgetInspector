
CREATE OR ALTER PROCEDURE [dbo].[Gadgets_GetGridItems]
--	v1.0 - 2025-03-23 - K. Seymour 
--	SAMPLE USE: EXEC Gadgets_GetGridItems 3
	@gadgetTypeId int = null
AS
BEGIN
	--We are assuming all Gadgets have at least one passed inspection for now.
	--Not a lot of time for edge cases for the purposes of this demo
	SELECT
		gadget.Id as GadgetId,
		gadget.[Name] as GadgetName,
		gadgetType.[Name] as GadgetTypeName,
		lastPassedInspection.CompletionDate as LastInspectedDate,
		DATEADD(DAY, gadgetType.InspectionIntervalDays, lastPassedInspection.CompletionDate) as DueDate,
		--This is lazy for the demo, assuming all dates and time zones are the same
		--In real life, we would use UTC and the DateTime from the client's browser to determine days remaining
		DATEDIFF(DAY, GETDATE(), DATEADD(DAY, gadgetType.InspectionIntervalDays, lastPassedInspection.CompletionDate)) as DaysRemaining,
		nextScheduledInspection.Id as ScheduledInspectionId,
		nextScheduledInspection.ScheduledDate,
		scheduledTechnician.[Name] as ScheduledTechnicianName
	FROM Gadgets gadget
	INNER JOIN GadgetTypes gadgetType ON gadgetType.Id = gadget.GadgetTypeId
	OUTER APPLY (
		SELECT TOP 1 CompletionDate
		FROM Inspections
		WHERE GadgetId = gadget.Id
			AND IsPassed = 1
		ORDER BY CompletionDate DESC
	) lastPassedInspection
	OUTER APPLY (
		--We will have a constraint to block more than one scheduled inspection per gadget
		--But taking TOP 1 just in case for now, since this is so theoretical
		SELECT TOP 1 Id, ScheduledDate, TechnicianId
		FROM Inspections
		WHERE GadgetId = gadget.Id
			AND IsComplete = 0
		ORDER BY ScheduledDate ASC
	) nextScheduledInspection
	LEFT JOIN Technicians scheduledTechnician ON scheduledTechnician.Id = nextScheduledInspection.TechnicianId
	WHERE @gadgetTypeId IS NULL OR gadgetType.Id = @gadgetTypeId;
END


GO


