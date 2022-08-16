/* Update one product */
CREATE PROCEDURE [dbo].[sp_UpdateProduct]
@Id bigint,
@Description nvarchar(MAX)
AS
BEGIN
	 SET NOCOUNT ON;

	 UPDATE [Products] 
	 SET [Description]=@Description 
	 WHERE [Products].[ID]=@Id

	 select @@ROWCOUNT as [Count]
END