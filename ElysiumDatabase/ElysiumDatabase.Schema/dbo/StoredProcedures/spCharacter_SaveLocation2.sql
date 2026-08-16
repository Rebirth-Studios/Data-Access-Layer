-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/27/2022 - Added @batchRowId
-- Description: Save character location
-- =============================================
CREATE procedure [dbo].[spCharacter_SaveLocation2]
    @spawnedWorldObjectId uniqueIdentifier,
    @coordinateX decimal(18,6),
    @coordinateY decimal(18,6),
    @coordinateZ decimal(18,6),
    @chunk int,
    @rotationX decimal(18,6),
    @rotationY decimal(18,6),
    @rotationZ decimal(18,6),
    @lastUpdate datetime,
    @updateLocationCount tinyint output
AS
    --@insertBatchProcessingCount tinyint,
    --@updateLocationCount tinyint
    --BEGIN TRY
    --Add parameters passed by C# for logging
-- 	SET @errParameters =  CONCAT_WS(',','  @spawnedWorldObjectId - ', @spawnedWorldObjectId, 
-- 		 '  @coordinateX - ', @coordinateX, 
-- 		 '  @coordinateY - ', @coordinateY, 
-- 		 '  @coordinateZ - ', @coordinateZ, 
-- 		 '  @chunk - ', @chunk, 
-- 		 '  @rotationX - ', @rotationX, 
-- 		 '  @rotationY - ', @rotationY, 
-- 		 '  @rotationZ - ', @rotationZ, 
-- 		 '  @logging - ', @logging,
-- 		 '  @batchRowId - ', @batchRowId)

    --USED IF SERVER CRASHES DURING PROCESSING
    --INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
    --SET @insertBatchProcessingCount = @@rowcount


    --Character Location
Update [runtime].[spawnedWorldObjects] SET
                                   coordinateX = @coordinateX,
                                   coordinateY = @coordinateY,
                                   coordinateZ = @coordinateZ,
                                   rotationX = @rotationX,
                                   rotationY = @rotationY,
                                   rotationZ = @rotationZ,
                                   lastUpdate = @lastUpdate
WHERE spawnedWorldObjectId = @spawnedWorldObjectId
    SET @updateLocationCount = @@rowcount

GO

